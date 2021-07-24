using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Input
            int[,] matrix = new int[,]
            {
                {1   ,-2,   5},
                {2,   2,   4},
                {4,   -4,   73}


            };

            double[] vektor1111 = new double[]
            {
                0.9451086641965009,
                0.9298211009846167,
                0.03265740723938561,
                0.13534266601099756,
                0.5398110223653778,
                0.32010522173722517
            };
            double[] vektor2222 = new double[vektor1111.Length];





            int[,] m = new int[,]
            {
                {1,2,3,2},
                {2,0,-3,1},
                {3,-3,5,-4},
                {2,2,-4,0}

            };
            //Test input END 













            int[,] inputMatrix = Algebra.CreateSymmetricMatrix(Algebra.MatrixRandomElements());
            double[] resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
            List<double> listDisplayResults = new List<double>();
            double[] checkForGegativeDiagonals = Algebra.RandomVektorForRandomMatrix(inputMatrix);
            checkForGegativeDiagonals = Preprocessing.CheckForNegativeDiagonalElement(checkForGegativeDiagonals, inputMatrix);
            double[] vektorResultFinal = Algebra.RandomVektorForRandomMatrix(inputMatrix);
            double finalResult = 0;


            if (checkForGegativeDiagonals == null)
            {
                Console.WriteLine("Case BRUTE FORCE");
                Algebra.DisplayResults(listDisplayResults, finalResult, resultTest, vektorResultFinal, inputMatrix);
                Console.WriteLine("NO negative diagonals");
                PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                Console.WriteLine("______________________________________________________");
            }
            else
            {
                Console.WriteLine("Case A");
                Preprocessing.CheckForNull(checkForGegativeDiagonals);
                Console.WriteLine("there are negative diagonal elements");
                PrintingToConsole.PrintMatrixToConsole(inputMatrix);

            }


            Console.WriteLine("Results Case A");
            double resultCaseA = Algebra.SkalarProdukt(checkForGegativeDiagonals,
                Algebra.VektorMatrixMultiplikation(inputMatrix, checkForGegativeDiagonals, resultTest));
            Console.WriteLine(resultCaseA);


            //Case B
            Preprocessing.CaseB(resultCaseA, inputMatrix);
            //END CASE B___________________________________________________

            //CASE C
            Preprocessing.CaseC(resultCaseA, inputMatrix);
            //END CASE C___________________________________________________



        }
    }
}
