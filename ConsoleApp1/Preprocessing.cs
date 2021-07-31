﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace ConsoleApp1
{
    class Preprocessing
    {


        public static bool NegativityTestForColumns(double[,] inputMatrix)
        {
            int indexJ = -1;
            int IndexI = 0;
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    if (inputMatrix[j, i] <= 0)
                    {
                        indexJ++;

                        if (indexJ == inputMatrix.GetLength(1) - 1)
                        {
                            IndexI = 1;
                            Console.WriteLine("The input matrix is copositive");
                            return true; 

                        }
                    }


                }


                indexJ = -1;
            }

            if (IndexI == 0)
            {
                Console.WriteLine("Input matrix not meeting criteria for Case D");
            }

            return false; 
        }



        public static double[] CheckForNegativeDiagonalElement(int[,] matrix)
        {
            double[] resultVektor = new double[matrix.GetLength(0)];
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

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

                }
            }

            int sum = 0;
            for (int i = 0; i < resultVektor.Length; i++)
            {
                sum += (int)resultVektor[i];
            }

            if (sum == 0)
            {
                return null;
            }
            return resultVektor;

        }

        public static double[] CheckForNegativeDiagonalElement(double[,] matrix)
        {
            double[] resultVektor = new double[matrix.GetLength(0)];
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

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

                }
            }

            int sum = 0;
            for (int i = 0; i < resultVektor.Length; i++)
            {
                sum += (int)resultVektor[i];
            }

            if (sum == 0)
            {
                return null;
            }
            return resultVektor;

        }



        public static double[] CheckForNegativeDiagonalElementAndIgnoreIndex(int[,] matrix, int index)
        {
            double[] resultVektor = new double[matrix.GetLength(0)];
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

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

                }
            }

            int sum = 0;
            for (int i = 0; i < resultVektor.Length; i++)
            {
                sum += (int)resultVektor[i];
            }

            if (sum == 0)
            {
                return null;
            }
            return resultVektor;

        }


        public static List<int> CheckIfDiagonalElementsAreZero(List<int> list, int[,] matrix)
        {
            if (matrix != null)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i == j)
                        {

                            if (matrix[i, j] == 0)
                            {
                                list.Add(i);
                            }

                        }

                    }
                }


            }
            if (list.Count > 0)
            {
                return list;
            }

            else
            {
                Console.WriteLine("No diagonal element is 0");
                return null;

            }

        }


        public static double[] TestMethod(List<int> list, double[] violatingVector, int[,] matrix)
        {
            if (list != null)
            {
                int counter = 0;
                foreach (var i in list)
                {
                    if (counter > 1)
                    {
                        break;

                    }
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != i)
                        {
                            if (matrix[i, j] < 0)
                            {
                                violatingVector[i] = (matrix[j, j] + 1);
                                violatingVector[j] = -matrix[i, j];

                            }
                            else
                            {
                                violatingVector[j] = 0;
                            }


                        }


                    }

                    counter++;
                }


                return violatingVector;


            }

            else
            {
                return null;
            }
        }

        //Case C
        public static int[,] TestCaseC(int[,] inputMatrix, int[,] outputMatrix)
        {
            int? indexI = -1;
            int indexJ = -1;
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {

                indexI = i;
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {

                    if (inputMatrix[i, j] >= 0)
                    {
                        indexJ++;
                        if (indexJ == inputMatrix.GetLength(1) - 1 && indexI != null)
                        {
                            for (int m = 0; m < inputMatrix.GetLength(0); m++)
                            {
                                for (int k = 0; k < inputMatrix.GetLength(0); k++)
                                {


                                    int? number = null;

                                    if (k != indexI && m != indexI)
                                    {
                                        number = inputMatrix[m, k];
                                    }

                                    if (number != null)
                                    {
                                        outputMatrix[m, k] = (int)number;
                                    }

                                }
                            }

                            if (indexI != null)
                            {
                                
                                outputMatrix = TrimForCaseC(indexI, outputMatrix);

                                return outputMatrix;
                            }
                        }
                    }
                }

                indexJ = -1;
            }

            return null;

        }

        public static int[,] TrimForCaseC(int? removeIndex, int[,] originalArray)
        {
            int[,] result = new int[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

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

        public static double[] CaseC(double resultCaseA, int[,] inputMatrix)
        {


            if (resultCaseA == 0)
            {

                Console.WriteLine("Case C");
                Console.WriteLine("First iteration");
                double[] resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                int[,] outputMatrix = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
                PrintingToConsole.PrintMatrixToConsole(Preprocessing.TestCaseC(inputMatrix, outputMatrix));
                int[,] afterCaseC = Preprocessing.TestCaseC(inputMatrix, outputMatrix);
                int counter = 1;
                while (afterCaseC != null)
                {

                    outputMatrix = new int[afterCaseC.GetLength(0), afterCaseC.GetLength(1)];
                    afterCaseC = Preprocessing.TestCaseC(afterCaseC, outputMatrix);
                    counter++;


                    if (afterCaseC != null)
                    {
                        Console.WriteLine("next iteration");
                        Console.WriteLine("_________________________________________");
                        PrintingToConsole.PrintMatrixToConsole(afterCaseC);
                        Console.WriteLine("____________________________________________________");
                        Console.WriteLine("Case B called from Case C");
                        List<int> listCheckZero2 = new List<int>();

                        //Call to Case E
                        CaseE(afterCaseC);

                        List<int> listZero2 = Preprocessing.CheckIfDiagonalElementsAreZero(listCheckZero2, afterCaseC);
                        double[] violatingVectorReduced = new double[afterCaseC.GetLength(0)];
                        violatingVectorReduced =
                            Preprocessing.TestMethod(listZero2, violatingVectorReduced, afterCaseC);
                        if (violatingVectorReduced != null)
                        {

                            Console.WriteLine("A violating vector is REDUCED");
                            PrintingToConsole.PrintVektorToConsole(violatingVectorReduced);
                            PrintingToConsole.PrintMatrixToConsole(afterCaseC);
                            Console.WriteLine(Algebra.SkalarProdukt(violatingVectorReduced,
                                Algebra.VektorMatrixMultiplikation(afterCaseC, violatingVectorReduced, resultTest)));
                            double[] violatingVectorCaseC = new double[violatingVectorReduced.Length + counter];
                            for (int i = 0; i < violatingVectorCaseC.Length; i++)
                            {
                                if (i < counter)
                                {
                                    violatingVectorCaseC[i] = 0;

                                }
                                else
                                {
                                    violatingVectorCaseC[i] = violatingVectorReduced[i - counter];
                                }
                            }

                            double result = Algebra.SkalarProdukt(violatingVectorCaseC,
                                Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVectorCaseC, resultTest));
                            if (result < 0)
                            {
                                Console.WriteLine("Extended Violating Vector");
                                PrintingToConsole.PrintVektorToConsole(violatingVectorCaseC);
                                Console.WriteLine("The Result is " + Algebra.SkalarProdukt(violatingVectorCaseC,
                                    Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVectorCaseC, resultTest)));
                                return violatingVectorCaseC;


                            }






                        }
                        else
                        {
                            Console.WriteLine("No violating Vector for Case C");
                        }
                    }
                    else
                    {
                        if (counter < 2)
                        {
                            Console.WriteLine("No row had only nonnegative entries CASE C failed");
                        }



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
                double[] resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                List<int> listCheckZero = new List<int>();
                List<int> listZero = Preprocessing.CheckIfDiagonalElementsAreZero(listCheckZero, inputMatrix);
                double[] violatingVector = new double[inputMatrix.GetLength(0)];
                violatingVector = Preprocessing.TestMethod(listZero, violatingVector, inputMatrix);
                if (violatingVector != null)
                {
                    double[] v2 = new double[violatingVector.Length];
                    double sum = 0;
                    for (int i = 0; i < violatingVector.Length; i++)
                    {
                        sum += violatingVector[i];
                    }

                    if (sum > 0)
                    {
                        Console.WriteLine("Results Case B");
                        Console.WriteLine("A violating vector is");
                        PrintingToConsole.PrintVektorToConsole(violatingVector);
                        PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                        Console.WriteLine(Algebra.SkalarProdukt(violatingVector, Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVector, resultTest)));
                        return violatingVector;
                    }

                }
            }

            return null;
        }

        public static double[] CaseE(int[,] inputMatrix)
        {
            Console.WriteLine("Case E starting");
            double[] violatingVector = new double[inputMatrix.GetLength(0)];
            bool rowFound = false;
            double[] result = new double[inputMatrix.GetLength(0)];
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {

                    for (int k = 0; k < violatingVector.Length; k++)
                    {
                        if (k == j && inputMatrix[i, j] < -Math.Sqrt(inputMatrix[i, i] * inputMatrix[j, j]) && -Math.Sqrt(inputMatrix[i, i] * inputMatrix[j, j]) < 0)
                        {
                            rowFound = true;
                            violatingVector[i] = Math.Sqrt(inputMatrix[j, j]);
                            violatingVector[j] = Math.Sqrt(inputMatrix[i, i]);
                        }
                        else
                        {
                            violatingVector[k] = 0;
                        }
                    }

                    if (rowFound)
                    {
                        double sum = 0;
                        for (int l = 0; l < violatingVector.Length; l++)
                        {
                            sum += violatingVector[l];
                        }

                        if (sum > 0)
                        {
                            PrintingToConsole.PrintVektorToConsole(violatingVector);
                            double resultCaseE = Algebra.SkalarProdukt(violatingVector,
                                Algebra.VektorMatrixMultiplikation(inputMatrix, violatingVector, result));
                            Console.WriteLine("The result for case E is : " + resultCaseE);
                            return violatingVector;
                        }
                    }
                }
            }

            Console.WriteLine("No violating vector for Case E");
            return null;
        }

        public static void CaseD(int[,] inputMatrix)
        {
            double[] valuesVector = new double[inputMatrix.GetLength(0)];
            double[] saveForValuesVector = new double[valuesVector.Length];
            int[,] negativeSignMatrix = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
            int[,] saveForInputMatrix = inputMatrix;


            do
            {


                for (int i = 0; i < inputMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < inputMatrix.GetLength(1); j++)
                    {
                        if (inputMatrix[i, j] < 0)
                        {
                            negativeSignMatrix[i, j] = 1;
                        }
                        else
                        {
                            negativeSignMatrix[i, j] = 0;
                        }
                    }
                }

                for (int i = 0; i < valuesVector.Length; i++)
                {
                    valuesVector[i] = 0;
                }

                for (int i = 0; i < negativeSignMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < negativeSignMatrix.GetLength(1); j++)
                    {
                        valuesVector[i] += negativeSignMatrix[i, j];
                    }
                }


                double maxValue = valuesVector.Max();
                int indexOfMax = valuesVector.ToList().IndexOf(maxValue);



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



                    int[,] T = TMatrixForCaseD(saveForInputMatrix, indexOfMax);
                    Console.WriteLine("this is matrix T");
                    PrintingToConsole.PrintMatrixToConsole(T);



                    //Case A

                    double[] checkForGegativeDiagonals = CheckForNegativeDiagonalElementAndIgnoreIndex(T, indexOfMax - 1);

                    if (checkForGegativeDiagonals != null)
                    {
                        double[] resultTest = new double[checkForGegativeDiagonals.Length];
                        Preprocessing.CheckForNull(checkForGegativeDiagonals);
                        double resultCaseA = Algebra.SkalarProdukt(checkForGegativeDiagonals,
                            Algebra.VektorMatrixMultiplikation(T, checkForGegativeDiagonals, resultTest));
                        Console.WriteLine("the result is " + resultCaseA);
                    }




                    //_________________________________________________________________________________________
                    //_________________________________________________________________________________________



                    ////Case B
                    //Console.WriteLine("Result for Case B and matrix T");
                    //var caseB = CaseB(0, T);
                    //if (caseB != null)
                    //{

                    //}

                    ////CaseC
                    //Console.WriteLine("Result for Case C and matrix T");
                    //var caseC = CaseC(0, T);
                    //if (caseC != null)
                    //{

                    //}
                    ////CaseE
                    //Console.WriteLine("Result for Case E and matrix T");
                    //var caseE = CaseE(T);
                    //if (caseE != null)
                    //{

                    //}
                    ////__________________________________________________________________________________________
                    ////__________________________________________________________________________________________


                    if (checkForGegativeDiagonals != null)
                    {
                        int length = saveForValuesVector.Length - valuesVector.Length;
                        double[] violatingVector = new double[saveForValuesVector.Length];
                        double[] violatingVectorShorter = new double[checkForGegativeDiagonals.Length];
                        List<double> violatingList = new List<double>();
                        for (int i = 0; i < saveForValuesVector.Length; i++)
                        {
                            double temp = 0;
                            if (i < length)
                            {


                                for (int j = 0; j < saveForInputMatrix.GetLength(1); j++)
                                {


                                    if (j != indexOfMax)
                                    {
                                        violatingList.Add((double)saveForInputMatrix[indexOfMax, j]);





                                    }

                                }

                                violatingVectorShorter = violatingList.ToArray();

                                for (int k = 0; k < checkForGegativeDiagonals.Length; k++)
                                {

                                    temp += -violatingVectorShorter[k] * checkForGegativeDiagonals[k];

                                }

                                violatingVector[i] = temp;
                            }


                            else
                            {
                                violatingVector[i] = saveForInputMatrix[indexOfMax, indexOfMax] * checkForGegativeDiagonals[i - 1];
                            }

                        }





                        //if (caseE != null)
                        //{

                        //    double[] resultVektorCaseE = new double[violatingVector.Length];
                        //    double resultE = Algebra.SkalarProdukt(violatingVector,
                        //        Algebra.VektorMatrixMultiplikation(saveForInputMatrix, violatingVector, resultVektorCaseE));
                        //    Console.WriteLine("Result For Case E with input matrix = " + resultE);
                        //    PrintingToConsole.PrintVektorToConsole(violatingVector);
                        //}

                        //if (caseB != null)
                        //{

                        //    double[] resultVektorCaseE = new double[violatingVector.Length];
                        //    double resultE = Algebra.SkalarProdukt(violatingVector,
                        //        Algebra.VektorMatrixMultiplikation(saveForInputMatrix, violatingVector, resultVektorCaseE));
                        //    Console.WriteLine("Result For Case B with input matrix = " + resultE);
                        //}
                        //if (caseC != null)
                        //{

                        //    double[] resultVektorCaseE = new double[violatingVector.Length];
                        //    double resultE = Algebra.SkalarProdukt(violatingVector,
                        //        Algebra.VektorMatrixMultiplikation(saveForInputMatrix, violatingVector, resultVektorCaseE));
                        //    Console.WriteLine("Result For Case C with input matrix = " + resultE);
                        //}






                        double[] resultVektor = new double[violatingVector.Length];
                        PrintingToConsole.PrintVektorToConsole(violatingVector);
                        double resultA = Algebra.SkalarProdukt(violatingVector,
                            Algebra.VektorMatrixMultiplikation(saveForInputMatrix, violatingVector, resultVektor));
                        Console.WriteLine(resultA);
                        if (resultA < 0)
                        {
                            Console.WriteLine("Case A");
                            PrintingToConsole.PrintVektorToConsole(violatingVector);
                            Console.WriteLine("RESULT Case A");
                            Console.WriteLine(resultA);
                            break;

                        }
                        else
                        {
                            Console.WriteLine("No violating Vector could be found For Case A (Called from Case D)");
                        }

                    }



                }






            } while (valuesVector.Sum() > 0);




        }

        public static double[] NegativityTestCaseD(int[,] inputMatrix)
        {
            int indexJ = -1;
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    if (inputMatrix[i, j] <= 0 && j != i && inputMatrix[i,i] > 0)
                    {
                        indexJ++;

                        if (indexJ == inputMatrix.GetLength(1) - 2)
                        {

                            CaseD(inputMatrix);
                            return null; 
                        }
                    }


                }

                indexJ = -1;
            }

            Console.WriteLine("Input matrix not meeting criteria for Case D");
            return null;

        }

        public static double[] PositivityTestCaseC(int[,] inputMatrix, double resultCaseA)
        {
            if (resultCaseA == 0)
            {
                int indexJ = -1;
                for (int i = 0; i < inputMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < inputMatrix.GetLength(1); j++)
                    {
                        if (inputMatrix[i, j] >= 0)
                        {
                            indexJ++;

                            if (indexJ == inputMatrix.GetLength(1) - 2)
                            {

                                CaseC(resultCaseA, inputMatrix);
                                return null;
                            }
                        }


                    }

                    indexJ = -1;
                }
            }
            else
            {
                Console.WriteLine("Input matrix not meeting criteria for Case C");
                return null;
            }

            return null; 

        }

        public static int[,] TMatrixForCaseD(int[,] inputMatrix, int i)
        {
            int[,] matrixT = new int[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];


            for (int j = 0; j < matrixT.GetLength(1); j++)
            {
                for (int k = 0; k < matrixT.GetLength(1); k++)
                {
                    if (j != i && k != i)
                    {
                        matrixT[j, k] = inputMatrix[i, i] * inputMatrix[j, k] - inputMatrix[i, j] * inputMatrix[i, k];
                    }

                }
            }

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
