using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class MainForm : Form
    {
        SyntaxAnalysis sa;
        GPDictionary gpDict = new GPDictionary();
        LFDictionary lfDict = new LFDictionary();
        public MainForm()
        {
            InitializeComponent();
            try
            {
                gpDict.Load("gpdict.gpd");
                lfDict.Load("lfdict.lfd");
            }
            catch { }
        }
        void MainForm_Load(object sender, EventArgs e)
        {
            sa = new SyntaxAnalysis("dictionary.xml", false, false, 2);
        }
        void createGpDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gpDict = new GPDictionary();
        }
        void openGPDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файл *.gpd|*.gpd";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                gpDict.Load(openFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки");
            }
        }
        void saveGPDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файл *.gpd|*.gpd";
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                gpDict.Save(saveFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения");
            }
        }
        void importGPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файл *.txt|*.txt";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            ImportGPForm impForm = new ImportGPForm(openFileDialog1.FileName,
                sa, gpDict);
            impForm.ShowDialog();
        }
        void editGPDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGPDictForm editForm = new EditGPDictForm(gpDict, sa);
            editForm.ShowDialog();
        }
        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        void importLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файл *.txt|*.txt";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            ImportLFForm addForm = new ImportLFForm(openFileDialog1.FileName, sa, lfDict);
            addForm.ShowDialog();
        }
        void editLFDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLFDictForm editForm = new EditLFDictForm(lfDict, sa);
            editForm.ShowDialog();
        }
        void createLFDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lfDict = new LFDictionary();
        }
        void openLFDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файл *.lfd|*.lfd";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                lfDict.Load(openFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки");
            }
        }
        void saveLFDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файл *.lfd|*.lfd";
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                lfDict.Save(saveFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения");
            }
        }
        void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareForm cf = new CompareForm(sa, gpDict, lfDict);
            cf.ShowDialog();
        }
        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил Кондауров А.С.");
        }
        void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceForm lForm = new LicenceForm();
            lForm.ShowDialog();
        }
    }
}