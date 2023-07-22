using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    public class ComplexNumber
    {
        public double Real { get; private set; }
        public double Complex { get; private set; }

        public ComplexNumber(double real, double complex)
        {
            Real = real;
            Complex = complex;
        }

        public double AbsoluteValue()
        {
            return Math.Sqrt(Real * Real + Complex * Complex);
        }

        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            double realSum = num1.Real + num2.Real;
            double complexSum = num1.Complex + num2.Complex;
            return new ComplexNumber(realSum, complexSum);
        }

        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            double realDiff = num1.Real - num2.Real;
            double complexDiff = num1.Complex - num2.Complex;
            return new ComplexNumber(realDiff, complexDiff);
        }

        public static ComplexNumber operator *(ComplexNumber num, double scalar)
        {
            double realResult = num.Real * scalar;
            double complexResult = num.Complex * scalar;
            return new ComplexNumber(realResult, complexResult);
        }

        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            double realProduct = num1.Real * num2.Real - num1.Complex * num2.Complex;
            double complexProduct = num1.Real * num2.Complex + num1.Complex * num2.Real;
            return new ComplexNumber(realProduct, complexProduct);
        }

        public static implicit operator double(ComplexNumber num)
        {
            return num.Real;
        }

        public static explicit operator ComplexNumber(double real)
        {
            return new ComplexNumber(real, 0);
        }

        public override string ToString()
        {
            if (Complex >= 0)
                return $"{Real} + {Complex}i";
            else
                return $"{Real} - {Math.Abs(Complex)}i";
        }
    }
}
