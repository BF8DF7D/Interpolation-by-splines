using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Program.Polinom;

namespace Program
{
    public partial class FormSpline : Form
    {
        Polinom polinom;
        Func<double, double?> func = (X) => Math.Abs(X);
        public FormSpline()
        {
            InitializeComponent();
        }

        private void ChooseFile(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                formsPlot1.Plot.Clear();

                DeviationBox.Text = "";
                polinom = new Polinom(OpenFile.FileName);
                polinom.Interpolation();
                polinom.EnterPlotForm(formsPlot1);
                formsPlot1.Refresh();
            }
        }
        private void FunctionChoose(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                formsPlot1.Plot.Clear();
                
                formsPlot1.Plot.AddFunction(func, Color.Black, 2);
                polinom = new Polinom(Polinom.MakeFunctionFile(func, OpenFile.FileName));
                polinom.Interpolation();
                polinom.EnterPlotForm(formsPlot1);
                ScatterPlot Deviation = polinom.MaxDevuation(func, 0.01);
                DeviationBox.Text = Deviation.Label;
                formsPlot1.Plot.Add(Deviation);
                formsPlot1.Refresh();
            }
        }

        private void CalculateNodesSpline(object sender, EventArgs e)
        {
            NodesY.Text = Convert.ToString(polinom.YPolinom(Convert.ToDouble(NodesX.Text)));
        }

        private void RadioChecked(object sender, EventArgs e)
        {
            if (RadioABS.Checked == true)
            {
                func = (x) => Math.Abs(x);
            } 
            else if (RadioSIN.Checked == true)
            {
                func = (x) => Math.Sin(x);
            }
            else if (RadioEXP.Checked == true)
            {
                func = (x) => Math.Exp(-x);
            }
        }
    }
}

/*
//            Polinom polinom = new Polinom(Polinom.MakeFunctionFile(ABS, "RM14384388_4.txt"));
//           Polinom.Spline[] splines = polinom.Interpolation();
//            polinom.EnterPlotForm(formsPlot1, splines);
//            formsPlot1.Plot.AddFunction(ABS, Color.Orange, 2);


            foreach (var spline in splines)
            {
                formsPlot1.Plot.Add(spline.GetFunctionPlot());
                foreach (var node in spline.GetMarkerPlots())
                {
                    formsPlot1.Plot.Add(node);
                }
            }
                       
                    Func<double, double?> parabola = (x) => x * x;
                    double[] dataX = new double[] { 1, 2, 3, 4, 5 };
                    double[] dataY = new double[] { 1, 4, 9, 16, 25 };
                    formsPlot1.Plot.AddPoint(1, 2, Color.Red);
                    formsPlot1.Plot.AddPoint(4, 2, Color.Red);
                    FunctionPlot function = new FunctionPlot(parabola);
                    function.XMin = 0;
                    function.XMax = 5;
                    function.LineWidth = 2;

                    VLine vLine = new VLine();
                    vLine.X = 2;
                    vLine.DragEnabled = true;
                    vLine.LineColor = Color.Red;
                    formsPlot1.Plot.Add(vLine);

                    formsPlot1.Plot.Add(function);
                    formsPlot1.Plot.AddScatter(dataX, dataY);
        
            //formsPlot1.Plot.Frameless(); function.XMin, function.XMax, parabola(function.XMin), parabola(function.XMax)
*/
