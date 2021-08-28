using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace proj1
{
    public partial class UC1 : UserControl
    {
        [DllImport("Project.dll")]
        public static extern IntPtr[] read_intial_board();

        Form1 f = new Form1();
        IntPtr[] str =new IntPtr[100];

        //List<string> _items = new List<string>();

        public UC1()
        {
            InitializeComponent();
        }

        public void UC1_Load(object sender, EventArgs e)
        {
            //f.DGVShow(byte[,] arr);

           // str = read_intial_board();
            try
            {

                
                for (int i = 0; i < str.Length; i++)
                {
                    listBox1.Items.Add(str[i].ToString());
                    //str[i] = byte.Parse(txtbxshow.Text.ToString());
                    //txtbxshow.AppendText();
                    //listBox1.DataSource = _items;

                }
            }
            catch(Exception ex)
            {
                ex.GetType();
                listBox1.Items.Clear();
                listBox1.Items.Add("EXX1");
            }
            
        }
       
    }
}
