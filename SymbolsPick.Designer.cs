namespace S7Connection
{
    partial class SymbolsPick
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
            this.Symbole_dataGridView = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SymboleFilePath_text = new System.Windows.Forms.TextBox();
            this.SymbolFilePath_label = new System.Windows.Forms.Label();
            this.Open_button = new System.Windows.Forms.Button();
            this.Select_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Symbole_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Symbole_dataGridView
            // 
            this.Symbole_dataGridView.AllowUserToAddRows = false;
            this.Symbole_dataGridView.AllowUserToDeleteRows = false;
            this.Symbole_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Symbole_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Symbole_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Symbole_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.Address,
            this.DataType,
            this.Comment});
            this.Symbole_dataGridView.Location = new System.Drawing.Point(0, 44);
            this.Symbole_dataGridView.Name = "Symbole_dataGridView";
            this.Symbole_dataGridView.ReadOnly = true;
            this.Symbole_dataGridView.RowHeadersVisible = false;
            this.Symbole_dataGridView.RowTemplate.Height = 24;
            this.Symbole_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Symbole_dataGridView.Size = new System.Drawing.Size(784, 709);
            this.Symbole_dataGridView.TabIndex = 0;
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
            // SymboleFilePath_text
            // 
            this.SymboleFilePath_text.Location = new System.Drawing.Point(138, 11);
            this.SymboleFilePath_text.Name = "SymboleFilePath_text";
            this.SymboleFilePath_text.Size = new System.Drawing.Size(293, 22);
            this.SymboleFilePath_text.TabIndex = 1;
            // 
            // SymbolFilePath_label
            // 
            this.SymbolFilePath_label.AutoSize = true;
            this.SymbolFilePath_label.Location = new System.Drawing.Point(25, 15);
            this.SymbolFilePath_label.Name = "SymbolFilePath_label";
            this.SymbolFilePath_label.Size = new System.Drawing.Size(98, 14);
            this.SymbolFilePath_label.TabIndex = 2;
            this.SymbolFilePath_label.Text = "Symbol List Path:";
            // 
            // Open_button
            // 
            this.Open_button.Location = new System.Drawing.Point(437, 11);
            this.Open_button.Name = "Open_button";
            this.Open_button.Size = new System.Drawing.Size(75, 26);
            this.Open_button.TabIndex = 3;
            this.Open_button.Text = "Open";
            this.Open_button.UseVisualStyleBackColor = true;
            this.Open_button.Click += new System.EventHandler(this.Open_button_Click);
            // 
            // Select_button
            // 
            this.Select_button.Location = new System.Drawing.Point(627, 12);
            this.Select_button.Name = "Select_button";
            this.Select_button.Size = new System.Drawing.Size(75, 26);
            this.Select_button.TabIndex = 4;
            this.Select_button.Text = "Select";
            this.Select_button.UseVisualStyleBackColor = true;
            this.Select_button.Click += new System.EventHandler(this.Select_button_Click);
            // 
            // SymbolsPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 753);
            this.Controls.Add(this.Select_button);
            this.Controls.Add(this.Open_button);
            this.Controls.Add(this.SymbolFilePath_label);
            this.Controls.Add(this.SymboleFilePath_text);
            this.Controls.Add(this.Symbole_dataGridView);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SymbolsPick";
            this.ShowIcon = false;
            this.Text = "SymbolePicker";
            this.Load += new System.EventHandler(this.SymbolePicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Symbole_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Symbole_dataGridView;
        private System.Windows.Forms.TextBox SymboleFilePath_text;
        private System.Windows.Forms.Label SymbolFilePath_label;
        private System.Windows.Forms.Button Open_button;
        private System.Windows.Forms.Button Select_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}