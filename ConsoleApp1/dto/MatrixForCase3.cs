namespace ConsoleApp1.dto
{
    public class MatrixForCase3
    {
        private int[,] MatrixCase3;

        public void SetMatrix(int[,] matrixT)
        {
            this.MatrixCase3 = matrixT; 
        }

        public int[,] GetMatrix()
        {
            return this.MatrixCase3; 
        }


    }
}