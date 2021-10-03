using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_Hackathon.Controllers
{
    public class GMT
    {
        public static double Convert_GMT_to_Efficacy(double gmt)
        {
            // double person_eff=0;
            double Threshold_30 = 0.3138;
            double Threshold_50 = 0.7442;
            double Threshold_70 = 2.3632;

            if (gmt <= 0)
            {
                Console.WriteLine("T0");
                return 0;
            }

            if (gmt < Threshold_30)
            {
                Console.WriteLine("T1");
                double a = 88.20654544;
                double b = -331.34874918;
                double c = 1636.20965312;

                return My_Log(gmt, a, b, c);
            }
            else if (gmt < Threshold_50)
            {
                Console.WriteLine("T2");
                double a = 84.82325081;
                double b = -149.59361144;
                double c = 783.64198275;

                return My_Log(gmt, a, b, c);
            }
            else if (gmt < Threshold_70)
            {
                Console.WriteLine("T3");
                double L = 3.22451678 * Math.Pow(10, 05);
                double x0 = -7.54057041;
                double k = 1.19762785;
                double b = -3.22356833 * Math.Pow(10, 05);

                return My_Sigmoid(gmt, L, x0, k, b);
            }
            else
            {
                Console.WriteLine("T4");
                double L = 2.79587140 * Math.Pow(10, 05);
                double x0 = -2.40531155 * Math.Pow(10, 1);
                double k = 4.08057039 * Math.Pow(10, -1);
                double b = -2.79488387 * Math.Pow(10, 05);

                return My_Sigmoid(gmt, L, x0, k, b);
            }
        }

        static private double My_Log(double x, double a, double b, double c)
        {
            return a + b * Math.Log(x) + c * (Math.Log(x, 100));
        }

        static private double My_Sigmoid(double x, double L, double x0, double k, double b)
        {

            return L / (1 + Math.Exp(-k * (x - x0))) + b;
        }
    }
}
