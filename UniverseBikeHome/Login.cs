using BikeClassLibrary;
using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniverseBikeHome
{
    public partial class Login : Form
    {
        AccountService service;
        public Login(IAccountRepository accrep)
        {
            InitializeComponent();
            service = new AccountService(accrep);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnAddBike_Click(object sender, EventArgs e)
        {

            if(txtLogin.Text == "admin@bikeuniverse.com")
            {
                Account acc = service.GetAccountByEmail(txtLogin.Text);
                if(HashHelper.VerifyPassword(txtPassword.Text, acc.GetSalt(), acc.GetPassword(), 8000))
                {
                    HomePage home = new HomePage();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Text = "Incorrect Password";
                }
            }
            else
            {
                lblError.Text = "Incorect Login";
            }
        }
    }
}
