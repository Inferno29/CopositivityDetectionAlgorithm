using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Threading.Channels;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Input
            double[,] matrix = new double[,]
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





            double[,] m = new double[,]
            {
                {1,-1,1,1,-1},
                {-1,1,-1,1,1},
                {1,-1,1,-1,1},
                {1,1,-1,1,-1},
                {-1,1,1,-1,1}

            };

            double[][] testMatrix = new double[][] { new double[] { 2, -3, 5 }, new double[] { -3, 1, -2 }, new double[] { 5, -2, 2 } };
            //Test input END 


            int[,] inputMatrix = Algebra.CreateSymmetricMatrix(Algebra.MatrixRandomElements());
            double[,] inputMatrixDoubles = Algebra.CreateSymmetricMatrixOfDoubles(inputMatrix);
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
            
            Preprocessing.PositivityTestCaseC(inputMatrix,resultCaseA); 




            //END CASE C___________________________________________________

            Console.WriteLine("____________________Case E____________________");
            Preprocessing.CaseE(inputMatrix);



            Console.WriteLine("____________________Case D____________________");

            
            Preprocessing.NegativityTestCaseD(inputMatrix);


            Console.WriteLine("________________________________________________________");
            Console.WriteLine("____________________Lemma 0.2 Case B____________________");
            Console.WriteLine("________________________________________________________");


            var inMatrix = Preprocessing2.CaseB2(inputMatrix);
            Console.WriteLine("The processed inputmatrix is now: ");
            PrintingToConsole.PrintMatrixToConsole(inMatrix);
            Preprocessing2.CaseB(0, inMatrix);
            Console.WriteLine("____________________Case C2____________________");
            Preprocessing2.PositivityTestCaseC(inMatrix,resultCaseA); 
            Console.WriteLine("____________________Case E2____________________");
            Preprocessing2.CaseE(inMatrix);
            Console.WriteLine("____________________Case D2____________________");
            Preprocessing2.NegativityTestCaseD(inMatrix);
            Console.WriteLine("____________________Case Lemma0.2 C____________________");
            Preprocessing2.Lemma2CaseC(inputMatrix);

            Console.WriteLine("________________________________________________________");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("________________________________________________________");
            


            //____________________________________________________________________________
            //____________________________________________________________________________
            //____________________________________________________________________________


            PrintingToConsole.PrintMatrixToConsole(inputMatrixDoubles);
           var jaggedInputMatrix = MatrixOperations.ConvertToJaggedArray(inputMatrixDoubles);
           PrintingToConsole.PrintJaggedArrayToConsole(jaggedInputMatrix);



           var identityMatrix = MatrixOperations.MatrixIdentity(jaggedInputMatrix.GetLength(0));
           Console.WriteLine("INVERSE MATRIX");
           var inverseMatrix = MatrixOperations.MatrixInverse(jaggedInputMatrix); 
           PrintingToConsole.PrintJaggedArrayToConsole(inverseMatrix);

           Console.WriteLine("__________________________________________________________________________");
           Console.WriteLine("__________________________________________________________________________");
           Console.WriteLine("__________________________________________________________________________");
           //var lol = MatrixOperations.MatrixProduct(testMatrix, inverseMatrix);

           double[][] mmm = new double[][] { new double[] { 2, -3, 5 }, new double[] { -3, 1, -2 }, new double[] { 5, -2, 2 } };
           double[][] inv = MatrixOperations.MatrixInverse(testMatrix);



           Console.WriteLine();
           double[][] invMultiplication = MatrixOperations.MatrixProduct(jaggedInputMatrix,inverseMatrix);

           PrintingToConsole.PrintJaggedArrayToConsole(invMultiplication);




            //var det = MatrixOperations.Determinant(inputMatrixDoubles);
            //Console.WriteLine(Math.Round(det,3));
        }
    }
}
