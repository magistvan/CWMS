namespace Project.Ui
{
    partial class DocumentForm
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
            this.ContentTbx = new System.Windows.Forms.TextBox();
            this.KeywordsTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateDocumentButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DocumentNameTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DocumentTypeCbx = new System.Windows.Forms.ComboBox();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ModLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContentTbx
            // 
            this.ContentTbx.Location = new System.Drawing.Point(12, 12);
            this.ContentTbx.Multiline = true;
            this.ContentTbx.Name = "ContentTbx";
            this.ContentTbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContentTbx.Size = new System.Drawing.Size(614, 238);
            this.ContentTbx.TabIndex = 0;
            // 
            // KeywordsTbx
            // 
            this.KeywordsTbx.Location = new System.Drawing.Point(12, 451);
            this.KeywordsTbx.Multiline = true;
            this.KeywordsTbx.Name = "KeywordsTbx";
            this.KeywordsTbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KeywordsTbx.Size = new System.Drawing.Size(614, 76);
            this.KeywordsTbx.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Keywords:";
            // 
            // CreateDocumentButton
            // 
            this.CreateDocumentButton.BackColor = System.Drawing.SystemColors.Control;
            this.CreateDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateDocumentButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreateDocumentButton.Location = new System.Drawing.Point(549, 546);
            this.CreateDocumentButton.Name = "CreateDocumentButton";
            this.CreateDocumentButton.Size = new System.Drawing.Size(77, 23);
            this.CreateDocumentButton.TabIndex = 12;
            this.CreateDocumentButton.Text = "Save";
            this.CreateDocumentButton.UseVisualStyleBackColor = false;
            this.CreateDocumentButton.Click += new System.EventHandler(this.CreateDocumentButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description:";
            // 
            // DescriptionTbx
            // 
            this.DescriptionTbx.Location = new System.Drawing.Point(12, 336);
            this.DescriptionTbx.Multiline = true;
            this.DescriptionTbx.Name = "DescriptionTbx";
            this.DescriptionTbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTbx.Size = new System.Drawing.Size(614, 76);
            this.DescriptionTbx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Document name:";
            // 
            // DocumentNameTbx
            // 
            this.DocumentNameTbx.Location = new System.Drawing.Point(141, 279);
            this.DocumentNameTbx.Name = "DocumentNameTbx";
            this.DocumentNameTbx.Size = new System.Drawing.Size(209, 20);
            this.DocumentNameTbx.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(384, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Document type:";
            // 
            // DocumentTypeCbx
            // 
            this.DocumentTypeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocumentTypeCbx.FormattingEnabled = true;
            this.DocumentTypeCbx.Items.AddRange(new object[] {
            "WORD",
            "PDF"});
            this.DocumentTypeCbx.Location = new System.Drawing.Point(505, 279);
            this.DocumentTypeCbx.Name = "DocumentTypeCbx";
            this.DocumentTypeCbx.Size = new System.Drawing.Size(121, 21);
            this.DocumentTypeCbx.TabIndex = 2;
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.AutoSize = true;
            this.CreatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatedLabel.Location = new System.Drawing.Point(85, 549);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(61, 16);
            this.CreatedLabel.TabIndex = 18;
            this.CreatedLabel.Text = "created";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 549);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Created:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(251, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Modified:";
            // 
            // ModLabel
            // 
            this.ModLabel.AutoSize = true;
            this.ModLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModLabel.Location = new System.Drawing.Point(329, 549);
            this.ModLabel.Name = "ModLabel";
            this.ModLabel.Size = new System.Drawing.Size(68, 16);
            this.ModLabel.TabIndex = 21;
            this.ModLabel.Text = "modified";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(478, 549);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(59, 16);
            this.VersionLabel.TabIndex = 22;
            this.VersionLabel.Text = "version";
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 586);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ModLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CreatedLabel);
            this.Controls.Add(this.DocumentTypeCbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DocumentNameTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionTbx);
            this.Controls.Add(this.CreateDocumentButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeywordsTbx);
            this.Controls.Add(this.ContentTbx);
            this.MaximizeBox = false;
            this.Name = "DocumentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocumentForm";
            this.Load += new System.EventHandler(this.DocumentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ContentTbx;
        private System.Windows.Forms.TextBox KeywordsTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateDocumentButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DocumentNameTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DocumentTypeCbx;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ModLabel;
        private System.Windows.Forms.Label VersionLabel;
    }
}