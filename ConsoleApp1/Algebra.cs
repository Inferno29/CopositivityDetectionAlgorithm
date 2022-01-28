using System;
using System.Linq;
using ConsoleApp1.dto;
using MathNet.Numerics.LinearAlgebra;

namespace ConsoleApp1
{
    internal class Algebra
    {
        public static int[,] CreateSymmetricMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j || i < j) matrix[i, j] = matrix[i, j];

                if (i > j) matrix[i, j] = matrix[j, i];
            }


            return matrix;
        }

        public static double[,] CreateSymmetricMatrixOfDoubles(int[,] matrix)
        {
            var inputMatrixDoubles = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j || i < j) inputMatrixDoubles[i, j] = Math.Round((double) matrix[i, j], 3);

                if (i > j) inputMatrixDoubles[i, j] = Math.Round((double) matrix[j, i], 3);
            }


            return inputMatrixDoubles;
        }

        public static double[] VektorRandomElements(double[] vektor)
        {
            var random = new Random();
            for (var i = 0; i < vektor.Length; i++) vektor[i] = random.NextDouble();

            return vektor;
        }


        //work on the random numbers in the matrix 
        public static int[,] MatrixRandomElements()
        {
            var random = new Random();
            var number = random.Next(5, 20);
            var randomMatrix = new int[number, number];


            for (var i = 0; i < randomMatrix.GetLength(0); i++)
            for (var j = 0; j < randomMatrix.GetLength(1); j++)
                randomMatrix[i, j] = random.Next(0, 60) - random.Next(0, 20);
            return randomMatrix;
        }

        public static double[,] MatrixRandomDoubles()
        {
            var random = new Random();
            var number = random.Next(5, 20);
            var randomMatrix = new double[number, number];


            for (var i = 0; i < randomMatrix.GetLength(0); i++)
            for (var j = 0; j < randomMatrix.GetLength(1); j++)
                randomMatrix[i, j] = random.Next(0, 60) - random.Next(0, 20);
            return randomMatrix;
        }

        public static double[] RandomVektorForRandomMatrix(int[,] matrix)
        {
            var random = new Random();
            var randomVektor = new double[matrix.GetLength(0)];

            for (var i = 0; i < matrix.GetLength(0); i++) randomVektor[i] = random.NextDouble();

            return randomVektor;
        }

        public static double[] RandomVektorForRandomMatrix(double[,] matrix)
        {
            var random = new Random();
            var randomVektor = new double[matrix.GetLength(0)];

            for (var i = 0; i < matrix.GetLength(0); i++) randomVektor[i] = Math.Round(random.NextDouble(), 3);

            return randomVektor;
        }

        public static double[] VektorMatrixMultiplikation(int[,] matrix, double[] vektor, double[] result)
        {
            if (matrix != null && vektor != null && result != null)
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    double temp = 0;
                    for (var j = 0; j < matrix.GetLength(1); j++) temp += matrix[i, j] * vektor[j];

                    result[i] = temp;
                }

            return result;
        }

        public static double[] VektorMatrixMultiplikation(double[,] matrix, double[] vektor, double[] result)
        {
            if (matrix != null && vektor != null && result != null)
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    double temp = 0;
                    for (var j = 0; j < matrix.GetLength(1); j++) temp += matrix[i, j] * vektor[j];

                    result[i] = temp;
                }

            return result;
        }


        //MatrixMultiplikation

        private static int[,] MatrixMultiplikation(int[,] result, int[,] matrix1, int[,] matrix2)
        {
            for (var i = 0; i < matrix1.GetLength(0); i++)
            for (var j = 0; j < matrix1.GetLength(1); j++)
            {
                var temp = 0;
                var test = 0;
                var test2 = 0;
                for (var k = 0; k < matrix1.GetLength(0); k++)
                {
                    test = matrix1[i, k];
                    test2 = matrix2[k, i];
                    temp += matrix1[i, k] * matrix2[k, j];
                }

                result[i, j] = temp;
            }


            return result;
        }


        //SkalarProdukt

        public static double SkalarProdukt(double[] vektor1, double[] vektor2)
        {
            double temp = 0;
            if (vektor1 != null && vektor2 != null)
                for (var i = 0; i < vektor1.Length; i++)
                    temp += vektor1[i] * vektor2[i];


            return temp;
        }


        public static EigenVectorAndValue EigenVectorViolating(int[,] inputMatrix, int counter,
            EigenVectorAndValue eigenVectorAndValue)
        {
            //EIGENVALUES AND EIGENVECTORS


            var M = Matrix<double>.Build;


            var inputMatrixForEigen = M.DenseOfArray(CreateSymmetricMatrixOfDoubles(inputMatrix));
            var eigenValue = inputMatrixForEigen.Evd();
            var eigenVectors = eigenValue.EigenVectors;
            var eigenValues = eigenValue.EigenValues;

            Console.WriteLine(eigenValues);
            Console.WriteLine(eigenVectors);

            var orderedEigenValues = eigenValues.OrderBy(x => x.Real);
            double min = 0;
            double max = 0;
            min = eigenValues[0].Real;
            max = eigenValues[0].Real;
            var indexOfMax = -1;
            var eigenValuesVector = new double[eigenValues.Count];
            for (var i = 0; i < eigenValues.Count; i++)
            {
                eigenValuesVector[i] = eigenValues[i].Real;
                if (eigenValues[i].Real < min) min = eigenValues[i].Real;

                if (eigenValues[i].Real > max)
                {
                    max = eigenValues[i].Real;
                    indexOfMax = i;
                }
            }


            Console.WriteLine($"Lambda1 = {min} ||| LambdaN = {max}");

            // Get First Eigenvector
            var eigenVectorsArray = eigenVectors.ToArray();
            var firstEigenVector = new double[eigenVectorsArray.GetLength(0)];
            var positiveEigenVector = new double[eigenVectorsArray.GetLength(0)];
            var NegativeEigenVector = new double[eigenVectorsArray.GetLength(0)];
            var resultVector = new double[eigenVectorsArray.GetLength(0)];

            eigenVectorAndValue.SetEigenValues(eigenValuesVector);
            eigenVectorAndValue.SetEigenVector(eigenVectorsArray);


            for (var i = 0; i < firstEigenVector.Length; i++)
            {
                firstEigenVector[i] = eigenVectorsArray[i, 0];
                positiveEigenVector[i] = Math.Abs(firstEigenVector[i]);
                NegativeEigenVector[i] = positiveEigenVector[i] - firstEigenVector[i];
            }


            if (min >= 0)
            {
                Console.WriteLine("Matrix is positive semidefinite");
                counter++;
            }

            if (min < -max)
            {
                Console.WriteLine("matrix is not copositive");
                var pos = SkalarProdukt(positiveEigenVector,
                    VektorMatrixMultiplikation(inputMatrix, positiveEigenVector, resultVector));
                var neg = SkalarProdukt(NegativeEigenVector,
                    VektorMatrixMultiplikation(inputMatrix, NegativeEigenVector, resultVector));

                if (pos < 0)
                {
                    eigenVectorAndValue.SetEViolatingVector(positiveEigenVector);
                    return eigenVectorAndValue;
                }

                if (neg < 0)
                {
                    eigenVectorAndValue.SetEViolatingVector(NegativeEigenVector);
                    return eigenVectorAndValue;
                }
            }


            if (indexOfMax >= 0)
                if (min == -max)
                    for (var i = 0; i < eigenVectorsArray.Length; i++)
                        if (eigenVectorsArray[indexOfMax, i] != null)
                        {
                            Console.WriteLine("matrix is not copositive");

                            var pos = SkalarProdukt(positiveEigenVector,
                                VektorMatrixMultiplikation(inputMatrix, positiveEigenVector, resultVector));
                            var neg = SkalarProdukt(NegativeEigenVector,
                                VektorMatrixMultiplikation(inputMatrix, NegativeEigenVector, resultVector));

                            if (pos < 0)
                            {
                                eigenVectorAndValue.SetEViolatingVector(positiveEigenVector);
                                return eigenVectorAndValue;
                            }

                            if (neg < 0)
                            {
                                eigenVectorAndValue.SetEViolatingVector(NegativeEigenVector);
                                return eigenVectorAndValue;
                            }
                        }


            return eigenVectorAndValue;
        }
    }
}