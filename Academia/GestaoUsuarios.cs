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
    public partial class GestaoUsuarios : Form
    {
        public GestaoUsuarios()
        {
            InitializeComponent();
        }

        private void btnFecharJanela_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GestaoUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Banco.ObterUsuariosIdNome();
            dgvUsuarios.Columns[0].Width = 85;
            dgvUsuarios.Columns[1].Width = 190;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int cont = dgv.SelectedRows.Count;
            if(cont > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                Banco.ObterDadosUsuario(vid);
                dt = Banco.ObterDadosUsuario(vid);
                tbId.Text = dt.Rows[0].Field<Int64>("id_usuario").ToString();
                tbNome.Text = dt.Rows[0].Field<string>("nome_usuario").ToString();
                tbuser.Text = dt.Rows[0].Field<string>("username").ToString();
                tbSenha.Text = dt.Rows[0].Field<string>("senha").ToString();
                cbStatus.Text = dt.Rows[0].Field<string>("status_usuario").ToString();
            }
            
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            NovoUsuario nu = new NovoUsuario();
            nu.ShowDialog();
            dgvUsuarios.DataSource = Banco.ObterUsuariosIdNome();
        }

        private void btnSalvarUsuario_Click(object sender, EventArgs e)
        {
            int linha = dgvUsuarios.SelectedRows[0].Index;
            Usuario u = new Usuario();
            u.id_usuario = Convert.ToInt32(tbId.Text);
            u.nome_usuario = tbNome.Text;
            u.username = tbuser.Text;
            u.senha = tbSenha.Text;
            u.status = cbStatus.Text;
            Banco.AtualizarUsuario(u);
            dgvUsuarios[1, linha].Value = tbId.Text;
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma a exclusão?", "Excluir?",MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                Banco.ExcluirUsuario(tbId.Text);
                dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
            }
        }
    }
}
