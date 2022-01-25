namespace ConsoleApp1.dto
{
    public class EigenVectorAndValue
    {
        private double[,] eigenVector;
        private double[] eigenvalues;
        private double[] violatingVector; 


        public void SetEigenVector(double[,] vector)
        {
            this.eigenVector = vector; 
        }
        public void SetEigenValues(double[] eigenvalues)
        {
            this.eigenvalues = eigenvalues; 
        }

        public double[] GetEigenValues()
        {
            return this.eigenvalues; 
        }
        public double[,] GetEigenVectors()
        {
            return this.eigenVector; 
        }
        public void SetEViolatingVector(double[] violatingvector)
        {
            this.violatingVector = violatingvector; 
        }

        public double[] GetViolatingVector()
        {
            return this.violatingVector; 
        }
    }
}