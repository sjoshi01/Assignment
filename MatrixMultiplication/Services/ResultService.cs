using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ResultService : IResultService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ResultService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public string ComputeHash(double[,] matrix)
    {
        StringBuilder sb = new StringBuilder();
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sb.Append(matrix[i, j]);
            }
        }

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashSb.Append(b.ToString("x2"));
            }
            return hashSb.ToString();
        }
    }

    public async Task<string> ValidateHash(string hash)
    {
        var content = new FormUrlEncodedContent(new[] 
        {
            new KeyValuePair<string, string>("hash", hash)
        });

        HttpResponseMessage response = await _httpClient.PostAsync($"{_baseUrl}/api/numbers/validate", content);
        response.EnsureSuccessStatusCode();
        string jsonResponse = await response.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject(jsonResponse);
        return result.Value;
    }
}
