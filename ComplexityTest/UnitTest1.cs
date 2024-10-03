namespace ComplexityTest;
using Xunit;

public class ComplexNumberBasicTests
{
    [Fact]
    public void TestAddition()
    {
        var z1 = new ComplexNumber(1, 2);
        var z2 = new ComplexNumber(3, 4);
        var expected = new ComplexNumber(4, 6);

        var result = z1.Add(z2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestSubtraction()
    {
        var z1 = new ComplexNumber(5, 6);
        var z2 = new ComplexNumber(1, 1);
        var expected = new ComplexNumber(4, 5);

        var result = z1.Subtract(z2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestMultiplication()
    {
        var z1 = new ComplexNumber(1, 2);
        var z2 = new ComplexNumber(2, 3);
        var expected = new ComplexNumber(-4, 7);

        var result = z1.Multiply(z2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestDivision()
    {
        var z1 = new ComplexNumber(4, 6);
        var z2 = new ComplexNumber(1, 1);
        var expected = new ComplexNumber(5, 1);

        var result = z1.Divide(z2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestDivisionByZero()
    {
        var z1 = new ComplexNumber(4, 6);
        var z2 = new ComplexNumber(0, 0);

        Assert.Throws<DivideByZeroException>(() => z1.Divide(z2));
    }

    // Тест для метода ToTrigonometricForm
    [Fact]
    public void ToTrigonometricForm_ShouldReturnCorrectString()
    {
        // Arrange
        var complex = new ComplexNumber(1, 1);
        var expected = $"{Math.Sqrt(2)} * (cos({Math.PI / 4}) + i * sin({Math.PI / 4}))";

        // Act
        var result = complex.ToTrigonometricForm();

        // Assert
        Assert.Equal(expected, result);
    }

    // Тест для метода ToExponentialForm
    [Fact]
    public void ToExponentialForm_ShouldReturnCorrectString()
    {
        // Arrange
        var complex = new ComplexNumber(1, 1);
        var expected = $"{Math.Sqrt(2)} * e^(i * {Math.PI / 4})";

        // Act
        var result = complex.ToExponentialForm();

        // Assert
        Assert.Equal(expected, result);
    }

    // Тест для метода ToRadialExponentialForm
    [Fact]
    public void ToRadialExponentialForm_ShouldReturnSameAsExponentialForm()
    {
        // Arrange
        var complex = new ComplexNumber(1, 1);
        var expected = complex.ToExponentialForm();  // должно быть то же самое

        // Act
        var result = complex.ToRadialExponentialForm();

        // Assert
        Assert.Equal(expected, result);
    }

    // Тест для метода IsConjugateOf
    [Fact]
    public void IsConjugateOf_ShouldReturnTrueForConjugates()
    {
        // Arrange
        var complex1 = new ComplexNumber(1, 2);
        var complex2 = new ComplexNumber(1, -2);

        // Act
        var result = complex1.IsConjugateOf(complex2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsConjugateOf_ShouldReturnFalseForNonConjugates()
    {
        // Arrange
        var complex1 = new ComplexNumber(1, 2);
        var complex2 = new ComplexNumber(2, -2);

        // Act
        var result = complex1.IsConjugateOf(complex2);

        // Assert
        Assert.False(result);
    }

    // Тест для метода ToString
    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        // Arrange
        var complex = new ComplexNumber(1, 2);
        var expected = "1 + 2i";

        // Act
        var result = complex.ToString();

        // Assert
        Assert.Equal(expected, result);
    }
}
