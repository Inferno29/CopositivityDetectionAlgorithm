using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
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
            double[,] matrix1 = new double[,]
            {
                {0   ,-1,   1,1,1},
                {-1,   1,   1,1,1},
                {1,   1,   1,1,1},
                {1,   1,   1,1,1},
                {1,   1,   1,1,1},


            };


            double[,] m = new double[,]
            {
                {0,-1,1,1,-1},
                {-1,1,-1,1,1},
                {1,-1,1,-1,1},
                {1,1,-1,1,-1},
                {-1,1,1,-1,1}

            };

            double[][] testMatrix = new double[][] { new double[] { 2, -3, 5 }, new double[] { -3, 1, -2 }, new double[] { 5, -2, 2 } };
            //Test input END 
            //_____________________________________________________________________________________________________________________________
            //_____________________________________________________________________________________________________________________________

            double determinant = 0;
            bool positivity = false;
            bool negativity = false;
            bool allElementsNegative = false;
            bool negativityForInputMatrix = false;







            using (var sw = new StreamWriter("results.txt"))
            {
                int copositive = 0;
                int notCopositive = 0;
                int noAnswer = 0;
                int counter = 0;

                int numberOfCaseA = 0;
                int numberOfCaseB = 0;
                int numberOfCaseC = 0;
                int numberOfCaseD = 0;
                int numberOfCaseE = 0;
                int numberOfLemma02 = 0;
                while (counter < 100000)
                {

                    counter++;

                    int[,] inputMatrix = Algebra.CreateSymmetricMatrix(Algebra.MatrixRandomElements());
                    double[,] inputMatrixDoubles = Algebra.CreateSymmetricMatrixOfDoubles(inputMatrix);
                    double[] resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                    double[] caseA = Preprocessing.CheckForNegativeDiagonalElement(inputMatrix);



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
                    allElementsNegative = Preprocessing.NegativityTest(inverseMatrixDouble);




                    //Case A
                    Console.WriteLine("Case A");
                    Preprocessing.CheckForNull(caseA);
                    PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                    Console.WriteLine("Results Case A");
                    double resultCaseA = Algebra.SkalarProdukt(caseA,
                        Algebra.VektorMatrixMultiplikation(inputMatrix, caseA, resultTest));
                    Console.WriteLine(resultCaseA);


                    //Case A inv
                    Console.WriteLine("Case A inv");
                    Preprocessing.CheckForNull(caseA);
                    PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                    Console.WriteLine("Results Case A inv");
                    double resultCaseAinv = Algebra.SkalarProdukt(caseA,
                        Algebra.VektorMatrixMultiplikation(inputMatrix, caseA, resultTest));
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


                    var ProcessedMatrix = Preprocessing2.CaseB2(inputMatrix);
                    Console.WriteLine("The Processed Matrix is now: ");
                    PrintingToConsole.PrintMatrixToConsole(ProcessedMatrix);
                    var caseB2Processed = Preprocessing2.CaseB(0, ProcessedMatrix);
                    Console.WriteLine("____________________Case C2____________________");
                    var caseC2Processed = Preprocessing2.PositivityTestCaseC(ProcessedMatrix, resultCaseA);
                    Console.WriteLine("____________________Case E2____________________");
                    var caseE2Processed = Preprocessing2.CaseE(ProcessedMatrix);
                    Console.WriteLine("____________________Case D2____________________");
                    var caseD2Processed = Preprocessing2.NegativityTestCaseD(ProcessedMatrix);
                    Console.WriteLine("____________________Case Lemma0.2 C____________________");
                    var caseL2CProcessed = Preprocessing2.Lemma2CaseC(ProcessedMatrix);


                    Console.WriteLine("________________________________________________________");
                    Console.WriteLine("________________________________________________________");
                    Console.WriteLine("________________________________________________________");
                    Console.WriteLine("________________________________________________________");

                    if (caseA != null)
                    {
                        numberOfCaseA++;
                    }
                    if (caseB2 != null)
                    {
                        numberOfCaseB++;
                    }
                    if (caseC2 != null)
                    {
                        numberOfCaseC++;
                    }
                    if (caseD2 != null)
                    {
                        numberOfCaseD++;
                    }
                    if (caseE2 != null)
                    {
                        numberOfCaseE++;
                    }
                    if (caseL2C != null)
                    {
                        numberOfLemma02++;
                    }
                    determinant = MatrixOperations.Det(inputMatrixDoubles, inputMatrixDoubles.GetLength(0));
                    negativityForInputMatrix = Preprocessing.NegativityTestForColumns(inverseMatrixDouble);
                    double[] violatingVector = new double[inputMatrixDoubles.GetLength(0)];
                    double result = 0;
                    List<double[]> violatingVectors = new List<double[]>()
                    {
                        caseA, caseB,caseC,caseD, caseE,caseE2, caseB2, caseC2, caseD2, caseL2C,caseB2Processed, caseC2Processed,
                        caseE2Processed, caseL2CProcessed
                    };
                    List<double[]> violatingVectorsNew = new List<double[]>();
                    foreach (var item in violatingVectors)
                    {
                        if (item != null)
                        {
                            violatingVectorsNew.Add(item);
                        }
                    }
                    foreach (var vector in violatingVectors)
                    {
                        if (vector != null && vector.Sum() > 0)
                        {
                            violatingVector = vector;
                            result = Algebra.SkalarProdukt(vector,
                                Algebra.VektorMatrixMultiplikation(inputMatrix, vector, resultTest));
                            if (vector == caseC)
                            {
                                sw.Write("Case C violating vector");
                            }

                            if (result < 0)
                            {
                                break;
                            }

                        }
                        else
                        {
                            violatingVector = null;
                        }
                    }



                    if (resultCaseA == 0 && caseB == null && caseC == null && caseD == null
                        && caseE == null && caseE2 == null && caseB2 == null && caseC2 == null && caseD2 == null
                        && caseL2C == null && caseB2Processed == null && caseC2Processed == null &&
                        caseE2Processed == null
                        && caseD2Processed == null && caseL2CProcessed == null)
                    {



                        List<double[,]> firstList = new List<double[,]>();
                        var det = 0;


                        for (int i = 0; i < inputMatrixDoubles.GetLength(0); i++)
                        {
                            firstList = MatrixOperations.returnListForTrim(firstList,
                                MatrixOperations.Trim(firstList, i, inputMatrixDoubles));
                        }

                        foreach (var item in firstList)
                        {
                            det = (int)MatrixOperations.Det(item, item.GetLength(0));
                            if (det != 0)
                            {
                                var jaggedSubInputMatrix = MatrixOperations.ConvertToJaggedArray(item);
                                var identitySubMatrix = MatrixOperations.MatrixIdentity(item.GetLength(0));
                                var inverseSubMatrix = MatrixOperations.MatrixInverse(jaggedSubInputMatrix);
                                var inverseSubMatrixDouble = MatrixOperations.ConvertToArray(inverseSubMatrix);



                                negativity = false;
                                negativity = Preprocessing.NegativityTestForColumns(inverseSubMatrixDouble);
                                if (negativity == true)
                                {
                                    break;
                                }



                            }

                        }

                        positivity = Preprocessing.PositivityTestForColumns(inverseMatrixDouble);



                        // ____________________________________________________________________________
                        // ____________________________________________________________________________
                        //____________________________________________________________________________


                        Console.WriteLine("The Determinant is = " + determinant);

                        if (determinant < 0)
                        {
                            Console.WriteLine(
                                "Based on Cottle-Habetler-Lemke there is no answer. The Determinant is negative. ");
                        }
                        else if (positivity == true && determinant > 0)
                        {
                            Console.WriteLine("The input matrix is copositive");
                        }



                    }
                    else
                    {
                        Console.WriteLine("The Input matrix is not copositive!");
                    }

                    sw.WriteLine("Example : " + counter);
                    for (int i = 0; i < inputMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < inputMatrix.GetLength(1); j++)
                        {
                            sw.Write(inputMatrix[i, j] + "  ");
                            if (j == inputMatrix.GetLength(0) - 1 && violatingVector != null && violatingVector.Sum() > 0)
                            {
                                sw.Write("            " + violatingVector[i]);
                            }
                        }

                        sw.Write("\n");
                    }

                    sw.Write("\n");

                    if (result < 0)
                    {
                        sw.Write("The result is : " + result);
                    }


                    sw.Write("\n");
                    sw.Write("\n");


                    sw.WriteLine("Inverse Matrix");
                    for (int i = 0; i < inverseMatrixDouble.GetLength(0); i++)
                    {
                        for (int j = 0; j < inverseMatrixDouble.GetLength(1); j++)
                        {
                            sw.Write(Math.Round(inverseMatrixDouble[i, j], 3) + "  ");

                        }

                        sw.Write("\n");
                    }
                    sw.Write("\n");
                    sw.Write("\n");

                    if (positivity == true && determinant > 0 && violatingVector == null)
                    {
                        copositive++;

                        sw.Write("The input matrix is copositive based on proposition 7.5 and 3.3 if A is nonsingular and copositive, then each column of Ainv contains a positive entry. Determinant = " + determinant);
                    }
                    sw.Write("\n");
                    if (determinant < 0 && violatingVector == null)
                    {
                        noAnswer++;
                        sw.Write("Based on Cottle-Habetler-Lemke theorem 3.3 there is no answer. The Determinant is negative. Determinant = " + determinant);
                    }
                    sw.Write("\n");

                    if (allElementsNegative == true)
                    {
                        notCopositive++;
                        sw.Write("Input matrix is not copositive based on theorem 3.4");
                    }
                    sw.Write("\n");
                    if (violatingVector != null && violatingVector.Sum() > 0)
                    {
                        notCopositive++;
                        sw.Write("The input matrix is not copositive. A violating vector exists.");
                    }
                    sw.Write("\n");
                    if (negativityForInputMatrix == true)
                    {
                        notCopositive++;
                        sw.Write("The input matrix is not copositive based on theorem 3.4. The inverse matrix in nonpositive entrywise. ");
                    }
                    sw.Write("\n");
                    if (positivity == true && violatingVector == null)
                    {
                        copositive++;
                        sw.Write("The input matrix is copositive based on theorem 7.5. Each column of the inverse of the input matrix contains a positive entry");
                    }
                    sw.Write("\n");
                    if (determinant >= 0 && violatingVector == null)
                    {
                        copositive++;
                        sw.Write("Based on Cottle-Habetler-Lemke theorem 3.3 the input matrix is copositive. Determinant = " + determinant);
                    }
                    sw.Write("\n");



                    sw.Write("\n");
                    sw.WriteLine("________________________________________________________________________________________________________");
                    sw.Write("\n");

                }

                sw.WriteLine("Number of copositive matrices: " + copositive);
                sw.WriteLine("Number of not copositive matrices: " + notCopositive);
                sw.WriteLine("Number of no answer possible cases: " + noAnswer);
                sw.WriteLine("Number of answers with case A: " + numberOfCaseA);
                sw.WriteLine("Number of answers with case B: " + numberOfCaseB);
                sw.WriteLine("Number of answers with case C: " + numberOfCaseC);
                sw.WriteLine("Number of answers with case D: " + numberOfCaseD);
                sw.WriteLine("Number of answers with case E: " + numberOfCaseE);
                sw.WriteLine("Number of answers with Lemma 0.2 C: " + numberOfLemma02);
                sw.Flush();
                sw.Close();
            }




        }
    }
}
