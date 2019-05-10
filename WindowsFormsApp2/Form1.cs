using System;

using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

				saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				saveFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

		}

        NewProgram program = new NewProgram();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				program.loadFile(openFileDialog1.FileName);
			}
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            program.taskTriangle(textBox1, (int)numericUpDown1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            program.taskRTriangle(textBox2, (int)numericUpDown2.Value);
        }

		private void button_save_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;

			string filename = saveFileDialog1.FileName;

			program.saveFile(filename, 1);
		}
		private void button_load_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				program.loadFile(openFileDialog1.FileName);
			}
		}


		//==========================================================================================
		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void saveFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void button_saveRtriangle_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;

			string filename = saveFileDialog1.FileName;

			program.saveFile(filename, 2);
		}
	}
}
