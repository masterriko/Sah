using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah3
{
    public partial class Form1 : Form
    {
        private int positionX;
        private int positionY;
        private bool clicked = false;
        Grid grid = new Grid();
        public Form1()
        {
            InitializeComponent();
            this.Height = 720;
            this.Width = 1080;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //CreateChessBoard();
            try { createGrid(); }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            paintGrid();
        }
        private void CreateChessBoard()
        {
            Color lightSquareColor = Color.White;
            Color darkSquareColor = Color.Gray;
            tableLayoutPanel2.Width = 420;
            tableLayoutPanel2.Height = 420;

            // Calculate the size of each cell to make them square
            int cellSize = Math.Min(tableLayoutPanel2.Width / 8, tableLayoutPanel2.Height / 8);

            tableLayoutPanel2.RowCount = 8;
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Clear();
            tableLayoutPanel2.RowStyles.Clear();

            for (int row = 0; row < 8; row++)
            {
                tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));

                for (int col = 0; col < 8; col++)
                {
                    tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));

                    Panel squarePanel = new Panel();
                    squarePanel.BackColor = (row + col) % 2 == 0 ? lightSquareColor : darkSquareColor;
                    squarePanel.Margin = new Padding(0);
                    squarePanel.Dock = DockStyle.Fill;
                    tableLayoutPanel2.Controls.Add(squarePanel, col, row);
                    squarePanel.Click += SquarePanelClickEventHandler;

                    //Črn kmet
                    if (row == 1)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.kmc;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);
                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Bel kmet
                    if (row == 6)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.kmb;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);
                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Bel konj
                    if (row == 7 && (col == 1 || col == 6))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.kob;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Črn konj
                    if (row == 0 && (col == 1 || col == 6))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.koc;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Črn tekač
                    if (row == 0 && (col == 2 || col == 5))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.tec;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }
                    //Bel tekač
                    if (row == 7 && (col == 2 || col == 5))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.teb;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Bela trdnjava
                    if (row == 7 && (col == 0 || col == 7))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.trb;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Črna trdnjava
                    if (row == 0 && (col == 0 || col == 7))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.trc;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Črn kralj
                    if (row == 0 && col ==  4)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.krc;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Bel kralj
                    if (row == 7 && col == 4)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.krc;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Bela kraljica
                    if (row == 7 && col == 3)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.kb;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    //Crna kraljica
                    if (row == 0 && col == 3)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Properties.Resources.kc;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Dock = DockStyle.Fill;
                        squarePanel.Controls.Add(pictureBox);

                        pictureBox.Click += FigureClickEventHandler;
                    }

                    tableLayoutPanel2.Controls.Add(squarePanel, col, row);
                }
            }
        }

        /// <summary>
        /// Ustvarimo grid in nanj postavimo figure
        /// </summary>
        public void createGrid()
        {
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; i++ )
                {

                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                        {
                            grid.dodaj(i, j, "TRC");
                        }
                        else if (j == 1 || j == 6)
                        {
                            grid.dodaj(i, j, "KOC");
                        }
                        else if (j == 2 || j == 5)
                        {
                            grid.dodaj(i, j, "TEC");

                        }
                        else if(j == 3)
                        {
                            grid.dodaj(i, j, "KC");
                        }
                        else
                        {
                            grid.dodaj(i, j, "KRC");
                        }
                    }
                    else if(i == 1)
                    {
                        grid.dodaj(i, j, "KMC");
                    }
                    else if (i == 6)
                    {
                        grid.dodaj(i, j, "KMB");
                    }
                    else if (i == 7)
                    {
                        if (j == 0 || j == 7)
                        {
                            grid.dodaj(i, j, "TRB");
                        }
                        else if (j == 1 || j == 6)
                        {
                            grid.dodaj(i, j, "KOB");
                        }
                        else if (j == 2 || j == 5)
                        {
                            grid.dodaj(i, j, "TEB");

                        }
                        else if (j == 3)
                        {
                            grid.dodaj(i, j, "KB");
                        }
                        else
                        {
                            grid.dodaj(i, j, "KRB");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Grid narišemo na okno
        /// </summary>
        public void paintGrid()
        {
            Color lightSquareColor = Color.White;
            Color darkSquareColor = Color.Gray;
            tableLayoutPanel2.Width = 420;
            tableLayoutPanel2.Height = 420;

            // Calculate the size of each cell to make them square
            int cellSize = Math.Min(tableLayoutPanel2.Width / 8, tableLayoutPanel2.Height / 8);

            tableLayoutPanel2.RowCount = 8;
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Clear();
            tableLayoutPanel2.RowStyles.Clear();

            for (int i = 0; i < 8; i++)
            {
                tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));


                for (int j = 0; j < 8; j++)
                {
                    tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));

                    Panel squarePanel = new Panel();
                    squarePanel.BackColor = (i + j) % 2 == 0 ? lightSquareColor : darkSquareColor;
                    squarePanel.Margin = new Padding(0);
                    squarePanel.Dock = DockStyle.Fill;
                    tableLayoutPanel2.Controls.Add(squarePanel, j, i);
                    squarePanel.Click += SquarePanelClickEventHandler;

                    //Figura figura = grid.grid[i, j];
                    tableLayoutPanel2.Controls.Add(squarePanel, j, i);
                }
            }
        }

        /// <summary>
        /// izberi figuro, ki jo želiš premakniti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FigureClickEventHandler(object sender, EventArgs e)
        {
            PictureBox knight = (PictureBox)sender;
            Panel squarePanel = (Panel)knight.Parent;

            if (squarePanel != null)
            {
                TableLayoutPanelCellPosition position = tableLayoutPanel2.GetPositionFromControl(squarePanel);
                int row = position.Row;
                int col = position.Column;

                positionX = col;
                positionY = row;
                clicked = true;
            }
        }

        /// <summary>
        /// Premakni figuro na željeno polje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquarePanelClickEventHandler(object sender, EventArgs e)
        {
            if (clicked)
            {
                
                Panel squarePanel = (Panel)sender;

                TableLayoutPanelCellPosition position = tableLayoutPanel2.GetPositionFromControl(squarePanel);
                int newRow = position.Row;
                int newCol = position.Column;

                MovePiece(positionX, positionY, newCol,newRow);
                clicked = false;
            }
        }

        /// <summary>
        /// Metoda premakne figuro
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="newCol"></param>
        /// <param name="newRow"></param>
        private void MovePiece(int col, int row, int newCol, int newRow)
        {
            Panel sourcePanel = (Panel)tableLayoutPanel2.GetControlFromPosition(col, row);
            Panel destinationPanel = (Panel)tableLayoutPanel2.GetControlFromPosition(newCol, newRow);

            if (sourcePanel.Controls.Count > 0)
            {
                // Get the PictureBox control from the sourcePanel
                PictureBox pictureBox = (PictureBox)sourcePanel.Controls[0];

                // Remove the PictureBox from the sourcePanel
                sourcePanel.Controls.Remove(pictureBox);

                // Add the PictureBox to the destinationPanel
                destinationPanel.Controls.Add(pictureBox);
            }
        }
    }
}

