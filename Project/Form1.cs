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

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ctrl = new UserController();
            ctrl.registation(0, "magistvan", "1234", "email1", 0, 0);
            var user = ctrl.getUserByUsername("magistvan");
        }
    }
}
