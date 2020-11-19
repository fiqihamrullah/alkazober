using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace alkazober
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void chkLoginAsUser_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !chkLoginAsUser.Checked;
            txtPassword.Enabled = !chkLoginAsUser.Checked;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!chkLoginAsUser.Checked)
            {
                String sql = "Select * from `User`  where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
                DBQuery dbQ = new DBQuery();
                dbQ.GetConn().Open();
                OleDbDataReader reader =  dbQ.ExecuteReader(sql);
                if (reader.Read())
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nama Pengguna atau Kata Sandi Salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
                dbQ.CloseConn();
                


            }else
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Hide();
            }

        }
    }
}
