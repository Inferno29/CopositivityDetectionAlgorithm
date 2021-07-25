using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class Preprocessing
    {
        public static double[] CheckForNegativeDiagonalElement(double[] resultVektor, int[,] matrix)
        {
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


        public static void CaseC(double resultCaseA, int[,] inputMatrix)
        {


            if (resultCaseA > -1000)
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


                //

            }


        }


        public static void CaseB(double resultCaseA, int[,] inputMatrix)
        {
            if (resultCaseA == 0)
            {
                Console.WriteLine("____________________________________________________");
                Console.WriteLine("Case B");
                double[] resultTest = Algebra.RandomVektorForRandomMatrix(inputMatrix);
                List<int> listCheckZero = new List<int>();
                List<int> listZero = Preprocessing.CheckIfDiagonalElementsAreZero(listCheckZero, inputMatrix);
                double[] v1 = new double[inputMatrix.GetLength(0)];
                v1 = Preprocessing.TestMethod(listZero, v1, inputMatrix);
                if (v1 != null)
                {
                    double[] v2 = new double[v1.Length];
                    double sum = 0;
                    for (int i = 0; i < v1.Length; i++)
                    {
                        sum += v1[i];
                    }

                    if (sum > 0)
                    {
                        Console.WriteLine("Results Case B");
                        Console.WriteLine("A violating vector is");
                        PrintingToConsole.PrintVektorToConsole(v1);
                        PrintingToConsole.PrintMatrixToConsole(inputMatrix);
                        Console.WriteLine(Algebra.SkalarProdukt(v1, Algebra.VektorMatrixMultiplikation(inputMatrix, v1, resultTest)));
                    }

                }
            }
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
                            Console.WriteLine(resultCaseE);
                            return violatingVector;
                        }
                    }
                }
            }

            Console.WriteLine("No violating vector for Case E");
            return null;
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
