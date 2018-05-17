using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SemanticsNew
{
    public partial class ImportLFForm : Form
    {
        LFDictionary lfDict;
        SyntaxAnalysis sa;
        Word wArg, wVal;
        string fileName;
        string[] arrArg;
        int aIndex;
        public ImportLFForm(string fileName, SyntaxAnalysis sa, LFDictionary lfDict)
        {
            this.lfDict = lfDict;
            this.sa = sa;
            this.fileName = fileName;
            InitializeComponent();
            int valMax = Enum.GetValues(typeof(LexFunction)).Length;
            for (int i = 1; i < valMax; i++)
                lvLf.Items.Add(((LexFunction)i).ToString());
        }
        void AddLFForm_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.Unicode);
                string s = sr.ReadToEnd();
                arrArg = s.Split(new char[] { ' ', '\r', '\n', '\t' ,
                    '.', ',', '?', ':', ';' });                
                fs.Close();
                aIndex = 0;
                NextArgument();
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла");
                Close();
            }
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                PhraseComparer pc = new PhraseComparer(sa, lfDict);
                //Actant[] arrActArg, arrActVal;
                LexFunction lf = (LexFunction)(lvLf.SelectedIndices[0] + 1);
                //if (lf == LexFunction.Conv)
                //    pc.ParseConvParam(tbParam.Text, out arrActArg, out arrActVal);
                lfDict.AddLF(new LFArgVal(wArg, wVal, lf, tbParam.Text));
            }
            catch
            {
                MessageBox.Show("Ошибка добавления лексической функции");
                return;
            }
            tbVal.Text = "";
        }
        void btnSkip_Click(object sender, EventArgs e)
        {
            aIndex++;
            NextArgument();
        }
        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        void tbArg_TextChanged(object sender, EventArgs e)
        {
            tbArgDescr.Text = "";
            try
            {
                STNode[] arrRoot = sa.Analize(tbArg.Text);
                wArg = arrRoot[0].word;
                tbArgDescr.Text = wArg.ToString();
            }
            catch { }
        }
        void tbVal_TextChanged(object sender, EventArgs e)
        {
            tbValDescr.Text = "";
            try
            {
                STNode[] arrRoot = sa.Analize(tbVal.Text);
                wVal = arrRoot[0].word;
                tbValDescr.Text = wVal.ToString();
            }
            catch { }
        }
        void NextArgument()
        {
            STNode[] arrNode = null;
            while (aIndex < arrArg.Length)
            {
                try
                {
                    arrNode = sa.Analize(arrArg[aIndex]);
                    break;
                }
                catch { }
                aIndex++;
            }
            if (aIndex == arrArg.Length)
            {
                MessageBox.Show("Просмотр файла окончен");
                Close();                
                return;
            }
            tbArg.Text = arrNode[0].word.initial;
            tbVal.Text = "";
        }        
    }
}