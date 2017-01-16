using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Controllers;
using Project.Domain;
using System.IO;
namespace Project.Ui
{
    public partial class LoginForm : Form
    {
        private static readonly string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static readonly string OnlineConnectionString = "asdasd";
        private string OfflineConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + projectDirectory + "\\db.mdf\";Integrated Security=True";
        private UserController userController;
        private WorkFlowForm workFLowForm;
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void LoginButton_Click(object sender, EventArgs e)
        {
            handleLogin();
        }

        private void handleLogin()
        {
            if (OfflineModeCheckBox.Checked)
            {
                Login(OfflineConnectionString);
            }
            else
            {
                Login(OnlineConnectionString);
            }
        }

        private void Login(string connectionString)
        {
            try
            {
                userController = new UserController(connectionString);
                int Id = userController.login(UserNameTextBox.Text, PasswordTextBox.Text);
                User user = userController.getUserById(Id);
                workFLowForm = new WorkFlowForm(connectionString, user);
                this.Hide();
                workFLowForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
