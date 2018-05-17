using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Semantics
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        void addWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordForm wf = new WordForm();
            wf.ShowDialog();
        }
        void findWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindWordForm f = new FindWordForm();
            f.ShowDialog();
        }
        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}