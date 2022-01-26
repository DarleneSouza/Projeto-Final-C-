using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_cadastro_de_roupas
{
    public partial class Sistema : Form
    {
        public Sistema()
        {
            InitializeComponent();
            textSenha.Text = "";
            textSenha.PasswordChar = '*';

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text.Equals("Darlene") && (textSenha.Text.Equals("123456")))
            {
                MessageBox.Show("Seja bem vindo!");
                Cadastro cad = new Cadastro();
                cad.Show();

            }
            else
            {
                MessageBox.Show("Usuario ou Senha incorretos!");
            }
        }
    }
}
