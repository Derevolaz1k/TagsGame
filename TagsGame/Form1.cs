using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagsGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Table table = new Table();
        Gamepad gamepad = new Gamepad();
        List<TextBox> textBoxes = new List<TextBox>();
        public void Win()
        {
            if(table.Sorted()==true)
            {
    DialogResult dialog = MessageBox.Show(
    "Начать заново?",
    "Победа!",
    MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    table = new Table();
                    updateForm();
                }
                else
                {
                    this.Close();
                }
            }
        }
        public void updateForm()
        {
            textBox1.Text = table.arr[0, 0].ToString();
            textBox2.Text = table.arr[0, 1].ToString();
            textBox3.Text = table.arr[0, 2].ToString();
            textBox4.Text = table.arr[0, 3].ToString();
            textBox5.Text = table.arr[1, 0].ToString();
            textBox6.Text = table.arr[1, 1].ToString();
            textBox7.Text = table.arr[1, 2].ToString();
            textBox8.Text = table.arr[1, 3].ToString();
            textBox9.Text = table.arr[2, 0].ToString();
            textBox10.Text = table.arr[2, 1].ToString();
            textBox11.Text = table.arr[2, 2].ToString();
            textBox12.Text = table.arr[2, 3].ToString();
            textBox13.Text = table.arr[3, 0].ToString();
            textBox14.Text = table.arr[3, 1].ToString();
            textBox15.Text = table.arr[3, 2].ToString();
            textBox16.Text = table.arr[3, 3].ToString();
            foreach (var item in textBoxes)
            {
                if (item.Text == "0")
                {
                    item.Text = "";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxes = new List<TextBox>()
            { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10,
                textBox11, textBox12, textBox13, textBox14,textBox15,textBox16
            };
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gamepad.press_key(ref table, e);
            updateForm();
            Win();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string text = sr.ReadToEnd();
                table = new Table(text.Split(' ').
          Where(x => !string.IsNullOrWhiteSpace(x)).
          Select(x => int.Parse(x)).ToArray());
            }
            updateForm();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        sw.Write(table.arr[i, j].ToString() + " ");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table = new Table();
            updateForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
