using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
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
                        if (matrix[i, j] < 0 && counter< 1)
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {

                        if (matrix[i,j] == 0)
                        {
                             list.Add(i); 
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
                                violatingVector[j] =  -matrix[i, j];

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
                    
                    if (inputMatrix[i,j] >= 0)
                    {
                        indexJ++;
                        if (indexJ == inputMatrix.GetLength(1) -1 && indexI !=null)
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

                            indexI = null;
                            return null;

                        }
                    }
                }

                indexJ = -1; 
            }








            //int counter = 0;
            //int? removeIndex = null; 
            //for (int i = 0; i < inputMatrix.GetLength(0); i++)
            //{
               
            //    for (int j = 0; j < inputMatrix.GetLength(1); j++)
            //    {
            //        if (inputMatrix[i,j] > 0)
            //        {
                      
            //            for (int k = 0; k < inputMatrix.GetLength(0); k++)
            //            {
            //                if (counter <=1)
            //                {
            //                    int? number = null;
            //                    removeIndex = i; 
            //                    if (k != i && j != i)
            //                    {
            //                        number = inputMatrix[j, k];
            //                    }

            //                    if (number != null)
            //                    {
            //                        outputMatrix[j,k] = (int) number;
            //                    }

            //                }
                           
                            
            //            }

            //        }
            //    }
            //}

            //if (removeIndex != null)
            //{
            //    outputMatrix = TrimForCaseC(removeIndex, outputMatrix);

            //    return outputMatrix;
            //}

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

        public static int[,] WhileLoopForCaseC(int[,] inputMatrix, int[,] outputMatrix)
        {
            outputMatrix = TestCaseC(inputMatrix, outputMatrix);
            int sumOfRow = 0;
            while (sumOfRow >= 0)
            {
                for (int i = 0; i < outputMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < outputMatrix.GetLength(1); j++)
                    {
                        sumOfRow += inputMatrix[i, j]; 
                        outputMatrix = TestCaseC(inputMatrix, outputMatrix);
                    }
                }

            }
          

            return outputMatrix; 
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
