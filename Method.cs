using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_for_optimal_selection_of_terrains
{
    class Method
    {
        static int terrainCount;

        static int yearCount;

        static int capital;

        static double maxEfficiency;

        static int sumCost;

        static double[,] temps;

        static double[,] radiations;

        static double[] tempEfficiency;

        static double[] gravityArr;

        static double[] radiationEfficiency;

        static double[] efficiency;

        static int[] cost;

        static  int[] index ;

        static List<string> boughtTerrains = new List<string>();

        static public void form1CreateArray(int a, int b, int c)
        {
            terrainCount = a;
            yearCount = b;
            capital = c;
            temps = new double[terrainCount, yearCount];
            radiations = new double[terrainCount, yearCount];
            tempEfficiency = new double[terrainCount];
            radiationEfficiency = new double[terrainCount];
            efficiency = new double[terrainCount];
            cost = new int[terrainCount];
            index = new int[terrainCount];            
            for (int i = 0; i < temps.GetLength(0); i++)
            {
                for (int j = 0; j < temps.GetLength(1); j++)
                {
                    temps[i, j] = Double.MinValue;
                    radiations[i, j] = Double.MinValue;
                }
            }
            for (int i = 0; i < cost.Length; i++)
            {
                cost[i] = int.MinValue;
            }
            gravityArr = gravity(yearCount);
        }
        static public int terrainNumber()
        {
            return terrainCount;
        }
        static public int yearNumber()
        {
            return yearCount;
        }
        static public void form2Add(int a, int b)
        {
            cost[a-1] = b;
            MessageBox.Show("Ready.");
        }
        static public bool form2Check()
        {
            bool a = true;
            for (int i = 0; i < cost.Length; i++)
            {
                if (cost[i] == int.MinValue)
                {
                    a = false;
                    int p = i + 1;
                    MessageBox.Show("There isnt set any price for a terrain № " + p + ".");
                    break;
                }
            }
            return a;
        }
        static public void form3Add(int a, int b, double c)
        {
            radiations[a-1, b-1] = c;
            MessageBox.Show("Ready.");
        }
        static public bool form3Check()
        {
            bool a = true;
            for (int i = 0; i < radiations.GetLength(0); i++)
            {
                for (int j = 0; j < radiations.GetLength(1); j++)
                {
                    if (radiations[i,j] == Double.MinValue)
                    {
                        a = false;
                        int p = i + 1;
                        int d = j + 1;
                        MessageBox.Show("You didnt enter a value for solar radiation for terrain №" +p+" and year №"+d+".");
                        break;
                    }
                }

            }
            return a;
        }
        static public void form4Add(int a, int b, double c)
        {
            temps[a - 1, b - 1] = c;
            MessageBox.Show("Ready.");
        }
        static public bool form4Check()
        {
            bool a = true;
            for (int i = 0; i < radiations.GetLength(0); i++)
            {
                for (int j = 0; j < radiations.GetLength(1); j++)
                {
                    if (temps[i, j] == Double.MinValue)
                    {
                        a = false;
                        int p = i + 1;
                        int d = j + 1;
                        MessageBox.Show("You didnt enter a value for temperature for terrain №" + p + " and year №" + d + ".");
                        break;
                    }
                }

            }
            return a;
        }
        static public void form5Calculate()
        {
            tempEfficiency = matrixMultiplication(temps, gravityArr);
            radiationEfficiency = matrixMultiplication(radiations, gravityArr);
            efficiency = averageVector(tempEfficiency, radiationEfficiency);
            knapSack(capital, cost, efficiency, index);
            sumCost = sumCosts(cost, index);
        }
        static public string getSumCost()
        {
            return Convert.ToString(sumCost);
        }
        static public string getMaxEfficiency()
        {
            return Convert.ToString(maxEfficiency);
        }
        static public List<string> getBoughtTerrains()
        {
            return boughtTerrains;
        }
        static public int getBoughtTerrainsLend()
        {
            return boughtTerrains.Count();
        }
        static public double[] gravity(int count)
        {
            double sum = 0;

            double[] gravityArray = new double[count];

            for (int i = 1; i <= count; i++)
            {
                sum += i;
            }

            for (int i = 1; i <= count; i++)
            {
                gravityArray[i - 1] = i / sum;
            }

            return gravityArray;
        }
        static public double[] matrixMultiplication(double[,] a, double[] b)
        {
            double[] result = new double[a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    result[i] += a[i, j] * b[j];
                }
            }

            return result;
        }
        static public double[] averageVector(double[] a, double[] b)
        {
            double[] result = new double[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                double c= a[i] + b[i];
                result[i] = c / 2;
            }

            return result;
        }
        static public void knapSack(int capital, int[] cost, double[] efficienc, int[] index)
        {
            double[] effic = new double[efficienc.Length];
            long[] efficiency = new long[efficienc.Length];
            for (int l = 0; l < efficienc.Length; l++)
            {
                effic[l] = efficienc[l];
            }
            for (int f = 0; f < efficienc.Length; f++)
            {
                double prop = effic[f];
                effic[f] = prop * 100000;
                if (effic[f] < 0)
                {
                    effic[f] = 0;
                }
            }
            for (int f = 0; f < efficienc.Length; f++)
            {
                efficiency[f] = Convert.ToInt64(effic[f]);
            }
            int n = efficiency.Length;

            int i;

            int w;

            for (int p = 0; p < terrainCount; p++)
            {
                index[p] = 0;
            }
            long[,] K = new long[n + 1, capital + 1];

            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= capital; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (cost[i - 1] <= w)
                    {
                        K[i, w] = Math.Max(efficiency[i - 1] + K[i - 1, w - cost[i - 1]], K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }

            long res = K[n, capital];

            w = capital;

            for (i = n; i > 0 && res > 0; i--)
            {
                if (res == K[i - 1, w])
                    continue;
                else
                {
                    index[i - 1] = 1;
                    res = res - efficiency[i - 1];
                    w = w - cost[i - 1];
                }
            }
        }
        static public int sumCosts(int[] cost, int[] index)
        {
            int sum = 0;
            for (int i = 0; i < cost.Length; i++)
            {
                if (index[i]==1)
                {
                    int p = i + 1;
                    int d = cost[i];
                    double f = efficiency[i];
                    sum += cost[i];
                    maxEfficiency += efficiency[i];
                    boughtTerrains.Add("Terrain №"+ p +" for a price "+ d +".");
                }
            }
            return sum;
        }
    }
}
