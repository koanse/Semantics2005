namespace SemanticsNew
{
    partial class ImportLFForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbArg = new System.Windows.Forms.TextBox();
            this.tbVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbArgDescr = new System.Windows.Forms.TextBox();
            this.tbValDescr = new System.Windows.Forms.TextBox();
            this.lvLf = new System.Windows.Forms.ListView();
            this.btnSkip = new System.Windows.Forms.Button();
            this.tbParam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(447, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(285, 304);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Аргумент:";
            // 
            // tbArg
            // 
            this.tbArg.Location = new System.Drawing.Point(12, 25);
            this.tbArg.Name = "tbArg";
            this.tbArg.Size = new System.Drawing.Size(510, 20);
            this.tbArg.TabIndex = 13;
            this.tbArg.TextChanged += new System.EventHandler(this.tbArg_TextChanged);
            // 
            // tbVal
            // 
            this.tbVal.Location = new System.Drawing.Point(12, 90);
            this.tbVal.Name = "tbVal";
            this.tbVal.Size = new System.Drawing.Size(510, 20);
            this.tbVal.TabIndex = 15;
            this.tbVal.TextChanged += new System.EventHandler(this.tbVal_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Значение:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Лексическая функция:";
            // 
            // tbArgDescr
            // 
            this.tbArgDescr.Enabled = false;
            this.tbArgDescr.Location = new System.Drawing.Point(12, 51);
            this.tbArgDescr.Name = "tbArgDescr";
            this.tbArgDescr.Size = new System.Drawing.Size(510, 20);
            this.tbArgDescr.TabIndex = 18;
            // 
            // tbValDescr
            // 
            this.tbValDescr.Enabled = false;
            this.tbValDescr.Location = new System.Drawing.Point(12, 116);
            this.tbValDescr.Name = "tbValDescr";
            this.tbValDescr.Size = new System.Drawing.Size(510, 20);
            this.tbValDescr.TabIndex = 19;
            // 
            // lvLf
            // 
            this.lvLf.HideSelection = false;
            this.lvLf.Location = new System.Drawing.Point(12, 194);
            this.lvLf.MultiSelect = false;
            this.lvLf.Name = "lvLf";
            this.lvLf.Size = new System.Drawing.Size(510, 104);
            this.lvLf.TabIndex = 51;
            this.lvLf.UseCompatibleStateImageBehavior = false;
            this.lvLf.View = System.Windows.Forms.View.List;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(366, 304);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 40;
            this.btnSkip.Text = "Пропустить";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // tbParam
            // 
            this.tbParam.Location = new System.Drawing.Point(12, 155);
            this.tbParam.Name = "tbParam";
            this.tbParam.Size = new System.Drawing.Size(510, 20);
            this.tbParam.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Параметр:";
            // 
            // ImportLFForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(534, 339);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbParam);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.lvLf);
            this.Controls.Add(this.tbValDescr);
            this.Controls.Add(this.tbArgDescr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbArg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportLFForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Добавление лексических функций";
            this.Load += new System.EventHandler(this.AddLFForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbArg;
        private System.Windows.Forms.TextBox tbVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbArgDescr;
        private System.Windows.Forms.TextBox tbValDescr;
        private System.Windows.Forms.ListView lvLf;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TextBox tbParam;
        private System.Windows.Forms.Label label4;
    }
}