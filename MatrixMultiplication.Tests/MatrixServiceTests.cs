using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

public class MatrixServiceTests
{
    [Fact]
    public async Task InitializeDatasets_ShouldReturnDatasetSize()
    {
        var httpClient = new HttpClient(new MockHttpMessageHandler("{\"Value\":1000,\"Cause\":null,\"Success\":true}"));
        var service = new MatrixService(httpClient, "https://test-url.com");

        int result = await service.InitializeDatasets(1000);

        Assert.Equal(1000, result);
    }

    [Fact]
    public async Task FetchRowOrColumn_ShouldReturnCorrectRow()
    {
        var httpClient = new HttpClient(new MockHttpMessageHandler("{\"Value\":[1, 2, 3],\"Cause\":null,\"Success\":true}"));
        var service = new MatrixService(httpClient, "https://test-url.com");

        int[] result = await service.FetchRowOrColumn("A", "row", 1);

        Assert.Equal(new int[] { 1, 2, 3 }, result);
    }

    [Fact]
    public async Task FetchRowOrColumn_ShouldHandleEmptyMatrix()
    {
        var httpClient = new HttpClient(new MockHttpMessageHandler("{\"Value\":[],\"Cause\":null,\"Success\":true}"));
        var service = new MatrixService(httpClient, "https://test-url.com");

        int[] result = await service.FetchRowOrColumn("A", "row", 0);

        Assert.Empty(result);
    }

    [Fact]
    public async Task FetchRowOrColumn_ShouldHandleInvalidJsonResponse()
    {
        var httpClient = new HttpClient(new MockHttpMessageHandler("{\"InvalidJson\"}", HttpStatusCode.OK));
        var service = new MatrixService(httpClient, "https://test-url.com");

        await Assert.ThrowsAsync<JsonReaderException>(() => service.FetchRowOrColumn("A", "row", 0));
    }

    [Fact]
    public async Task InitializeDatasets_ShouldHandleApiError()
    {
        var httpClient = new HttpClient(new MockHttpMessageHandler("", HttpStatusCode.InternalServerError));
        var service = new MatrixService(httpClient, "https://test-url.com");

        await Assert.ThrowsAsync<HttpRequestException>(() => service.InitializeDatasets(1000));
    }
}
