using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class MatrixOperations
    {

        public static List<double[,]> CreateAllSubmatrices(double[,] inputMatrix)
        {
            double[,] saveInputMatrix = inputMatrix;
            List<double[,]> listOfMatrices = new List<double[,]>();
            List<double[,]> saveForListOfMatrices = new List<double[,]>();
            List<double[,]> Matrices = saveForListOfMatrices; 
            saveForListOfMatrices.Add(inputMatrix);
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                listOfMatrices.Add(CreateSubmatrix(i, inputMatrix));
            }

            foreach (var item in listOfMatrices)
            {
                for (int j = 0; j < item.GetLength(0); j++)
                {
                    saveForListOfMatrices.Add(CreateSubmatrix(j, item));
                }
                
                saveForListOfMatrices.Add(item);
            }


            return saveForListOfMatrices; 
        }
        public static double[,] CreateSubmatrix(int? removeIndex, double[,] originalArray)
        {
            if (originalArray.GetLength(0)-1 >= 0)
            {
                double[,] result = new double[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

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
            else
            {
                return null; 
            }
           
        }
        public static double[][] ConvertToJaggedArray(double[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            double[][] jaggedArray = new double[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new double[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }

        public static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        public static double[][] MatrixIdentity(int n)
        {
            // return an n x n Identity matrix
            double[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
                result[i][i] = 1.0;

            return result;
        }

        public static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");

            double[][] result = MatrixCreate(aRows, bCols);

            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k) // could use k less-than bRows
                        result[i][j] += matrixA[i][k] * matrixB[k][j];

            return result;
        }

        public static double[][] PreprocessingMatrix(double[][] inputMatrix)
        {
            int aRows = inputMatrix.Length; int aCols = inputMatrix[0].Length;
            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < aCols; j++)
                {
                    if (inputMatrix[i][j] < 0.004)
                    {
                        inputMatrix[i][j] = 0; 
                    }
                    else
                    {
                        inputMatrix[i][j] = inputMatrix[i][j]; 
                    }
                }
            }

            return inputMatrix; 
        }
        //Inversion

        public static double[][] MatrixInverse(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm,
                out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        public static double[][] MatrixDuplicate(double[][] matrix)
        {
            // allocates/creates a duplicate of a matrix.
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // copy the values
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        public static double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            // before calling this helper, permute b using the perm array
            // from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        public static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length; // assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            int n = rows; // convenience

            double[][] result = MatrixDuplicate(matrix);

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j) // each column
            {
                double colMax = Math.Abs(result[j][j]); // find largest val in col
                int pRow = j;
                //for (int i = j + 1; i less-than n; ++i)
                //{
                //  if (result[i][j] greater-than colMax)
                //  {
                //    colMax = result[i][j];
                //    pRow = i;
                //  }
                //}

                // reader Matt V needed this:
                for (int i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(result[i][j]) > colMax)
                    {
                        colMax = Math.Abs(result[i][j]);
                        pRow = i;
                    }
                }
                // Not sure if this approach is needed always, or not.

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                // --------------------------------------------------
                // This part added later (not in original)
                // and replaces the 'return null' below.
                // if there is a 0 on the diagonal, find a good row
                // from i = j+1 down that doesn't have
                // a 0 in column j, and swap that good row with row j
                // --------------------------------------------------

                if (result[j][j] == 0.0)
                {
                    // find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row][j] != 0.0)
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    // swap rows so 0.0 no longer on diagonal
                    double[] rowPtr = result[goodRow];
                    result[goodRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }
                // --------------------------------------------------
                // if diagonal after swap is zero . .
                //if (Math.Abs(result[j][j]) less-than 1.0E-20) 
                //  return null; // consider a throw

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }


            } // main j column loop

            return result;
        }


        //Determinant

        public static int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        //this method determines the sub matrix corresponding to a given element
        public static double[,] CreateSmallerMatrix(double[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            double[,] output = new double[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
        //this method determines the value of determinant using recursion
        public static double Determinant(double[,] input)
        {

            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    double[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = (value + input[0, j] * (SignOfElement(0, j) * Determinant(Temp)));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }






        }



        public static double CalculateDeterminant(double[][] matrix)
        {
            int numRows = matrix.Length;
            int numColumns = matrix[0].Length;

            if (numRows != numColumns)
            {
                throw new ArgumentException("Matrix not square"); 
            }

            if (numColumns ==1 && numColumns ==1)
            {
                return matrix[0][0]; 
            }

            if (numColumns == 2 && numColumns == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1]; 
            }

            double result = 0;
            double counter = 0; 

            for (int col = 0; col < numColumns; col++)
            {

                if (col % 2 == 0)
                {
                    counter++;
                    result += matrix[0][col] * CalculateDeterminant(GetMinorMatrix(0, col, matrix)); 
                }
                else
                {
                    counter++;
                    result -= matrix[0][col] * CalculateDeterminant(GetMinorMatrix(0, col, matrix));
                }
                
            }

            return result; 
        }

        public static double[][] GetMinorMatrix(int row, int col, double[][] matrix)
        {
            int numRows = matrix.Length;
            int numColumns = matrix[0].Length;
            double[][] minor = new double[numRows - 1][];
            int rowIndex = 0; 

            for (int i = 0; i < numRows; i++)
            {
                if (i == row)
                {
                    continue;
                }

                minor[rowIndex] = new double[numColumns - 1];
                int colIndex = 0; 
                for (int j = 0; j < numColumns; j++)
                {
                    if (j == col)
                    {
                        continue;
                    }

                    minor[rowIndex][colIndex++] = matrix[i][j];
                }

                ++rowIndex; 
            }
            return minor; 
        }
    }





}




