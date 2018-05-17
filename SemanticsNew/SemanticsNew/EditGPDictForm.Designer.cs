namespace SemanticsNew
{
    partial class EditGPDictForm
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
            this.lbGp = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.labNum = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDict = new System.Windows.Forms.TabPage();
            this.tpFreq = new System.Windows.Forms.TabPage();
            this.lbGpFreq = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWMain = new System.Windows.Forms.TextBox();
            this.tbWAct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpDict.SuspendLayout();
            this.tpFreq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGp
            // 
            this.lbGp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGp.FormattingEnabled = true;
            this.lbGp.Location = new System.Drawing.Point(6, 6);
            this.lbGp.Name = "lbGp";
            this.lbGp.Size = new System.Drawing.Size(342, 160);
            this.lbGp.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(299, 354);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(273, 169);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // labNum
            // 
            this.labNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(6, 174);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(45, 13);
            this.labNum.TabIndex = 3;
            this.labNum.Text = "Объем:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpDict);
            this.tabControl1.Controls.Add(this.tpFreq);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(362, 225);
            this.tabControl1.TabIndex = 4;
            // 
            // tpDict
            // 
            this.tpDict.Controls.Add(this.lbGp);
            this.tpDict.Controls.Add(this.labNum);
            this.tpDict.Controls.Add(this.btnDel);
            this.tpDict.Location = new System.Drawing.Point(4, 22);
            this.tpDict.Name = "tpDict";
            this.tpDict.Padding = new System.Windows.Forms.Padding(3);
            this.tpDict.Size = new System.Drawing.Size(354, 199);
            this.tpDict.TabIndex = 0;
            this.tpDict.Text = "Словарь";
            this.tpDict.UseVisualStyleBackColor = true;
            // 
            // tpFreq
            // 
            this.tpFreq.Controls.Add(this.lbGpFreq);
            this.tpFreq.Location = new System.Drawing.Point(4, 22);
            this.tpFreq.Name = "tpFreq";
            this.tpFreq.Padding = new System.Windows.Forms.Padding(3);
            this.tpFreq.Size = new System.Drawing.Size(354, 199);
            this.tpFreq.TabIndex = 1;
            this.tpFreq.Text = "Частоты";
            this.tpFreq.UseVisualStyleBackColor = true;
            // 
            // lbGpFreq
            // 
            this.lbGpFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGpFreq.FormattingEnabled = true;
            this.lbGpFreq.Location = new System.Drawing.Point(6, 6);
            this.lbGpFreq.Name = "lbGpFreq";
            this.lbGpFreq.Size = new System.Drawing.Size(342, 186);
            this.lbGpFreq.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbConn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbWAct);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbWMain);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Главное слово:";
            // 
            // tbWMain
            // 
            this.tbWMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWMain.Location = new System.Drawing.Point(151, 19);
            this.tbWMain.Name = "tbWMain";
            this.tbWMain.Size = new System.Drawing.Size(204, 20);
            this.tbWMain.TabIndex = 1;
            // 
            // tbWAct
            // 
            this.tbWAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWAct.Location = new System.Drawing.Point(151, 45);
            this.tbWAct.Name = "tbWAct";
            this.tbWAct.Size = new System.Drawing.Size(204, 20);
            this.tbWAct.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Семантический актант:";
            // 
            // tbConn
            // 
            this.tbConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConn.Location = new System.Drawing.Point(151, 71);
            this.tbConn.Name = "tbConn";
            this.tbConn.Size = new System.Drawing.Size(204, 20);
            this.tbConn.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Слово-связка:";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(218, 354);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // EditGPDictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 389);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGPDictForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Словарь моделей управления";
            this.tabControl1.ResumeLayout(false);
            this.tpDict.ResumeLayout(false);
            this.tpDict.PerformLayout();
            this.tpFreq.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDict;
        private System.Windows.Forms.TabPage tpFreq;
        private System.Windows.Forms.ListBox lbGpFreq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbWMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWAct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFind;
    }
}