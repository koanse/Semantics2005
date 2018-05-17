using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SemanticsNew
{
    public partial class AddGPForm : Form
    {
        GPDictionary gpDict;
        GovPattern[] arrGp;
        int gpIndex;
        public AddGPForm(GovPattern[] arrGp, GPDictionary gpDict)
        {
            InitializeComponent();
            this.gpDict = gpDict;
            this.arrGp = arrGp;
            gpIndex = 0;
            int valMax = Enum.GetValues(typeof(Actant)).Length;
            for (int i = 1; i < valMax; i++)
                lbAct.Items.Add((Actant)i);            
            ShowGPInfo();
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbAct.SelectedIndex == -1)
            {
                MessageBox.Show("Отсутствует тип актанта");
                return;
            }
            try
            {
                arrGp[gpIndex].actant = (Actant)lbAct.SelectedItem;
                gpDict.AddGP(arrGp[gpIndex]);
                gpIndex++;
                if (gpIndex == arrGp.Length)
                    Close();
                else
                    ShowGPInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        void btnSkip_Click(object sender, EventArgs e)
        {
            gpIndex++;
            if (gpIndex == arrGp.Length)
                Close();
            else
                ShowGPInfo();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        void ShowGPInfo()
        {
            try
            {
                tbWMain.Text = arrGp[gpIndex].wMain.ToString();
                tbWAct.Text = arrGp[gpIndex].wActant.ToString();
                tbConn.Text = arrGp[gpIndex].connector;
                lbAct.SelectedIndex = (int)arrGp[gpIndex].actant - 1;
            }
            catch { }
        }
    }
}