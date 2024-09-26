using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace Projeto_agenda
{
    internal class cl_ControleContato
    {
        cl_Conexao c = new cl_Conexao();

        public string cadastrar(cl_Contato cont) //Metodo onde o parametro instancia a classe cl_Contato
        {

            try
            {
                string sql = "INSERT INTO tbcontato (nome,telefone,celular,email) " + "VALUES('" + cont.Nome + "','" + cont.Tel + "','" + cont.Cel + "','" + cont.Email + "')";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //Abrir conexão
                c.conectar();//A conexão com o banco de dados é aberta.
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro realizado com sucesso.");
            }

            catch(MySqlException e) 
            {
                return (e.ToString());  //Retorna a Falha
            }


        }
        
        public string excluir(cl_Contato cont)
        {
            try
            {
                string sql = "delete from tbcontato where codcontato = " +cont.Codcontato+";" ;
                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro excluido com sucesso");
            }
            catch (MySqlException e)
            {
                
                return (e.ToString());
            }


        }

        public string altererar(cl_Contato cont) //Metodo onde o parametro instancia a classe cl_Contato
        {

            try
            {
                //Construção da consulta SQL:
                string sql = "update tbcontato set nome = '" + cont.Nome + "', telefone = '" + cont.Tel + "'," +
                    " Celular = '" + cont.Cel + "', Email = '" + cont.Email + "' where Codcontato = "
                    + cont.Codcontato + ";";


                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //Abrir conexão
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro alterado com sucesso.");
            }

            catch (MySqlException e)
            {
                return (e.ToString());  //Retorna a Falha
            }


        }


        // metodo publico que vai retornar os dados da classe cl_Contato com o parametro codigo
        public cl_Contato buscar(int codigo) 
        {
            // novo objeto da classe cl_Contato é criado para armazenar os dados recuperados do banco de dados.
            cl_Contato cont = new cl_Contato();

            try //Este bloco envolve o código que pode lançar exceções
            {
                //consulta SQL
                string sql = "select * from tbcontato where codcontato=" + codigo + ";";

                //Um novo comando MySQL é criado com a consulta SQL e a conexão do banco de dados.
                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();

                //A consulta é executada e os resultados são lidos em um MySqlDataReader.
                MySqlDataReader objDados = cmd.ExecuteReader(); 


                if (!objDados.HasRows)//Verifica se a consulta não retornou nenhuma linha. Se for o caso, retorna null
                {

                    return null;

                }

                else //os dados são lidos da linha retornada e atribuídos às propriedades do objeto cl_Contato.
                {
                    objDados.Read();
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Tel = objDados["telefone"].ToString();
                    cont.Cel = objDados["celular"].ToString();
                    cont.Email = objDados["email"].ToString();

                    objDados.Close();
                    return cont;
                }
            }

            catch (MySqlException e) //No caso de uma exceção, o código no bloco catch é executado.
            {
                throw (e);
            }
            finally //garante que o código dentro dele será executado, independentemente de ocorrer uma exceção ou não.
            {
                c.desconectar(); //A conexão com o banco de dados é fechada para liberar recursos.
            }

            
        }

        public DataTable PesquisaCodigo(int codigo) 
        {

            string sql = "select codContato as 'Codigo',nome as Nome,telefone as Telefone," + "celular as Celular,email as Email from tbcontato where codcontato=" + codigo + ";";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;

        }

        public DataTable PesquisaNome(string nomecontato)
        {

            string sql = "select codContato as 'Codigo',nome as Nome,telefone as Telefone," + "celular as Celular,email as Email from tbcontato where nome like '%"+nomecontato+"%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;

        }
        public DataTable PesquisaTelefone(string telefonecontato)
        {
            string sql = "select codContato as 'Codigo', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where telefone like '%" + telefonecontato + "%'";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);

            c.desconectar();

            return contato;
        }
        public DataTable PesquisaCelular(string celularcontato)
        {
            string sql = "select codContato as 'Codigo', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where celular like '%" + celularcontato + "%'";
            //string sql = "select codContato as 'Codigo', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where telefone like '%" + telefonecontato + "%'";


            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);

            c.desconectar();

            return contato;
        }
        public DataTable PesquisaEmail(string emailcontato)
        {
            string sql = "select codContato as 'Codigo', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where email like '%" + emailcontato + "%'";


            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);

            c.desconectar();

            return contato;
        }





        public DataTable PreencherTodos()
        {

            string sql = "select codContato as 'Codigo',nome as Nome,telefone as Telefone," + "celular as Celular,email as Email from tbcontato;" ;
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;

        }
        public string Backup(string Caminho)
        {
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string CaminhoBackup = Caminho + "\\backupContatos_" + dataAtual + ".sql";

            try
            {
                MySqlCommand cmd = new MySqlCommand(CaminhoBackup, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                c.conectar();
                mb.ExportToFile(CaminhoBackup);
                c.desconectar();
                return ("Backup  do banco de dados realizado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
        public string Retore(string Caminho) //Backup a MySQL database
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(Caminho, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                c.conectar();
                mb.ImportFromFile(Caminho);
                c.desconectar();
                return ("Banco de dados restaurado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }



    }
}
