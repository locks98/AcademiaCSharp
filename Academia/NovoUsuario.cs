using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia
{
    public partial class NovoUsuario : Form
    {
        public NovoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.nome_usuario = tbNome.Text;
            u.username = tbuser.Text;
            u.senha = tbSenha.Text;
            u.status = cbStatus.Text;

            Banco.NovoUsuario(u);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbNome.Clear();
            tbSenha.Clear();
            tbuser.Clear();
            cbStatus.Text = "";
            tbNome.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbNome.Clear();
            tbSenha.Clear();
            tbuser.Clear();
            cbStatus.Text = "";
            tbNome.Focus();
        }
    }
}
