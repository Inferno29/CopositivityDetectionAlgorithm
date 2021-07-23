﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    class Algebra
    {



        public static int[,] CreateSymmetricMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j || i < j)
                    {
                        matrix[i, j] = matrix[i,j]; 
                    }

                    if (i > j)
                    {
                        matrix[i,j] = matrix[j, i];
                        
                    }

                }
            }




            return matrix; 
        }

        public static double[] VektorRandomElements(double[] vektor)
        {
            Random random = new Random();
            for (int i = 0; i < vektor.Length; i++)
            {
                vektor[i] = random.NextDouble();
            }

            return vektor;
        }


        //work on the random numbers in the matrix 
        public static int[,] MatrixRandomElements()
        {
            Random random = new Random();
            int number = random.Next(5, 20);
            int[,] randomMatrix = new int[number,number];


            for (int i = 0; i < randomMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] = random.Next(0, 60)-random.Next(0,20);
                }
            }
            return randomMatrix; 
        }

        public static double[] RandomVektorForRandomMatrix(int[,] matrix)
        {
            Random random = new Random();
            double[] randomVektor = new double[matrix.GetLength(0)];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                randomVektor[i] = random.NextDouble(); 
            }

            return randomVektor;
        }


        public static double[] VektorMatrixMultiplikation(int[,] matrix, double[] vektor, double[] result)
        {
            if (matrix != null && vektor != null && result != null)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double temp = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        temp += (double)matrix[i, j] * vektor[j];
                    }

                    result[i] = temp;
                }


                
            }
            return result;
        }



        //MatrixMultiplikation

        private static int[,] MatrixMultiplikation(int[,] result, int[,] matrix1, int[,] matrix2)
        {

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    int temp = 0;
                    int test = 0;
                    int test2 = 0;
                    for (int k = 0; k < matrix1.GetLength(0); k++)
                    {
                        test = matrix1[i, k];
                        test2 = matrix2[k, i];
                        temp += matrix1[i, k] * matrix2[k, j];
                    }

                    result[i, j] = temp;
                }
            }


            return result;
        }





        //SkalarProdukt

        public static double SkalarProdukt(double[] vektor1, double[] vektor2)
        {
            
            double temp = 0;
            if (vektor1 != null && vektor2 != null)
            {
                for (int i = 0; i < vektor1.Length; i++)
                {
                    temp += vektor1[i] * vektor2[i];
                }
            }
            

            return temp;
        }





        public static double[] DisplayResults(List<double> list, double finalResult, double[] result, double[] vektor, int[,] matrix)
        {
            finalResult = Algebra.SkalarProdukt(Algebra.VektorMatrixMultiplikation(matrix, vektor, result), vektor);
            int counter = 0;
            while (counter < 1000000)
            {
                finalResult = Algebra.SkalarProdukt(Algebra.VektorMatrixMultiplikation(matrix, Algebra.VektorRandomElements(vektor),result), Algebra.VektorRandomElements(vektor));
                //Console.WriteLine(finalResult);
                //Console.WriteLine("___________________");
                counter++;
                list.Add(finalResult);

                if (finalResult < 0)
                {
                    Console.WriteLine("the final result is: " + finalResult);
                    Console.WriteLine("A violating vector is");
                    PrintingToConsole.PrintVektorToConsole(vektor);
                    return vektor;

                }
                if (counter == 1000000)
                {
                    Console.WriteLine("no violating vector could be found");
                   
                    break;
                }
            }
            return null;

        }



    }
}
