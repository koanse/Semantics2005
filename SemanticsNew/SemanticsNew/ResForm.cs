using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class ResForm : Form
    {
        public ResForm(STNode[] arrRootX, STNode[] arrRootY,
            double[,] matrCmp, double [,] matrParent, double[,] matr,
            int[] arrIndex, SyntaxAnalysis sa, double res)
        {
            InitializeComponent();
            tvSa.Nodes.AddRange(sa.CreateTreeNodes(arrRootX));
            tvSa.ExpandAll();
            tbRes.Text = res.ToString();

            List<STNode> listNodeX = STNode.GetDescendants(arrRootX);
            List<STNode> listNodeY = STNode.GetDescendants(arrRootY);
            wbCmp.DocumentText = MatrToHTML(matrCmp, listNodeX, listNodeY, arrIndex);
            wbPar.DocumentText = MatrToHTML(matrParent, listNodeX, listNodeY, arrIndex);
            wbMatr.DocumentText = MatrToHTML(matr, listNodeX, listNodeY, arrIndex);
        }
        void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        string MatrToHTML(double[,] matr, List<STNode> listNodeX,
            List<STNode> listNodeY, int[] arrIndex)
        {
            string s = "<TABLE BORDER = 3><TR><TD>Эталон / Сравниваемое предложение";
            foreach (STNode nd in listNodeY)
                s += string.Format("<TD>{0}", nd);
            for (int i = 0; i < listNodeX.Count; i++)
            {
                s += string.Format("<TR><TD>{0}", listNodeX[i]);
                for (int j = 0; j < listNodeY.Count; j++)
                    if (arrIndex[i] == j)
                        s += string.Format("<TD BGCOLOR = YELLOW>{0}",
                            Math.Round(matr[i, j], 3));
                    else
                        s += string.Format("<TD>{0}",
                            Math.Round(matr[i, j], 3));
            }
            s += "</TABLE>";
            return s;
        }
    }
}