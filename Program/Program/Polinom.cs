using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Program.Polinom;

namespace Program
{
    internal partial class Polinom
    {
        private List<double[]> Nodes;       //Узлы интерполяции
        private Spline[] Splines;           //Сплайны

        //Перечисления для обозначения индексов
        //Координаты узла интерполяции
        static readonly int Argument = 0,    
            Function = 1;
        //Индексы ячеек в тридиагональной матрице
        static readonly int Ai = 0,
                   Bi = 1,
                   Ci = 2,
                   Di = 3,
                   Fi = 3;
        //Идексы ячеек максимального отклонения 
        static readonly int XDev = 0, //X координата
            YPoly = 1,                //Y координата на полноме
            YFunct = 2,               //Y координата на функции
            Max = 3;                  //Макс. значение
        
        //КОНСТРУКТОР ЭЛЕМЕНТА
        public Polinom(String FILENAME)
        {
            System.IO.FileStream File = new System.IO.FileStream(FILENAME, System.IO.FileMode.OpenOrCreate);
            System.IO.StreamReader Stream = new System.IO.StreamReader(File);

            Nodes = new List<double[]>();
            char[] separator = { ' ', '\t' };
            while(!Stream.EndOfStream)
            {
                String line = Stream.ReadLine();
                String[] dot = line.Replace('.', ',').Split(separator, StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<double> Node = dot.Select(X => Convert.ToDouble(X));
                Nodes.Add(Node.ToArray());
            }
            Stream.Close();
            File.Close();
        }
        /*  СОЗДАНИЕ ФОРМАТИРОВАННОГО ФАЙЛА УЗЛОВ ИНТЕРПОЛЯЦИИ 
            func - функция для вычисления значения Y в заданому аргументу
            FILENAME - Файл, содержащий значение координат X узлов интерполяции
         */
        public static String MakeFunctionFile(Func<double, double?> func, String FILENAME)
        {
            String FunctionNameFile = func.Method.Name;
            int index = FILENAME.LastIndexOf('\\');
            if (index != -1)
            {
                FunctionNameFile = $"FNI_{FILENAME.Substring(index + 1)}";
            }
            else
            {
                FunctionNameFile = $"FNI_{FILENAME}";
            }

            FileStream File = new FileStream(FILENAME, FileMode.OpenOrCreate);
            FileStream FunctionFile = new FileStream(FunctionNameFile, FileMode.Create);
            StreamReader ArgumentStream = new StreamReader(File);
            StreamWriter FunctionStream = new StreamWriter(FunctionFile);
            char[] separator = { ' ', '\t' };
            while (!ArgumentStream.EndOfStream)
            {
                String line = ArgumentStream.ReadLine();
                String[] dot = line.Replace('.', ',').Split(separator, StringSplitOptions.RemoveEmptyEntries);
                double X = Convert.ToDouble(dot[0]);
                FunctionStream.WriteLine($"{X} {func(X)}");
            }
            ArgumentStream.Close();
            FunctionStream.Close();
            File.Close();
            FunctionFile.Close();

            return FunctionNameFile;
        }

        /*  ЗАПОЛНЕНИЕ ТРИДИАГОНАЛЬНОЙ МАТРИЦЫ
            Матрица имеет оптимизированный вид:
                    | 0  B  C  |
                A = | Ai Bi Ci |
                    | .. .. .. |
                    | An Bn 0  |
         */
        public List<double[]> GetTrigiagonal()
        {

            List<double[]> Tridiagonal = new List<double[]>();  
            Func<int, double> U = (i) =>
            {
                double F = (Nodes[i + 2][Function] - Nodes[i + 1][Function])
                         / (Nodes[i + 2][Argument] - Nodes[i + 1][Argument]);
                F -= (Nodes[i + 1][Function] - Nodes[i][Function])
                  / (Nodes[i + 1][Argument] - Nodes[i][Argument]);
                return F ;
            };
            for (int i = 0, Size = Nodes.Count - 2; i < Size; i++)
            {
                double A, C, B = 2 * (Nodes[i + 2][Argument] - Nodes[i][Argument]);
                if (i == 0)
                    A = 0;
                else
                    A = (Nodes[i + 1][Argument] - Nodes[i][Argument]);
                if (i == Size - 1)
                    C = 0;
                else
                    C = Nodes[i + 2][Argument] - Nodes[i + 1][Argument];
                double F = 6 * U(i);
                Tridiagonal.Add(new double[4] { A, B, C, F });
            }

            return Tridiagonal;
        }

        /*  ИНТЕРПОЛЯЦИЯ СПЛАЙНАМИ 
            Испольуется оптимальная формула, через соотвествия индексов и
            равенство формул Xn и Bi+1
         */
        public void Interpolation()
        {
            List<double[]> Tridiagonal = GetTrigiagonal(); //Получение трёхдиагональной матрицы
            int Size = Tridiagonal.Count;                  //Получение размера матрицы
            if (Size != 0)                                 //Если матрица не пуста
            {
                //ПРЯМОЙ ХОД: НАХОЖДЕНИЕ ПРОГОНОЧНЫХ КОЭФФИЦИЕНТОВ 
                //Получение начальных прогоночных коэффициентов
                double[] Alpha = new double[Size - 1],         //Альфа: меньше на 1, т.к. соотвествующий элемент имеет лог.инд. i+1
                    Beta = new double[Size],                   //Бетта: по размеру матрицы. Будет содержать в себе Сi
                    MatrixLine = Tridiagonal[0];               //Строка матрицы
                Alpha[0] = -MatrixLine[Ci] / MatrixLine[Bi];   //Начальные коэффициенты
                Beta[0] = MatrixLine[Fi] / MatrixLine[Bi];

                for (int i = 1; i < Size; i++)
                {
                    MatrixLine = Tridiagonal[i];                                            //Следующая строка
                    double Denominator = MatrixLine[Ai] * Alpha[i - 1] + MatrixLine[Bi];    //Знаменатель дроби
                    if (i < Size - 1)                                                       //Лишний Альфа, который е будет нигде использоваться
                        Alpha[i] = -MatrixLine[Ci] / Denominator;
                    Beta[i] = (MatrixLine[Fi] - MatrixLine[Ai] * Beta[i - 1]) / Denominator;    
                }
                //ОБРАТНЫЙ ХОД: НАХОЖДЕНИЕ НЕИЗВЕСТНЫХ
                //Ие
                for (int i = Size - 2; i >= 0; i--)
                    Beta[i] += Beta[i + 1] * Alpha[i];
                double[] C = new double[Nodes.Count];                               //Создание массива Сi с размером по количеству узлов
                Beta.CopyTo(C, 1);                                                  //Копирование Сi значений [1..n-1], где C0 и Ci = 0

                //СОСТАВЛЕНИЕ СПЛАЙНОВ
                Splines = new Spline[Size + 1];
                for (int i = 1; i < Size + 2; i++)
                {
                    double[] Ratios = new double[4];                                //Передача коэффициентов Ai,Bi,Ci,Di
                    double Hi = Nodes[i][Argument] - Nodes[i - 1][Argument],
                        FDiff = Nodes[i][Function] - Nodes[i - 1][Function];
                    
                    Ratios[Ai] = Nodes[i][Function];
                    Ratios[Ci] = C[i];
                    Ratios[Di] = (C[i] - C[i - 1]) / Hi;
                    Ratios[Bi] = Hi*C[i]/3 + C[i-1]*Hi/6 + FDiff/Hi;
                    Splines[i - 1] = new Spline(Ratios, Nodes[i][Argument], Nodes[i - 1][Argument]);
                }
            }
        }

        //ВЫСЧИТЫВАНИЕ ЗНАЧЕНИЕ СПЛАЙНА В ТОЧКЕ
        public double YPolinom(double X)
        {
            //Выход за пределы сплайнов
            if (X >= Splines[0].GetFunctionPlot().XMin
                || X <= Splines[Splines.Length - 1].GetFunctionPlot().XMax)
            {
                //Поиск соотвествующего сплайна
                foreach (var spline in Splines)
                {
                    FunctionPlot fucntion = spline.GetFunctionPlot();
                    if (X >= fucntion.XMin && X <= fucntion.XMax)
                        return spline.Y(X);                                 //Возврат значения сплайна в точке
                }
            }
            return double.NaN;
        }

        //МАКСИМАЛЬНОЕ ОТКЛОНЕНИЕ СРЕДИ ОТКЛОНЕНИЙ
        public ScottPlot.Plottable.ScatterPlot MaxDevuation(Func<double, double?> func, double step)
        {
            double[][] SplinesDeviation = new double[Splines.Length][];
            double MaxValue = 0;
            int MaxIndex = 0;
            //ПОИСК СПЛАЙНА С МАКСИМАЛЬНЫМ ОТКЛОНЕНИЕМ
            for (int i = 0, Size = Splines.Length; i < Size; i++)
            {
                SplinesDeviation[i] = Splines[i].FindDeviation(func, step);
                if (SplinesDeviation[i][Max] > MaxValue)
                {
                    MaxValue = SplinesDeviation[i][Max];
                    MaxIndex = i;
                }
            }
            //ПОСТРОЕНИЕ ОТРЕЗКА, ИЗОБРАЖАЮЩЕГО ОТКЛОНЕНИЕ
            double[] x = new double[] { SplinesDeviation[MaxIndex][XDev], SplinesDeviation[MaxIndex][XDev] };
            double[] y = new double[] { SplinesDeviation[MaxIndex][YFunct], SplinesDeviation[MaxIndex][YPoly] };
            ScatterPlot scatterPlot = new ScatterPlot(x, y);
            scatterPlot.Label = Convert.ToString(MaxValue);
            scatterPlot.Color = Color.LightSteelBlue;
            return scatterPlot;
        }

        //ПЕРЕДАЧА СПЛАЙНОВ В ФОРМУ
        public void EnterPlotForm(ScottPlot.FormsPlot formsPlot)
        {
            foreach (var spline in Splines)
            {
                formsPlot.Plot.Add(spline.GetFunctionPlot());
                foreach (var node in spline.GetMarkerPlots())
                {
                    formsPlot.Plot.Add(node);
                }
            }
            formsPlot.Refresh();
        }
    }
}
