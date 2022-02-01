using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApp1.dto;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Test Input
            int[,] matrix =
            {
                {2, -3, 5},
                {-3, 1, -2},
                {5, -2, 2}
            };


            double[,] matrix1 =
            {
                {0, -1, 1, 1, 1},
                {-1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1}
            };
            double[,] matrix2 =
            {
                {32, 5, 9, 29, 43},
                {5, 0, 21, -12, 40},
                {9, 21, 13, 45, 14},
                {29, -12, 45, 20, 20},
                {43, 40, 14, 20, 50}
            };
            int[,] matrix3 =
            {
                {8, -3, -4, -4},
                {-3, 25, 18, 36},
                {-4, 18, 35, 49},
                {-4, 36, 49, 8}
            };


            double[,] m =
            {
                {1, -1, 1, 1, -1},
                {-1, 1, -1, 1, 1},
                {1, -1, 1, -1, 1},
                {1, 1, -1, 1, -1},
                {-1, 1, 1, -1, 1}
            };

            int[,] example839 =
            {
                {51, 3, 9, 1, 55},
                {3, 34, 11, 33, 24},
                {9, 11, 38, 11, 2},
                {1, 33, 11, 18, -10},
                {55, 24, 2, -10, 9}
            };
            int[,] example37 =
            {
                {39, -12, -2, 18, -4},
                {-12, 35, 13, 6, 3},
                {-2, 13, 18, -14, 27},
                {18, 6, -14, 40, 37},
                {-4, 3, 27, 37, 15}
            };

            int[,] example81905 =
            {
                {14, 8, -3, 24},
                {8, 40, 33, -14},
                {-3, 33, 53, 54},
                {24, -14, 54, 36}
            };
            int[,] example980 =
            {
                {22, -18, -6, 40, 8},
                {-18, 22, 25, 2, -7},
                {-6, 25, 18, 25, 7},
                {40, 2, 25, 44, 4},
                {8, -7, 7, 4, 21}
            };

            int[,] example81905a =
            {
                {14, 8, -3, 24, 14},
                {8, 40, 33, -14, 8},
                {-3, 33, 53, 54, 3},
                {24, -14, 54, 36, 24},
                {14, 8, 3, 24, 10}
            };
            int[,] example101 =
            {
                {41, -6, -8, 24, 9},
                {-6, 30, -14, 40, 38},
                {-8, -14, 43, 33, 34},
                {24, 40, 33, 5, 18},
                {9, 38, 34, 18, 37}
            };

            int[,] example975 =
            {
                {20, 8, 6, 11, 18, 25, 30},
                {8, 4, 30, 43, -4, 20, 32},
                {6, 30, 10, 11, 9, -2, 41},
                {11, 43, 11, 45, 37, 44, 16},
                {18, -4, 9, 37, 35, 10, 21},
                {25, 20, -2, 44, 10, 21, 27},
                {30, 32, 41, 16, 21, 27, 11}
            };
            int[,] example294 =
            {
                {24, 16, 0, 1, 22, -1, -12},
                {16, 40, 0, 12, 37, 19, 12},
                {0, 0, 0, 0, 29, 12, 1},
                {1, 12, 0, 20, 3, 37, 28},
                {22, 37, 29, 3, 6, 24, 32},
                {-1, 19, 12, 37, 24, 16, 28},
                {-12, 12, 1, 28, 32, 28, 48}
            };
            int[,] example213 =
            {
                {20, 31, 40, 20, -2, 8},
                {31, 27, 20, 31, 1, 6},
                {40, 20, 14, 39, -11, 36},
                {20, 31, 39, 26, 52, 2},
                {-2, 1, -11, 52, 47, 17},
                {8, 6, 36, 2, 17, 10}
            };
            int[,] example229 =
            {
                {25, 2, 6, 46, -1, 53, 57, 6, 30},
                {2, 33, 5, 8, 18, 33, 3, 1, 8},
                {6, 5, 24, 26, 19, 42, 37, 35, 0},
                {46, 8, 26, 54, 10, 9, 49, 29, -7},
                {-1, 18, 19, 10, 28, 30, -4, 15, -1},
                {53, 33, 42, 9, 30, 12, 6, 26, -4},
                {57, 3, 37, 49, -4, 6, 4, 6, 21},
                {6, 1, 35, 29, 15, 26, 6, 10, 3},
                {30, 8, 0, -7, -1, -4, 21, 3, 36}
            };


            int[,] example336 =
            {
                {27, 10, -11, 42, 12, -13},
                {10, 2, 8, 46, 22, 19},
                {-11, 8, 43, 32, 13, -11},
                {42, 46, 32, 12, 51, 15},
                {12, 22, 13, 51, 13, 4},
                {-13, 19, -11, 15, 4, 34}
            };

            int[,] example399 =
            {
                {12, 19, -4, 50, 23, 41, 6},
                {19, 17, 35, 51, -6, -15, 27},
                {-4, 35, 30, 33, -3, 39, 18},
                {50, 51, 33, 16, -3, 52, 15},
                {23, -6, -3, -3, 37, -6, 33},
                {41, -15, 39, 52, -6, 36, 17},
                {6, 27, 18, 15, 33, 17, 44}
            };

            int[,] example329 =
            {
                {6, 39, 25, 47, 41, 21, 42, 43, 17, 3, 17, 30},
                {39, 45, -1, 34, 30, -9, 29, 8, 1, -12, 17, -4},
                {25, -1, 35, 9, 43, 18, -3, 6, -1, 22, 19, 48},
                {47, 34, 9, 25, 45, 38, 44, 1, -1, 53, 30, 30},
                {41, 30, 43, 45, 14, 21, 7, 34, 32, -2, 45, -2},
                {21, -9, 18, 38, 21, 23, 19, 24, 19, 22, -2, -11},
                {42, 29, -3, 44, 7, 19, 49, -15, 7, 35, 40, 20},
                {43, 8, 6, 1, 34, 24, -15, 21, -2, 20, 8, 13},
                {17, 1, -1, -1, 32, 19, 7, -2, 23, 29, -10, 6},
                {3, -12, 22, 53, -2, 22, 35, 20, 29, 4, 17, 7},
                {17, 17, 19, 30, 45, -2, 40, 8, -10, 17, 14, -6},
                {30, -4, 48, 30, -2, -11, 20, 13, 6, 7, -6, 29}
            };
            int[,] example5429 =
            {
                {29, 17, 33, 4, -15, 36, 14, -18, 5, 16, 19, 12, 16, 2, 28, 3},
                {17, 12, 17, 15, 48, 13, 45, 45, 29, -2, 26, -3, 45, 41, 51, 0},
                {33, 17, 24, 17, 51, 14, 17, 18, 4, 0, 39, -5, 1, 35, -12, 11},
                {4, 15, 17, 45, -1, 25, 7, 22, 37, 40, -6, -10, 40, 53, 27, -12},
                {-15, 48, 51, -1, 8, 13, 2, 52, 51, 25, 52, 20, -6, 30, 36, 20},
                {36, 13, 14, 25, 13, 31, 56, 20, 44, 1, 10, 47, 21, 39, 39, 38},
                {14, 45, 17, 7, 2, 56, 23, 15, 19, -5, 13, -5, 37, -13, 29, 9},
                {-18, 45, 18, 22, 52, 20, 15, 46, -6, 4, 15, 40, -6, 19, 17, 32},
                {5, 29, 4, 37, 51, 44, 19, -6, 36, 15, -8, 18, 16, 33, 24, 42},
                {16, -2, 0, 40, 25, 1, -5, 4, 15, 33, -15, 22, -2, 30, 54, 31},
                {19, 26, 39, -6, 52, 10, 13, 15, -8, -15, 46, 40, 26, 12, 49, 32},
                {12, -3, -5, -10, 20, 47, -5, 40, 18, 22, 40, 19, 19, 9, 12, 8},
                {16, 45, 1, 40, -6, 21, 37, -6, 16, -2, 26, 19, 0, -11, 19, -6},
                {2, 41, 35, 53, 30, 39, -13, 19, 33, 30, 12, 9, -11, 38, -8, 6},
                {28, 51, -12, 27, 36, 39, 29, 17, 24, 54, 49, 12, 19, -8, 30, 0},
                {3, 0, 11, -12, 20, 38, 9, 32, 42, 31, 32, 8, -6, 6, 0, 38}
            };
            int[,] example996 =
            {
                {30, 36, 48, 11, 4, 10, 32, 11, 0, 17, 13, 39, 11},
                {36, 19, -1, 14, 13, 4, 15, 22, 44, 26, 52, 9, 29},
                {48, -1, 4, 7, 10, -7, 5, 1, 46, 34, 0, 0, 36},
                {11, 14, 7, 37, 36, 51, 29, 42, 45, 58, 44, 23, 28},
                {4, 13, 10, 36, 43, 42, -3, 3, -4, 23, 28, 49, 18},
                {10, 4, -7, 51, 42, 26, 43, 31, 34, -6, 7, -17, 20},
                {32, 15, 5, 29, -3, 43, 19, 39, 50, 15, -9, 32, 24},
                {11, 22, 1, 42, 3, 31, 39, 35, 4, 5, 42, -4, 37},
                {0, 44, 46, 45, -4, 34, 50, 4, 17, 35, 12, 45, -7},
                {17, 26, 34, 58, 23, -6, 15, 5, 35, 54, 36, 33, -5},
                {13, 52, 0, 44, 28, 7, -9, 42, 12, 36, 21, 40, 6},
                {39, 9, 0, 23, 49, -17, 32, -4, 45, 33, 40, 34, 7},
                {11, 29, 36, 28, 18, 20, 24, 37, -7, -5, 6, 7, 19}
            };


            double[][] testMatrix = {new double[] {2, -3, 5}, new double[] {-3, 1, -2}, new double[] {5, -2, 2}};
            //Test input END 
            //_____________________________________________________________________________________________________________________________
            //_____________________________________________________________________________________________________________________________

            double determinant = 0;
            var positivity = false;
            var negativity = false;
            var allElementsNegative = false;
            var negativityForInputMatrix = false;
            var counter = 0;


            //using (var sw = new StreamWriter("C:/Users/dejan/Desktop/Master/Results/resultsnotcopositive.txt"))
            //{

            var swnotcop = new StreamWriter("C:/Users/z004f7tr/Desktop/Results/notCopositiveResults5.txt");
            var swcop = new StreamWriter("C:/Users/z004f7tr/Desktop/Results/copositiveResults5.txt");
            var swnoansw = new StreamWriter("C:/Users/z004f7tr/Desktop/Results/NoAnswerResults5.txt");


            var copositive = 0;
            var notCopositive = 0;
            var noAnswer = 0;
            var notCopositiveWithoutViolatingVector = 0;

            var numberOfCaseA = 0;
            var numberOfCaseB = 0;
            var numberOfCaseC = 0;
            var numberOfCaseD = 0;
            var numberOfCaseE = 0;
            var numberOfLemma02 = 0;
            var numberOfCase2 = 0;
            var numberOfPositiveSemiDefinite = 0;
            var numberOfSpectralPreProcessing = 0;
            var deletedRowsCase3 = 0;
            var deletedRowsCase4 = 0;


            while (counter < 100000)
            {
                var matrixDto = new Case4Dto();
                var matrixCase4 = new MatrixforCase4();
                var matrixCase3 = new MatrixForCase3();
                var eigenVectorAndValue = new EigenVectorAndValue();
                decimal percentageofRows3 = 0;
                decimal percentageofRows4 = 0;

                counter++;
                //
                var inputMatrix = Algebra.CreateSymmetricMatrix(Algebra.MatrixRandomElements());
                var inputMatrixDoubles = Algebra.CreateSymmetricMatrixOfDoubles(inputMatrix);
                // var inputMatrix = example975;
                // var inputMatrixDoubles = Algebra.CreateSymmetricMatrixOfDoubles(inputMatrix);

                var resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                var caseA = Preprocessing.CheckForNegativeDiagonalElement(inputMatrix);


                //Case A
                Console.WriteLine("Case 1");
                Preprocessing.CheckForNull(caseA);
                PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                Console.WriteLine("Results Case A");
                var resultCaseA = Algebra.SkalarProdukt(caseA,
                    Algebra.VektorMatrixMultiplikation(inputMatrix, caseA, resultTest));
                Console.WriteLine(resultCaseA);


                var case2Test = new double[inputMatrixDoubles.GetLength(1)];
                var case2 = Preprocessing.Case2(case2Test, inputMatrixDoubles);
                if (case2 != null)
                {
                    var resultvectortest = new double[case2.Length];
                }

                var resultCase2 = Algebra.SkalarProdukt(case2,
                    Algebra.VektorMatrixMultiplikation(inputMatrix, case2, resultTest));
                double[] violatingCase2 = null;
                if (resultCase2 < 0) violatingCase2 = case2;


                //Case B
                Console.WriteLine("____________________Case 2____________________");
                var caseB = Preprocessing.CaseB(resultCaseA, inputMatrix);
                //END CASE B___________________________________________________

                //CASE C

                Console.WriteLine("____________________Case 3____________________");

                var caseC = Preprocessing.PositivityTestCaseC(inputMatrix, resultCaseA, matrixCase4, matrixCase3,
                    matrixDto, eigenVectorAndValue);
                if (matrixCase3.GetMatrix() != null)
                    Preprocessing.DiagonalNegativeDominance(matrixCase3.GetMatrix(), matrixDto);


                //END CASE C___________________________________________________

                Console.WriteLine("____________________Case 5____________________");
                var caseE = Preprocessing.CaseE(inputMatrix);


                Console.WriteLine("____________________Case 4____________________");


                var caseD = Preprocessing.NegativityTestCaseD(inputMatrix, matrixCase4, matrixCase3, matrixDto,
                    eigenVectorAndValue);
                if (caseD != null) Console.WriteLine();

                if (matrixCase4.GetMatrix() != null)
                    Preprocessing.DiagonalNegativeDominance(matrixCase4.GetMatrix(), matrixDto);


                Console.WriteLine("________________________________________________________");
                Console.WriteLine("____________________Lemma 0.2 Case B____________________");
                Console.WriteLine("________________________________________________________");


                var caseB2 = Preprocessing2.CaseB(0, inputMatrixDoubles);
                // var caseB2inv = Preprocessing2.CaseB(0, inverseMatrixDouble);
                Console.WriteLine("____________________Case C2____________________");
                var caseC2 = Preprocessing2.PositivityTestCaseC(inputMatrixDoubles, resultCaseA);
                // Console.WriteLine("____________________Case C2 inv____________________");
                // var caseC2inv = Preprocessing2.PositivityTestCaseC(inverseMatrixDouble, resultCaseA);
                Console.WriteLine("____________________Case E2____________________");
                var caseE2 = Preprocessing2.CaseE(inputMatrixDoubles);
                // Console.WriteLine("____________________Case E2inv____________________");
                // var caseE2inv = Preprocessing2.CaseE(inverseMatrixDouble);
                Console.WriteLine("____________________Case D2____________________");
                var caseD2 = Preprocessing2.NegativityTestCaseD(inputMatrixDoubles);
                // Console.WriteLine("____________________Case D2inv____________________");
                // var caseD2inv = Preprocessing2.NegativityTestCaseD(inverseMatrixDouble);
                Console.WriteLine("____________________Case Lemma0.2 C____________________");
                var caseL2C = Preprocessing2.Lemma2CaseC(inputMatrixDoubles);
                // Console.WriteLine("____________________Case Lemma0.2 Cinv____________________");
                // var caseL2C2 = Preprocessing2.Lemma2CaseC(inverseMatrixDouble);
                Console.WriteLine("____________________Spectral Preprocessing________________");

                //WE ARE HERE
                var spectral = Algebra
                    .EigenVectorViolating(inputMatrix, numberOfPositiveSemiDefinite, eigenVectorAndValue)
                    .GetViolatingVector();
                var eigenValues = Algebra
                    .EigenVectorViolating(inputMatrix, numberOfPositiveSemiDefinite, eigenVectorAndValue)
                    .GetEigenValues();


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


                var violatingVectorsList = new List<double[]>
                {
                    caseA, caseB, caseC, caseD, caseE,
                    caseE2, caseB2, caseC2, caseD2, caseL2C, caseB2Processed,
                    caseC2Processed,
                    caseE2Processed, caseL2CProcessed, spectral, violatingCase2
                };
                var counterVar = 0;
                foreach (var vector in violatingVectorsList)
                    if (vector != null)
                    {
                        counterVar++;
                        matrixDto.SetVector(vector);
                        break;
                    }

                if (counterVar == 0) matrixDto.SetVector(null);

                var finalMatrixCase4 = matrixCase4.GetMatrix();
                var finalMatrixCase3 = matrixCase3.GetMatrix();
                var rows3 = 0;
                var rows4 = 0;
                decimal store1 = 0;
                decimal store2 = 0;
                if (finalMatrixCase3 != null)
                {
                    rows3 = finalMatrixCase3.GetLength(1);
                    deletedRowsCase3 += Math.Abs(finalMatrixCase3.GetLength(1) - inputMatrix.GetLength(1));
                }

                if (finalMatrixCase4 != null)
                {
                    rows4 = finalMatrixCase4.GetLength(1);
                    deletedRowsCase4 += Math.Abs(finalMatrixCase4.GetLength(1) - inputMatrix.GetLength(1));
                }

                if (deletedRowsCase3 > 0)
                {
                    store1 =
                        Math.Round(100 - rows3 / (decimal) inputMatrix.GetLength(0) * 100, 2);
                    if (store1 > 0 && store1 < 100) percentageofRows3 = store1;
                }

                if (deletedRowsCase4 > 0)
                {
                    store2 =
                        Math.Round(100 - rows4 / (decimal) inputMatrix.GetLength(0) * 100, 2);
                    if (store2 > 0 && store2 < 100) percentageofRows4 = store2;
                }


                double[] violatingVector = null;
                double result = 0;
                var violatingVectorsNew = new List<double[]>();
                foreach (var item in violatingVectorsList)
                    if (item != null)
                        violatingVectorsNew.Add(item);

                foreach (var vector in violatingVectorsList)
                    if (vector != null && vector.Sum() > 0 && vector.Length == inputMatrix.GetLength(0))
                    {
                        violatingVector = vector;
                        result = Algebra.SkalarProdukt(vector,
                            Algebra.VektorMatrixMultiplikation(inputMatrix, vector, resultTest));
                        if (result < 0)
                        {
                            if (caseA == violatingVector) numberOfCaseA++;

                            if (caseB == violatingVector) numberOfCaseB++;

                            if (caseC == violatingVector) numberOfCaseC++;

                            if (caseD == violatingVector) numberOfCaseD++;

                            if (caseE == violatingVector) numberOfCaseE++;

                            if (caseL2C == violatingVector) numberOfLemma02++;

                            if (spectral == violatingVector) numberOfSpectralPreProcessing++;

                            if (violatingCase2 == violatingVector) numberOfCase2++;


                            break;
                        }
                    }


                var length = 0;
                for (var i = 0; i < inputMatrix.GetLength(0); i++)
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                    if (inputMatrix[i, j] >= 0)
                        length++;

                if (length == inputMatrix.Length)
                {
                    matrixDto.SetCopositive(true);
                    matrixDto.SetVector(null);
                }

                Preprocessing.DiagonalNegativeDominance(inputMatrix, matrixDto);
                Preprocessing.DiagonalDominance(inputMatrix, matrixDto);


                if (matrixDto.GetVector() == null && matrixDto.GetCopositive())
                    copositive++;
                else if (matrixDto.GetVector() != null && !matrixDto.GetCopositive())
                    notCopositive++;
                else if (!matrixDto.GetCopositive() && matrixDto.GetVector() == null)
                    noAnswer++;
                else if (matrixDto.GetCopositive() && matrixDto.GetVector() != null) notCopositive++;


                if (eigenValues[0] < -eigenValues[eigenValues.Length - 1]) numberOfPositiveSemiDefinite++;


                //WRITE ALL NOT COPOSITIVE MATRICES

                if (matrixDto.GetVector() != null && !matrixDto.GetCopositive() ||
                    matrixDto.GetCopositive() && matrixDto.GetVector() != null || matrixDto.GetVector() != null &&
                    violatingVector.Length == inputMatrix.GetLength(0))
                {
                    swnotcop.Write("\n");
                    swnotcop.Write("\n");

                    swnotcop.WriteLine("Example : " + counter);
                    for (var i = 0; i < inputMatrix.GetLength(0); i++)
                    {
                        for (var j = 0; j < inputMatrix.GetLength(1); j++)
                        {
                            swnotcop.Write(inputMatrix[i, j] + "  ");
                            if (j == inputMatrix.GetLength(0) - 1 && violatingVector != null &&
                                violatingVector.Sum() > 0)
                                swnotcop.Write("            " + violatingVector[i]);
                        }

                        swnotcop.Write("\n");
                    }

                    swnotcop.Write("\n");

                    if (result < 0) swnotcop.Write("The result is : " + result);
                    swnotcop.Write("\n");

                    if (matrixDto.GetVector() == null && matrixDto.GetCopositive())
                        swnotcop.Write("Matrix is copositive");
                    else if (matrixDto.GetVector() != null && !matrixDto.GetCopositive())
                        swnotcop.Write("Matrix is not copositive");
                    else if (matrixDto.GetCopositive() && matrixDto.GetVector() != null)
                        swnotcop.Write("Matrix is not copositive");
                    else if (!matrixDto.GetCopositive() && matrixDto.GetVector() == null)
                        swnotcop.Write("No answer possible");

                    if (eigenValues[0] < -eigenValues[eigenValues.Length - 1])
                        swnotcop.Write("Matrix is positive semi definite");
                    swnotcop.Write("\n");

                    if (percentageofRows3 > 0)
                        swnotcop.Write("The percentage of deleted rows with Case 3 is " + percentageofRows3);

                    swnotcop.Write("\n");
                    if (percentageofRows4 > 0)
                        swnotcop.Write("The percentage of deleted rows with Case 4 is " + percentageofRows4);


                    swnotcop.Write("\n");
                    swnotcop.WriteLine(
                        "________________________________________________________________________________________________________");
                    swnotcop.Write("\n");
                    swnotcop.Write("Sorted Eigenvalues");
                    swnotcop.Write("\n");

                    for (var i = 0; i < eigenValues.Length; i++) swnotcop.Write(eigenValues[i] + " ");

                    swnotcop.Write("\n");


                    swnotcop.Write("\n");
                    swnotcop.WriteLine(
                        "________________________________________________________________________________________________________");
                    swnotcop.Write("\n");
                }


                //WRITE ALL COPOSITIVE MATRICES

                if (matrixDto.GetVector() == null && matrixDto.GetCopositive() ||
                    eigenValues[0] < -eigenValues[eigenValues.Length - 1] ||
                    matrixDto.GetPositiveDefinite())
                {
                    swnotcop.Write("\n");
                    swnotcop.Write("\n");

                    swcop.WriteLine("Example : " + counter);
                    for (var i = 0; i < inputMatrix.GetLength(0); i++)
                    {
                        for (var j = 0; j < inputMatrix.GetLength(1); j++)
                        {
                            swcop.Write(inputMatrix[i, j] + "  ");
                            if (j == inputMatrix.GetLength(0) - 1 && violatingVector != null &&
                                violatingVector.Sum() > 0)
                                swcop.Write("            " + violatingVector[i]);
                        }

                        swcop.Write("\n");
                    }

                    swcop.Write("\n");

                    if (result < 0) swcop.Write("The result is : " + result);
                    swcop.Write("\n");

                    if (matrixDto.GetVector() == null && matrixDto.GetCopositive())
                        swcop.Write("Matrix is copositive");
                    else if (matrixDto.GetVector() != null && !matrixDto.GetCopositive())
                        swcop.Write("Matrix is not copositive");
                    else if (matrixDto.GetCopositive() && matrixDto.GetVector() != null)
                        swcop.Write("Matrix is not copositive");
                    else if (!matrixDto.GetCopositive() && matrixDto.GetVector() == null)
                        swcop.Write("No answer possible");

                    if (eigenValues[0] < -eigenValues[eigenValues.Length - 1])
                        swcop.Write("Matrix is positive semi definite");
                    swcop.Write("\n");

                    if (percentageofRows3 > 0)
                        swnotcop.Write("The percentage of deleted rows with Case 3 is " + percentageofRows3);

                    swcop.Write("\n");
                    if (percentageofRows4 > 0)
                        swcop.Write("The percentage of deleted rows with Case 4 is " + percentageofRows4);


                    swcop.Write("\n");
                    swcop.WriteLine(
                        "________________________________________________________________________________________________________");
                    swcop.Write("\n");
                    swcop.Write("Sorted Eigenvalues");
                    swcop.Write("\n");

                    for (var i = 0; i < eigenValues.Length; i++) swcop.Write(eigenValues[i] + " ");

                    swcop.Write("\n");

                    if (matrixDto.GetDiagonalDominance())
                        swcop.Write("This matrix is copositive by diagonal dominance");

                    if (matrixDto.GetDiagonalNegativeDominance())
                        swcop.Write(
                            "This matrix is copositive by diagonal dominance by setting all positive off-diagonal entries to 0");


                    swcop.Write("\n");
                    swcop.WriteLine(
                        "________________________________________________________________________________________________________");
                    swcop.Write("\n");
                }


                //WRITE ALL NO ANSWER CASES

                if (!matrixDto.GetCopositive() && matrixDto.GetVector() == null)
                {
                    swnotcop.Write("\n");
                    swnotcop.Write("\n");

                    swnoansw.WriteLine("Example : " + counter);
                    for (var i = 0; i < inputMatrix.GetLength(0); i++)
                    {
                        for (var j = 0; j < inputMatrix.GetLength(1); j++)
                        {
                            swnoansw.Write(inputMatrix[i, j] + "  ");
                            if (j == inputMatrix.GetLength(0) - 1 && violatingVector != null &&
                                violatingVector.Sum() > 0)
                                swnoansw.Write("            " + violatingVector[i]);
                        }

                        swnoansw.Write("\n");
                    }

                    swnoansw.Write("\n");

                    if (result < 0) swnoansw.Write("The result is : " + result);
                    swnoansw.Write("\n");

                    if (matrixDto.GetVector() == null && matrixDto.GetCopositive())
                        swnoansw.Write("Matrix is copositive");
                    else if (matrixDto.GetVector() != null && !matrixDto.GetCopositive())
                        swnoansw.Write("Matrix is not copositive");
                    else if (matrixDto.GetCopositive() && matrixDto.GetVector() != null)
                        swnoansw.Write("Matrix is not copositive");
                    else if (!matrixDto.GetCopositive() && matrixDto.GetVector() == null)
                        swnoansw.Write("No answer possible");

                    if (eigenValues[0] < -eigenValues[eigenValues.Length - 1])
                        swnoansw.Write("Matrix is positive semi definite");
                    swnoansw.Write("\n");

                    if (percentageofRows3 > 0)
                        swnoansw.Write("The percentage of deleted rows with Case 3 is " + percentageofRows3);

                    swnoansw.Write("\n");
                    if (percentageofRows4 > 0)
                        swnoansw.Write("The percentage of deleted rows with Case 4 is " + percentageofRows4);


                    swnoansw.Write("\n");
                    swnoansw.WriteLine(
                        "________________________________________________________________________________________________________");
                    swnoansw.Write("\n");
                    swnoansw.Write("Sorted Eigenvalues");
                    swnoansw.Write("\n");

                    for (var i = 0; i < eigenValues.Length; i++) swnoansw.Write(eigenValues[i] + " ");

                    swnoansw.Write("\n");


                    swnoansw.Write("\n");
                    swnoansw.WriteLine(
                        "________________________________________________________________________________________________________");
                    swnoansw.Write("\n");
                }
            }

            swnoansw.Write("\n");
            swnoansw.Write("\n");

            swnotcop.WriteLine("Number of copositive matrices: " + copositive);
            swnotcop.WriteLine("Number of not copositive matrices: " + notCopositive);
            swnotcop.WriteLine("Number of No Answer cases: " + noAnswer);
            swnotcop.WriteLine("Number of answers with case A: " + numberOfCaseA);
            swnotcop.WriteLine("Number of answers with case B: " + numberOfCaseB);
            swnotcop.WriteLine("Number of answers with case C: " + numberOfCaseC);
            swnotcop.WriteLine("Number of answers with case D: " + numberOfCaseD);
            swnotcop.WriteLine("Number of answers with case E: " + numberOfCaseE);
            swnotcop.WriteLine("Number of answers with case 2 " + numberOfCase2);
            swnotcop.WriteLine("Number of answers with Lemma 0.2 C: " + numberOfLemma02);
            swnotcop.WriteLine("Number of positive semi definite matrices: " + numberOfPositiveSemiDefinite);
            swnotcop.WriteLine("Number of spectral preprocessing violating vectors: " + numberOfSpectralPreProcessing);
            swnotcop.WriteLine("Number of lines deleted with case 3 " + deletedRowsCase3);
            swnotcop.WriteLine("Number of lines deleted with case 4 " + deletedRowsCase4);


            swnotcop.Flush();
            swnotcop.Close();

            swnoansw.Flush();
            swnoansw.Close();

            swcop.Flush();
            swcop.Close();

            Console.WriteLine();
        }
    }
}