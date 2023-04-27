using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Picasyfijas
{
    public partial class Form1 : Form
    {
        int[] Numero;
        int[] Numero1;
        public Form1()
        {
            InitializeComponent();
            Numero1 = new int[4];
            Numero = new int[4];
            Numero = RamVector();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private int[] RamVector()
        {
            Random Nr = new Random();
            int[] vector = new int[4];
            for (int x = 0; x < 4; x++)
            {
                vector[x] = Nr.Next(1, ((int)numericUpDown1.Value) + 1);
                if (x > 0)
                {
                    for (int y = x - 1; y >= 0; y--)
                    {
                        if (vector[x] == vector[y])
                            x = x - 1;
                    }
                }
            }

            return vector;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] Vector = RamVector();
            textBox1.Text = Vector[0] + "" + Vector[1] + "" + Vector[2] + "" + Vector[3];
        }
        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Numero = RamVector();
            listBox1.Items.Clear();
        }

        public void convertirArray(string Cadena)
        {

            int a = Convert.ToInt32(Cadena);
            for (int i = Cadena.Length - 1; i >= 0; i--)
            {
                try
                {
                    int b = a % 10;
                    a = a / 10;
                    Numero1[i] = b;
                }
                catch (Exception) { }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int punto = 0;
            int fama = 0;
            convertirArray(textBox1.Text);
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {

                    if (Numero[x] == Numero1[y])
                    {
                        if (x == y) punto = punto + 1;
                        else fama = fama + 1;
                    }
                }
            }
            if (punto == 4)
            {
                MessageBox.Show("Ganaste !!!! el número era " + Numero[0] + Numero[1] + Numero[2] + Numero[3], "Ganador", MessageBoxButtons.OK);
                Numero = RamVector();
                listBox1.Items.Clear();
                textBox1.Text = string.Empty;
            }
            else
                listBox1.Items.Add(" " + textBox1.Text + "       " + punto + "       " + fama);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Al cambiar nivel, inicias nuevo juego", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Numero = RamVector();
            listBox1.Items.Clear();
        }
    }
}