using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SemanticsNew
{
    public partial class ImportGPForm : Form
    {
        string fileName;
        string[] arrPhrase;
        int pIndex;
        GovPattern[] arrGp;
        SyntaxAnalysis sa;
        GPDictionary gpDict;

        public ImportGPForm(string fileName, SyntaxAnalysis sa, GPDictionary gpDict)
        {
            InitializeComponent();
            this.fileName = fileName;
            this.sa = sa;
            this.gpDict = gpDict;
        }
        void GPForm_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.Unicode);
                string s = sr.ReadToEnd();
                fs.Close();
                arrPhrase = s.Split(new char[] { '.', ',', ';', ':', '!', '?' });                
                pIndex = 0;
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла");
                Close();
            }
            AnalizePhrase();
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (arrGp == null || arrGp.Length == 0)
                return;
            AddGPForm addForm = new AddGPForm(arrGp, gpDict);
            addForm.ShowDialog();
            pIndex++;
            if (pIndex == arrPhrase.Length)
                Close();
            else
                AnalizePhrase();
        }
        void btnSkip_Click(object sender, EventArgs e)
        {
            pIndex++;
            if (pIndex == arrPhrase.Length)
                Close();
            else
                AnalizePhrase();
        }
        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        void AnalizePhrase()
        {
            tbPhrase.Text = arrPhrase[pIndex];
            tvSa.Nodes.Clear();
            lbGp.Items.Clear();
            try
            {
                STNode[] arrRoot = sa.Analize(arrPhrase[pIndex]);
                sa.SetActants(arrRoot, gpDict);
                TreeNode[] arrNode = sa.CreateTreeNodes(arrRoot);
                tvSa.Nodes.AddRange(arrNode);
                tvSa.ExpandAll();
                arrGp = sa.GetGovPatterns(arrRoot, gpDict);
                lbGp.Items.AddRange(arrGp);
            }
            catch
            {
                tvSa.Nodes.Add("Ошибка синтаксического анализа");
            }
        }
    }
}