using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PrintingToConsole
    {


        //Printing Methods

        public static void PrintMatrixToConsole(int[,] newMatrix)
        {
            if (newMatrix != null)
            {
                for (int i = 0; i <= newMatrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j <= newMatrix.GetLength(1) - 1; j++)
                    {
                        Console.Write(newMatrix[i, j] + "   ");
                    }
                    Console.Write("\n");
                    Console.Write("\n");
                }
            }
           
        }


        public static void PrintMatrixToConsole(double[,] newMatrix)
        {
            if (newMatrix != null)
            {
                for (int i = 0; i <= newMatrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j <= newMatrix.GetLength(1) - 1; j++)
                    {
                        Console.Write(newMatrix[i, j] + "   ");
                    }
                    Console.Write("\n");
                    Console.Write("\n");
                }
            }

        }


        public static void PrintVektorToConsole(double[] vektorResult)
        {
            if (vektorResult != null)
            {
                for (int i = 0; i < vektorResult.Length; i++)
                {
                    Console.WriteLine(vektorResult[i]);
                }
            }
            
        }


        public static void PrintJaggedArrayToConsole(double[][] inputMatrix)
        {
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(0); j++)
                    
                    Console.Write(Math.Round(inputMatrix[i][j], 3).ToString().PadLeft(5, ' ') + "|");
                Console.WriteLine();
            }
        }


    }
}
