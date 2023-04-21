using ScottPlot.Plottable;
using System;
using System.Drawing;

namespace Program
{
    internal partial class Polinom
    {
        public class Spline
        {
            double A,B,C,D;                                 //Коэффициенты 
            ScottPlot.Plottable.FunctionPlot functionPlot;  //Функция полинома
            ScottPlot.Plottable.MarkerPlot[] NodesSpline;   //точки интерполяции

            //КОНСТРУКТОР СПЛАЙНА
            public Spline(double[] Ratios, double Xmax, double Xmin)
            {
                //ПАРАМЕТРЫ ФУНКЦИИ СПЛАЙНА
                A = Ratios[Ai]; 
                B = Ratios[Bi]; 
                C = Ratios[Ci]; 
                D = Ratios[Di];
                //ФУНКЦИЯ СПЛАЙНА
                Func<double, double?> polinom = (X) =>
                {
                    double Hi = X - Xmax;
                    double y = A + (B * Hi) + (C * Math.Pow(Hi, 2) / 2) + (D * Math.Pow(Hi, 3) / 6);
                    return y;
                };
                //НАСТРОЙКА ОТОБРАЖЕНИЯ УЗЛОВ ИНТЕРПОЛЯЦИИ
                NodesSpline = new MarkerPlot[2] { new MarkerPlot(), new MarkerPlot() };
                NodesSpline[0].X = Xmin;
                NodesSpline[1].X = Xmax;
                foreach( var Node in NodesSpline)
                {
                    Node.Y = Convert.ToDouble(polinom(Node.X));
                    Node.Color = Color.Red;
                    Node.MarkerSize = 6;
                }
                //НАСТРОЙКА ОТОБРАЖЕНИЯ СПЛАЙНА
                functionPlot = new FunctionPlot(polinom);
                functionPlot.XMax = Xmax;
                functionPlot.XMin = Xmin;
                functionPlot.Color = Color.DarkOrange;
                functionPlot.LineWidth = 2;
            }

            //ВЫЧИСЛЕНИЕ ФУНКЦИИ
            public double Y(double X)
            {
                return Convert.ToDouble(functionPlot.Function(X));
            }

            //ВЫЧИСЛЕНИЕ МАКСИМАЛЬНОГО ОТКЛОНЕНИЯ
            public double[] FindDeviation(Func<double, double?> func, double step)
            {
                double [] Deviation = new double[4];
                Deviation[Max] = 0;
                for (double X = functionPlot.XMin, Size = functionPlot.XMax; X < Size; X += step)
                {
                    double YPolinom = Convert.ToDouble(functionPlot.Function(X)); 
                    double YFunction = Convert.ToDouble(func(X));
                    double Deviat = Math.Abs(YPolinom - YFunction);
                    if (Deviat > Deviation[Max])
                    {
                        Deviation[YPoly] = YPolinom;
                        Deviation[YFunct] = YFunction;
                        Deviation[XDev] = X;
                        Deviation[Max] = Deviat;
                    }
                }
                return Deviation;
            }
            //ГЕТЕРЫ ЗНАЧЕНИЕ
            //ГЕТЕР ФУНКЦИИ ПОЛИНОМА 
            public FunctionPlot GetFunctionPlot()
            {
                return functionPlot;
            }
            //ГЕТЕР УЗЛОВ ИНТЕРПОЛЯЦИИ
            public MarkerPlot[] GetMarkerPlots()
            {
                return NodesSpline;
            }
        }

    }
}
