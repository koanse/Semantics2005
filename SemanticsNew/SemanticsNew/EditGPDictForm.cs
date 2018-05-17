using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class EditGPDictForm : Form
    {
        GPDictionary gpDict;
        SyntaxAnalysis sa;
        public EditGPDictForm(GPDictionary gpDict, SyntaxAnalysis sa)
        {
            InitializeComponent();
            this.gpDict = gpDict;
            this.sa = sa;
            lbGp.Items.AddRange(gpDict.GetList());
            lbGpFreq.Items.AddRange(gpDict.GetFreqList());
            labNum.Text = string.Format("Объем: {0}", lbGp.Items.Count);
        }
        void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        void btnDel_Click(object sender, EventArgs e)
        {
            if (lbGp.SelectedIndex == -1)
                return;
            gpDict.DelGP(lbGp.SelectedIndex);
            lbGp.Items.RemoveAt(lbGp.SelectedIndex);
            labNum.Text = string.Format("Объем: {0}", lbGp.Items.Count);
            lbGpFreq.Items.Clear();
            lbGpFreq.Items.AddRange(gpDict.GetFreqList());
        }
        void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                STNode[] arrRoot = sa.Analize(tbWMain.Text);
                Word wMain = arrRoot[0].word;
                arrRoot = sa.Analize(tbWAct.Text);
                Word wActant = arrRoot[0].word;
                Actant actant = gpDict.GetActant(wMain, wActant, tbConn.Text);
                MessageBox.Show("Результат: " + actant.ToString());
            }
            catch
            {
                MessageBox.Show("Ошибка: проверьте вводимые данные");
            }
        }
    }
}