namespace ConsoleApp1.dto
{
    public class MatrixDto
    {
        private double[] Vector;
        private bool Copositive;
        

        public void SetVector(double[] vector)
        {
            this.Vector = vector; 
        }
        public void SetCopositive(bool copositive)
        {
            this.Copositive = copositive; 
        }

        public bool GetCopositive()
        {
            return this.Copositive; 
        }

        public double[] GetVector()
        {
            return this.Vector; 
        }
       
    
    }
}