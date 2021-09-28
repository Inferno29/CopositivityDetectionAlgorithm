using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Complex = System.Numerics.Complex;

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

        public static double[,] CreateSymmetricMatrixOfDoubles(int[,] matrix)
        {
            double[,] inputMatrixDoubles = new double[matrix.GetLength(0), matrix.GetLength(1)];  
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j || i < j)
                    {
                        inputMatrixDoubles[i,j] = Math.Round((double)matrix[i, j],3);
                    }

                    if (i > j)
                    {
                        inputMatrixDoubles[i, j] = Math.Round((double)matrix[j, i],3);

                    }

                }
            }




            return inputMatrixDoubles;
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
        
        public static double[,] MatrixRandomDoubles()
        {
            Random random = new Random();
            int number = random.Next(5, 20);
            double[,] randomMatrix = new double[number, number];


            for (int i = 0; i < randomMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] = random.Next(0, 60) - random.Next(0, 20);
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

        public static double[] RandomVektorForRandomMatrix(double[,] matrix)
        {
            Random random = new Random();
            double[] randomVektor = new double[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                randomVektor[i] = Math.Round(random.NextDouble(), 3);
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

        public static double[] VektorMatrixMultiplikation(double[,] matrix, double[] vektor, double[] result)
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




        public static double[] EigenVectorViolating(double[,] inputMatrix, int counter)
        {
            //EIGENVALUES AND EIGENVECTORS

            var M = Matrix<double>.Build;


            var inputMatrixForEigen = M.DenseOfArray(inputMatrix);
            Evd<double> eigenValue = inputMatrixForEigen.Evd();
            Matrix<double> eigenVectors = eigenValue.EigenVectors;
            Vector<Complex> eigenValues = eigenValue.EigenValues;

            Console.WriteLine(eigenValues);
            Console.WriteLine(eigenVectors);

            var orderedEigenValues = eigenValues.OrderBy(x => x.Real);
            double min = 0;
            double max = 0;
            min = eigenValues[0].Real;
            max = eigenValues[0].Real;
            for (var i = 0; i < eigenValues.Count; i++)
            {
                if (eigenValues[i].Real < min)
                {
                    min = eigenValues[i].Real;
                }

                if (eigenValues[i].Real > max)
                {
                    max = eigenValues[i].Real;
                }

            }

            // Get First Eigenvector
            var eigenVectorsArray = eigenVectors.ToArray();
            double[] firstEigenVector = new double[eigenVectorsArray.GetLength(0)];
            double[] positiveEigenVector = new double[eigenVectorsArray.GetLength(0)];
            double[] NegativeEigenVector = new double[eigenVectorsArray.GetLength(0)];
            double[] resultVector = new double[eigenVectorsArray.GetLength(0)];


            for (var i = 0; i < firstEigenVector.Length; i++)
            {
                firstEigenVector[i] = eigenVectorsArray[i, 0];
                positiveEigenVector[i] = Math.Abs(firstEigenVector[i]);
                NegativeEigenVector[i] = positiveEigenVector[i] - firstEigenVector[i];
            }


            if (min >= 0)
            {
                Console.WriteLine("Matrix is copositive");
                counter++; 
            }

            if (min < -max)
            {
                Console.WriteLine("matrix is not copositive");
                var pos = Algebra.SkalarProdukt(positiveEigenVector, Algebra.VektorMatrixMultiplikation(inputMatrix, positiveEigenVector, resultVector));
                var neg = Algebra.SkalarProdukt(NegativeEigenVector, Algebra.VektorMatrixMultiplikation(inputMatrix, NegativeEigenVector, resultVector));

                if (pos < 0)
                {
                    return positiveEigenVector;
                }

                if (neg < 0)
                {
                    return NegativeEigenVector; 
                }

            }


            if (min == -max)
            {
                Console.WriteLine("matrix is not copositive");

                var pos = Algebra.SkalarProdukt(positiveEigenVector, Algebra.VektorMatrixMultiplikation(inputMatrix, positiveEigenVector, resultVector));
                var neg = Algebra.SkalarProdukt(NegativeEigenVector, Algebra.VektorMatrixMultiplikation(inputMatrix, NegativeEigenVector, resultVector));

                if (pos < 0)
                {
                    return positiveEigenVector;
                }

                if (neg < 0)
                {
                    return NegativeEigenVector;
                }
            }

            return null; 

        }



    }
}
