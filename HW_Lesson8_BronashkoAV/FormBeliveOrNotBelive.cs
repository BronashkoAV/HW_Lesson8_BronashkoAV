using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Lesson8_BronashkoAV
{
    public partial class FormBeliveOrNotBelive : Form
    {
        TrueFalse db = new TrueFalse("data.xml");

        public FormBeliveOrNotBelive()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.Add("", false);
            numericUpDown1.Maximum++;
            numericUpDown1.Value = numericUpDown1.Maximum;
            tbQuestion.Text = "";
            checkBoxTrueFalse.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db[(int)numericUpDown1.Value].Text = tbQuestion.Text;
            db[(int)numericUpDown1.Value].TrueFalse = checkBoxTrueFalse.Checked;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xml|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                db = new TrueFalse(ofd.FileName);
                db.Load();
                numericUpDown1.Maximum = db.Count;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Save();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.LoadFromTxt("E:\\Aleksey\\IT\\VS project\\C# Level 1 Restart\\Lesson 8\\HW_Lesson8_BronashkoAV\\HW_Lesson8_BronashkoAV\\questions.txt");
        }
    }
}
