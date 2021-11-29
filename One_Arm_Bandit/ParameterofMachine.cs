using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_Arm_Bandit
{
    public class ParameterofMachine
    {
        public int _nPosReward = 1;
        public int _nNegReward = 1;

        /// <summary>
        /// Dodaje 1 do liczby sukcesów
        /// </summary>
        public void Add_Pos()
        { 
            _nPosReward++;
        }

        /// <summary>
        /// Dodaje jeden do liczby porażek
        /// </summary>
        public void Add_Neg()
        {
            _nNegReward++;
        }


        /// <summary>
        /// Zwraca ile razy maszyna została wybrana
        /// </summary>
        /// <returns></returns>
        public int Statistic()
        {
            return _nPosReward + _nNegReward;
        }


    }

    
}
