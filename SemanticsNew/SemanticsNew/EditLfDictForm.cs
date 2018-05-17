using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class EditLFDictForm : Form
    {
        LFDictionary lfDict;
        SyntaxAnalysis sa;
        public EditLFDictForm(LFDictionary lfDict, SyntaxAnalysis sa)
        {
            InitializeComponent();
            this.lfDict = lfDict;
            this.sa = sa;
            lbLf.Items.AddRange(lfDict.GetList());
            labNum.Text = string.Format("Объем: {0}", lbLf.Items.Count);
        }
        void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        void btnDel_Click(object sender, EventArgs e)
        {
            if (lbLf.SelectedIndex == -1)
                return;
            lfDict.DelLF(lbLf.SelectedIndex);
            lbLf.Items.RemoveAt(lbLf.SelectedIndex);
            labNum.Text = string.Format("Объем: {0}", lbLf.Items.Count);
        }
        void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                STNode[] arrRoot = sa.Analize(tbWArg.Text);
                Word wArg = arrRoot[0].word;
                arrRoot = sa.Analize(tbWVal.Text);
                Word wVal = arrRoot[0].word;
                tbRes.Text = lfDict.GetLF(wArg, wVal).ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка: проверьте вводимые данные");
            }
        }
    }
}