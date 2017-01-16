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

namespace Project.Ui
{
    public partial class DocumentForm : Form
    {
        public string DocumentName { get; set; }
        public string DocumentContent { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string CreatedTime { get; set; }
        public string ModTime { get; set; }
        public int DocumentType { get; set; }
        private string DraftVersion { get; set; }

        public DocumentForm()
        {
            InitializeComponent();
            DocumentName = "";
            DocumentContent = "";
            Description = "";
            Keywords = "";
            CreatedTime = "Creating now...";
            ModTime = "N/A";
            DocumentType = 0;
            DraftVersion = "1.0";
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            DocumentNameTbx.Text = DocumentName;
            ContentTbx.Text = DocumentContent;
            DescriptionTbx.Text = Description;
            KeywordsTbx.Text = Keywords;
            DocumentTypeCbx.SelectedIndex = DocumentType;
            CreatedLabel.Text = CreatedTime;
            ModLabel.Text = ModTime;
            VersionLabel.Text = "Ver.: " + DraftVersion;
        }

        private void CreateDocumentButton_Click(object sender, EventArgs e)
        {
            if(DocumentNameTbx.Text == "")
            {
                MessageBox.Show("Please provide a name for the document.");
                return;
            }
            UpdateContent();
            DialogResult = DialogResult.OK;
        }

        private void UpdateContent()
        {
            DocumentName = DocumentNameTbx.Text;
            if(DocumentName.Split('.').Last<string>() != "pdf" &&
                DocumentName.Split('.').Last<string>() != "doc" &&
                DocumentName.Split('.').Last<string>() != "docx")
            {
                if(DocumentTypeCbx.SelectedIndex == 0)
                {
                    DocumentName += ".doc";
                }
                else
                {
                    DocumentName += ".pdf";
                }
            }

            DocumentContent = ContentTbx.Text;
            Description = DescriptionTbx.Text;
            Keywords = KeywordsTbx.Text;
            DocumentType = DocumentTypeCbx.SelectedIndex;
            this.Close();
        }

        internal void UpdateContent(Document pDoc)
        {
            DocumentName = pDoc.FileName;
            DocumentContent = pDoc.Abstract_string;
            Description = "";
            Keywords = pDoc.Keywords;
            DocumentType = pDoc.DocumentType == DOCUMENT_TYPE.WORD ? 0 : 1;
            CreatedTime = pDoc.CreationDate.ToString();
            ModTime = pDoc.ModificationDate.ToString();
            DraftVersion = pDoc.DraftVersion.ToString("F1");
            DocumentNameTbx.ReadOnly = true;
            DocumentTypeCbx.Enabled = false;
        }

        private void KeywordsTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                UpdateContent();
            }
        }
    }
}
