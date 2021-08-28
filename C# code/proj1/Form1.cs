using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace proj1
{
    public partial class Form1 : Form
    {

        [DllImport("project.dll")]
        public static extern void displayResultBoard(byte[] finishedArr, byte[] colorArr);

        [DllImport("project.dll")]
        public static extern void chooseLevel(byte diff, byte[] initialArr, byte[] initColorArr, byte[] finishedArr, byte[] finishedColorArr); //,byte[] errorMsg


        //[DllImport("project.dll")]
        //public static extern void readInitialArr( byte[] initialArr,byte[] colorArr);

        [DllImport("project.dll")]
        public static extern void StorePlayerCell(byte val, byte row, byte col);

        [DllImport("project.dll")]
        public static extern void IsWithinRange(out byte rangeFlag,ref byte cellVal);


         [DllImport("project.dll")]
        public static extern void IsCorrect(out byte cellColor,ref byte cellVal);

         [DllImport("project.dll")]
         public static extern void countEmptyCells();

        

          [DllImport("project.dll")]
         public static extern void readSavedArrFromAssem(byte[] savedArr, byte[] colorArr);

          [DllImport("project.dll")]
          public static extern void writeSavedBoardInFile(byte[] errorFlag);

          [DllImport("project.dll")]
          public static extern void displayScore(byte correct, byte inCorrect);
          

        //MY ARRAYS
          byte[] finishedArr = new byte[rows * cols];
          byte[] finishedColorArr = new byte[rows * cols];

          byte[] initialArr = new byte[rows*cols];
          byte[] initialColorArr =new byte[rows*cols];
          byte correct, inCorrect;


          static byte[] errorMsg;
          static int rows = 9;
          static int cols = 9;      
        //byte[] zeroArr = new byte[rows*cols];
          

        //byte[,] finalArr = new byte[rows, cols];


          DataGridView DGV = new DataGridView();
        

        public Form1()
        {
            InitializeComponent();
            initDGV();
        }

        private void fillInitialBoard()
        {
            //byte[] assemInitialArr = new byte[rows * cols];
            //byte[] colorArr =new byte[rows*cols];
            //readInitialArr(assemInitialArr, colorArr);

            //initialArr = convert1Dto2DArray(assemInitialArr);
            //initialColorArr = convert1Dto2DArray(colorArr);

            fillDGV(convert1Dto2DArray(initialArr), convert1Dto2DArray(initialColorArr));
        }

        private void initDGV()
        {
            int cColWidth = 45;
            int cRowHeigth = 45;
            int cMaxCell = 9;
            int cSidelength = cColWidth * cMaxCell + 3;
            DGV = new DataGridView();
            DGV.Name = "DGV";
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToAddRows = false;
            DGV.RowHeadersVisible = false;
            DGV.ColumnHeadersVisible = false;
            DGV.GridColor = Color.DarkBlue;
            DGV.DefaultCellStyle.BackColor = Color.AliceBlue;
            DGV.ScrollBars = ScrollBars.None;
            DGV.Size = new Size(cSidelength, cSidelength);
            DGV.Location = new Point(50, 50);
            DGV.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            DGV.ForeColor = Color.DarkBlue;
            DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DGV.BackgroundColor = Color.Red;
            DGV.ColumnCount = cols;

            // add 81 cells
            for (int i = 0; i < rows; i++)
            {
                DGV.Columns[i].Width = cColWidth;
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                
                row.CreateCells(this.DGV);
                row.Height = cRowHeigth;
                DGV.Rows.Add(row);
            }

            // mark the 9 square areas consisting of 9 cells
            DGV.Columns[2].DividerWidth = 2;
            DGV.Columns[5].DividerWidth = 2;
            DGV.Rows[2].DividerHeight = 2;
            DGV.Rows[5].DividerHeight = 2;

            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);

            Controls.Add(DGV);
            DGV.Visible = false;
        }

        private void showDGV()
        {
            DGV.Visible = true;
        }
       

        //DONE
        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            byte cellColor;
            byte rangeFlag;
            byte[,] initialArr2D = convert1Dto2DArray(initialArr);
            if (initialArr2D[e.RowIndex, e.ColumnIndex] == 0)
            {
                byte cellVal =(byte)int.Parse(this.DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                
                IsWithinRange(out rangeFlag,ref cellVal );
                if (rangeFlag == 0)
                {
                    DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellVal;
                    errorLabel.Visible = true;
                    errorLabel.Text = "Enter values between 1 and 9";
                }
                else
                {
                    errorLabel.Visible = false;
                    StorePlayerCell((byte)cellVal, (byte)e.RowIndex, (byte)e.ColumnIndex);
                    IsCorrect(out cellColor,ref cellVal);

                    /**/
                    if (cellColor == 0)
                        DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.OrangeRed;
                    else if(cellColor == 1)
                        DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Green;

                    DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellVal;
                    
                }
            }

            displayScore(correct,inCorrect);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           // UC1 uc = new UC1();
            // uc.Dock = DockStyle.Fill;
            //panel1.Controls.Add(uc);
            
            //uc.Show();
            //obj = this;
            

        }


        private byte[,] convert1Dto2DArray(byte[] arr1D)
        {
            byte[,] arr2D = new byte[9, 9];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr2D[i, j] = arr1D[i * 9 + j];
                }
            }
            return arr2D;
        }

        private void fillDGV(byte[,] valArr, byte[,] colorArr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    DGV.Rows[i].Cells[j].Value = valArr[i, j];
                    if (colorArr[i, j] == 1)
                        DGV.Rows[i].Cells[j].Style.ForeColor = Color.Green;

                    else if (colorArr[i, j] == 2)
                        DGV.Rows[i].Cells[j].Style.ForeColor = Color.Blue;

                    else if (colorArr[i, j] == 3)
                    {
                        DGV.Rows[i].Cells[j].ReadOnly = true;
                        DGV.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

      
        private void showMenu()
        {
            bool isVisible=true;
            Easyybtn.Visible = isVisible;
            mediumbtn.Visible = isVisible;
            Harddbtn.Visible = isVisible;
            Resumbtn.Visible = isVisible;
            corLbl.Visible = !isVisible;
            corCount.Visible = !isVisible;
            incorLbl.Visible = !isVisible;
            incorCount.Visible = !isVisible;
        }

        private void hideMenu()
        {
            bool isVisible = false;
            Easyybtn.Visible = isVisible;
            mediumbtn.Visible = isVisible;
            Harddbtn.Visible = isVisible;
            Resumbtn.Visible = isVisible;
            corLbl.Visible = !isVisible;
            corCount.Visible = !isVisible;
            incorLbl.Visible = !isVisible;
            incorCount.Visible = !isVisible;
            corCount.Text = correct.ToString();
            incorCount.Text = inCorrect.ToString();

        }

        private void Resumbtn_Click(object sender, EventArgs e)
        {
            byte[] assemSavedArr = new byte[rows * cols];
            byte[] assemColorArr = new byte[rows*cols];

            readSavedArrFromAssem(assemSavedArr, assemColorArr);

            byte[,] sArr = convert1Dto2DArray(assemSavedArr);
            byte[,] cArr = convert1Dto2DArray(assemColorArr);

            fillDGV(sArr, cArr);
            hideMenu();
            showDGV();
        }


        private void FinalBtn_Click(object sender, EventArgs e)
        {
            //byte[] assemFinalArr = new byte[81];
            //byte[] assemColorArr = new byte[81];
            displayResultBoard(finishedArr, finishedColorArr);

            //finalArr = convert1Dto2DArray(assemFinalArr);
            //finalColorArr = convert1Dto2DArray(assemColorArr);

            fillDGV(convert1Dto2DArray(finishedArr), convert1Dto2DArray(finishedColorArr));
            activateBoard(false);
        }

        void activateBoard(bool isActive)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    DGV.Rows[i].Cells[j].ReadOnly = !isActive;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DGV.Visible = false;
            writeSavedBoardInFile(errorMsg);
            Array.Clear(finishedColorArr,0,rows*cols);
            showMenu();
        }

        private void Easyybtn_Click(object sender, EventArgs e)
        {
            activateBoard(true);
            
            hideMenu();
            chooseLevel(1, initialArr, initialColorArr, finishedArr, finishedColorArr);  //, errorMsg
            fillInitialBoard();
            showDGV();
            
        }

        private void mediumbtn_Click(object sender, EventArgs e)
        {
            activateBoard(true);
            hideMenu();
            chooseLevel(2, initialArr, initialColorArr, finishedArr, finishedColorArr);   //, errorMsg
            fillInitialBoard();
            showDGV();
        
        }

        private void Harddbtn_Click(object sender, EventArgs e)
        {
            activateBoard(true);
            hideMenu();
            chooseLevel(3, initialArr, initialColorArr, finishedArr, finishedColorArr);      //, errorMsg
            fillInitialBoard();
            showDGV();
        }


    }
}
