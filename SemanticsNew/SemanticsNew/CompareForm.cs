using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class CompareForm : Form
    {
        SyntaxAnalysis sa;
        GPDictionary gpDict;
        LFDictionary lfDict;
        public CompareForm(SyntaxAnalysis sa, GPDictionary gpDict, LFDictionary lfDict)
        {
            this.sa = sa;
            this.gpDict = gpDict;
            this.lfDict = lfDict;
            InitializeComponent();
        }
        void btnAnalize_Click(object sender, EventArgs e)
        {
            tvSa1.Nodes.Clear();
            tvSa2.Nodes.Clear();
            try
            {
                STNode[] arrRootX = sa.Analize(tbPhrase1.Text);
                sa.SetActants(arrRootX, gpDict);
                sa.RemovePrepositions(arrRootX);
                TreeNode[] arrNodeX = sa.CreateTreeNodes(arrRootX);
                tvSa1.Nodes.AddRange(arrNodeX);
                tvSa1.ExpandAll();                
                STNode[] arrRootY = sa.Analize(tbPhrase2.Text);
                sa.SetActants(arrRootY, gpDict);
                sa.RemovePrepositions(arrRootY);
                TreeNode[] arrNodeY = sa.CreateTreeNodes(arrRootY);
                tvSa2.Nodes.AddRange(arrNodeY);
                tvSa2.ExpandAll();
                PhraseComparer pc = new PhraseComparer(sa, lfDict);
                STNode[] arrRoot;
                double[,] matrCmp, matrParent, matr;
                int[] arrIndex;
                double res = pc.Analize(arrRootX, arrRootY,
                    out arrRoot, out matrCmp, out matrParent,
                    out matr, out arrIndex);
                ResForm rForm = new ResForm(arrRoot, arrRootY, matrCmp,
                    matrParent, matr, arrIndex, sa, res);
                rForm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка анализа");
            }
        }
        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}