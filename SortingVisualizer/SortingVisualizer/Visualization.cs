using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace SortingVisualizer
{
    public class Visualization
    {
        internal static void redrawPoint(Chart canvas, int i, int newval)
        {
            
            canvas.Series[0].Points.ElementAt(i).SetValueY(newval);
            canvas.Refresh();
        }

        internal static void redrawSeries(Chart canvas, int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                canvas.Series[0].Points.ElementAt(i).SetValueY(arr[i]);
            }
            canvas.Refresh();
        }
    }
}
