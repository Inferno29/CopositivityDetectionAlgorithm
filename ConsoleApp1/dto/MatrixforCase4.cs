namespace ConsoleApp1.dto
{
    public class MatrixforCase4
    {
        private int[,] MatrixT;

        public void SetMatrix(int[,] matrixT)
        {
            this.MatrixT = matrixT; 
        }

        public int[,] GetMatrix()
        {
            return this.MatrixT; 
        }
        
        
    }
}