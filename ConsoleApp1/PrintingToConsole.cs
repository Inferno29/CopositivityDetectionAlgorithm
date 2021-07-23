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
    }
}
