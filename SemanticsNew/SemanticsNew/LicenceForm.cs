using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class LicenceForm : Form
    {
        public LicenceForm()
        {
            InitializeComponent();
            tb.Text = Properties.Resources.GNU;
        }
    }
}