using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Academia
{
    class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source =C:\\Users\\bi_ga\\Desktop\\Academia\\Academia\\bd\\banco_academia.db");
            conexao.Open(); 
            return conexao;
        }

        public static DataTable ObterTodosUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "select * from usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);   
                da.Fill(dt);
                return dt;             
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static DataTable consulta(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {              
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand(); 
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                return dt;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterUsuariosIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "select id_usuario as 'ID', nome_usuario as 'Nome' from usuarios";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void AtualizarUsuario(Usuario u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "update usuarios set nome_usuario='"+u.nome_usuario+"', username='"+u.username
                    +"', senha='"+u.senha+"', status_usuario='"+u.status+"' where id_usuario ="+u.id_usuario;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ExcluirUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "delete from usuarios where id_usuario =" +id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable ObterDadosUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "select * from usuarios where id_usuario = "+id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void NovoUsuario(Usuario u)
        {
            if(existeUserName(u))
            {
                MessageBox.Show("Username já existe");
                return;
            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "insert into usuarios (nome_usuario, username, senha, status_usuario) values (@nome_usuario, @username, @senha, @status_usuario)";
                cmd.Parameters.AddWithValue("@nome_usuario", u.nome_usuario);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status_usuario", u.status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo Usuario Cadastrado com sucesso");
                vcon.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao gravar usuário");
            }
        }

        public static bool existeUserName(Usuario u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            bool res;

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "select username from usuarios where username = '" + u.username + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            vcon.Close();
            return res;
        }
    }
}
