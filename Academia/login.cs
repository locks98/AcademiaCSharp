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
    public partial class login : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();
        public login(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btn_logar_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string senha = tb_senha.Text;
            if(username == "" || senha == "")
            {
                MessageBox.Show("Usuário e ou Senha inválidos");
                tb_username.Focus();
                return;
            }
            
            string sql = "select * from usuarios where username ='" + username + "' and senha = '" + senha+"'" ;
            dt = Banco.consulta(sql);
            if(dt.Rows.Count == 1)
            {
                form1.lbusuario.Text ="Usuário "+ dt.Rows[0].Field<string>("nome_usuario");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário não encontrado");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
