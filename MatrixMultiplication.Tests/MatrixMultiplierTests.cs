using Xunit;

public class MatrixMultiplierTests
{
    [Fact]
    public void Multiply_ShouldReturnCorrectResult()
    {
        var multiplier = new MatrixMultiplier();
        int[,] A = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] B = new int[,] { { 5, 6 }, { 7, 8 } };
        int size = 2;

        double[,] result = multiplier.Multiply(A, B, size);

        Assert.Equal(19, result[0, 0]);
        Assert.Equal(22, result[0, 1]);
        Assert.Equal(43, result[1, 0]);
        Assert.Equal(50, result[1, 1]);
    }

    [Fact]
    public void Multiply_WithZeroMatrix_ShouldReturnZeroMatrix()
    {
        var multiplier = new MatrixMultiplier();
        int[,] A = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] zeroMatrix = new int[,] { { 0, 0 }, { 0, 0 } };
        int size = 2;

        double[,] result = multiplier.Multiply(A, zeroMatrix, size);

        Assert.All(result.Cast<double>(), value => Assert.Equal(0, value));
    }
}
