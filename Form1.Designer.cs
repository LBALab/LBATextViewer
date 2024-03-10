namespace LBA1TextViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lvText = new ListView();
            chEnglish = new ColumnHeader();
            chFrench = new ColumnHeader();
            chItalian = new ColumnHeader();
            chGerman = new ColumnHeader();
            chSpanish = new ColumnHeader();
            chPortuguese = new ColumnHeader();
            chJapanese = new ColumnHeader();
            lblSearch = new Label();
            txtSearchText = new TextBox();
            cboLanguage = new ComboBox();
            lblLanguage = new Label();
            btnSearch = new Button();
            btnClearFilter = new Button();
            btnPopulateFromTextFiles = new Button();
            btnPopulateSpreadsheet = new Button();
            btnDumpToFile = new Button();
            SuspendLayout();
            // 
            // lvText
            // 
            lvText.AllowColumnReorder = true;
            lvText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvText.Columns.AddRange(new ColumnHeader[] { chEnglish, chFrench, chItalian, chGerman, chSpanish, chPortuguese, chJapanese });
            lvText.FullRowSelect = true;
            lvText.GridLines = true;
            lvText.Location = new Point(12, 40);
            lvText.Name = "lvText";
            lvText.Size = new Size(1003, 434);
            lvText.TabIndex = 0;
            lvText.UseCompatibleStateImageBehavior = false;
            lvText.View = View.Details;
            lvText.Click += lvText_Click;
            lvText.DoubleClick += lvText_DoubleClick;
            lvText.Resize += listView1_Resize;
            // 
            // chEnglish
            // 
            chEnglish.Text = "English";
            // 
            // chFrench
            // 
            chFrench.Text = "Français";
            // 
            // chItalian
            // 
            chItalian.Text = "Italiano";
            // 
            // chGerman
            // 
            chGerman.Text = "Deutsch";
            // 
            // chSpanish
            // 
            chSpanish.Text = "Español";
            // 
            // chPortuguese
            // 
            chPortuguese.Text = "Portuguese";
            // 
            // chJapanese
            // 
            chJapanese.Text = "Japanese";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSearch.Location = new Point(12, 13);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // txtSearchText
            // 
            txtSearchText.Location = new Point(63, 10);
            txtSearchText.Name = "txtSearchText";
            txtSearchText.Size = new Size(281, 23);
            txtSearchText.TabIndex = 2;
            txtSearchText.Click += txtSearchText_Click;
            // 
            // cboLanguage
            // 
            cboLanguage.FormattingEnabled = true;
            cboLanguage.Location = new Point(416, 11);
            cboLanguage.Name = "cboLanguage";
            cboLanguage.Size = new Size(187, 23);
            cboLanguage.TabIndex = 3;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblLanguage.Location = new Point(350, 15);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(60, 15);
            lblLanguage.TabIndex = 4;
            lblLanguage.Text = "Language";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(609, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Filter";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Location = new Point(690, 10);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(77, 22);
            btnClearFilter.TabIndex = 6;
            btnClearFilter.Text = "Clear";
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Visible = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // btnPopulateFromTextFiles
            // 
            btnPopulateFromTextFiles.Location = new Point(773, 10);
            btnPopulateFromTextFiles.Name = "btnPopulateFromTextFiles";
            btnPopulateFromTextFiles.Size = new Size(66, 23);
            btnPopulateFromTextFiles.TabIndex = 7;
            btnPopulateFromTextFiles.Text = "Pop File";
            btnPopulateFromTextFiles.UseVisualStyleBackColor = true;
            btnPopulateFromTextFiles.Visible = false;
            btnPopulateFromTextFiles.Click += btnPopulateFromTextFiles_Click;
            // 
            // btnPopulateSpreadsheet
            // 
            btnPopulateSpreadsheet.Location = new Point(845, 9);
            btnPopulateSpreadsheet.Name = "btnPopulateSpreadsheet";
            btnPopulateSpreadsheet.Size = new Size(72, 24);
            btnPopulateSpreadsheet.TabIndex = 8;
            btnPopulateSpreadsheet.Text = "Pop XLS";
            btnPopulateSpreadsheet.UseVisualStyleBackColor = true;
            btnPopulateSpreadsheet.Visible = false;
            btnPopulateSpreadsheet.Click += btnPopulateSpreadsheet_Click;
            // 
            // btnDumpToFile
            // 
            btnDumpToFile.Location = new Point(923, 9);
            btnDumpToFile.Name = "btnDumpToFile";
            btnDumpToFile.Size = new Size(75, 23);
            btnDumpToFile.TabIndex = 9;
            btnDumpToFile.Text = "Dump";
            btnDumpToFile.UseVisualStyleBackColor = true;
            btnDumpToFile.Click += btnOutputToFile_Click;
            // 
            // Form1
            // 
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 486);
            Controls.Add(btnDumpToFile);
            Controls.Add(btnPopulateSpreadsheet);
            Controls.Add(btnPopulateFromTextFiles);
            Controls.Add(btnClearFilter);
            Controls.Add(btnSearch);
            Controls.Add(lblLanguage);
            Controls.Add(cboLanguage);
            Controls.Add(txtSearchText);
            Controls.Add(lblSearch);
            Controls.Add(lvText);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Text Viewer";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvText;
        private ColumnHeader chEnglish;
        private ColumnHeader chFrench;
        private ColumnHeader chItalian;
        private ColumnHeader chGerman;
        private ColumnHeader chSpanish;
        private Label lblSearch;
        private TextBox txtSearchText;
        private ComboBox cboLanguage;
        private Label lblLanguage;
        private Button btnSearch;
        private Button btnClearFilter;
        private Button btnPopulateFromTextFiles;
        private Button btnPopulateSpreadsheet;
        private Button btnDumpToFile;
        private ColumnHeader chPortuguese;
        private ColumnHeader chJapanese;
    }
}