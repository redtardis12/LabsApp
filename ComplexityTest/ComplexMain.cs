using System;

public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        ComplexNumber other = (ComplexNumber)obj;
        return Real == other.Real && Imaginary == other.Imaginary;
    }

    public override int GetHashCode()
    {
        return Real.GetHashCode() ^ Imaginary.GetHashCode();
    }

    // Сложение комплексных чисел
    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
    }

    // Вычитание комплексных чисел
    public ComplexNumber Subtract(ComplexNumber other)
    {
        return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
    }

    // Умножение комплексных чисел
    public ComplexNumber Multiply(ComplexNumber other)
    {
        double realPart = Real * other.Real - Imaginary * other.Imaginary;
        double imaginaryPart = Real * other.Imaginary + Imaginary * other.Real;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    // Деление комплексных чисел
    public ComplexNumber Divide(ComplexNumber other)
    {
        double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;
        if (denominator == 0)
            throw new DivideByZeroException("Division by zero!");

        double realPart = (Real * other.Real + Imaginary * other.Imaginary) / denominator;
        double imaginaryPart = (Imaginary * other.Real - Real * other.Imaginary) / denominator;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    // Преобразование в тригонометрическую форму
    public string ToTrigonometricForm()
    {
        double magnitude = Math.Sqrt(Real * Real + Imaginary * Imaginary);
        double angle = Math.Atan2(Imaginary, Real);
        return $"{magnitude} * (cos({angle}) + i * sin({angle}))";
    }

    // Преобразование в показательную форму
    public string ToExponentialForm()
    {
        double magnitude = Math.Sqrt(Real * Real + Imaginary * Imaginary);
        double angle = Math.Atan2(Imaginary, Real);
        return $"{magnitude} * e^(i * {angle})";
    }

    // Преобразование в экспоненциальную форму (эквивалентную показательной)
    public string ToRadialExponentialForm()
    {
        return ToExponentialForm();
    }

    // Проверка на сопряженность
    public bool IsConjugateOf(ComplexNumber other)
    {
        return Real == other.Real && Imaginary == -other.Imaginary;
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}