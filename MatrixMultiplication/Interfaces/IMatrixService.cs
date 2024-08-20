public interface IMatrixService
{    
    Task<int> InitializeDatasets(int size);
    Task<int[]> FetchRowOrColumn(string dataset, string type, int index);
}
