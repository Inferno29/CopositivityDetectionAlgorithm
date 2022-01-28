namespace ConsoleApp1.dto
{
    public class Case4Dto
    {
        private double[] Vector;
        private bool Copositive;
        private bool DiagonalDominance = false;
        private bool DiagonalNegativeDominance = false;
        private bool PositiveDefinite = false;



        public void SetPositiveDefinite(bool positiveDefinite)
        {
            this.PositiveDefinite = positiveDefinite; 
        }
        public bool GetPositiveDefinite()
        {
            return this.PositiveDefinite; 
        }
        
        
        public void SetDiagonalNegativeDominance(bool diagonalDominance)
        {
            this.DiagonalNegativeDominance = diagonalDominance; 
        }

        public bool GetDiagonalNegativeDominance()
        {
            return this.DiagonalNegativeDominance; 
        }
        public void SetDiagonalDominance(bool diagonalDominance)
        {
            this.DiagonalDominance = diagonalDominance; 
        }

        public bool GetDiagonalDominance()
        {
            return this.DiagonalDominance; 
        }
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