using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace SortingVisualizer
{

    class SortingAlgorithms
    {
        public static void BubbleSort(int[] arr)
        {
            int temp;
            bool flag = true;
            int cursor = 1;
            while (flag)
            {
                //**Color ALL Red
                flag = false;
                for (int i = 0; i < arr.Length - cursor; i++)
                {                  
                    Program.mainForm.recolor(i, Color.Blue);
                    Program.mainForm.recolor(i+1, Color.Blue);
                    if(arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        Program.mainForm.redrawPoint(i, arr[i]);                      
                        Program.mainForm.redrawPoint(i+1, arr[i+1]);
                        flag = true;
                    }
                    Program.mainForm.recolor(i, Color.Red);
                    Program.mainForm.recolor(i+1, Color.Red);
                }
                Program.mainForm.recolor(arr.Length-cursor, Color.Green);
                cursor++;
            }
            Program.mainForm.completed();
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i + 1; j > 0;j--)
                {
                    Program.mainForm.recolor(j, Color.Blue);
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        Program.mainForm.recolor(j-1,Color.Blue);
                        Program.mainForm.recolor(j, Color.Green);
                        Program.mainForm.redrawPoint(j - 1, arr[j - 1]);
                        Program.mainForm.redrawPoint( j, arr[j]);
                    }
                    else {
                        Program.mainForm.recolor(j, Color.Green);
                        Program.mainForm.recolor(j - 1, Color.Green);
                        break;
                    }
                    Program.mainForm.recolor(j - 1, Color.Green);
                }
                Program.mainForm.recolor(i, Color.Green);
            }
            Program.mainForm.completed();
        }

        public static void SelectionSort(int[] arr)
        {
            int minindex = 0;
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                minindex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    Program.mainForm.recolor(j, Color.Blue);
                    if (arr[j] < arr[minindex])
                    {
                        Program.mainForm.recolor(minindex, Color.Green);
                        Program.mainForm.recolor(minindex, Color.Red);
                        minindex = j;
                    }else{
                        Program.mainForm.recolor(minindex, Color.Green);
                        Program.mainForm.recolor(j, Color.Red);
                    }
                }
                temp = arr[i];
                arr[i] = arr[minindex];
                arr[minindex] = temp;;
                Program.mainForm.recolor(minindex, Color.Red);
                Program.mainForm.redrawPoint(minindex, arr[minindex]);
                Program.mainForm.recolor(i, Color.Green);
                Program.mainForm.recolor(minindex, Color.Green);
                Program.mainForm.redrawPoint(i, arr[i]);                
            }
            Program.mainForm.completed();
        }

        public static void MergeSort(int[] arr,int f,int l)
        {
            if (arr.Length <= 1) { return; }
            if (f < l)
            {
                int m = (f + l) / 2;
                MergeSort(arr, f, m);
                MergeSort(arr, m + 1, l);
                Merge(arr, f, m, l);
                if (arr.Length == l + 1 & f==0)
                {
                    Program.mainForm.completed();
                }
            }           
        }
        public static void Merge(int[] arr, int f, int m, int l)
        {
            int sizetemp1 = m - f + 1;
            int sizetemp2 = l-m;
            int[] temp1 = new int[sizetemp1];
            int[] temp2 = new int[sizetemp2];
            
            int cursor1 = 0;
            int cursor2 = 0;
            for (int i = 0; i < sizetemp1; i++)
            {
                temp1[i] = arr[f + i];
            }
            for (int i = 0; i < sizetemp2; i++)
            {
                temp2[i] = arr[m + 1 + i];
            }

            for (int i = f; i <= l; i++)
            {
                if (cursor1 >= sizetemp1)
                {
                    arr[i] = temp2[cursor2];
                    cursor2++;
                }
                else if (cursor2 >= sizetemp2)
                {
                    arr[i] = temp1[cursor1];
                    cursor1++;
                }
                else if (temp1[cursor1] < temp2[cursor2])
                {
                    arr[i] = temp1[cursor1];
                    cursor1++;
                }
                else if (temp1[cursor1] > temp2[cursor2])
                {
                    arr[i] = temp2[cursor2];
                    cursor2++;
                }
                Program.mainForm.recolor(i, Color.Blue);
                Program.mainForm.redrawPoint(i, arr[i]);
            }          
        }

        
        public static void QuickSort(int[] arr,int first,int last,int pivot)
        {
            if(first<last)
            {                 
                  pivot=Partition(arr,first,last,pivot);
                  QuickSort(arr,first,pivot-1, pivot - 1);
                  QuickSort(arr,pivot+1,last, last);   
            }
            if (arr.Length == last + 1 & first == 0)
            {
                Program.mainForm.completed();
            }
        }
 
        public static int Partition(int[] arr,int first,int last,int pivot)
        {
            int[] temp= new int[last-first+1];
            int cursor1=0;
            int cursor2=last-first;
            int maincursor=first;
            while(cursor1<cursor2)
            {
                if(arr[maincursor]<arr[pivot])
                {
                    temp[cursor1]=arr[maincursor];
                    cursor1++;
                }else if(arr[maincursor]>arr[pivot])
                {
                   temp[cursor2]=arr[maincursor];
                   cursor2--;
               }
                maincursor++;
            }
            temp[cursor1]=arr[pivot];
            pivot=cursor1;
            for(int i=0;i<last-first+1;i++)
            {
                arr[first+i]=temp[i];
                if (i == pivot)
                {
                    Program.mainForm.recolor(first + i, Color.Green);
                }
                else { Program.mainForm.recolor(first + i, Color.Blue); }
                Program.mainForm.redrawPoint(first+i, arr[first+i]);
            }
            return first+pivot;
        }

        static void pause()
        {
            Thread.Sleep(1);
        }
    }
}
