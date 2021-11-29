using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

namespace One_Arm_Bandit
{
    public class CreateData
    {

        public List<double> conversion_rates = new List<double>();

        public void Add_Rate(double rate)
        { 
            conversion_rates.Add(rate);
        }
        

        public Matrix<double> Generated_of_Data(int row)
        {
            int d = conversion_rates.Count();
            var M = Matrix<double>.Build;
            var m = M.Random(row, d, new ContinuousUniform(0.0, 1.0));

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    if (m[i, j] < conversion_rates[j])
                    {
                        m[i, j] = 1;
                    }
                    else
                    {
                        m[i, j] = 0;
                    }
                }
            }

            return m;
        }
    }
}
