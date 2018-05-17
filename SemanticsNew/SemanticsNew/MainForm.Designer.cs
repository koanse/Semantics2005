namespace SemanticsNew
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGpDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLFDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGPDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLFDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGPDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLFDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGPDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLFDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.licenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(445, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGpDictToolStripMenuItem,
            this.createLFDictToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createToolStripMenuItem.Text = "Создать";
            // 
            // createGpDictToolStripMenuItem
            // 
            this.createGpDictToolStripMenuItem.Name = "createGpDictToolStripMenuItem";
            this.createGpDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.createGpDictToolStripMenuItem.Text = "Словарь моделей управления";
            this.createGpDictToolStripMenuItem.Click += new System.EventHandler(this.createGpDictToolStripMenuItem_Click);
            // 
            // createLFDictToolStripMenuItem
            // 
            this.createLFDictToolStripMenuItem.Name = "createLFDictToolStripMenuItem";
            this.createLFDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.createLFDictToolStripMenuItem.Text = "Словарь лексических функций";
            this.createLFDictToolStripMenuItem.Click += new System.EventHandler(this.createLFDictToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGPDictToolStripMenuItem,
            this.openLFDictToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            // 
            // openGPDictToolStripMenuItem
            // 
            this.openGPDictToolStripMenuItem.Name = "openGPDictToolStripMenuItem";
            this.openGPDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.openGPDictToolStripMenuItem.Text = "Словарь моделей управления";
            this.openGPDictToolStripMenuItem.Click += new System.EventHandler(this.openGPDictToolStripMenuItem_Click);
            // 
            // openLFDictToolStripMenuItem
            // 
            this.openLFDictToolStripMenuItem.Name = "openLFDictToolStripMenuItem";
            this.openLFDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.openLFDictToolStripMenuItem.Text = "Словарь лексический функций";
            this.openLFDictToolStripMenuItem.Click += new System.EventHandler(this.openLFDictToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGPDictToolStripMenuItem,
            this.saveLFDictToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            // 
            // saveGPDictToolStripMenuItem
            // 
            this.saveGPDictToolStripMenuItem.Name = "saveGPDictToolStripMenuItem";
            this.saveGPDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.saveGPDictToolStripMenuItem.Text = "Словарь моделей управления";
            this.saveGPDictToolStripMenuItem.Click += new System.EventHandler(this.saveGPDictToolStripMenuItem_Click);
            // 
            // saveLFDictToolStripMenuItem
            // 
            this.saveLFDictToolStripMenuItem.Name = "saveLFDictToolStripMenuItem";
            this.saveLFDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.saveLFDictToolStripMenuItem.Text = "Словарь лексических функций";
            this.saveLFDictToolStripMenuItem.Click += new System.EventHandler(this.saveLFDictToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.editGPDictToolStripMenuItem,
            this.editLFDictToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editToolStripMenuItem.Text = "Правка";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importGPToolStripMenuItem,
            this.addLFToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.importToolStripMenuItem.Text = "Импорт";
            // 
            // importGPToolStripMenuItem
            // 
            this.importGPToolStripMenuItem.Name = "importGPToolStripMenuItem";
            this.importGPToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.importGPToolStripMenuItem.Text = "Модели управления";
            this.importGPToolStripMenuItem.Click += new System.EventHandler(this.importGPToolStripMenuItem_Click);
            // 
            // addLFToolStripMenuItem
            // 
            this.addLFToolStripMenuItem.Name = "addLFToolStripMenuItem";
            this.addLFToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addLFToolStripMenuItem.Text = "Лексические функции";
            this.addLFToolStripMenuItem.Click += new System.EventHandler(this.importLFToolStripMenuItem_Click);
            // 
            // editGPDictToolStripMenuItem
            // 
            this.editGPDictToolStripMenuItem.Name = "editGPDictToolStripMenuItem";
            this.editGPDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.editGPDictToolStripMenuItem.Text = "Словарь моделей управления";
            this.editGPDictToolStripMenuItem.Click += new System.EventHandler(this.editGPDictToolStripMenuItem_Click);
            // 
            // editLFDictToolStripMenuItem
            // 
            this.editLFDictToolStripMenuItem.Name = "editLFDictToolStripMenuItem";
            this.editLFDictToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.editLFDictToolStripMenuItem.Text = "Словарь лексических функций";
            this.editLFDictToolStripMenuItem.Click += new System.EventHandler(this.editLFDictToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.analysisToolStripMenuItem.Text = "Анализ";
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.compareToolStripMenuItem.Text = "Оценка близости предложений";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.licenceToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // licenceToolStripMenuItem
            // 
            this.licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            this.licenceToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.licenceToolStripMenuItem.Text = "Лицензионное соглашение Integra";
            this.licenceToolStripMenuItem.Click += new System.EventHandler(this.licenceToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 313);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Оценка близости предложений";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGPDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLFDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGpDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createLFDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGPDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLFDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGPDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLFDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenceToolStripMenuItem;
    }
}