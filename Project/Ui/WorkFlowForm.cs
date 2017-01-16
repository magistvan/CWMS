using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Domain;
using Project.Controllers;

namespace Project.Ui
{
    public partial class WorkFlowForm : Form
    {
        private string connectionString;
        private User user;
        private UserController userController;
        private Controller controller;
        private Dictionary<int,string> userRole;
        public WorkFlowForm(string connectionString,User user)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.user = user;
            initComponents();
            fillListBox();
        }
        private void initComponents()
        {
            userController = new UserController(connectionString);
            controller = new Controller(user, connectionString);
            initMap();
            initUserDetails();
        }
        private void initMap()
        {
            userRole = new Dictionary<int, string>();
            userRole.Add(3, "Admin");
            userRole.Add(2, "Manager");
            userRole.Add(1, "Contributor");
            userRole.Add(0, "Reader");
        }
        private void initUserDetails()
        {
            UserNameValueLabel.Text = user.Username;
            UserRoleValueLabel.Text = userRole[user.AccessLevel()];
            EmailValueLabel.Text = user.Email;
        }
        private void WorkFlowForm_Load(object sender, EventArgs e)
        {
            
        }
        private void fillListBox()
        {
            DocumentListView.Clear();
            DocumentListView.View = View.Details;
            DocumentListView.Columns.Add("Id");
            DocumentListView.Columns.Add("File Name");
            DocumentListView.Columns.Add("Author");
            DocumentListView.Columns.Add("Type");
            DocumentListView.Columns.Add("Status");
            DocumentListView.Columns[1].Width = 150;
            DocumentListView.Columns[2].Width = 100;
            DocumentListView.Columns[3].Width = 80;
            foreach (Document doc in controller.GetAllDocuments())
            {
               DocumentListView.Items.Add(new ListViewItem(new string[] { doc.Id.ToString()
                   , doc.FileName, doc.Author.Username, doc.DocumentType.ToString(), doc.Status.ToString() }));
            }
        }

        private void WorkFlowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CreateDocumentButton_Click(object sender, EventArgs e)
        {
            DocumentForm lDocForm = new DocumentForm();
            lDocForm.ShowDialog();
            if(lDocForm.DocumentName.Length < 5)
            {
                MessageBox.Show("The document was not saved.");
                return;
            }
            controller.AddDocumentFromString(DOCUMENT_STATUS.DRAFT, lDocForm.DocumentContent, lDocForm.Keywords, lDocForm.DocumentName, 
                lDocForm.DocumentType == 0 ? DOCUMENT_TYPE.WORD : DOCUMENT_TYPE.PDF);
            fillListBox();
        }

        private void UploadDocumentButton_Click(object sender, EventArgs e)
        {
            UploadFileDialog.ShowDialog();
            if(UploadFileDialog.FileName == "")
            {
                return;
            }
            DOCUMENT_TYPE lDocType = UploadFileDialog.DefaultExt == "pdf" ? DOCUMENT_TYPE.PDF : DOCUMENT_TYPE.WORD;
            controller.AddDocumentFromFile(UploadFileDialog.FileName, lDocType);
            fillListBox();
        }

        private void DeleteDocumentButton_Click(object sender, EventArgs e)
        {
            if (DocumentListView.SelectedItems.Count < 1)
            {
                return;
            }
            controller.DeleteDocument(controller.getDocumentById(int.Parse(DocumentListView.SelectedItems[0].SubItems[0].Text)));
            fillListBox();
        }

        private void DocumentListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDocument();
        }

        private void OpenDocument()
        {
            if(DocumentListView.SelectedItems.Count < 1)
            {
                return;
            }
            int ID = int.Parse(DocumentListView.SelectedItems[0].SubItems[0].Text);
            DocumentForm lDocForm = new DocumentForm();
            lDocForm.UpdateContent(controller.getDocumentById(ID));
            lDocForm.ShowDialog();
            if(lDocForm.DialogResult == DialogResult.OK)
            {
                controller.ModifyDocument(ID, lDocForm.DocumentContent, lDocForm.Keywords, lDocForm.DocumentName);
            }
        }

        private void OpenDocBtn_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void WorkFlowTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch(e.TabPageIndex)
            {
                case 0:
                    fillListBox();
                    break;
                case 1:
                    FillFlows();
                    break;
            }
        }

        private void FillFlows()
        {
            FlowListView.Clear();
            FlowListView.View = View.Details;
            FlowListView.Columns.Add("Id");
            FlowListView.Columns.Add("Creator");
            FlowListView.Columns.Add("Step");
            FlowListView.Columns.Add("Status");
            FlowListView.Columns.Add("Documents");
            FlowListView.Columns[1].Width = 120;
            FlowListView.Columns[2].Width = 50;
            FlowListView.Columns[3].Width = 120;
            FlowListView.Columns[4].Width = 100;
            foreach (Flow f in controller.GetAllFlows())
            {
                FlowListView.Items.Add(new ListViewItem(new string[] { f.Id.ToString(),
                   f.Creator.Username.ToString(), f.Step.ToString(), f.Status.ToString(), f.Documents.Count.ToString() }));
            }
        }

        private void FillFlowDocs(int pFlowID)
        {
            FlowDocsView.Clear();
            FlowDocsView.View = View.Details;
            FlowDocsView.Columns.Add("Id");
            FlowDocsView.Columns.Add("File Name");
            FlowDocsView.Columns.Add("Author");
            FlowDocsView.Columns.Add("Type");
            FlowDocsView.Columns.Add("Status");
            FlowDocsView.Columns[1].Width = 150;
            FlowDocsView.Columns[2].Width = 100;
            FlowDocsView.Columns[3].Width = 80;
            foreach (int docID in controller.getFlowById(pFlowID).Documents)
            {
                Document doc = controller.getDocumentById(docID);
                FlowDocsView.Items.Add(new ListViewItem(new string[] { doc.Id.ToString()
                   , doc.FileName, doc.Author.Username, doc.DocumentType.ToString(), doc.Status.ToString() }));
            }
        }
        

        private void FlowListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FlowListView.SelectedItems.Count > 0)
            {
                FillFlowDocs(int.Parse(FlowListView.SelectedItems[0].SubItems[0].Text));
            }
        }

        private void CreateFlowBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddDocToFlowBrn_Click(object sender, EventArgs e)
        {

        }

        private void ChangePWBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
