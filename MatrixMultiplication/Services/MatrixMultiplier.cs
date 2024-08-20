public class MatrixMultiplier : IMatrixMultiplier
{
    public double[,] Multiply(int[,] A, int[,] B, int size)
    {
        double[,] result = new double[size, size];
        
        Parallel.For(0, size, i =>
        {
            for (int j = 0; j < size; j++)
            {
                double sum = 0;
                for (int k = 0; k < size; k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                result[i, j] = sum;
            }
        });

        return result;
    }
}
