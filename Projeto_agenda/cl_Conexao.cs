
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_agenda
{
    internal class cl_Conexao
    {
        //string de conexão
        public MySqlConnection con = new MySqlConnection(@"Server=localhost;Port=3306;Database=agenda;User=root;Pwd=''");
        public string conectar()
        {
            
            try
            {
                con.Open();
                return ("conexão realizada com sucesso");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string desconectar()
        {
            try
            {
                con.Close();
                return ("conexão Encerrada!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

    }
}
