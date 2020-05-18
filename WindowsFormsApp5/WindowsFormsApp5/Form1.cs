using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        const int MaxV = 20; 
        int V = 1; 
        const int INF = 9999;
        TextBox[,] MatrText = null; 
        int[,] graph = new int[MaxV, MaxV]; 
        int[,] dist = new int[MaxV, MaxV];
        int[,] dist2 = new int[MaxV, MaxV];
        bool f1; 
        int dx = 40, dy = 20; 
        Form2 form2 = null;   

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            f1 = false; 
            label2.Text = "false";

            int i, j;

            form2 = new Form2();

            MatrText = new TextBox[MaxV, MaxV];

            for (i = 0; i < MaxV; i++)
                for (j = 0; j < MaxV; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + j * dx, 10 + i * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    form2.Controls.Add(MatrText[i, j]);
                }
        }

        private void Clear_MatrText()
        {
            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                {
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Visible = false;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                return;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            V = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.ColumnCount = V;
            dataGridView1.RowCount = V;
            dataGridView2.ColumnCount = V;
            dataGridView2.RowCount = V;
            dataGridView3.ColumnCount = V;
            dataGridView3.RowCount = V;

            Clear_MatrText();

            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                {
                    MatrText[i, j].TabIndex = i * V + j + 1;
                    MatrText[i, j].Visible = true;
                }

            form2.Width = 10 + V * dx + 20;
            form2.Height = 10 + V * dy + form2.button1.Height + 50;
            form2.button1.Left = 10;
            form2.button1.Top = 10 + V * dy + 10;
            form2.button1.Width = form2.Width - 30;

            if (form2.ShowDialog() == DialogResult.OK)
            {
                graph = new int[V, V];
                dist = new int[V, V];
                dist2 = new int[V, V];
                for (int i = 0; i < V; i++)
                    for (int j = 0; j < V; j++)
                        if (MatrText[i, j].Text != "")
                        {
                            graph[i, j] = Int32.Parse(MatrText[i, j].Text);
                            dist[i, j] = Int32.Parse(MatrText[i, j].Text);
                            if (i == j)
                            {
                                dist2[i, j] = 0;
                            }
                            else
                                dist2[i, j] = (j + 1);
                        }
                        else
                        {
                            graph[i, j] = 0;
                            dist[i, j] = 0;
                        }
                f1 = true;
                label2.Text = "true";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int nn;
            nn = Convert.ToInt32(numericUpDown1.Value);
            if (nn != V)
            {
                f1 = false;
                label2.Text = "false";
                Clear_MatrText();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(f1 == true)) return;

            if (radioButton1.Checked)
            {
                V = 7;
                graph = new int[,]{
                {0, 5, 3, INF, INF, INF, INF},
                {5, 0, 1, 5, 2, INF, INF},
                {3, 1, 0, 7, INF, INF, 12},
                {INF, 5, 7, 0, 3, INF, 3},
                {INF, 2, INF, 3, 0, 1, INF},
                {INF, INF, INF, 1, 1, 0, INF},
                {INF, INF, 12, 3, INF, 4, 0}};

                dist = new int[,]{
                {0, 5, 3, INF, INF, INF, INF},
                {5, 0, 1, 5, 2, INF, INF},
                {3, 1, 0, 7, INF, INF, 12},
                {INF, 5, 7, 0, 3, INF, 3},
                {INF, 2, INF, 3, 0, 1, INF},
                {INF, INF, INF, 1, 1, 0, INF},
                {INF, INF, 12, 3, INF, 4, 0}};

                dist2 = new int[V, V];
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (i == j)
                            dist2[i, j] = 0;
                        else
                            dist2[i, j] = (j + 1);
                    }
                }
            }

            if (radioButton2.Checked)
            {
                V = 6;
                graph = new int[,]{
                {0, 700, 200, INF, INF, INF},
                {700, 0, 300, 200, INF, 400},
                {200, 300, 0, 700, 600, INF},
                {INF, 200, 700, 0, 300, 100},
                {INF, INF, 600, 300, 0, 500},
                {INF, 400, INF, 100, 500, 0}};

                dist = new int[,]{
                {0, 700, 200, INF, INF, INF},
                {700, 0, 300, 200, INF, 400},
                {200, 300, 0, 700, 600, INF},
                {INF, 200, 700, 0, 300, 100},
                {INF, INF, 600, 300, 0, 500},
                {INF, 400, INF, 100, 500, 0}};

                dist2 = new int[V, V];
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (i == j)
                            dist2[i, j] = 0;
                        else
                            dist2[i, j] = (j + 1);
                    }
                }
            }

            if (radioButton3.Checked)
            {
                V = 8;
                graph = new int[,]{
                {0, 1, 2, INF, INF, INF, INF, INF},
                {INF, 0, 1, 5, 2, INF, INF, INF},
                {INF, INF, 0, 2, 1, 4, INF, INF},
                {INF, INF, INF, 0, 3, 6, 8, INF},
                {INF, INF, INF, INF, 0, 3, 7, INF},
                {INF, INF, INF, INF, INF, 0, 5, 2},
                {INF, INF, INF, INF, INF, INF, 0, 6},
                {INF, INF, INF, INF, INF, INF, INF, 0}};

                dist = new int[,]{
                {0, 1, 2, INF, INF, INF, INF, INF},
                {INF, 0, 1, 5, 2, INF, INF, INF},
                {INF, INF, 0, 2, 1, 4, INF, INF},
                {INF, INF, INF, 0, 3, 6, 8, INF},
                {INF, INF, INF, INF, 0, 3, 7, INF},
                {INF, INF, INF, INF, INF, 0, 5, 2},
                {INF, INF, INF, INF, INF, INF, 0, 6},
                {INF, INF, INF, INF, INF, INF, INF, 0}};

                dist2 = new int[V, V];
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (i == j)
                            dist2[i, j] = 0;
                        else
                            dist2[i, j] = (j + 1);
                    }
                }
            }

            if (radioButton4.Checked)
            {
                V = 7;
                graph = new int[,]{
                {0, 5, 1, INF, INF, INF, INF},
                {INF, 0, INF, 7, 1, 6, INF},
                {INF, 2, 0, 6, 7, INF, INF},
                {INF, INF, 7, 0, INF, 4, 6},
                {INF, INF, INF, 3, 0, 5, 9},
                {INF, 7, INF, INF, INF, 0, 2},
                {INF, INF, INF, INF, INF, INF, 0}};

                dist = new int[,]{
                {0, 5, 1, INF, INF, INF, INF},
                {INF, 0, INF, 7, 1, 6, INF},
                {INF, 2, 0, 6, 7, INF, INF},
                {INF, INF, 7, 0, INF, 4, 6},
                {INF, INF, INF, 3, 0, 5, 9},
                {INF, 7, INF, INF, INF, 0, 2},
                {INF, INF, INF, INF, INF, INF, 0}};

                dist2 = new int[V, V];
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (i == j)
                            dist2[i, j] = 0;
                        else
                            dist2[i, j] = (j + 1);
                    }
                }
            }

            for (int k = 0; k < V; k++)
                for (int i = 0; i < V; i++)
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            dist2[i, j] = (k + 1);
                        }
                    }
            dataGridView1.ColumnCount = V;
            dataGridView1.RowCount = V;
            dataGridView2.ColumnCount = V;
            dataGridView2.RowCount = V;
            dataGridView3.ColumnCount = V;
            dataGridView3.RowCount = V;
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dataGridView1.Width = 10 + V * dx + 20;
                    dataGridView1.Height = 10 + V * dy;
                    dataGridView2.Width = 10 + V * dx + 20;
                    dataGridView2.Height = 10 + V * dy;
                    dataGridView3.Width = 10 + V * dx + 20;
                    dataGridView3.Height = 10 + V * dy;
                    if (dist2[i, j] == 0)
                        dataGridView1.Rows[i].Cells[j].Value = null;
                    else
                        dataGridView1.Rows[i].Cells[j].Value = dist2[i, j];
                    if (dist[i, j] == 0)
                        dataGridView2.Rows[i].Cells[j].Value = null;
                    else if (dist[i,j] < 9999)
                        dataGridView2.Rows[i].Cells[j].Value = dist[i, j];
                    else
                        dataGridView2.Rows[i].Cells[j].Value = "INF";
                    if (dist[i, j] == 0)
                        dataGridView3.Rows[i].Cells[j].Value = null;
                    else if (graph[i, j] == 9999)
                        dataGridView3.Rows[i].Cells[j].Value = "INF";
                    else
                        dataGridView3.Rows[i].Cells[j].Value = graph[i, j];
                }
            }
            numericUpDown2.Maximum = V;
            numericUpDown3.Maximum = V;
            Width = Math.Max(dataGridView3.Width + 380, dataGridView1.Width + dataGridView2.Width + 100);  
            Height = Math.Max(dataGridView1.Height + 250, dataGridView3.Height + dataGridView1.Height + 100);
            dataGridView1.Location = new Point(5,Math.Max(dataGridView3.Height + 20, 200));
            dataGridView2.Location = new Point(dataGridView1.Width + 30,dataGridView1.Location.Y);
            label5.Location = new Point(dataGridView3.Location.X, dataGridView3.Location.Y - 13);
            label8.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y - 13);
            label9.Location = new Point(dataGridView2.Location.X, dataGridView2.Location.Y - 13);

        }

        public void path(int[,] dist2, int a0, int a1)
        {
            if (a1 == dist2[a0 - 1,a1 - 1])
            {
                
                label6.Text += (" --> " + Convert.ToString(a1));
            }
            else if (dist2[a0-1,a1-1] != 0)
            {
                path(dist2, a0, dist2[a0 - 1,a1 - 1]);
                path(dist2, dist2[a0 - 1,a1 - 1], a1);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            f1 = true;
            label2.Text = "true";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            f1 = true;
            label2.Text = "true";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            f1 = true;
            label2.Text = "true";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            f1 = true;
            label2.Text = "true";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != 0 && numericUpDown3.Value != 0) {
                if (numericUpDown2.Value == numericUpDown3.Value)
                {
                    label6.Text = "-";
                    label7.Text = "-";
                }
                else
                {
                    label6.Text = Convert.ToString(numericUpDown2.Value);
                    path(dist2, Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value));
                    label7.Text = Convert.ToString(dist[Convert.ToInt32(numericUpDown2.Value)-1, Convert.ToInt32(numericUpDown3.Value)-1]);
                }
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value != 0 && numericUpDown3.Value != 0)
            {
                if (numericUpDown2.Value == numericUpDown3.Value)
                {
                    label6.Text = "-";
                    label7.Text = "-";
                }
                else
                {
                    label6.Text = Convert.ToString(numericUpDown2.Value);
                    path(dist2, Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value));
                    label7.Text = Convert.ToString(dist[Convert.ToInt32(numericUpDown2.Value) - 1, Convert.ToInt32(numericUpDown3.Value) - 1]);
                }
                }
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
