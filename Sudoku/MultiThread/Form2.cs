using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread
{
    public partial class Form2 : Form
    {
        public int[,] Th1;
        public Form2()
        {

            InitializeComponent();
        }

        public Form2(int[,] Matris)
        {

            InitializeComponent();

            Th1 = (int[,])Matris.Clone();
            ekranaBas();

        }

        private void ekranaBas()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Th1[i, j] == -1)
                        Th1View.Items.Add(" ");
                    else
                        Th1View.Items.Add(Convert.ToString(Th1[i, j]));
                }

            }
        }
        
    }
}
