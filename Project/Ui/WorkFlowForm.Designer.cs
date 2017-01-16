namespace Project.Ui
{
    partial class WorkFlowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkFlowForm));
            this.WorkFlowTabControl = new System.Windows.Forms.TabControl();
            this.WorkZone = new System.Windows.Forms.TabPage();
            this.OpenDocBtn = new System.Windows.Forms.Button();
            this.UserRoleValueLabel = new System.Windows.Forms.Label();
            this.UserRoleValue = new System.Windows.Forms.Label();
            this.EmailValueLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.UserNameValueLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.DocumentListView = new System.Windows.Forms.ListView();
            this.CreateDocumentButton = new System.Windows.Forms.Button();
            this.UploadDocumentButton = new System.Windows.Forms.Button();
            this.DeleteDocumentButton = new System.Windows.Forms.Button();
            this.InitiateTask = new System.Windows.Forms.TabPage();
            this.AddDocToFlowBrn = new System.Windows.Forms.Button();
            this.CreateFlowBtn = new System.Windows.Forms.Button();
            this.FlowDocsView = new System.Windows.Forms.ListView();
            this.FlowListView = new System.Windows.Forms.ListView();
            this.TaskZone = new System.Windows.Forms.TabPage();
            this.TerminateTask = new System.Windows.Forms.TabPage();
            this.UploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChangePWBtn = new System.Windows.Forms.Button();
            this.AddUserBtn = new System.Windows.Forms.Button();
            this.WorkFlowTabControl.SuspendLayout();
            this.WorkZone.SuspendLayout();
            this.InitiateTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkFlowTabControl
            // 
            this.WorkFlowTabControl.Controls.Add(this.WorkZone);
            this.WorkFlowTabControl.Controls.Add(this.InitiateTask);
            this.WorkFlowTabControl.Controls.Add(this.TaskZone);
            this.WorkFlowTabControl.Controls.Add(this.TerminateTask);
            this.WorkFlowTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkFlowTabControl.Location = new System.Drawing.Point(0, 0);
            this.WorkFlowTabControl.Name = "WorkFlowTabControl";
            this.WorkFlowTabControl.SelectedIndex = 0;
            this.WorkFlowTabControl.Size = new System.Drawing.Size(746, 502);
            this.WorkFlowTabControl.TabIndex = 0;
            this.WorkFlowTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.WorkFlowTabControl_Selecting);
            // 
            // WorkZone
            // 
            this.WorkZone.BackColor = System.Drawing.SystemColors.Control;
            this.WorkZone.Controls.Add(this.AddUserBtn);
            this.WorkZone.Controls.Add(this.ChangePWBtn);
            this.WorkZone.Controls.Add(this.OpenDocBtn);
            this.WorkZone.Controls.Add(this.UserRoleValueLabel);
            this.WorkZone.Controls.Add(this.UserRoleValue);
            this.WorkZone.Controls.Add(this.EmailValueLabel);
            this.WorkZone.Controls.Add(this.EmailLabel);
            this.WorkZone.Controls.Add(this.UserNameValueLabel);
            this.WorkZone.Controls.Add(this.UserNameLabel);
            this.WorkZone.Controls.Add(this.DocumentListView);
            this.WorkZone.Controls.Add(this.CreateDocumentButton);
            this.WorkZone.Controls.Add(this.UploadDocumentButton);
            this.WorkZone.Controls.Add(this.DeleteDocumentButton);
            this.WorkZone.Location = new System.Drawing.Point(4, 22);
            this.WorkZone.Name = "WorkZone";
            this.WorkZone.Padding = new System.Windows.Forms.Padding(3);
            this.WorkZone.Size = new System.Drawing.Size(738, 476);
            this.WorkZone.TabIndex = 0;
            this.WorkZone.Text = "Work Zone";
            // 
            // OpenDocBtn
            // 
            this.OpenDocBtn.BackColor = System.Drawing.SystemColors.Control;
            this.OpenDocBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenDocBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OpenDocBtn.Location = new System.Drawing.Point(509, 306);
            this.OpenDocBtn.Name = "OpenDocBtn";
            this.OpenDocBtn.Size = new System.Drawing.Size(224, 23);
            this.OpenDocBtn.TabIndex = 12;
            this.OpenDocBtn.Text = "View Document";
            this.OpenDocBtn.UseVisualStyleBackColor = false;
            this.OpenDocBtn.Click += new System.EventHandler(this.OpenDocBtn_Click);
            // 
            // UserRoleValueLabel
            // 
            this.UserRoleValueLabel.AutoSize = true;
            this.UserRoleValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRoleValueLabel.Location = new System.Drawing.Point(604, 78);
            this.UserRoleValueLabel.Name = "UserRoleValueLabel";
            this.UserRoleValueLabel.Size = new System.Drawing.Size(45, 16);
            this.UserRoleValueLabel.TabIndex = 11;
            this.UserRoleValueLabel.Text = "label6";
            // 
            // UserRoleValue
            // 
            this.UserRoleValue.AutoSize = true;
            this.UserRoleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRoleValue.Location = new System.Drawing.Point(509, 78);
            this.UserRoleValue.Name = "UserRoleValue";
            this.UserRoleValue.Size = new System.Drawing.Size(82, 16);
            this.UserRoleValue.TabIndex = 10;
            this.UserRoleValue.Text = "User Role:";
            // 
            // EmailValueLabel
            // 
            this.EmailValueLabel.AutoSize = true;
            this.EmailValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailValueLabel.Location = new System.Drawing.Point(605, 52);
            this.EmailValueLabel.Name = "EmailValueLabel";
            this.EmailValueLabel.Size = new System.Drawing.Size(45, 16);
            this.EmailValueLabel.TabIndex = 9;
            this.EmailValueLabel.Text = "label4";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(509, 52);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(51, 16);
            this.EmailLabel.TabIndex = 8;
            this.EmailLabel.Text = "Email:";
            // 
            // UserNameValueLabel
            // 
            this.UserNameValueLabel.AutoSize = true;
            this.UserNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameValueLabel.Location = new System.Drawing.Point(605, 25);
            this.UserNameValueLabel.Name = "UserNameValueLabel";
            this.UserNameValueLabel.Size = new System.Drawing.Size(45, 16);
            this.UserNameValueLabel.TabIndex = 7;
            this.UserNameValueLabel.Text = "label2";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.Location = new System.Drawing.Point(509, 25);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(90, 16);
            this.UserNameLabel.TabIndex = 6;
            this.UserNameLabel.Text = "User Name:";
            // 
            // DocumentListView
            // 
            this.DocumentListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.DocumentListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentListView.FullRowSelect = true;
            this.DocumentListView.Location = new System.Drawing.Point(3, 3);
            this.DocumentListView.MultiSelect = false;
            this.DocumentListView.Name = "DocumentListView";
            this.DocumentListView.Size = new System.Drawing.Size(500, 470);
            this.DocumentListView.TabIndex = 5;
            this.DocumentListView.UseCompatibleStateImageBehavior = false;
            this.DocumentListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DocumentListView_MouseDoubleClick);
            // 
            // CreateDocumentButton
            // 
            this.CreateDocumentButton.BackColor = System.Drawing.SystemColors.Control;
            this.CreateDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateDocumentButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreateDocumentButton.Location = new System.Drawing.Point(508, 391);
            this.CreateDocumentButton.Name = "CreateDocumentButton";
            this.CreateDocumentButton.Size = new System.Drawing.Size(224, 23);
            this.CreateDocumentButton.TabIndex = 4;
            this.CreateDocumentButton.Text = "Create Document";
            this.CreateDocumentButton.UseVisualStyleBackColor = false;
            this.CreateDocumentButton.Click += new System.EventHandler(this.CreateDocumentButton_Click);
            // 
            // UploadDocumentButton
            // 
            this.UploadDocumentButton.BackColor = System.Drawing.SystemColors.Control;
            this.UploadDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadDocumentButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UploadDocumentButton.Location = new System.Drawing.Point(508, 420);
            this.UploadDocumentButton.Name = "UploadDocumentButton";
            this.UploadDocumentButton.Size = new System.Drawing.Size(224, 23);
            this.UploadDocumentButton.TabIndex = 3;
            this.UploadDocumentButton.Text = "Upload Document";
            this.UploadDocumentButton.UseVisualStyleBackColor = false;
            this.UploadDocumentButton.Click += new System.EventHandler(this.UploadDocumentButton_Click);
            // 
            // DeleteDocumentButton
            // 
            this.DeleteDocumentButton.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteDocumentButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteDocumentButton.Location = new System.Drawing.Point(508, 449);
            this.DeleteDocumentButton.Name = "DeleteDocumentButton";
            this.DeleteDocumentButton.Size = new System.Drawing.Size(224, 23);
            this.DeleteDocumentButton.TabIndex = 2;
            this.DeleteDocumentButton.Text = "Delete Document";
            this.DeleteDocumentButton.UseVisualStyleBackColor = false;
            this.DeleteDocumentButton.Click += new System.EventHandler(this.DeleteDocumentButton_Click);
            // 
            // InitiateTask
            // 
            this.InitiateTask.BackColor = System.Drawing.SystemColors.Control;
            this.InitiateTask.Controls.Add(this.AddDocToFlowBrn);
            this.InitiateTask.Controls.Add(this.CreateFlowBtn);
            this.InitiateTask.Controls.Add(this.FlowDocsView);
            this.InitiateTask.Controls.Add(this.FlowListView);
            this.InitiateTask.Location = new System.Drawing.Point(4, 22);
            this.InitiateTask.Name = "InitiateTask";
            this.InitiateTask.Padding = new System.Windows.Forms.Padding(3);
            this.InitiateTask.Size = new System.Drawing.Size(738, 476);
            this.InitiateTask.TabIndex = 1;
            this.InitiateTask.Text = "Initiate Tasks";
            // 
            // AddDocToFlowBrn
            // 
            this.AddDocToFlowBrn.BackColor = System.Drawing.SystemColors.Control;
            this.AddDocToFlowBrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDocToFlowBrn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddDocToFlowBrn.Location = new System.Drawing.Point(508, 266);
            this.AddDocToFlowBrn.Name = "AddDocToFlowBrn";
            this.AddDocToFlowBrn.Size = new System.Drawing.Size(224, 23);
            this.AddDocToFlowBrn.TabIndex = 9;
            this.AddDocToFlowBrn.Text = "Add Document to Flow";
            this.AddDocToFlowBrn.UseVisualStyleBackColor = false;
            this.AddDocToFlowBrn.Click += new System.EventHandler(this.AddDocToFlowBrn_Click);
            // 
            // CreateFlowBtn
            // 
            this.CreateFlowBtn.BackColor = System.Drawing.SystemColors.Control;
            this.CreateFlowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateFlowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreateFlowBtn.Location = new System.Drawing.Point(506, 6);
            this.CreateFlowBtn.Name = "CreateFlowBtn";
            this.CreateFlowBtn.Size = new System.Drawing.Size(224, 23);
            this.CreateFlowBtn.TabIndex = 8;
            this.CreateFlowBtn.Text = "Create Flow";
            this.CreateFlowBtn.UseVisualStyleBackColor = false;
            this.CreateFlowBtn.Click += new System.EventHandler(this.CreateFlowBtn_Click);
            // 
            // FlowDocsView
            // 
            this.FlowDocsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlowDocsView.FullRowSelect = true;
            this.FlowDocsView.Location = new System.Drawing.Point(1, 266);
            this.FlowDocsView.MultiSelect = false;
            this.FlowDocsView.Name = "FlowDocsView";
            this.FlowDocsView.Size = new System.Drawing.Size(500, 207);
            this.FlowDocsView.TabIndex = 7;
            this.FlowDocsView.UseCompatibleStateImageBehavior = false;
            // 
            // FlowListView
            // 
            this.FlowListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlowListView.FullRowSelect = true;
            this.FlowListView.Location = new System.Drawing.Point(1, 2);
            this.FlowListView.MultiSelect = false;
            this.FlowListView.Name = "FlowListView";
            this.FlowListView.Size = new System.Drawing.Size(500, 207);
            this.FlowListView.TabIndex = 6;
            this.FlowListView.UseCompatibleStateImageBehavior = false;
            this.FlowListView.SelectedIndexChanged += new System.EventHandler(this.FlowListView_SelectedIndexChanged);
            // 
            // TaskZone
            // 
            this.TaskZone.Location = new System.Drawing.Point(4, 22);
            this.TaskZone.Name = "TaskZone";
            this.TaskZone.Padding = new System.Windows.Forms.Padding(3);
            this.TaskZone.Size = new System.Drawing.Size(738, 476);
            this.TaskZone.TabIndex = 2;
            this.TaskZone.Text = "Task Zone";
            this.TaskZone.UseVisualStyleBackColor = true;
            // 
            // TerminateTask
            // 
            this.TerminateTask.Location = new System.Drawing.Point(4, 22);
            this.TerminateTask.Name = "TerminateTask";
            this.TerminateTask.Padding = new System.Windows.Forms.Padding(3);
            this.TerminateTask.Size = new System.Drawing.Size(738, 476);
            this.TerminateTask.TabIndex = 3;
            this.TerminateTask.Text = "Terminated Tasks";
            this.TerminateTask.UseVisualStyleBackColor = true;
            // 
            // UploadFileDialog
            // 
            this.UploadFileDialog.Filter = "Documents | *.doc; *.docx;";
            // 
            // ChangePWBtn
            // 
            this.ChangePWBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ChangePWBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePWBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChangePWBtn.Location = new System.Drawing.Point(506, 111);
            this.ChangePWBtn.Name = "ChangePWBtn";
            this.ChangePWBtn.Size = new System.Drawing.Size(224, 23);
            this.ChangePWBtn.TabIndex = 13;
            this.ChangePWBtn.Text = "Change Password";
            this.ChangePWBtn.UseVisualStyleBackColor = false;
            this.ChangePWBtn.Click += new System.EventHandler(this.ChangePWBtn_Click);
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.BackColor = System.Drawing.SystemColors.Control;
            this.AddUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddUserBtn.Location = new System.Drawing.Point(506, 140);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(224, 23);
            this.AddUserBtn.TabIndex = 14;
            this.AddUserBtn.Text = "Add a user to the system";
            this.AddUserBtn.UseVisualStyleBackColor = false;
            this.AddUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // WorkFlowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 502);
            this.Controls.Add(this.WorkFlowTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WorkFlowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkFlowForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkFlowForm_FormClosed);
            this.Load += new System.EventHandler(this.WorkFlowForm_Load);
            this.WorkFlowTabControl.ResumeLayout(false);
            this.WorkZone.ResumeLayout(false);
            this.WorkZone.PerformLayout();
            this.InitiateTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl WorkFlowTabControl;
        private System.Windows.Forms.TabPage WorkZone;
        private System.Windows.Forms.Button CreateDocumentButton;
        private System.Windows.Forms.Button UploadDocumentButton;
        private System.Windows.Forms.Button DeleteDocumentButton;
        private System.Windows.Forms.TabPage InitiateTask;
        private System.Windows.Forms.TabPage TaskZone;
        private System.Windows.Forms.TabPage TerminateTask;
        private System.Windows.Forms.ListView DocumentListView;
        private System.Windows.Forms.Label UserRoleValueLabel;
        private System.Windows.Forms.Label UserRoleValue;
        private System.Windows.Forms.Label EmailValueLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label UserNameValueLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.OpenFileDialog UploadFileDialog;
        private System.Windows.Forms.Button OpenDocBtn;
        private System.Windows.Forms.ListView FlowListView;
        private System.Windows.Forms.ListView FlowDocsView;
        private System.Windows.Forms.Button AddDocToFlowBrn;
        private System.Windows.Forms.Button CreateFlowBtn;
        private System.Windows.Forms.Button AddUserBtn;
        private System.Windows.Forms.Button ChangePWBtn;
    }
}