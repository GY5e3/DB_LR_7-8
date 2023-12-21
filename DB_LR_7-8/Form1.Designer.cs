namespace DB_LR_7_8
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tableList = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.queryList = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.Size = new System.Drawing.Size(767, 418);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(785, 162);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(125, 50);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "SAVE CHANGES";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.onSaveChangesClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(785, 218);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(125, 50);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.onDeleteClick);
            // 
            // tableList
            // 
            this.tableList.FormattingEnabled = true;
            this.tableList.ItemHeight = 16;
            this.tableList.Location = new System.Drawing.Point(785, 40);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(155, 116);
            this.tableList.TabIndex = 3;
            this.tableList.SelectedIndexChanged += new System.EventHandler(this.SelectTableFromTableList);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(785, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "TABLES";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // queryList
            // 
            this.queryList.FormattingEnabled = true;
            this.queryList.ItemHeight = 16;
            this.queryList.Location = new System.Drawing.Point(972, 40);
            this.queryList.Name = "queryList";
            this.queryList.Size = new System.Drawing.Size(155, 116);
            this.queryList.TabIndex = 5;
            this.queryList.SelectedIndexChanged += new System.EventHandler(this.SelectQueryFromQueriesList);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(972, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 22);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "QUERIES";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 514);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.queryList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tableList);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.onForm1Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListBox tableList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox queryList;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

