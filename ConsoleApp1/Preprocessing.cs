using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.dto;

namespace ConsoleApp1
{
    internal class Preprocessing
    {
        public static bool PositivityTestForColumns(double[,] inputMatrix)
        {
            var indexJ = -1;
            var IndexI = 0;
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            for (var j = 0; j < inputMatrix.GetLength(1); j++)
                if (inputMatrix[j, i] > 0)
                {
                    indexJ++;
                    break;
                }

            if (indexJ == inputMatrix.GetLength(1) - 1)
            {
                IndexI = 1;
                Console.WriteLine(
                    "The input matrix is copositive because each column of the inverse matrix contains a positive entry Proposition 7.5");
                return true;
            }

            if (IndexI == 0) Console.WriteLine("No Answer possible for this case - Positivity Test");

            return false;
        }

        public static bool NegativityTestForColumns(double[,] inputMatrix)
        {
            var indexJ = -1;
            var IndexI = 0;
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                    if (inputMatrix[j, i] <= 0)
                    {
                        indexJ++;

                        if (indexJ == inputMatrix.GetLength(1) - 1)
                        {
                            IndexI = 1;
                            Console.WriteLine(
                                "The input matrix is copositive because a column of a nonsingular principal submatrix of the inverse input matrix contains a nonpositive column");
                            return true;
                        }
                    }


                indexJ = -1;
            }

            if (IndexI == 0)
                Console.WriteLine(
                    "Input matrix has positive elements in every row - No answer for negativity test columns");

            return false;
        }

        public static bool NegativityTest(double[,] inputMatrix)
        {
            var numberOfNegativeElements = -1;

            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            for (var j = 0; j < inputMatrix.GetLength(1); j++)
                if (inputMatrix[j, i] < 0)
                {
                    numberOfNegativeElements++;

                    if (numberOfNegativeElements == (inputMatrix.GetLength(1) - 1) * inputMatrix.GetLength(1) - 1)
                    {
                        Console.WriteLine("The input matrix is not copositive based on theorem 3.4");
                        return true;
                    }
                }

            return false;
        }

        public static double[] CheckForNegativeDiagonalElement(int[,] matrix)
        {
            var resultVektor = new double[matrix.GetLength(0)];
            var counter = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
                if (i == j)
                {
                    if (matrix[i, j] < 0 && counter < 1)
                    {
                        resultVektor[j] = 1;
                        counter++;
                    }

                    else
                    {
                        resultVektor[j] = 0;
                    }
                }

            var sum = 0;
            for (var i = 0; i < resultVektor.Length; i++) sum += (int) resultVektor[i];

            if (sum == 0) return null;
            return resultVektor;
        }

        public static double[] CheckForNegativeDiagonalElement(double[,] matrix)
        {
            var resultVektor = new double[matrix.GetLength(0)];
            var counter = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
                if (i == j)
                {
                    if (matrix[i, j] < 0 && counter < 1)
                    {
                        resultVektor[j] = 1;
                        counter++;
                    }

                    else
                    {
                        resultVektor[j] = 0;
                    }
                }

            var sum = 0;
            for (var i = 0; i < resultVektor.Length; i++) sum += (int) resultVektor[i];

            if (sum == 0) return null;
            return resultVektor;
        }


        public static double[] CheckForNegativeDiagonalElementAndIgnoreIndex(int[,] matrix, int index)
        {
            var resultVektor = new double[matrix.GetLength(0)];
            var counter = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
                if (i == j && i != index)
                {
                    if (matrix[i, j] < 0 && counter < 1)
                    {
                        resultVektor[j] = 1;
                        counter++;
                    }

                    else
                    {
                        resultVektor[j] = 0;
                    }
                }

            var sum = 0;
            for (var i = 0; i < resultVektor.Length; i++) sum += (int) resultVektor[i];

            if (sum == 0) return null;
            return resultVektor;
        }


        public static List<int> CheckIfDiagonalElementsAreZero(List<int> list, int[,] matrix)
        {
            if (matrix != null)
                for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                    if (i == j)
                        if (matrix[i, j] == 0)
                            list.Add(i);
            if (list.Count > 0) return list;

            Console.WriteLine("No diagonal element is 0");
            return null;
        }


