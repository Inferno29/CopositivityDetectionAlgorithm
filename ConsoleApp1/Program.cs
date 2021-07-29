using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Threading;
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
            double[] checkForGegativeDiagonals = Preprocessing.CheckForNegativeDiagonalElement(inputMatrix);



            //INVERSE
            var jaggedInputMatrix = MatrixOperations.ConvertToJaggedArray(inputMatrixDoubles);
            PrintingToConsole.PrintJaggedArrayToConsole(jaggedInputMatrix);
            Console.WriteLine("IDENTITY MATRIX");
            var identityMatrix = MatrixOperations.MatrixIdentity(inputMatrixDoubles.GetLength(0));
            PrintingToConsole.PrintJaggedArrayToConsole(identityMatrix);
            Console.WriteLine("INVERSE MATRIX");
            var inverseMatrix = MatrixOperations.MatrixInverse(jaggedInputMatrix);
            PrintingToConsole.PrintJaggedArrayToConsole(inverseMatrix);
            var inverseMatrixDouble = MatrixOperations.ConvertToArray(inverseMatrix); 




            //Case A
            Console.WriteLine("Case A");
            Preprocessing.CheckForNull(checkForGegativeDiagonals);
            PrintingToConsole.PrintMatrixToConsole(inputMatrix);
            Console.WriteLine("Results Case A");
            double resultCaseA = Algebra.SkalarProdukt(checkForGegativeDiagonals,
                Algebra.VektorMatrixMultiplikation(inputMatrix, checkForGegativeDiagonals, resultTest));
            Console.WriteLine(resultCaseA);


            //Case A inv
            Console.WriteLine("Case A inv");
            Preprocessing.CheckForNull(checkForGegativeDiagonals);
            PrintingToConsole.PrintMatrixToConsole(inputMatrix);
            Console.WriteLine("Results Case A inv");
            double resultCaseAinv = Algebra.SkalarProdukt(checkForGegativeDiagonals,
                Algebra.VektorMatrixMultiplikation(inputMatrix, checkForGegativeDiagonals, resultTest));
            Console.WriteLine(resultCaseA);


            //Case B
            Console.WriteLine("____________________Case B____________________");
            var caseB = Preprocessing.CaseB(resultCaseA, inputMatrix);
            //END CASE B___________________________________________________

            //CASE C

            Console.WriteLine("____________________Case C____________________");

            var caseC = Preprocessing.PositivityTestCaseC(inputMatrix, 0);




            //END CASE C___________________________________________________

            Console.WriteLine("____________________Case E____________________");
            var caseE = Preprocessing.CaseE(inputMatrix);



            Console.WriteLine("____________________Case D____________________");


            var caseD = Preprocessing.NegativityTestCaseD(inputMatrix);


            Console.WriteLine("________________________________________________________");
            Console.WriteLine("____________________Lemma 0.2 Case B____________________");
            Console.WriteLine("________________________________________________________");


            var inMatrix = Preprocessing2.CaseB2(inputMatrix);
            Console.WriteLine("The processed inputmatrix is now: ");
            PrintingToConsole.PrintMatrixToConsole(inputMatrixDoubles);
            var caseB2 = Preprocessing2.CaseB(0, inputMatrixDoubles);
            var caseB2inv = Preprocessing2.CaseB(0, inverseMatrixDouble);
            Console.WriteLine("____________________Case C2____________________");
            var caseC2 = Preprocessing2.PositivityTestCaseC(inputMatrixDoubles, resultCaseA);
            Console.WriteLine("____________________Case C2 inv____________________");
            var caseC2inv = Preprocessing2.PositivityTestCaseC(inverseMatrixDouble, resultCaseA);
            Console.WriteLine("____________________Case E2____________________");
            var caseE2 = Preprocessing2.CaseE(inputMatrixDoubles);
            Console.WriteLine("____________________Case E2inv____________________");
            var caseE2inv = Preprocessing2.CaseE(inverseMatrixDouble);
            Console.WriteLine("____________________Case D2____________________");
            var caseD2 = Preprocessing2.NegativityTestCaseD(inputMatrixDoubles);
            Console.WriteLine("____________________Case D2inv____________________");
            var caseD2inv = Preprocessing2.NegativityTestCaseD(inverseMatrixDouble);
            Console.WriteLine("____________________Case Lemma0.2 C____________________");
            var caseL2C = Preprocessing2.Lemma2CaseC(inputMatrixDoubles);
            Console.WriteLine("____________________Case Lemma0.2 Cinv____________________");
            var caseL2C2 = Preprocessing2.Lemma2CaseC(inverseMatrixDouble);

            Console.WriteLine("________________________________________________________");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("________________________________________________________");


            if (resultCaseA == 0 &&
            resultCaseAinv == 0 && caseB == null && caseC == null && caseD == null 
            && caseE == null && caseB2 == null && caseC2 == null && caseD2 == null 
            && caseB2inv == null && caseC2inv == null && caseD2inv == null &&
            caseE2inv == null && caseL2C2 == null && caseL2C == null)
            {
               // ____________________________________________________________________________
               // ____________________________________________________________________________
                //____________________________________________________________________________


               

                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                //var lol = MatrixOperations.MatrixProduct(testMatrix, inverseMatrix);

             




                double[][] invMultiplication = MatrixOperations.PreprocessingMatrix(MatrixOperations.MatrixProduct(jaggedInputMatrix, inverseMatrix));
                double[][] invIdentityMultiplication = MatrixOperations.MatrixProduct(invMultiplication, identityMatrix);
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                PrintingToConsole.PrintJaggedArrayToConsole(MatrixOperations.MatrixProduct(invIdentityMultiplication, jaggedInputMatrix));

                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("__________________________________________________________________________");

                //Proof that inv(invA) = A
                var invinv = MatrixOperations.MatrixInverse(inverseMatrix);
                PrintingToConsole.PrintJaggedArrayToConsole(invinv);

                var determinant = MatrixOperations.CalculateDeterminant(jaggedInputMatrix);

                if (determinant >= 0)
                {
                    
                    Console.WriteLine("The input matrix is copositive with determinant " + determinant);
                }
                else
                {
                    Console.WriteLine("The input matrix is not copositive with determinant " + determinant);
                }
                //var listForMatrices = MatrixOperations.CreateAllSubmatrices(inputMatrixDoubles);

                //foreach (var item in listForMatrices)
                //{
                //    Console.WriteLine("___________________________________________________");
                //    Console.WriteLine("Submatrix");
                //    PrintingToConsole.PrintMatrixToConsole(item);
                //    Console.WriteLine("the determinant is : " + MatrixOperations.CalculateDeterminant(MatrixOperations.ConvertToJaggedArray(item)));
                //}
            }




        }
    }
}
