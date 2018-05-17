using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Semantics
{
    public partial class FindWordForm : Form
    {
        OleDbConnection conn;
        public FindWordForm()
        {
            InitializeComponent();
            this.conn =
                new OleDbConnection(Properties.Settings.Default.dbConnectionString);
            conn.Open();
        }
        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        void btnFind_Click(object sender, EventArgs e)
        {
            DataAdapter da = new DataAdapter(conn);
            Форма[] arrФорма = da.НайтиФормы(tbФорма.Text);
            lbRes.Items.Clear();
            foreach (Форма f in arrФорма)
            {
                string s = "Часть речи: " + f.частьРечи.ToString() +
                    "; пост. призн.: " + f.постПризн.ToString() +
                    "; изм. призн: " + f.измПризн.ToString() +
                    "; нач. форма: " + f.начФорма;
                lbRes.Items.Add(s);
            }
        }
        void FindWordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }
    }
}