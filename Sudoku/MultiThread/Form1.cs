using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MultiThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int[,] sudokuOrj = new int[9,9];
        static int[,] matrisTh1 = new int[9, 9];
        static int[,] matrisTh2 = new int[9, 9];
        static int[,] matrisTh3 = new int[9, 9];
        static int[,] sonuc = new int[9, 9];
        static int[,] dizi = new int[9,9];
        static int[,] dizi5 = new int[3, 3];
        static int[,,] dizi2 = new int[9, 9, 9];
        static int temp;
        static bool thKontrol = false;
        OpenFileDialog file = new OpenFileDialog();
        static Thread thread1 = new Thread(cozum1);
        static Thread thread2 = new Thread(cozum2);
        static Thread thread3 = new Thread(cozum3);
        private void DosyaSec_Click(object sender, EventArgs e)
        {
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Filter = "Txt dosyası | *.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.Title = "Yüklenecek Sudokuyu Seçiniz";

            if (file.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string dosyaYolu = file.FileName;
            FileStream dosya = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(dosya);
            string sudoku = sr.ReadLine();
            int satir = 0, sutun = 0;
            while(sudoku !=null)
            {
                string karakter;
                for( int i = 0; i < 9 ; i++ )
                {
                    karakter = sudoku.Substring(i, 1);
                    if(karakter != "*")
                    {
                        sudokuOrj[satir, sutun] = Convert.ToInt32(sudoku.Substring(i, 1));
                    }
                    else
                    {
                        sudokuOrj[satir, sutun] = -1;
                    }
                    sutun++;
                    
                }
                sudoku = sr.ReadLine();
                sutun = 0;
                satir++;

            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudokuOrj[i, j] == -1)
                        listView1.Items.Add(" ");
                    else
                    listView1.Items.Add(Convert.ToString(sudokuOrj[i, j]));
                }

            }
            for (int x = 0;x<9;x++)
                for(int y=0;y<9;y++)
                {
                    matrisTh1[x, y] = sudokuOrj[x, y];
                    matrisTh2[x, y] = sudokuOrj[x, y];
                    matrisTh3[x, y] = sudokuOrj[x, y];
                }
            ekranaBas();
            Console.WriteLine("");
            Console.WriteLine("");
            thread1.Start();
            thread2.Start();
            thread3.Start();
            if (thread1.IsAlive==true )
            {
                thread2.Abort();
                thread3.Abort();
                Console.WriteLine("Thread 1 ");
                thKontrol = true;
                
                        
            }
            if (thread2.IsAlive==true )
            {
                thread1.Abort();
                thread3.Abort();
                Console.WriteLine("Thread 2 ");
                thKontrol = true;
            }
            if (thread3.IsAlive ==true)
            {
                thread1.Abort();
                thread2.Abort();
                Console.WriteLine("Thread 3 ");
                thKontrol = true;
            }
            if (thKontrol == true)
            {
                Form2 th1Form = new Form2(matrisTh1);
                Form3 th2Form = new Form3(matrisTh2);
                Form4 th3Form = new Form4(matrisTh3);

                th1Form.ShowDialog();
                th2Form.ShowDialog();
                th3Form.ShowDialog();
            }
        }

        static private void ekranaBas()
        {
            
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write("  "+sonuc[j, i]);
                }
                Console.WriteLine("");
            }
                
        }
        static private void cozum1()
        {
            for (int x = 0;x<9;x++)
                for (int y = 0; y < 9; y++)
                    for (int z = 0; z < 9; z++) 
                    {
                           dizi2[x, y, z] = matrisTh1[x,y];
                    }
            int kontrol = 0;

            while(kontrol!=81)

            {
                kontrol = 0;
                int sayi;
                int k, l, m;
                for (int h = 0; h < 9; h++)
                    for (int w = 0; w < 9; w++)
                        dizi[h, w] = 0;
                for(int a=0;a<9;a++)
                    for(int b = 0;b<9;b++)
                    {
                        int[] kume = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        int count = 0;
                        if (matrisTh1[a, b] == -1 && dizi[a, b] == 0)
                        {
                            k = a % 3;
                            l = b % 3;
                            m = a - k;
                            int t = b - l;
                            int p = t;
                            int n = m;
                            int[,] dizi5 = new int[3, 3];

                            for (int x = 1; x < 10; x++)
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh1[a, i];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh1[i, b];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }

                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {


                                        sayi = matrisTh1[m, t];

                                        switch (sayi)
                                        {
                                            case 1: kume[0] = -1; break;
                                            case 2: kume[1] = -1; break;
                                            case 3: kume[2] = -1; break;
                                            case 4: kume[3] = -1; break;
                                            case 5: kume[4] = -1; break;
                                            case 6: kume[5] = -1; break;
                                            case 7: kume[6] = -1; break;
                                            case 8: kume[7] = -1; break;
                                            case 9: kume[8] = -1; break;
                                        }
                                    }
                                }

                                int go = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        if (matrisTh1[m, t] == x)
                                            go++;

                                    }
                                }
                                if (go != 0)
                                    continue;
                                int satir = 0, sutun = 0;
                                for (int h = 0; h < 3; h++)
                                    for (int w = 0; w < 3; w++)
                                        dizi5[h, w] = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        dizi5[m % 3, t % 3] = matrisTh1[m, t];

                                    }
                                }
                                for (int y = a - a % 3; y < a - a % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == a) break;
                                        if (matrisTh1[y, z] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[y % 3, w] == -1)
                                                {
                                                    dizi5[y % 3, w] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                for (int y = b - b % 3; y < b - b % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == b) break;
                                        if (matrisTh1[z, y] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[w, y % 3] == -1)
                                                {
                                                    dizi5[w, y % 3] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                int sayici = 0;
                                for (int u = 0; u < 3; u++)
                                {
                                    for (int v = 0; v < 3; v++)
                                    {
                                        if (dizi5[u, v] == -1)
                                        {
                                            sayici++;
                                            satir = u; sutun = v;
                                        }
                                    }
                                }
                                if (sayici == 1)
                                {
                                    matrisTh1[a - a % 3 + satir, b - b % 3 + sutun] = x;
                                }


                                for (int i = 0; i < 9; i++)
                                {
                                    if (kume[i] != -1)
                                    {
                                        count++; temp = kume[i];
                                    }

                                }
                                if (count == 1)
                                {
                                    matrisTh1[a, b] = temp;
                                }
                                else continue;

                            }
                        
                        
                        }
                            

                    }

                for (int e=0;e<9;e++)

                {
                    for(int g=0;g<9;g++)
                    {
                        if (matrisTh1[e,g] != -1)
                        { kontrol++;}
                        else
                        {
                            kontrol = 0;
                        }
                            
                                }
                    if(kontrol==0) { kontrol = 0;}

                    
                }
                
            }
            Array.Clear(dizi, 0, 9);
            Array.Clear(dizi5, 0, 9);
            for (int satir = 0; satir < 9; satir++)
                for (int sutun = 0; sutun < 9; sutun++)
                    sonuc[satir, sutun] = matrisTh1[satir, sutun];
            Console.WriteLine("Thread1");
            ekranaBas();
            Console.WriteLine("");
        }
        static private void cozum2()
        {
            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    for (int z = 0; z < 9; z++)
                    {
                        dizi2[x, y, z] = matrisTh2[x, y];
                    }
            int kontrol = 0;

            while (kontrol != 81)

            {
                kontrol = 0;
                int sayi;
                int k, l, m;
                for (int h = 0; h < 9; h++)
                    for (int w = 0; w < 9; w++)
                        dizi[h, w] = 0;
                
                for (int a = 4; a < 9; a++)
                    for (int b = 0; b < 9; b++)
                    {
                        if (a == 4 && b < 4)
                            break;
                        int[] kume = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        int count = 0;
                        if (matrisTh2[a, b] == -1 && dizi[a, b] == 0)
                        {
                            k = a % 3;
                            l = b % 3;
                            m = a - k;
                            int t = b - l;
                            int p = t;
                            int n = m;
                            int[,] dizi5 = new int[3, 3];

                            for (int x = 1; x < 10; x++)
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh2[a, i];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh2[i, b];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }

                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {


                                        sayi = matrisTh2[m, t];

                                        switch (sayi)
                                        {
                                            case 1: kume[0] = -1; break;
                                            case 2: kume[1] = -1; break;
                                            case 3: kume[2] = -1; break;
                                            case 4: kume[3] = -1; break;
                                            case 5: kume[4] = -1; break;
                                            case 6: kume[5] = -1; break;
                                            case 7: kume[6] = -1; break;
                                            case 8: kume[7] = -1; break;
                                            case 9: kume[8] = -1; break;
                                        }
                                    }
                                }

                                int go = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        if (matrisTh2[m, t] == x)
                                            go++;

                                    }
                                }
                                if (go != 0)
                                    continue;
                                int satir = 0, sutun = 0;
                                for (int h = 0; h < 3; h++)
                                    for (int w = 0; w < 3; w++)
                                        dizi5[h, w] = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        dizi5[m % 3, t % 3] = matrisTh2[m, t];

                                    }
                                }
                                for (int y = a - a % 3; y < a - a % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == a) break;
                                        if (matrisTh2[y, z] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[y % 3, w] == -1)
                                                {
                                                    dizi5[y % 3, w] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                for (int y = b - b % 3; y < b - b % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == b) break;
                                        if (matrisTh2[z, y] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[w, y % 3] == -1)
                                                {
                                                    dizi5[w, y % 3] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                int sayici = 0;
                                for (int u = 0; u < 3; u++)
                                {
                                    for (int v = 0; v < 3; v++)
                                    {
                                        if (dizi5[u, v] == -1)
                                        {
                                            sayici++;
                                            satir = u; sutun = v;
                                        }
                                    }
                                }
                                if (sayici == 1)
                                {
                                    matrisTh2[a - a % 3 + satir, b - b % 3 + sutun] = x;
                                }


                                for (int i = 0; i < 9; i++)
                                {
                                    if (kume[i] != -1)
                                    {
                                        count++; temp = kume[i];
                                    }

                                }
                                if (count == 1)
                                {
                                    matrisTh2[a, b] = temp;
                                }
                                else continue;

                            }


                        }


                    }
                for (int a = 0; a <= 4; a++)
                    for (int b = 0; b < 9; b++)
                    {
                        if (a == 4 && b >= 4) break;
                        int[] kume = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        int count = 0;
                        if (matrisTh2[a, b] == -1 && dizi[a, b] == 0)
                        {
                            k = a % 3;
                            l = b % 3;
                            m = a - k;
                            int t = b - l;
                            int p = t;
                            int n = m;
                            int[,] dizi5 = new int[3, 3];

                            for (int x = 1; x < 10; x++)
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh2[a, i];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh2[i, b];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }

                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {


                                        sayi = matrisTh2[m, t];

                                        switch (sayi)
                                        {
                                            case 1: kume[0] = -1; break;
                                            case 2: kume[1] = -1; break;
                                            case 3: kume[2] = -1; break;
                                            case 4: kume[3] = -1; break;
                                            case 5: kume[4] = -1; break;
                                            case 6: kume[5] = -1; break;
                                            case 7: kume[6] = -1; break;
                                            case 8: kume[7] = -1; break;
                                            case 9: kume[8] = -1; break;
                                        }
                                    }
                                }

                                int go = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        if (matrisTh2[m, t] == x)
                                            go++;

                                    }
                                }
                                if (go != 0)
                                    continue;
                                int satir = 0, sutun = 0;
                                for (int h = 0; h < 3; h++)
                                    for (int w = 0; w < 3; w++)
                                        dizi5[h, w] = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        dizi5[m % 3, t % 3] = matrisTh2[m, t];

                                    }
                                }
                                for (int y = a - a % 3; y < a - a % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == a) break;
                                        if (matrisTh2[y, z] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[y % 3, w] == -1)
                                                {
                                                    dizi5[y % 3, w] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                for (int y = b - b % 3; y < b - b % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == b) break;
                                        if (matrisTh2[z, y] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[w, y % 3] == -1)
                                                {
                                                    dizi5[w, y % 3] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                int sayici = 0;
                                for (int u = 0; u < 3; u++)
                                {
                                    for (int v = 0; v < 3; v++)
                                    {
                                        if (dizi5[u, v] == -1)
                                        {
                                            sayici++;
                                            satir = u; sutun = v;
                                        }
                                    }
                                }
                                if (sayici == 1)
                                {
                                    matrisTh2[a - a % 3 + satir, b - b % 3 + sutun] = x;
                                }


                                for (int i = 0; i < 9; i++)
                                {
                                    if (kume[i] != -1)
                                    {
                                        count++; temp = kume[i];
                                    }

                                }
                                if (count == 1)
                                {
                                    matrisTh2[a, b] = temp;
                                }
                                else continue;

                            }


                        }


                    }

                for (int e = 0; e < 9; e++)

                {
                    for (int g = 0; g < 9; g++)
                    {
                        if (matrisTh2[e, g] != -1)
                        { kontrol++; }
                        else
                        {
                            kontrol = 0;
                        }

                    }
                    if (kontrol == 0) { kontrol = 0; }


                }
                
               
            }
            Array.Clear(dizi, 0, 9);
            Array.Clear(dizi5, 0, 9);
            for (int satir = 0; satir < 9; satir++)
                for (int sutun = 0; sutun < 9; sutun++)
                    sonuc[satir, sutun] = matrisTh2[satir, sutun];
            Console.WriteLine("Thread2");
            ekranaBas();
            Console.WriteLine("");
        }
        static private void cozum3()
        {
            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    for (int z = 0; z < 9; z++)
                    {
                        dizi2[x, y, z] = matrisTh3[x, y];
                    }
            int kontrol = 0;

            while (kontrol != 81)

            {
                kontrol = 0;
                int sayi;
                int k, l, m;
                for (int h = 0; h < 9; h++)
                    for (int w = 0; w < 9; w++)
                        dizi[h, w] = 0;
                
                for (int a = 7; a < 9; a++)
                    for (int b = 0; b < 9; b++)
                    {
                        int[] kume = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        int count = 0;
                        if (matrisTh3[a, b] == -1 && dizi[a, b] == 0)
                        {
                            k = a % 3;
                            l = b % 3;
                            m = a - k;
                            int t = b - l;
                            int p = t;
                            int n = m;

                            for (int x = 1; x < 10; x++)
                            {

                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh3[a, i];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh3[i, b];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }

                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {


                                        sayi = matrisTh3[m, t];

                                        switch (sayi)
                                        {
                                            case 1: kume[0] = -1; break;
                                            case 2: kume[1] = -1; break;
                                            case 3: kume[2] = -1; break;
                                            case 4: kume[3] = -1; break;
                                            case 5: kume[4] = -1; break;
                                            case 6: kume[5] = -1; break;
                                            case 7: kume[6] = -1; break;
                                            case 8: kume[7] = -1; break;
                                            case 9: kume[8] = -1; break;
                                        }
                                    }
                                }

                                int go = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        if (matrisTh3[m, t] == x)
                                            go++;

                                    }
                                }
                                if (go != 0)
                                    continue;
                                int satir = 0, sutun = 0;
                                for (int h = 0; h < 3; h++)
                                    for (int w = 0; w < 3; w++)
                                        dizi5[h, w] = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        dizi5[m % 3, t % 3] = matrisTh3[m, t];

                                    }
                                }
                                for (int y = a - a % 3; y < a - a % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == a) break;
                                        if (matrisTh3[y, z] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[y % 3, w] == -1)
                                                {
                                                    dizi5[y % 3, w] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                for (int y = b - b % 3; y < b - b % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == b) break;
                                        if (matrisTh3[z, y] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[w, y % 3] == -1)
                                                {
                                                    dizi5[w, y % 3] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                int sayici = 0;
                                for (int u = 0; u < 3; u++)
                                {
                                    for (int v = 0; v < 3; v++)
                                    {
                                        if (dizi5[u, v] == -1)
                                        {
                                            sayici++;
                                            satir = u; sutun = v;
                                        }
                                    }
                                }
                                if (sayici == 1)
                                {
                                    matrisTh3[a - a % 3 + satir, b - b % 3 + sutun] = x;
                                }


                                for (int i = 0; i < 9; i++)
                                {
                                    if (kume[i] != -1)
                                    {
                                        count++; temp = kume[i];
                                    }

                                }
                                if (count == 1)
                                {
                                    matrisTh3[a, b] = temp;
                                }
                                else continue;

                            }


                        }


                    }
                for (int a = 0; a < 7; a++)
                    for (int b = 0; b < 9; b++)
                    {
                        int[] kume = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        int count = 0;
                        if (matrisTh3[a, b] == -1 && dizi[a, b] == 0)
                        {
                            k = a % 3;
                            l = b % 3;
                            m = a - k;
                            int t = b - l;
                            int p = t;
                            int n = m;
                            int[,] dizi5 = new int[3, 3];

                            for (int x = 1; x < 10; x++)
                            {

                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh3[a, i];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }
                                for (int i = 0; i < 9; i++)
                                {
                                    sayi = matrisTh3[i, b];

                                    switch (sayi)
                                    {
                                        case 1: kume[0] = -1; break;
                                        case 2: kume[1] = -1; break;
                                        case 3: kume[2] = -1; break;
                                        case 4: kume[3] = -1; break;
                                        case 5: kume[4] = -1; break;
                                        case 6: kume[5] = -1; break;
                                        case 7: kume[6] = -1; break;
                                        case 8: kume[7] = -1; break;
                                        case 9: kume[8] = -1; break;
                                    }

                                }

                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {


                                        sayi = matrisTh3[m, t];

                                        switch (sayi)
                                        {
                                            case 1: kume[0] = -1; break;
                                            case 2: kume[1] = -1; break;
                                            case 3: kume[2] = -1; break;
                                            case 4: kume[3] = -1; break;
                                            case 5: kume[4] = -1; break;
                                            case 6: kume[5] = -1; break;
                                            case 7: kume[6] = -1; break;
                                            case 8: kume[7] = -1; break;
                                            case 9: kume[8] = -1; break;
                                        }
                                    }
                                }

                                int go = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        if (matrisTh3[m, t] == x)
                                            go++;

                                    }
                                }
                                if (go != 0)
                                    continue;
                                int satir = 0, sutun = 0;
                                for (int h = 0; h < 3; h++)
                                    for (int w = 0; w < 3; w++)
                                        dizi5[h, w] = 0;
                                for (m = a - k; m < n + 3; m++)
                                {
                                    for (t = b - l; t < p + 3; t++)
                                    {
                                        dizi5[m % 3, t % 3] = matrisTh3[m, t];

                                    }
                                }
                                for (int y = a - a % 3; y < a - a % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == a) break;
                                        if (matrisTh3[y, z] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[y % 3, w] == -1)
                                                {
                                                    dizi5[y % 3, w] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                for (int y = b - b % 3; y < b - b % 3 + 3; y++)
                                {
                                    for (int z = 0; z < 9; z++)
                                    {
                                        if (y == b) break;
                                        if (matrisTh3[z, y] == x)
                                        {
                                            for (int w = 0; w < 3; w++)
                                            {
                                                if (dizi5[w, y % 3] == -1)
                                                {
                                                    dizi5[w, y % 3] = x;
                                                }
                                            }
                                        }
                                    }
                                }
                                int sayici = 0;
                                for (int u = 0; u < 3; u++)
                                {
                                    for (int v = 0; v < 3; v++)
                                    {
                                        if (dizi5[u, v] == -1)
                                        {
                                            sayici++;
                                            satir = u; sutun = v;
                                        }
                                    }
                                }
                                if (sayici == 1)
                                {
                                    matrisTh3[a - a % 3 + satir, b - b % 3 + sutun] = x;
                                }


                                for (int i = 0; i < 9; i++)
                                {
                                    if (kume[i] != -1)
                                    {
                                        count++; temp = kume[i];
                                    }

                                }
                                if (count == 1)
                                {
                                    matrisTh3[a, b] = temp;
                                }
                                else continue;

                            }


                        }


                    }

                for (int e = 0; e < 9; e++)

                {
                    for (int g = 0; g < 9; g++)
                    {
                        if (matrisTh3[e, g] != -1)
                        { kontrol++; }
                        else
                        {
                            kontrol = 0;
                        }

                    }
                    if (kontrol == 0) { kontrol = 0; }


                }


            }
            Array.Clear(dizi,0,9);
            Array.Clear(dizi5, 0, 9);
            for (int satir = 0; satir < 9; satir++)
                for (int sutun = 0; sutun < 9; sutun++)
                    sonuc[satir, sutun] = matrisTh3[satir, sutun];
            Console.WriteLine("Thread3");
            ekranaBas();
            Console.WriteLine("");
        }

        
        
    }
}
