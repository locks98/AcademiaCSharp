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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            login f_login = new login(this);
            f_login.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f_login = new login(this);
            f_login.ShowDialog();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbusuario.Text = "Usuário -- ";
            this.Close();
        }

        private void novoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoUsuario nu = new NovoUsuario();
            nu.ShowDialog();
        }

        private void gestãoDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestaoUsuarios gu = new GestaoUsuarios();
            gu.ShowDialog();
        }
    }
}
