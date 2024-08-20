using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class ResultServiceTests
{
    [Fact]
    public void ComputeHash_ShouldReturnCorrectMD5Hash()
    {
        var resultService = new ResultService(new HttpClient(), "https://test-url.com");
        double[,] matrix = new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        };

        string hash = resultService.ComputeHash(matrix);

        Assert.Equal("81dc9bdb52d04dc20036dbd8313ed055", hash);
    }

    [Fact]
    public void ComputeHash_ShouldHandleLargeMatrix()
    {
        var resultService = new ResultService(new HttpClient(), "https://test-url.com");
        double[,] largeMatrix = new double[1000, 1000];
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                largeMatrix[i, j] = i + j;
            }
        }

        string hash = resultService.ComputeHash(largeMatrix);

        Assert.NotNull(hash);
        Assert.Equal(32, hash.Length); 
    }
}
