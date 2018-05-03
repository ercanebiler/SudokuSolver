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
    public partial class Form3 : Form
    {
        public int[,] Th2;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(int[,] Matris)
        {

            InitializeComponent();

            Th2 = (int[,])Matris.Clone();
            ekranaBas();

        }

        private void ekranaBas()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Th2[i, j] == -1)
                        Th2View.Items.Add(" ");
                    else
                        Th2View.Items.Add(Convert.ToString(Th2[i, j]));
                }

            }
        }
    }
}
