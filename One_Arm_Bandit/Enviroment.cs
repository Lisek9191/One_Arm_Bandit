using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

namespace One_Arm_Bandit
{
    public class Enviroment
    {
        List<Parameter_of_Machine> param = new List<Parameter_of_Machine>();

        /// <summary>
        /// Dodaje maszyny z różnymi prawdopobieństwami wygranej
        /// </summary>
        /// <param name="num"></param>
        public void Add_Machine(int num)
        {
            for (int i = 0; i < num; i++)
            {
                param.Add(new Parameter_of_Machine());
            }
        }

        /// <summary>
        /// Sprawdza, która maszyna jest najlepsza
        /// </summary>
        /// <param name="df"></param>
        public void Game(Matrix<double> df)
        {
            int N =  df.RowCount; 
            int d = df.ColumnCount;
            for (int i = 0; i < N; i++)
            {
                int selected = 0;
                double maxRandom = 0;
                for (int j = 0; j < d; j++)
                {
                    var gamma = new Gamma(param[j]._nPosReward, param[j]._nNegReward);
                    double num_sample = gamma.Sample();
                    if (num_sample > maxRandom)
                    {
                        maxRandom = num_sample;
                        selected = j;
                    }
                }

                if (df[i, selected] == 1)
                {
                    param[selected].Add_Pos();
                }
                else
                {
                    param[selected].Add_Neg();
                }

            }

            GetStatistic();
        }


        /// <summary>
        /// Wyświetla statystyki maszyn
        /// </summary>
        public void GetStatistic()
        {
            int num = 0;
            foreach (var p in param)
            {
                num++;
                Console.WriteLine($"Maszyna numer {num} została wybrana {p.Statistic()} razy");
            }
        }
    }
}
