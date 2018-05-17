using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Semantics
{
    public partial class WordForm : Form
    {
        OleDbConnection conn;
        public WordForm()
        {
            InitializeComponent();
            cbЧр.DataSource = new ЧастьРечи[] { ЧастьРечи.Сущ, ЧастьРечи.Прил,
                ЧастьРечи.Глаг, ЧастьРечи.Нар, ЧастьРечи.Числ, ЧастьРечи.Мест,
                ЧастьРечи.Предл, ЧастьРечи.Союз, ЧастьРечи.Част, ЧастьРечи.Межд };
            conn = new OleDbConnection(Properties.Settings.Default.dbConnectionString);
            conn.Open();
        }
        void cbЧр_SelectedValueChanged(object sender, EventArgs e)
        {
            ЧастьРечи чр = (ЧастьРечи)cbЧр.SelectedItem;
            IПостПризнак пп = ПризнакFactory.ПостПризнак(чр);
            int[] arrПп = пп.GetLegalValues();
            cbПп.Items.Clear();
            foreach (byte кодПп in arrПп)
            {
                пп = ПризнакFactory.ПостПризнак(чр);
                пп.Initialize(кодПп);
                cbПп.Items.Add(пп);
            }
        }
        void cbПп_SelectedValueChanged(object sender, EventArgs e)
        {
            IПостПризнак пп = cbПп.SelectedItem as IПостПризнак;
            int кодПп = пп.GetIndex();
            ЧастьРечи чр = (ЧастьРечи)cbЧр.SelectedItem;
            IИзмПризнак ип = ПризнакFactory.ИзмПризнак(чр);
            int[] arrИп = ип.GetLegalValues(кодПп);
            dgvMorph.Rows.Clear();
            dgvMorph.Rows.Add(arrИп.Length);
            cbНф.Items.Clear();
            for (int i = 0; i < arrИп.Length; i++)
            {
                ип = ПризнакFactory.ИзмПризнак(чр);
                ип.Initialize(arrИп[i]);
                string форма = tbОсн1.Text + tbОсн2.Text + tbОсн3.Text;
                dgvMorph.Rows[i].Cells["Наличие"].Value = true;
                dgvMorph.Rows[i].Cells["КодИзмПризн"].Value = arrИп[i];
                dgvMorph.Rows[i].Cells["ИзмПризн"].Value = ип.ToString();
                dgvMorph.Rows[i].Cells["Оконч1"].Value = "";
                dgvMorph.Rows[i].Cells["Оконч2"].Value = "";
                dgvMorph.Rows[i].Cells["Оконч3"].Value = "";
                dgvMorph.Rows[i].Cells["Форма"].Value = форма;

                cbНф.Items.Add(ип);
            }
        }
        void dgvMorph_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvMorph.Rows[e.RowIndex];
                string оконч1 = (string)r.Cells["Оконч1"].Value;
                string оконч2 = (string)r.Cells["Оконч2"].Value;
                string оконч3 = (string)r.Cells["Оконч3"].Value;
                string форма = tbОсн1.Text + оконч1 + tbОсн2.Text + оконч2 +
                    tbОсн3.Text + оконч3;
                r.Cells["Форма"].Value = форма;
                if (оконч1 == null)
                    r.Cells["Оконч1"].Value = "";
                if (оконч2 == null)
                    r.Cells["Оконч2"].Value = "";
                if (оконч3 == null)
                    r.Cells["Оконч3"].Value = "";
            }
            catch { }
        }        
        void tbОсн_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvMorph.Rows)
                dgvMorph_CellValueChanged(null,
                    new DataGridViewCellEventArgs(0, r.Index));
        }
        void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DataAdapter da = new DataAdapter(conn);
                ЧастьРечи чр = (ЧастьРечи)cbЧр.SelectedItem;
                IПостПризнак пп = (IПостПризнак)cbПп.SelectedItem;
                int кодПп = пп.GetIndex();
                IИзмПризнак ипНф = (IИзмПризнак)cbНф.SelectedItem;
                int кодИпНф = ипНф.GetIndex();
                int кодОкончНф = -1;
                foreach (DataGridViewRow r in dgvMorph.Rows)
                {
                    int кодИп = (int)r.Cells["КодИзмПризн"].Value;
                    if ((bool)r.Cells["Наличие"].Value == false)
                        if (кодИп == кодИпНф)
                            throw new Exception("Выберете другую начальную форму");
                        else
                            continue;
                    if (кодИп == кодИпНф)
                    {
                        string оконч1 = (string)r.Cells["Оконч1"].Value;
                        string оконч2 = (string)r.Cells["Оконч2"].Value;
                        string оконч3 = (string)r.Cells["Оконч3"].Value;

                        string начФорма = tbОсн1.Text + оконч1 +
                            tbОсн2.Text + оконч2 + tbОсн3.Text + оконч3;
                        Форма[] arrФорма = da.НайтиФормы(начФорма);
                        foreach (Форма f in arrФорма)
                            if (f.частьРечи == чр && f.постПризн.GetIndex() == кодПп)
                                throw new Exception("Слово уже имеется в словаре");
                                                
                        кодОкончНф = da.СоздатьОкончание(кодИп, оконч1, оконч2, оконч3);
                    }
                }

                int кодОсн = da.СоздатьОснову(чр, кодПп,
                    tbОсн1.Text, tbОсн2.Text, tbОсн3.Text, кодОкончНф);
                foreach (DataGridViewRow r in dgvMorph.Rows)
                {
                    int кодИп = (int)r.Cells["КодИзмПризн"].Value;
                    if ((bool)r.Cells["Наличие"].Value == false)
                        continue;
                    string оконч1 = (string)r.Cells["Оконч1"].Value;
                    string оконч2 = (string)r.Cells["Оконч2"].Value;
                    string оконч3 = (string)r.Cells["Оконч3"].Value;
                    int кодОконч;
                    if (кодИп != кодИпНф)
                    {
                        кодОконч = da.СоздатьОкончание(кодИп, оконч1, оконч2, оконч3);
                        da.СоздатьФорму(кодОсн, кодОконч);
                    }
                }

                if (chbAddTempl.Checked)
                {
                    da.СоздатьОбразец(кодОсн, tbНазв.Text, tbПрим.Text);
                }
                MessageBox.Show("Слово добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        void WordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }
        void chbИзм1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbИзм1.Checked)
            {
                dgvMorph.Columns["Оконч1"].Visible = true;
                tbОсн1.Visible = true;
            }
            else
            {
                dgvMorph.Columns["Оконч1"].Visible = false;
                tbОсн1.Visible = false;
            }
        }
        void chbИзм3_CheckedChanged(object sender, EventArgs e)
        {
            if (chbИзм3.Checked)
            {
                dgvMorph.Columns["Оконч3"].Visible = true;
                tbОсн3.Visible = true;
            }
            else
            {
                dgvMorph.Columns["Оконч3"].Visible = false;
                tbОсн3.Visible = false;
            }
        }
    }
}