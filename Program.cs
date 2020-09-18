using System;
using System.Diagnostics;
//Code sniped from Euclids Algoithm https://www.youtube.com/watch?v=QohAyJ4MPBs
namespace myApp {
    public class Program 
    {
        static void testPlus () {
            Rational a = new Rational(1,2); 
            Rational b = new Rational(1,3);
            Rational c = new Rational(2,7); 
            Rational d = new Rational(1,12);
            Rational e = new Rational(2,8);
            Rational expected = new Rational(5,6); 
            Rational actual = plus(a,b);
            Debug.Assert(actual.numerator == 5); 
            Debug.Assert(actual.denominator == 6);
            actual = plus(a,c);
            Debug.Assert(actual.numerator == 11); 
            Debug.Assert(actual.denominator == 14);
            actual = plus(a,d);
            Debug.Assert(actual.numerator == 7); 
            Debug.Assert(actual.denominator == 12);
            actual = plus(a,a);
            Debug.Assert(actual.numerator == 1); 
            Debug.Assert(actual.denominator == 1);
            actual = plus(a,e);
            Debug.Assert(actual.numerator == 3); 
            Debug.Assert(actual.denominator == 4);      

            //test overloaded operators
            actual = a + a;
            int gcd = GCD(actual.numerator,actual.denominator);
            actual.numerator = actual.numerator/gcd;
            actual.denominator = actual.denominator/gcd;
            Debug.Assert(actual.numerator == 1); 
            Debug.Assert(actual.denominator == 1); 

            actual = a * a;
            Debug.Assert(actual.numerator == 1); 
            Debug.Assert(actual.denominator == 4);    

            actual = a;
            actual += a;
            gcd = GCD(actual.numerator,actual.denominator);
            actual.numerator = actual.numerator/gcd;
            actual.denominator = actual.denominator/gcd;
            Debug.Assert(actual.numerator == 1); 
            Debug.Assert(actual.denominator == 1); 
            //Debug.Assert(actual.denominator == 0);
            
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
        public static Rational operator +(Rational a) => a;
        
        public static Rational operator +(Rational a, Rational b)
        => new Rational(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        
        public static Rational operator *(Rational a, Rational b)
        => new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        public void showRational () {
                Console.WriteLine(numerator + "/" + denominator);
        }

    }
    }
   
}