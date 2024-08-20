using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        string baseUrl = "https://recruitment-test.investcloud.com/";

        using HttpClient httpClient = new HttpClient();

        IMatrixService matrixService = new MatrixService(httpClient, baseUrl);
        IMatrixMultiplier matrixMultiplier = new MatrixMultiplier();
        IResultService resultService = new ResultService(httpClient, baseUrl);

        Stopwatch stopwatch = Stopwatch.StartNew();

        int size = 1000;
        int datasetSize = await matrixService.InitializeDatasets(size);

        Task<int[,]> taskA = FetchMatrixParallel(matrixService, "A", datasetSize);
        Task<int[,]> taskB = FetchMatrixParallel(matrixService, "B", datasetSize);

        await Task.WhenAll(taskA, taskB);

        int[,] A = taskA.Result;
        int[,] B = taskB.Result;

        double[,] resultMatrix = matrixMultiplier.Multiply(A, B, datasetSize);

        string resultHash = resultService.ComputeHash(resultMatrix);

        string passphrase = await resultService.ValidateHash(resultHash);
        stopwatch.Stop();

        Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

        Console.WriteLine($"Passphrase: {passphrase}");
    }

    static async Task<int[,]> FetchMatrixParallel(IMatrixService matrixService, string dataset, int size)
    {
        int[,] matrix = new int[size, size];
        var fetchTasks = new Task<int[]>[size];

        for (int i = 0; i < size; i++)
        {
            fetchTasks[i] = matrixService.FetchRowOrColumn(dataset, "row", i);
        }

        int[][] fetchedRows = await Task.WhenAll(fetchTasks);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = fetchedRows[i][j];
            }
        }

        return matrix;
    }
}