        public static double[] TestMethod(List<int> list, double[] violatingVector, int[,] matrix)
        {
            if (list != null)
            {
                var counter = 0;
                foreach (var i in list)
                {
                    if (counter > 1) break;
                    for (var j = 0; j < matrix.GetLength(1); j++)
                        if (j != i)
                        {
                            if (matrix[i, j] < 0)
                            {
                                violatingVector[i] = matrix[j, j] + 1;
                                violatingVector[j] = -matrix[i, j];
                            }
                            else
                            {
                                violatingVector[j] = 0;
                            }
                        }

                    counter++;
                }


                return violatingVector;
            }

            return null;
        }

        public static double[] Case2(double[] violatingVector, double[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, i] == 0)
                    for (var j = 0; j < matrix.GetLength(1); j++)
                        if (j != i && Math.Abs(i - j) == 1)
                        {
                            if (matrix[i, j] < matrix[i, i])
                            {
                                violatingVector[i] = matrix[j, j] + 1;
                                violatingVector[j] = -matrix[i, j];
                            }
                            else
                            {
                                violatingVector[j] = 0;
                            }
                        }

            if (violatingVector.Sum() > 0)
                return violatingVector;
            return null;
        }

        //Case C
        public static int[,] TestCaseC(int[,] inputMatrix, int[,] outputMatrix)
        {
            int? indexI = -1;
            var indexJ = -1;
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                indexI = i;
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                    if (inputMatrix[i, j] >= 0)
                    {
                        indexJ++;
                        if (indexJ == inputMatrix.GetLength(1) - 1 && indexI != null)
                        {
                            for (var m = 0; m < inputMatrix.GetLength(0); m++)
                            for (var k = 0; k < inputMatrix.GetLength(0); k++)
                            {
                                int? number = null;

                                if (k != indexI && m != indexI) number = inputMatrix[m, k];

                                if (number != null) outputMatrix[m, k] = (int) number;
                            }

                            if (indexI != null)
                            {
                                outputMatrix = TrimForCaseC(indexI, outputMatrix);

                                return outputMatrix;
                            }
                        }
                    }

                indexJ = -1;
            }

            return null;
        }

        public static int[,] TrimForCaseC(int? removeIndex, int[,] originalArray)
        {
            var result = new int[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == removeIndex)
                    continue;

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    if (k == removeIndex)
                        continue;

                    result[j, u] = originalArray[i, k];
                    u++;
                }

                j++;
            }

            return result;
        }

        public static double[] CaseC(double resultCaseA, int[,] inputMatrix, MatrixforCase4 matrixCase4,
            MatrixForCase3 matrixCase3, Case4Dto case4Dto, EigenVectorAndValue eigenVectorAndValue)
        {
            if (resultCaseA == 0)
            {
                Console.WriteLine("Case 3 deleting positive rows");
                Console.WriteLine("First iteration");
                var resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                var outputMatrix = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
                PrintingToConsole.PrintMatrixToConsole(TestCaseC(inputMatrix, outputMatrix));
                var afterCaseC = TestCaseC(inputMatrix, outputMatrix);
                if (afterCaseC != null) matrixCase3.SetMatrix(afterCaseC);
                var counter = 1;
                while (afterCaseC != null)
                {
                    outputMatrix = new int[afterCaseC.GetLength(0), afterCaseC.GetLength(1)];
                    afterCaseC = TestCaseC(afterCaseC, outputMatrix);
                    if (afterCaseC != null) matrixCase3.SetMatrix(afterCaseC);
                    counter++;


                    if (afterCaseC != null)
                    {
                        Console.WriteLine("next iteration");
                        Console.WriteLine("_________________________________________");
                        PrintingToConsole.PrintMatrixToConsole(afterCaseC);
                        Console.WriteLine("____________________________________________________");
                        Console.WriteLine("Case 2 called from Case 3");
                        var listCheckZero2 = new List<int>();


                        var violatingVectorReduced = new double[afterCaseC.GetLength(0)];
                        var listZero2 = CheckIfDiagonalElementsAreZero(listCheckZero2, afterCaseC);

                        DiagonalNegativeDominance(afterCaseC, case4Dto);
                        DiagonalDominance(afterCaseC, case4Dto);
                        if (!case4Dto.GetDiagonalNegativeDominance())
                            Console.WriteLine("No Diagonal Negative Dominance");
                        if (!case4Dto.GetDiagonalDominance()) Console.WriteLine("No Diagonal Dominance");
                        if (case4Dto.GetDiagonalNegativeDominance()) return null;

                        //Call to Case 5
                        var test5 = CaseE(afterCaseC);

                        //Call to Case 4
                        Console.WriteLine("Case 4 called from Case 3");
                        var test4 = NegativityTestCaseD(afterCaseC, matrixCase4, matrixCase3, case4Dto,
                            eigenVectorAndValue);
                        var testMethod = TestMethod(listZero2, violatingVectorReduced, afterCaseC);

                        //Call to spectral preprocessing


                        if (afterCaseC.GetLength(0) >= 2)
                        {
                            var spectral = Algebra
                                .EigenVectorViolating(afterCaseC, 0, eigenVectorAndValue).GetEigenValues();

                            var spectralCounter = 0;
                            for (var i = 0; i < spectral.Length; i++)
                                if (spectral[i] > 0)
                                    spectralCounter++;

                            if (spectralCounter == spectral.Length) case4Dto.SetPositiveDefinite(true);
                        }


                        if (test5 != null)
                        {
                            violatingVectorReduced = test5;
                        }

                        else if (test4 != null)
                        {
                            violatingVectorReduced = test5;
                        }

                        else if (testMethod != null)
                        {
                            TestMethod(listZero2, violatingVectorReduced, afterCaseC);
                            violatingVectorReduced = testMethod;
                        }
                        else
                        {
                            violatingVectorReduced = null;
                        }

                        Console.WriteLine();


                        if (violatingVectorReduced != null)
                        {
                            Console.WriteLine("A violating vector is REDUCED");
                            PrintingToConsole.PrintVektorToConsole(violatingVectorReduced);
                            PrintingToConsole.PrintMatrixToConsole(afterCaseC);
                            Console.WriteLine(Algebra.SkalarProdukt(violatingVectorReduced,
                                Algebra.VektorMatrixMultiplikation(afterCaseC, violatingVectorReduced, resultTest)));
                            var violatingVectorCaseC = new double[violatingVectorReduced.Length + counter];
                            for (var i = 0; i < violatingVectorCaseC.Length; i++)
                                if (i < counter)
                                    violatingVectorCaseC[i] = 0;
                                else
                                    violatingVectorCaseC[i] = violatingVectorReduced[i - counter];

                            var result = Algebra.SkalarProdukt(violatingVectorCaseC,
                                Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVectorCaseC, resultTest));
                            if (result < 0)
                            {
                                case4Dto.SetCopositive(false);
                                Console.WriteLine("Extended Violating Vector");
                                PrintingToConsole.PrintVektorToConsole(violatingVectorCaseC);
                                Console.WriteLine("The Result is " + Algebra.SkalarProdukt(violatingVectorCaseC,
                                    Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVectorCaseC, resultTest)));
                                return violatingVectorCaseC;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No violating Vector for Case 3");
                        }
                    }
                    else
                    {
                        if (counter < 2) Console.WriteLine("No row had only nonnegative entries CASE 3 failed");
                    }
                }
            }

            return null;
        }

        public static double[] CaseB(double resultCaseA, int[,] inputMatrix)
        {
            if (resultCaseA == 0)
            {
                Console.WriteLine("____________________________________________________");
                Console.WriteLine("Case B");
                var resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                var listCheckZero = new List<int>();
                var listZero = CheckIfDiagonalElementsAreZero(listCheckZero, inputMatrix);
                var violatingVector = new double[inputMatrix.GetLength(0)];
                violatingVector = TestMethod(listZero, violatingVector, inputMatrix);
                if (violatingVector != null)
                {
                    var v2 = new double[violatingVector.Length];
                    double sum = 0;
                    for (var i = 0; i < violatingVector.Length; i++) sum += violatingVector[i];

                    if (sum > 0)
                    {
                        Console.WriteLine("Results Case B");
                        Console.WriteLine("A violating vector is");
                        PrintingToConsole.PrintVektorToConsole(violatingVector);
                        PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                        Console.WriteLine(Algebra.SkalarProdukt(violatingVector,
                            Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVector, resultTest)));
                        return violatingVector;
                    }
                }
            }

            return null;
        }

        public static double[] CaseE(int[,] inputMatrix)
        {
            Console.WriteLine("Case 5 starting");
            var violatingVector = new double[inputMatrix.GetLength(0)];
            var rowFound = false;
            var result = new double[inputMatrix.GetLength(0)];
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            for (var j = 0; j < inputMatrix.GetLength(1); j++)
            {
                for (var k = 0; k < violatingVector.Length; k++)
                    if (k == j && inputMatrix[i, j] < -Math.Sqrt(inputMatrix[i, i] * inputMatrix[j, j]) &&
                        -Math.Sqrt(inputMatrix[i, i] * inputMatrix[j, j]) < 0)
                    {
                        rowFound = true;
                        violatingVector[i] = Math.Sqrt(inputMatrix[j, j]);
                        violatingVector[j] = Math.Sqrt(inputMatrix[i, i]);
                    }
                    else
                    {
                        violatingVector[k] = 0;
                    }

                if (rowFound)
                {
                    double sum = 0;
                    for (var l = 0; l < violatingVector.Length; l++) sum += violatingVector[l];

                    if (sum > 0)
                    {
                        PrintingToConsole.PrintVektorToConsole(violatingVector);
                        var resultCaseE = Algebra.SkalarProdukt(violatingVector,
                            Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVector, result));
                        Console.WriteLine("The result for case 5 is : " + resultCaseE);
                        return violatingVector;
                    }
                }
            }

            Console.WriteLine("No violating vector for Case 5");
            return null;
        }


        public static double[] CaseD(int[,] inputMatrix, MatrixforCase4 matrixCase4, MatrixForCase3 matrixCase3,
            Case4Dto case4Dto, EigenVectorAndValue eigenVectorAndValue)
        {
            var valuesVector = new double[inputMatrix.GetLength(0)];
            var saveForValuesVector = new double[valuesVector.Length];
            var negativeSignMatrix = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
            var saveForInputMatrix = inputMatrix;


            do
            {
                for (var i = 0; i < inputMatrix.GetLength(0); i++)
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                    if (inputMatrix[i, j] < 0)
                        negativeSignMatrix[i, j] = 1;
                    else
                        negativeSignMatrix[i, j] = 0;

                for (var i = 0; i < valuesVector.Length; i++) valuesVector[i] = 0;

                for (var i = 0; i < negativeSignMatrix.GetLength(0); i++)
                for (var j = 0; j < negativeSignMatrix.GetLength(1); j++)
                    valuesVector[i] += negativeSignMatrix[i, j];


                double maxValue = 0;
                if (valuesVector.Length == 0) return null;
                maxValue = valuesVector.Max();
                var indexOfMax = valuesVector.ToList().IndexOf(maxValue);


                if (maxValue > 0)
                {
                    Console.WriteLine("This is the negative sign matrix");
                    PrintingToConsole.PrintMatrixToConsole(negativeSignMatrix);
                    Console.WriteLine("this is the values vector");
                    PrintingToConsole.PrintVektorToConsole(valuesVector);
                    Console.WriteLine("this is the input matrix");
                    PrintingToConsole.PrintMatrixToConsole(inputMatrix);

                    inputMatrix = TrimForCaseC(indexOfMax, inputMatrix);
                    negativeSignMatrix = TrimForCaseC(indexOfMax, negativeSignMatrix);
                    var vectorList = valuesVector.ToList();
                    vectorList.RemoveAt(indexOfMax);
                    valuesVector = vectorList.ToArray();


                    var T = TMatrixForCaseD(saveForInputMatrix, indexOfMax);
                    matrixCase4.SetMatrix(T);
                    Console.WriteLine("this is matrix T");
                    PrintingToConsole.PrintMatrixToConsole(T);

                    if (T.GetLength(0) >= 2)
                    {
                        var spectral = Algebra
                            .EigenVectorViolating(T, 0, eigenVectorAndValue).GetEigenValues();

                        var spectralCounter = 0;
                        for (var i = 0; i < spectral.Length; i++)
                            if (spectral[i] > 0)
                                spectralCounter++;

                        if (spectralCounter == spectral.Length) case4Dto.SetPositiveDefinite(true);
                    }


                    if (T.GetLength(1) == 2)
                    {
                        var counter = 0;
                        for (var i = 0; i < T.GetLength(1); i++)
                        for (var j = 0; j < T.GetLength(1); j++)
                            if (i != j && T[i, j] < 0 && T[i, i] >= 0)
                            {
                                counter++;
                                if (counter == T.GetLength(1))
                                {
                                    case4Dto.SetCopositive(true);
                                    Console.WriteLine("MATRIX T IS COPOSITIVE");
                                    return null;
                                }
                            }

                        Console.WriteLine();
                    }

                    if (T.GetLength(1) > 2)
                    {
                        var counter = 0;
                        for (var i = 0; i < T.GetLength(1); i++)
                        for (var j = 0; j < T.GetLength(1); j++)
                            if (T[i, j] >= 0)
                            {
                                counter++;
                                if (counter == T.GetLength(1))
                                {
                                    case4Dto.SetCopositive(true);
                                    Console.WriteLine("MATRIX T IS COPOSITIVE");
                                    return null;
                                }
                            }

                        Console.WriteLine();
                    }


                    //Case A

                    var checkForGegativeDiagonals = CheckForNegativeDiagonalElementAndIgnoreIndex(T, indexOfMax);

                    var case2 = CaseB(0, T);
                    var case3 = CaseC(0, T, matrixCase4, matrixCase3, case4Dto, eigenVectorAndValue);
                    var case4 = CaseD(T, matrixCase4, matrixCase3, case4Dto, eigenVectorAndValue);
                    var case5 = CaseE(T);

                    if (checkForGegativeDiagonals != null)
                    {
                        var resultTest = new double[checkForGegativeDiagonals.Length];
                        CheckForNull(checkForGegativeDiagonals);
                        var resultCaseA = Algebra.SkalarProdukt(checkForGegativeDiagonals,
                            Algebra.VektorMatrixMultiplikation(T, checkForGegativeDiagonals, resultTest));
                        Console.WriteLine("the result is " + resultCaseA);
                    }


                    if (case2 != null)
                    {
                        case4Dto.SetVector(case2);
                        checkForGegativeDiagonals = case4Dto.GetVector();
                    }

                    if (case3 != null)
                    {
                        case4Dto.SetVector(case3);
                        checkForGegativeDiagonals = case4Dto.GetVector();
                    }

                    if (case4 != null)
                    {
                        case4Dto.SetVector(case4);
                        checkForGegativeDiagonals = case4Dto.GetVector();
                    }

                    if (case5 != null)
                    {
                        case4Dto.SetVector(case5);
                        checkForGegativeDiagonals = case4Dto.GetVector();
                    }


                    if (checkForGegativeDiagonals != null)
                    {
                        var length = saveForValuesVector.Length - valuesVector.Length;
                        var violatingVector = new double[saveForValuesVector.Length];
                        var violatingVectorShorter = new double[checkForGegativeDiagonals.Length];
                        var violatingList = new List<double>();
                        for (var i = 0; i < saveForValuesVector.Length; i++)
                        {
                            double temp = 0;
                            // if (i < length)
                            if (i == indexOfMax)
                            {
                                for (var j = 0; j < saveForInputMatrix.GetLength(1); j++)
                                    if (j != indexOfMax)
                                        violatingList.Add(saveForInputMatrix[indexOfMax, j]);

                                violatingVectorShorter = violatingList.ToArray();

                                for (var k = 0; k < checkForGegativeDiagonals.Length; k++)
                                    temp += -violatingVectorShorter[k] * checkForGegativeDiagonals[k];


                                violatingVector[i] = temp;
                            }


                            else
                            {
                                for (var m = 0; m < checkForGegativeDiagonals.Length; m++)
                                    if (m == i)
                                        violatingVector[i] = saveForInputMatrix[indexOfMax, indexOfMax] *
                                                             checkForGegativeDiagonals[i];
                            }
                        }


                        var resultVektor = new double[violatingVector.Length];
                        PrintingToConsole.PrintVektorToConsole(violatingVector);
                        var resultA = Algebra.SkalarProdukt(violatingVector,
                            Algebra.VektorMatrixMultiplikation(saveForInputMatrix, violatingVector, resultVektor));
                        Console.WriteLine(resultA);
                        if (resultA < 0)
                        {
                            Console.WriteLine("Case 1");
                            PrintingToConsole.PrintVektorToConsole(violatingVector);
                            Console.WriteLine("RESULT Case 1");
                            Console.WriteLine(resultA);
                            case4Dto.SetVector(violatingVector);
                            return case4Dto.GetVector();
                        }

                        Console.WriteLine("No violating Vector could be found For Case 1 (Called from Case 4)");
                    }
                }
            } while (valuesVector.Sum() > 0);

            if (case4Dto.GetVector() == null) case4Dto.SetCopositive(true);

            if (case4Dto.GetCopositive()) return null;

            return null;
        }

        public static double[] NegativityTestCaseD(int[,] inputMatrix, MatrixforCase4 matrixCase4,
            MatrixForCase3 matrixCase3, Case4Dto case4Dto, EigenVectorAndValue eigenVectorAndValue)
        {
            var indexJ = 0;
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                    if (inputMatrix[i, j] <= 0 && j != i && inputMatrix[i, i] >= 0)
                    {
                        indexJ++;

                        if (indexJ == inputMatrix.GetLength(1) - 1)
                            return CaseD(inputMatrix, matrixCase4, matrixCase3, case4Dto, eigenVectorAndValue);
                    }

                indexJ = 0;
            }

            Console.WriteLine("Input matrix not meeting criteria for Case D");
            return null;
        }


        public static void DiagonalDominance(int[,] inputMatrix, Case4Dto matrixDto)
        {
            var offDiagonals = new int[inputMatrix.GetLength(0)];
            var diagonals = new int[inputMatrix.GetLength(0)];
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                    if (i != j)
                        offDiagonals[i] += Math.Abs(inputMatrix[i, j]);
                diagonals[i] += inputMatrix[i, i];
            }

            var counter = 0;
            for (var i = 0; i < diagonals.Length; i++)
                if (diagonals[i] > offDiagonals[i])
                    counter++;

            if (counter == diagonals.Length)
            {
                matrixDto.SetCopositive(true);
                matrixDto.SetVector(null);
                matrixDto.SetDiagonalDominance(true);
            }

            Console.WriteLine();
        }

        public static void DiagonalNegativeDominance(int[,] inputMatrix, Case4Dto matrixDto)
        {
            var offDiagonals = new int[inputMatrix.GetLength(0)];
            var diagonals = new int[inputMatrix.GetLength(0)];
            var onlyNegativeOffDiagonals = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
            for (var i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    if (inputMatrix[i, j] < 0 && i != j) onlyNegativeOffDiagonals[i, j] = inputMatrix[i, j];
                    if (i != j) offDiagonals[i] += Math.Abs(onlyNegativeOffDiagonals[i, j]);
                }

                diagonals[i] += inputMatrix[i, i];
            }

            var counter = 0;
            for (var i = 0; i < diagonals.Length; i++)
                if (diagonals[i] > offDiagonals[i])
                    counter++;

            if (counter == diagonals.Length)
            {
                matrixDto.SetCopositive(true);
                matrixDto.SetVector(null);
                matrixDto.SetDiagonalNegativeDominance(true);
            }

            Console.WriteLine();
        }


        public static double[] PositivityTestCaseC(int[,] inputMatrix, double resultCaseA, MatrixforCase4 matrixCase4,
            MatrixForCase3 matrixCase3, Case4Dto case4Dto, EigenVectorAndValue eigenVectorAndValue)
        {
            if (resultCaseA == 0)
            {
                var indexJ = -1;
                for (var i = 0; i < inputMatrix.GetLength(0); i++)
                {
                    for (var j = 0; j < inputMatrix.GetLength(1); j++)
                        if (inputMatrix[i, j] >= 0)
                        {
                            indexJ++;

                            if (indexJ == inputMatrix.GetLength(1) - 2)
                                return CaseC(resultCaseA, inputMatrix, matrixCase4, matrixCase3, case4Dto,
                                    eigenVectorAndValue);
                        }

                    indexJ = -1;
                }
            }
            else
            {
                Console.WriteLine("Input matrix not meeting criteria for Case 3");
                return null;
            }

            return null;
        }

        public static int[,] TMatrixForCaseD(int[,] inputMatrix, int i)
        {
            var matrixT = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];


            for (var j = 0; j < matrixT.GetLength(1); j++)
            for (var k = 0; k < matrixT.GetLength(1); k++)
                if (j != i && k != i)
                    matrixT[j, k] = inputMatrix[i, i] * inputMatrix[j, k] - inputMatrix[i, j] * inputMatrix[i, k];

            matrixT = TrimForCaseC(i, matrixT);

            return matrixT;
        }

        public static void CheckForNull(double[] resultVektor)
        {
            if (resultVektor != null)
            {
                Console.WriteLine("A violating vector is");
                PrintingToConsole.PrintVektorToConsole(resultVektor);
            }

            else
            {
                Console.WriteLine("All diaglonal entries are positive");
            }
        }
    }
}