using System;
using System.Diagnostics;
//Code sniped from Euclids Algoithm https://www.youtube.com/watch?v=QohAyJ4MPBs
namespace myApp {
    public class Program 
    {
        static void testPlus () {
            Rational a = new Rational(1,2); 
            Rational b = new Rational(1,3);
            Rational expected = new Rational(5,6); 
            Rational actual = plus(a,b);
            Debug.Assert(actual.numerator == 5); 
            Debug.Assert(actual.denominator == 6);
            Debug.Assert(actual.denominator == 0);
            
        }
        static Rational plus(Rational a, Rational b) {
            Rational left = new Rational (a.numerator, a.denominator);
            Rational right = new Rational (b.numerator, b.denominator);
            Rational answer = new Rational (0,0);

            left.numerator *= right.denominator;
            left.denominator *= right.denominator;
            right.numerator *= a.denominator;
            right.denominator *= a.denominator;

            answer.numerator = left.numerator + right.numerator;
            answer.denominator = left.denominator;

            int gcd = GCD(answer.numerator,answer.denominator);
            answer.numerator = answer.numerator/gcd;
            answer.denominator = answer.denominator/gcd;
            return answer;
        }

        private static int GCD(int a, int b)
        {
            if(a > b)
            {
                return Euclids(a,b);
            }
            else
            {
                return Euclids(b,a);
            }

        }
        private static int Euclids(int a, int b)
        {
            int leftOver = a % b;
            if (leftOver == 0)
            {
                return b;
            }
            else
            {
                return Euclids(b, leftOver);
            }
        }
        public static void Main(string[] args) {
            Console.WriteLine("About to run test\n");
            testPlus();
            Console.WriteLine("No tests failed\n");
            return ;
        }
    class Rational {

        public int numerator {get; set;}
        public int denominator{get; set;}

        public Rational (int num, int den) {
            numerator = num;
            denominator = den;
         
        }
        public void showRational () {
                Console.WriteLine(numerator + "/" + denominator);
        }

    }
    }
   
}