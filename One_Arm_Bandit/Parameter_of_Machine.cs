using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_Arm_Bandit
{
    public class Parameter_of_Machine
    {
        public int _nPosReward = 1;
        public int _nNegReward = 1;

        public void Add_Pos()
        { 
            _nPosReward++;
        }

        public void Add_Neg()
        {
            _nNegReward++;
        }

        public int Statistic()
        {
            return _nPosReward + _nNegReward;
        }


    }

    
}
