using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Net;
using System.Net.Http;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;
using One_Arm_Bandit;

class TestClass
{
    static void Main(string[] args)
    {

    

        CreateData data = new CreateData();
        List<double> conversionRates = new List<double>() { 0.15, 0.04, 0.13, 0.11, 0.05 };
        int N = 100000000;
        foreach (var cr in conversionRates)
        {
            data.Add_Rate(cr);
        }

        var df = data.Generated_of_Data(N);
        Enviroment enviroment = new Enviroment();
        enviroment.Add_Machine(5);
        enviroment.Game(df);





    }

}