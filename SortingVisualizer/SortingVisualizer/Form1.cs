using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SortingVisualizer
{
    
    public partial class Form1 : Form
    {
        int[] mainlist;

        public Form1()
        {
            InitializeComponent();
            int maxnum = 100;
            mainlist = new int[maxnum];
            for (int i = 1; i <= maxnum; i++)
            {
                mainlist[i-1]=i;
            }
            shuffleArray(mainlist);
            for (int i = 0; i < mainlist.Length; i++)
            {
                mainChart.Series[0].Points.Add(mainlist[i]);
            }
            mainChart.ChartAreas[0].AxisY.Maximum = maxnum;

            listSortAlgos.Items.Add("Insertion");
            listSortAlgos.Items.Add("Selection");
            listSortAlgos.Items.Add("Bubble");
            listSortAlgos.Items.Add("Merge");
            listSortAlgos.Items.Add("Quick");
        }

        static void shuffleArray(int[] arr)
        {
            Random rand = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int index = rand.Next(i);
                int a = arr[index];
                arr[index] = arr[i];
                arr[i] = a;
            }
        }


        Thread sortThread;

       private void InitSortbtn_Click(object sender, EventArgs e)
        {
            disablebtns();
            for (int i = 0; i < mainChart.Series[0].Points.Count; i++)
            {
                mainChart.Series[0].Points.ElementAt(i).Color = Color.Red;
            }
            mainChart.Refresh();
            
            switch (listSortAlgos.SelectedItem) {
                case "Insertion":
                    //SortingAlgorithms.InsertionSort( mainlist);
                    sortThread = new Thread(() => SortingAlgorithms.InsertionSort(mainlist));
                    sortThread.Start();
                    break;
                case "Selection":
                    sortThread = new Thread(() => SortingAlgorithms.SelectionSort(mainlist));
                    sortThread.Start();
                    break;
                case "Bubble":
                    sortThread = new Thread(() => SortingAlgorithms.BubbleSort(mainlist));
                    sortThread.Start();
                    break;
                case "Merge":
                    sortThread = new Thread(() => SortingAlgorithms.MergeSort(mainlist,0,mainlist.Length-1));
                    sortThread.Start();
                    break;
                case "Quick":
                    sortThread = new Thread(() => SortingAlgorithms.QuickSort(mainlist, 0, mainlist.Length - 1, mainlist.Length - 1));
                    sortThread.Start();
                    break;

                default:
                    MessageBox.Show("Please select a sort algorithm.");
                    break;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            reloadData(Convert.ToInt32(txtSamples.Text));
        }

        private void reloadData(int volume)
        {
            mainChart.Series[0].Points.Clear();
            mainlist = new int[volume];
            for (int i = 1; i <= volume; i++)
            {
                mainlist[i - 1] = i;
            }
            shuffleArray(mainlist);
            for (int i = 0; i < mainlist.Length; i++)
            {
                mainChart.Series[0].Points.Add(mainlist[i]);
            }
            mainChart.ChartAreas[0].AxisY.Maximum = volume;
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            txtSamples.Text = barSamples.Value.ToString();
        }

        private void TxtSamples_TextChanged(object sender, EventArgs e)
        {
            try
            {
                barSamples.Value = Convert.ToInt32(txtSamples.Text);
            }
            catch (FormatException) {
                barSamples.Value = 0;
            }
            catch (ArgumentOutOfRangeException) {
                barSamples.Value = 1000;
            }
        }

        private delegate void recolorDelegate(int i, Color c);
        private delegate void redrawPointDelegate(int i, int newval);
        private delegate void refreshDelegate();
        private delegate void enableButton(System.Windows.Forms.Button btn);

        public void recolor(int i, Color c)
        {
            mainChart.Invoke(new recolorDelegate(color), i, c);
            mainChart.Invoke(new refreshDelegate(Refresh));
        }
        public void color(int i, Color c)
        {
            mainChart.Series[0].Points.ElementAt(i).Color = c;
        }


        internal void redrawPoint(int i, int newval)
        {
            mainChart.Invoke(new redrawPointDelegate(drawPoint), i, newval);
            mainChart.Invoke(new refreshDelegate(Refresh));
        }

        internal void drawPoint(int i, int newval)
        {
            mainChart.Series[0].Points.ElementAt(i).SetValueY(newval);
        }
        internal void completed()
        {
            for (int i = 0; i < mainChart.Series[0].Points.Count; i++)
            {
                mainChart.Invoke(new recolorDelegate(color), i, Color.Green);
            }
            mainChart.Invoke(new refreshDelegate(Refresh));
            initSortbtn.Invoke(new refreshDelegate(enablebtns));
            btnLoad.Invoke(new refreshDelegate(enablebtns));
        }

        internal void enablebtns()
        {
            btnCancelSort.Enabled = false;
            initSortbtn.Enabled = true;
            btnLoad.Enabled = true;
        }
        internal void disablebtns()
        {
            btnCancelSort.Enabled = true;
            initSortbtn.Enabled = false;
            btnLoad.Enabled = false;
        }

        private void BtnCancelSort_Click(object sender, EventArgs e)
        {
            sortThread.Abort();
            enablebtns();

        }
    }
}
