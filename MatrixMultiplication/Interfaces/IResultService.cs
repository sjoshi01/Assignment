public interface IResultService
{
    string ComputeHash(double[,] matrix);
    Task<string> ValidateHash(string hash);
}