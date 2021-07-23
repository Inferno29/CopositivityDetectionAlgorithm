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


            if (resultCaseA == 0)
            {
                Console.WriteLine("____________________________________________________");
                Console.WriteLine("Case B");
                List<int> listCheckZero = new List<int>();
                m = Algebra.CreateSymmetricMatrix(m);
                List<int> listZero = Preprocessing.CheckIfDiagonalElementsAreZero(listCheckZero, inputMatrix);
                double[] v1 = new double[inputMatrix.GetLength(0)];
                v1 = Preprocessing.TestMethod(listZero, v1, inputMatrix);
                if (v1 != null)
                {
                    double[] v2 = new double[v1.Length];
                    Console.WriteLine("Results Case B");
                    Console.WriteLine("A violating vector is");
                    PrintingToConsole.PrintVektorToConsole(v1);
                    PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                    Console.WriteLine(Algebra.SkalarProdukt(v1, Algebra.VektorMatrixMultiplikation(inputMatrix, v1, resultTest)));
                }
            }


            //CASE C

            Console.WriteLine("Case C");

            m = Algebra.CreateSymmetricMatrix(m);
            int[,] outputMatrix = new int[m.GetLength(0), m.GetLength(1)];
            int[,] outputMatrix2 = new int[m.GetLength(0) - 1, m.GetLength(1) - 1];
            PrintingToConsole.PrintMatrixToConsole(Preprocessing.TestCaseC(m, outputMatrix));
            int[,] afterCaseC = Preprocessing.TestCaseC(m, outputMatrix);
            int[,] againCaseC = Preprocessing.TestCaseC(afterCaseC, outputMatrix2);

            PrintingToConsole.PrintMatrixToConsole(againCaseC);

            Console.WriteLine("____________________________________________________");
            Console.WriteLine("Case B");
            List<int> listCheckZero2 = new List<int>();
            
            List<int> listZero2 = Preprocessing.CheckIfDiagonalElementsAreZero(listCheckZero2, afterCaseC);
            double[] v12 = new double[afterCaseC.GetLength(0)];
            v12 = Preprocessing.TestMethod(listZero2, v12, afterCaseC);
            if (v12 != null)
            {
                double[] v2 = new double[v12.Length];
                Console.WriteLine("Results Case B");
                Console.WriteLine("A violating vector is");
                PrintingToConsole.PrintVektorToConsole(v12);
                PrintingToConsole.PrintMatrixToConsole(afterCaseC);
                Console.WriteLine(Algebra.SkalarProdukt(v12, Algebra.VektorMatrixMultiplikation(afterCaseC, v12, resultTest)));
                PrintingToConsole.PrintVektorToConsole(v12);
            }

            //END CASE C___________________________________________________

            

        }
    }
}
