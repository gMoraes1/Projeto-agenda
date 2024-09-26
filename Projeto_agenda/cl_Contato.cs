using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;




namespace Projeto_agenda
{
    internal class cl_Contato
    {
        //encapsulamento
        private int codcontato;
        private string nome;
        private string tel;
        private string cel;
        private string email;

        public int Codcontato { get => codcontato; set => codcontato = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Cel { get => cel; set => cel = value; }
        public string Email { get => email; set => email = value; }
    }
}
