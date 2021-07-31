using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
            //_____________________________________________________________________________________________________________________________
            //_____________________________________________________________________________________________________________________________


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

            var caseC = Preprocessing.PositivityTestCaseC(inputMatrix, resultCaseA);




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
            && caseE == null && caseE2 == null && caseB2 == null && caseC2 == null && caseD2 == null
            && caseB2inv == null && caseC2inv == null && caseD2inv == null &&
            caseE2inv == null && caseL2C2 == null && caseL2C == null)
            {



                List<double[,]> firstList = new List<double[,]>();
                var det = 0; 


                for (int i = 0; i < inputMatrixDoubles.GetLength(0); i++)
                {
                    firstList = MatrixOperations.returnListForTrim(firstList, MatrixOperations.Trim(firstList, i, inputMatrixDoubles));
                }

                foreach (var item in firstList)
                {
                    det = (int) MatrixOperations.Det(item, item.GetLength(0));
                    if (det != 0)
                    {
                        var jaggedSubInputMatrix = MatrixOperations.ConvertToJaggedArray(item);
                        var identitySubMatrix = MatrixOperations.MatrixIdentity(item.GetLength(0));
                        var inverseSubMatrix = MatrixOperations.MatrixInverse(jaggedSubInputMatrix);
                        var inverseSubMatrixDouble = MatrixOperations.ConvertToArray(inverseSubMatrix);




                        double[] checkForGegativeDiagonalsSub = Preprocessing.CheckForNegativeDiagonalElement(inverseSubMatrixDouble);

                        var caseB2sub = Preprocessing2.CaseB(0, inverseSubMatrixDouble);
                        
                        var caseC2sub = Preprocessing2.PositivityTestCaseC(inverseSubMatrixDouble, 0);

                        var caseE2sub = Preprocessing2.CaseE(inverseSubMatrixDouble);

                        var caseD2sub = Preprocessing2.NegativityTestCaseD(inverseSubMatrixDouble);
                        
                        var caseL2Csub = Preprocessing2.Lemma2CaseC(inverseSubMatrixDouble);


                        if (caseL2Csub == null && caseB2sub == null && caseC2sub == null && caseE2sub == null && caseD2sub == null)
                        {
                            bool copositive = false;
                            copositive = Preprocessing.NegativityTestForColumns(item);
                            if (copositive == true)
                            {
                                break;
                            }
                        }


                    }
                }


                // ____________________________________________________________________________
                // ____________________________________________________________________________
                //____________________________________________________________________________

                var determinant = MatrixOperations.Det(m, m.GetLength(0));
                Console.WriteLine("The Determinant is = " + determinant);

                if (determinant < 0)
                {
                    Console.WriteLine("No answer");
                }
                else
                {
                    Console.WriteLine("The input matrix is copositive");
                }

                //Console.WriteLine("__________________________________________________________________________");
                //Console.WriteLine("__________________________________________________________________________");
                //Console.WriteLine("__________________________________________________________________________");
               

                //double[][] invMultiplication = MatrixOperations.PreprocessingMatrix(MatrixOperations.MatrixProduct(jaggedInputMatrix, inverseMatrix));
                //double[][] invIdentityMultiplication = MatrixOperations.MatrixProduct(invMultiplication, identityMatrix);
                //Console.WriteLine("__________________________________________________________________________");
                //Console.WriteLine("__________________________________________________________________________");
                //Console.WriteLine("__________________________________________________________________________");
                //PrintingToConsole.PrintJaggedArrayToConsole(MatrixOperations.MatrixProduct(invIdentityMultiplication, jaggedInputMatrix));

                //Console.WriteLine("__________________________________________________________________________");
                //Console.WriteLine("__________________________________________________________________________");
                //Console.WriteLine("__________________________________________________________________________");

                ////Proof that inv(invA) = A
                //var invinv = MatrixOperations.MatrixInverse(inverseMatrix);
                //PrintingToConsole.PrintJaggedArrayToConsole(invinv);

            }




        }
    }
}
