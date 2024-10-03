using Xunit;

public class ComplexNumberAdvancedTests
{
    [Fact]
    public void TestSequentialOperations()
    {
        var z1 = new ComplexNumber(1, 1);
        var z2 = new ComplexNumber(2, 0);
        var z3 = new ComplexNumber(0, 3);

        var result = z1.Add(z2).Multiply(z3); // (1+1i + 2) * (3i) = (3+1i)*(3i)
        var expected = new ComplexNumber(-3, 9);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestComplexDivisionSequence()
    {
        var z1 = new ComplexNumber(1, -1);
        var z2 = new ComplexNumber(1, 2);
        var z3 = new ComplexNumber(0, 1);

        // ((1-i) / (1+2i)) / i
        var result = z1.Divide(z2).Divide(z3);
        var expected = new ComplexNumber(-0.6, 0.2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestOperationWithZeroComplexValue()
    {
        var z1 = new ComplexNumber(1, 1);
        var z2 = new ComplexNumber(1, 0);
        var z3 = new ComplexNumber(2, 0);

        var result = z1.Subtract(z2).Multiply(z3);
        var expected = new ComplexNumber(0, 2); 
        
        Assert.Equal(expected, result);
    }
}
