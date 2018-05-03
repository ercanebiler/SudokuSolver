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
    public partial class Form4 : Form
    {
        public int[,] Th3;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(int[,] Matris)
        {

            InitializeComponent();

            Th3 = (int[,])Matris.Clone();
            ekranaBas();

        }

        private void ekranaBas()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Th3[i, j] == -1)
                        Th3View.Items.Add(" ");
                    else
                        Th3View.Items.Add(Convert.ToString(Th3[i, j]));
                }

            }
        }
    }
}
