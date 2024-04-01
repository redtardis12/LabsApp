using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabsApp.Shared
{
    public class CP
    {
        public abstract class Pair
        {
            protected int first;
            protected int second;

            public Pair(int a, int b)
            {
                first = a;
                second = b;
            }

            public abstract Pair Add(Pair other);
            public abstract Pair Subtract(Pair other);
            public abstract Pair Divide(Pair other);
            public abstract Pair Multiply(Pair other);

            public virtual string Print()
            {
                return $"Pair: {first}, {second}";
            }
        }

        public class Money : Pair
        {
            public Money(int dollars, int cents) : base(dollars, cents) { }

            public override Pair Add(Pair other)
            {
                Money otherMoney = (Money)other;
                int totalCents = second + otherMoney.second;
                int extraDollars = totalCents / 100;
                totalCents %= 100;
                return new Money(first + otherMoney.first + extraDollars, totalCents);
            }

            public override Pair Subtract(Pair other)
            {
                // Subtract dollars and cents separately
                Money otherMoney = (Money)other;
                return new Money(first - otherMoney.first, second - otherMoney.second);
            }
            public override Pair Divide(Pair other)
            {
                // You can't really divide money, but you could share it evenly among people (e.g., other.first)
                if (((Money)other).first != 0)
                    return new Money(first / ((Money)other).first, second / ((Money)other).second);
                else
                    throw new DivideByZeroException();
            }
            public override Pair Multiply(Pair other)
            {
                Money otherMoney = (Money)other;
                // Convert everything to cents to handle multiplication
                int thisTotalCentValue = (first * 100 + second);
                int otherTotalCentValue = (otherMoney.first * 100 + otherMoney.second);
                int resultCentValue = thisTotalCentValue * otherTotalCentValue;
                return new Money(resultCentValue / 100, resultCentValue % 100);
            }

            public override string Print()
            {
                return $"{first} rubs {second} cops";
            }
        }

        public class Complex : Pair
        {
            public Complex(int real, int imaginary) : base(real, imaginary) { }

            public override Pair Add(Pair other)
            {
                Complex otherComplex = (Complex)other;
                return new Complex(first + otherComplex.first, second + otherComplex.second);
            }

            public override Pair Subtract(Pair other)
            {
                Complex otherComplex = (Complex)other;
                return new Complex(first - otherComplex.first, second - otherComplex.second);
            }
            public override Pair Multiply(Pair other)
            {
                Complex otherComplex = (Complex)other;
                return new Complex((first * otherComplex.first - second * otherComplex.second), (first * otherComplex.second + second * otherComplex.first));
            }
            public override Pair Divide(Pair other)
            {
                Complex otherComplex = (Complex)other;
                int real = (first * otherComplex.first + second * otherComplex.second) / (otherComplex.first * otherComplex.first + otherComplex.second * otherComplex.second);
                int imag = (second * otherComplex.first - first * otherComplex.second) / (otherComplex.first * otherComplex.first + otherComplex.second * otherComplex.second);
                return new Complex(real, imag);
            }

            public override string Print()
            {
                return $"{first} + {second}i";
            }
        }

        public class Series
        {
            private List<Pair> pairList;

            public Series()
            {
                pairList = new List<Pair>();
            }

            public void AddPair(Pair pair)
            {
                pairList.Add(pair);
            }

            public string SumMoney()
            {
                Money res = new Money(0, 0);
                foreach (Pair pair in pairList)
                {
                    res = (Money)res.Add(pair);
                }
                return res.Print();
            }

            public string Print()
            {
                string res = "";
                foreach (Pair pair in pairList)
                {
                    res += pair.Print() + " | ";
                }
                return res;
            }
        }
    }
}
