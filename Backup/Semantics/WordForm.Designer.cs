namespace Semantics
{
    partial class WordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.cbПп = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMorph = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbЧр = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chbAddTempl = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbНазв = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbПрим = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbОсн2 = new System.Windows.Forms.TextBox();
            this.tbОсн1 = new System.Windows.Forms.TextBox();
            this.tbОсн3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbНф = new System.Windows.Forms.ComboBox();
            this.chbИзм1 = new System.Windows.Forms.CheckBox();
            this.chbИзм3 = new System.Windows.Forms.CheckBox();
            this.Наличие = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.КодИзмПризн = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ИзмПризн = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Оконч1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Оконч2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Оконч3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Форма = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Постоянные признаки:";
            // 
            // cbПп
            // 
            this.cbПп.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbПп.FormattingEnabled = true;
            this.cbПп.Location = new System.Drawing.Point(215, 65);
            this.cbПп.Name = "cbПп";
            this.cbПп.Size = new System.Drawing.Size(234, 21);
            this.cbПп.TabIndex = 5;
            this.cbПп.SelectedIndexChanged += new System.EventHandler(this.cbПп_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvMorph);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 111);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Формы";
            // 
            // dgvMorph
            // 
            this.dgvMorph.AllowUserToAddRows = false;
            this.dgvMorph.AllowUserToDeleteRows = false;
            this.dgvMorph.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMorph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMorph.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Наличие,
            this.КодИзмПризн,
            this.ИзмПризн,
            this.Оконч1,
            this.Оконч2,
            this.Оконч3,
            this.Форма});
            this.dgvMorph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMorph.Location = new System.Drawing.Point(3, 16);
            this.dgvMorph.Name = "dgvMorph";
            this.dgvMorph.Size = new System.Drawing.Size(431, 92);
            this.dgvMorph.TabIndex = 8;
            this.dgvMorph.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMorph_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Часть речи:";
            // 
            // cbЧр
            // 
            this.cbЧр.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbЧр.FormattingEnabled = true;
            this.cbЧр.Location = new System.Drawing.Point(215, 12);
            this.cbЧр.Name = "cbЧр";
            this.cbЧр.Size = new System.Drawing.Size(234, 21);
            this.cbЧр.TabIndex = 1;
            this.cbЧр.SelectedIndexChanged += new System.EventHandler(this.cbЧр_SelectedValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(374, 343);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(293, 343);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chbAddTempl
            // 
            this.chbAddTempl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbAddTempl.AutoSize = true;
            this.chbAddTempl.Location = new System.Drawing.Point(12, 236);
            this.chbAddTempl.Name = "chbAddTempl";
            this.chbAddTempl.Size = new System.Drawing.Size(113, 17);
            this.chbAddTempl.TabIndex = 9;
            this.chbAddTempl.Text = "Создать образец";
            this.chbAddTempl.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbНазв);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbПрим);
            this.groupBox1.Location = new System.Drawing.Point(12, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 78);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Образец";
            // 
            // tbНазв
            // 
            this.tbНазв.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbНазв.Location = new System.Drawing.Point(111, 19);
            this.tbНазв.Name = "tbНазв";
            this.tbНазв.Size = new System.Drawing.Size(317, 20);
            this.tbНазв.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Примечание";
            // 
            // tbПрим
            // 
            this.tbПрим.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbПрим.Location = new System.Drawing.Point(111, 45);
            this.tbПрим.Name = "tbПрим";
            this.tbПрим.Size = new System.Drawing.Size(317, 20);
            this.tbПрим.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Постоянные части:";
            // 
            // tbОсн2
            // 
            this.tbОсн2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbОсн2.Location = new System.Drawing.Point(215, 39);
            this.tbОсн2.Name = "tbОсн2";
            this.tbОсн2.Size = new System.Drawing.Size(152, 20);
            this.tbОсн2.TabIndex = 3;
            this.tbОсн2.TextChanged += new System.EventHandler(this.tbОсн_TextChanged);
            // 
            // tbОсн1
            // 
            this.tbОсн1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbОсн1.Location = new System.Drawing.Point(133, 39);
            this.tbОсн1.Name = "tbОсн1";
            this.tbОсн1.Size = new System.Drawing.Size(74, 20);
            this.tbОсн1.TabIndex = 2;
            this.tbОсн1.Visible = false;
            this.tbОсн1.TextChanged += new System.EventHandler(this.tbОсн_TextChanged);
            // 
            // tbОсн3
            // 
            this.tbОсн3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbОсн3.Location = new System.Drawing.Point(375, 39);
            this.tbОсн3.Name = "tbОсн3";
            this.tbОсн3.Size = new System.Drawing.Size(74, 20);
            this.tbОсн3.TabIndex = 4;
            this.tbОсн3.Visible = false;
            this.tbОсн3.TextChanged += new System.EventHandler(this.tbОсн_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Начальная форма:";
            // 
            // cbНф
            // 
            this.cbНф.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbНф.FormattingEnabled = true;
            this.cbНф.Location = new System.Drawing.Point(215, 92);
            this.cbНф.Name = "cbНф";
            this.cbНф.Size = new System.Drawing.Size(234, 21);
            this.cbНф.TabIndex = 6;
            // 
            // chbИзм1
            // 
            this.chbИзм1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbИзм1.AutoSize = true;
            this.chbИзм1.Location = new System.Drawing.Point(261, 236);
            this.chbИзм1.Name = "chbИзм1";
            this.chbИзм1.Size = new System.Drawing.Size(91, 17);
            this.chbИзм1.TabIndex = 47;
            this.chbИзм1.Text = "Изм. часть 1";
            this.chbИзм1.UseVisualStyleBackColor = true;
            this.chbИзм1.CheckedChanged += new System.EventHandler(this.chbИзм1_CheckedChanged);
            // 
            // chbИзм3
            // 
            this.chbИзм3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbИзм3.AutoSize = true;
            this.chbИзм3.Location = new System.Drawing.Point(358, 236);
            this.chbИзм3.Name = "chbИзм3";
            this.chbИзм3.Size = new System.Drawing.Size(91, 17);
            this.chbИзм3.TabIndex = 48;
            this.chbИзм3.Text = "Изм. часть 3";
            this.chbИзм3.UseVisualStyleBackColor = true;
            this.chbИзм3.CheckedChanged += new System.EventHandler(this.chbИзм3_CheckedChanged);
            // 
            // Наличие
            // 
            this.Наличие.HeaderText = "Наличие";
            this.Наличие.Name = "Наличие";
            // 
            // КодИзмПризн
            // 
            this.КодИзмПризн.HeaderText = "Код изм. призн.";
            this.КодИзмПризн.Name = "КодИзмПризн";
            this.КодИзмПризн.ReadOnly = true;
            this.КодИзмПризн.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.КодИзмПризн.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.КодИзмПризн.Visible = false;
            // 
            // ИзмПризн
            // 
            this.ИзмПризн.HeaderText = "Признаки";
            this.ИзмПризн.Name = "ИзмПризн";
            this.ИзмПризн.ReadOnly = true;
            // 
            // Оконч1
            // 
            this.Оконч1.HeaderText = "Изм. часть 1";
            this.Оконч1.Name = "Оконч1";
            this.Оконч1.Visible = false;
            // 
            // Оконч2
            // 
            this.Оконч2.HeaderText = "Изм. часть 2";
            this.Оконч2.Name = "Оконч2";
            // 
            // Оконч3
            // 
            this.Оконч3.HeaderText = "Изм. часть 3";
            this.Оконч3.Name = "Оконч3";
            this.Оконч3.Visible = false;
            // 
            // Форма
            // 
            this.Форма.HeaderText = "Форма";
            this.Форма.Name = "Форма";
            this.Форма.ReadOnly = true;
            // 
            // WordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 378);
            this.Controls.Add(this.chbИзм3);
            this.Controls.Add(this.chbИзм1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbНф);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbОсн2);
            this.Controls.Add(this.tbОсн1);
            this.Controls.Add(this.tbОсн3);
            this.Controls.Add(this.chbAddTempl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbПп);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbЧр);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreate);
            this.MinimumSize = new System.Drawing.Size(469, 412);
            this.Name = "WordForm";
            this.ShowIcon = false;
            this.Text = "Добавление слова";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WordForm_FormClosed);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbПп;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMorph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbЧр;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox chbAddTempl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbНазв;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbПрим;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbОсн2;
        private System.Windows.Forms.TextBox tbОсн1;
        private System.Windows.Forms.TextBox tbОсн3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbНф;
        private System.Windows.Forms.CheckBox chbИзм1;
        private System.Windows.Forms.CheckBox chbИзм3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Наличие;
        private System.Windows.Forms.DataGridViewTextBoxColumn КодИзмПризн;
        private System.Windows.Forms.DataGridViewTextBoxColumn ИзмПризн;
        private System.Windows.Forms.DataGridViewTextBoxColumn Оконч1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Оконч2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Оконч3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Форма;
    }
}