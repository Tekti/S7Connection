namespace S7Connection
{
    partial class DBpicker
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
            this.Select_button = new System.Windows.Forms.Button();
            this.Open_button = new System.Windows.Forms.Button();
            this.SymbolFilePath_label = new System.Windows.Forms.Label();
            this.SymboleFilePath_text = new System.Windows.Forms.TextBox();
            this.Symbole_dataGridView = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Symbole_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_button
            // 
            this.Select_button.Location = new System.Drawing.Point(625, 8);
            this.Select_button.Name = "Select_button";
            this.Select_button.Size = new System.Drawing.Size(75, 26);
            this.Select_button.TabIndex = 9;
            this.Select_button.Text = "Select";
            this.Select_button.UseVisualStyleBackColor = true;
            this.Select_button.Click += new System.EventHandler(this.Select_button_Click);
            // 
            // Open_button
            // 
            this.Open_button.Location = new System.Drawing.Point(405, 8);
            this.Open_button.Name = "Open_button";
            this.Open_button.Size = new System.Drawing.Size(75, 26);
            this.Open_button.TabIndex = 8;
            this.Open_button.Text = "Open";
            this.Open_button.UseVisualStyleBackColor = true;
            this.Open_button.Click += new System.EventHandler(this.Open_button_Click);
            // 
            // SymbolFilePath_label
            // 
            this.SymbolFilePath_label.AutoSize = true;
            this.SymbolFilePath_label.Location = new System.Drawing.Point(12, 15);
            this.SymbolFilePath_label.Name = "SymbolFilePath_label";
            this.SymbolFilePath_label.Size = new System.Drawing.Size(88, 13);
            this.SymbolFilePath_label.TabIndex = 7;
            this.SymbolFilePath_label.Text = "Symbol List Path:";
            // 
            // SymboleFilePath_text
            // 
            this.SymboleFilePath_text.Location = new System.Drawing.Point(106, 12);
            this.SymboleFilePath_text.Name = "SymboleFilePath_text";
            this.SymboleFilePath_text.Size = new System.Drawing.Size(293, 20);
            this.SymboleFilePath_text.TabIndex = 6;
            // 
            // Symbole_dataGridView
            // 
            this.Symbole_dataGridView.AllowUserToAddRows = false;
            this.Symbole_dataGridView.AllowUserToDeleteRows = false;
            this.Symbole_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Symbole_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Symbole_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.Address,
            this.DataType,
            this.Comment});
            this.Symbole_dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Symbole_dataGridView.Location = new System.Drawing.Point(0, 44);
            this.Symbole_dataGridView.Name = "Symbole_dataGridView";
            this.Symbole_dataGridView.ReadOnly = true;
            this.Symbole_dataGridView.RowHeadersVisible = false;
            this.Symbole_dataGridView.RowTemplate.Height = 24;
            this.Symbole_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Symbole_dataGridView.Size = new System.Drawing.Size(784, 709);
            this.Symbole_dataGridView.TabIndex = 5;
            // 
            // Symbol
            // 
            this.Symbol.FillWeight = 50F;
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.FillWeight = 50F;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // DataType
            // 
            this.DataType.FillWeight = 30F;
            this.DataType.HeaderText = "Data Type";
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(486, 11);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(121, 21);
            this.cboSheet.TabIndex = 10;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // DBpicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 753);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.Select_button);
            this.Controls.Add(this.Open_button);
            this.Controls.Add(this.SymbolFilePath_label);
            this.Controls.Add(this.SymboleFilePath_text);
            this.Controls.Add(this.Symbole_dataGridView);
            this.Name = "DBpicker";
            this.Text = "DB picker";
            this.Load += new System.EventHandler(this.DBpicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Symbole_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Select_button;
        private System.Windows.Forms.Button Open_button;
        private System.Windows.Forms.Label SymbolFilePath_label;
        private System.Windows.Forms.TextBox SymboleFilePath_text;
        private System.Windows.Forms.DataGridView Symbole_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.ComboBox cboSheet;
    }
}