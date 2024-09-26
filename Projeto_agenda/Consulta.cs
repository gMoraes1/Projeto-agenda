using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_agenda
{
 
    public partial class FormConsulta : Form
    {
        cl_ControleContato controle = new cl_ControleContato();
        public FormConsulta()
        {
            InitializeComponent();
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controle.PreencherTodos();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if(comboBoxOpcao.SelectedIndex == 0)
            {

                try
                {
                    int codigo = Convert.ToInt32(textBoxBuscar.Text);
                    dataGridView1.DataSource = controle.PesquisaCodigo(codigo);
                }
                catch 
                {
                    MessageBox.Show("Digite um valor inteiro para o Código!");
                    textBoxBuscar.Clear();
                    textBoxBuscar.Focus();
                
                }
            
            }
            else if (comboBoxOpcao.SelectedIndex == 1)
            {
            string nomecontato = (textBoxBuscar.Text);
            dataGridView1.DataSource = controle.PesquisaNome(nomecontato);
            }
            else if (comboBoxOpcao.SelectedIndex == 2)
            {
                string telefonecontato = (textBoxBuscar.Text);
                dataGridView1.DataSource = controle.PesquisaTelefone(telefonecontato);
            }
            else if (comboBoxOpcao.SelectedIndex == 3)
            {
                string celularcontato = (textBoxBuscar.Text);
                dataGridView1.DataSource = controle.PesquisaCelular(celularcontato);
            }
            else if (comboBoxOpcao.SelectedIndex == 4)
            {
                string emailcontato = (textBoxBuscar.Text);
                dataGridView1.DataSource = controle.PesquisaEmail(emailcontato);
            }
        }
    }
}

