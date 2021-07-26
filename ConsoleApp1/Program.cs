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
                {2   ,-3,   5},
                {-3,   1,   -2},
                {5,   -2,   2}


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
                {0,-2,3,2},
                {-2,1,3,2},
                {3,3,1,-4},
                {2,2,-1,4}

            };
            //Test input END 













            int[,] inputMatrix = Algebra.CreateSymmetricMatrix(Algebra.MatrixRandomElements());
            double[] resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
            List<double> listDisplayResults = new List<double>();
            double [] checkForGegativeDiagonals = Preprocessing.CheckForNegativeDiagonalElement(inputMatrix);
            double[] vektorResultFinal = Algebra.RandomVektorForRandomMatrix(inputMatrix);




            Console.WriteLine("Case A");
            Preprocessing.CheckForNull(checkForGegativeDiagonals);
            PrintingToConsole.PrintMatrixToConsole(inputMatrix);



            Console.WriteLine("Results Case A");
            double resultCaseA = Algebra.SkalarProdukt(checkForGegativeDiagonals,
                Algebra.VektorMatrixMultiplikation(inputMatrix, checkForGegativeDiagonals, resultTest));
            Console.WriteLine(resultCaseA);


            //Case B
            Console.WriteLine("____________________Case B____________________");
            Preprocessing.CaseB(resultCaseA, inputMatrix);
            //END CASE B___________________________________________________

            //CASE C

            Console.WriteLine("____________________Case C____________________");
            Preprocessing.CaseC(resultCaseA, inputMatrix);




            //END CASE C___________________________________________________

            Console.WriteLine("____________________Case E____________________");
            Preprocessing.CaseE(inputMatrix);



            Console.WriteLine("____________________Case D____________________");

            if (resultCaseA > 0)
            {
                Preprocessing.CaseD(inputMatrix);
            }
          

        }
    }
}
