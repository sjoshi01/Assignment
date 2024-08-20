using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class MatrixService : IMatrixService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public MatrixService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public async Task<int> InitializeDatasets(int size)
    {
        string url = $"{_baseUrl}/api/numbers/init/{size}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();
        InitResponse initResponse = JsonConvert.DeserializeObject<InitResponse>(json);

        return initResponse.Value;
    }

    public async Task<int[]> FetchRowOrColumn(string dataset, string type, int index)
    {
        string url = $"{_baseUrl}/api/numbers/{dataset}/{type}/{index}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();
        MatrixRowOrColumnResponse result = JsonConvert.DeserializeObject<MatrixRowOrColumnResponse>(json);
        return result.Value; 
    }

}
