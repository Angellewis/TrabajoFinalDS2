using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalDS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        DS2Entities DS2Final = new DS2Entities();
        List<string> Model1 = new List<string>();

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUser.Text != "Usuario") {
                if (txtPass.Text != "Contraseña")
                {
                    var user = DS2Final.ProyectoFinalGrupoX_User.FirstOrDefault(x => x.Username == txtUser.Text && x.Password == txtPass.Text);
                    if (user == null)
                    {
                        msgError("Usuario o Contraseña incorrecta");
                        txtPass.Clear();
                        txtUser.Focus();
                        return;
                    }

                    var obj = new Inventario();
                    obj.Show();

                    this.Hide();
                }
                else
                {
                    msgError("Favor ingresar contraseña");
                }
                
            }
            else
            {
                msgError("Favor ingresar nombre de usuario");
            }

            
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }

         
    }
}
