using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;*/
using ScottPlot;

namespace CanCOMApplication
{
    public delegate void ValuesRefreshed();
    partial class Form2 : Form
    {
        public List<TrafficElementCanDataFrame> tecdflist;
        private static int DataToVisualizeCount = 50;
        private static int TimeLineLen = 300;
        uint lastid = 0;
        //PlotModel pm;

        System.Timers.Timer t;

        private ValueType selectedValueType = ValueType.ULONG;

        private enum ValueType
        {
            ULONG=0,
            SINGLE=1,
            DOUBLE=2
        }

        public Form2(List<TrafficElementCanDataFrame> _tecdflist)
        {
            tecdflist = _tecdflist;
            InitializeComponent();
            t = new System.Timers.Timer();
            t.Elapsed += T_Elapsed;
            t.AutoReset = true;
            t.Interval=100;
            ValueTypesCB.DataSource=Enum.GetValues(typeof(ValueType));
            ValueTypesCB.SelectedIndex = 0;
            ValueTypesCB.SelectedIndexChanged += ValueTypesCB_SelectedIndexChanged;
        }

        private void ValueTypesCB_SelectedIndexChanged(object? sender, EventArgs e)
        {
            selectedValueType = (ValueType)ValueTypesCB.SelectedItem;
        }

        private void T_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                refreshPlot();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*pm = new PlotModel
            {
                Title = "Trigonometric functions",
                Subtitle = "Example using the FunctionSeries",
                PlotType = PlotType.Cartesian,
                Background = OxyColors.White
            };*/

            /*pm.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
            pm.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.1, "cos(x)"));
            pm.Series.Add(new FunctionSeries(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 0.1, "cos(t),sin(t)"));
            plotView1.Model = pm;*/
            
        }

        private void addTimelineAxis()
        {
            
        }
        private void createPointsFromData()
        {
            formsPlot1.Plot.Clear();
            List<TrafficElementCanDataFrame> dataFramesCut;
            List<TrafficElementCanDataFrame> dataFramesFiltered = new List<TrafficElementCanDataFrame>();
            lastid = 0;
            if(uint.TryParse(IDfilterTB.Text,out lastid))
            {
                foreach (TrafficElementCanDataFrame tre in tecdflist)
                {
                    if (tre.canDataFrame.ID == lastid)
                        dataFramesFiltered.Add(tre);
                }
                if (dataFramesFiltered.Count < DataToVisualizeCount)
                {
                    dataFramesCut = dataFramesFiltered.GetRange(0, dataFramesFiltered.Count);
                }
                else
                {
                    dataFramesCut = dataFramesFiltered.GetRange(dataFramesFiltered.Count - DataToVisualizeCount, DataToVisualizeCount);
                }

                long range = dataFramesCut[dataFramesCut.Count - 1].unixTime - dataFramesCut[0].unixTime;

                var startDate = dataFramesCut[0].timeStampDateTime;
                var endDate = dataFramesCut[dataFramesCut.Count-1].timeStampDateTime;

                var minValue = startDate.ToOADate;
                var maxValue = endDate.ToOADate;
                
                List<string> lines = new List<string>();

                List<double> a = new List<double>();
                List<double> b = new List<double>();
                
                for (int i = 0; i < dataFramesCut.Count; i++)
                {
                    a.Add(dataFramesCut[i].timeStampDateTime.ToOADate());
                    switch(selectedValueType)
                    {
                        case ValueType.ULONG: b.Add((double)dataFramesCut[i].canDataFrame.DataL);break;
                        case ValueType.SINGLE: b.Add((double)BitConverter.ToSingle(dataFramesCut[i].canDataFrame.DataB,0));break;
                        case ValueType.DOUBLE: b.Add(BitConverter.ToDouble(dataFramesCut[i].canDataFrame.DataB, 0)); break;
                    }
                }
                var splt = new ScottPlot.Plottable.ScatterPlot(a.ToArray(), b.ToArray());
                formsPlot1.Plot.Add(splt);
                formsPlot1.Plot.XAxis.DateTimeFormat(true);
                formsPlot1.Refresh();
            }
        }

        private void refreshPlot()
        {
            formsPlot1.Plot.Clear();
            List<TrafficElementCanDataFrame> dataFramesCut;
            List<TrafficElementCanDataFrame> dataFramesFiltered = new List<TrafficElementCanDataFrame>();
            foreach (TrafficElementCanDataFrame tre in tecdflist)
            {
                if (tre.canDataFrame.ID == lastid)
                    dataFramesFiltered.Add(tre);
            }
            if (dataFramesFiltered.Count < DataToVisualizeCount)
            {
                dataFramesCut = dataFramesFiltered.GetRange(0, dataFramesFiltered.Count);
            }
            else
            {
                dataFramesCut = dataFramesFiltered.GetRange(dataFramesFiltered.Count - DataToVisualizeCount, DataToVisualizeCount);
            }

            long range = dataFramesCut[dataFramesCut.Count - 1].unixTime - dataFramesCut[0].unixTime;

            var startDate = dataFramesCut[0].timeStampDateTime;
            var endDate = dataFramesCut[dataFramesCut.Count - 1].timeStampDateTime;

            var minValue = startDate.ToOADate;
            var maxValue = endDate.ToOADate;

            
            List<string> lines = new List<string>();

            List<double> a = new List<double>();
            List<double> b = new List<double>();
            
            for (int i = 0; i < dataFramesCut.Count; i++)
            {
                a.Add(dataFramesCut[i].timeStampDateTime.ToOADate());
                switch (selectedValueType)
                {
                    case ValueType.ULONG: b.Add((double)dataFramesCut[i].canDataFrame.DataL); break;
                    case ValueType.SINGLE: b.Add((double)BitConverter.ToSingle(dataFramesCut[i].canDataFrame.DataB, 0)); break;
                    case ValueType.DOUBLE: b.Add(BitConverter.ToDouble(dataFramesCut[i].canDataFrame.DataB, 0)); break;
                }

            }
            var splt = new ScottPlot.Plottable.ScatterPlot(a.ToArray(), b.ToArray());
            formsPlot1.Plot.Add(splt);
            formsPlot1.Plot.XAxis.DateTimeFormat(true);
            formsPlot1.Refresh();
        }

        private void applyFilterBT_Click(object sender, EventArgs e)
        {
            try
            {
                createPointsFromData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(AutoRefreshCB1.Checked)
            {
                t.Start();
            }
            else
            {
                t.Stop();
            }
        }
    }
}
