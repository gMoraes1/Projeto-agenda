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
    public partial class FormCadastro : Form
    {
        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void limpar()
        {
            textBoxCodigo.Clear();
            textBoxNome.Clear();
            maskedTextBoxTelefone.Clear();   
            maskedTextBoxCelular.Clear();
            textBoxEmail.Clear();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            if(textBoxNome.Text == "")
            {
                MessageBox.Show("Não é permitido o Cadastro sem um Nome ");
            }
            else
            {
                cont.Nome = textBoxNome.Text;
                cont.Tel = maskedTextBoxTelefone.Text;
                cont.Cel = maskedTextBoxCelular.Text;
                cont.Email = textBoxEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));
                limpar();
            }

        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {

            cont.Codcontato = int.Parse(textBoxCodigo.Text);
            MessageBox.Show(controle.excluir(cont));
            limpar() ;
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (textBoxCodigo.Text == "" )
            {
                MessageBox.Show("Não é permitido a Alteração sem um Codigo ");
            }
            else
            {
                cont.Codcontato = int.Parse(textBoxCodigo.Text);
                cont.Nome = textBoxNome.Text;
                cont.Tel = maskedTextBoxTelefone.Text;
                cont.Cel = maskedTextBoxCelular.Text;
                cont.Email = textBoxEmail.Text;

                MessageBox.Show(controle.altererar(cont));
                limpar();
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            try //tenta realizar a busca e preencher os campos com os dados do contato encontrado.
            {
                cont = controle.buscar(int.Parse(textBoxCodigo.Text)); // converter o texto em numero 

                if( cont is null) //Se a busca não retornar nenhum resultado 
                {
                    MessageBox.Show("Registro não encontrado");
                }

                else //realizar a busca e preencher os campos com os dados do contato encontrado.
                {
                    textBoxCodigo.Text=cont.Codcontato.ToString();
                    textBoxNome.Text = cont.Nome;
                    maskedTextBoxTelefone.Text= cont.Tel;
                    maskedTextBoxCelular.Text = cont.Cel;
                    textBoxEmail.Text = cont.Email;
                }
            }

            catch(Exception ex) //exibe uma mensagem de erro.
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        private void FormCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {

                SendKeys.Send("{TAB}");

            }
        }

        private void textBoxCodigo_Enter(object sender, EventArgs e)
        {
            textBoxCodigo.BackColor = Color.Aqua;
        }

        private void textBoxCodigo_Leave(object sender, EventArgs e)
        {
            textBoxCodigo.BackColor = Color.White;
        }

        private void textBoxNome_Enter(object sender, EventArgs e)
        {
            textBoxNome.BackColor = Color.Aqua;
        }

        private void textBoxNome_Leave(object sender, EventArgs e)
        {
            textBoxNome.BackColor = Color.White;
        }

      

       

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            textBoxEmail.BackColor = Color.White;
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            textBoxEmail.BackColor = Color.Aqua;
        }

        private void maskedTextBoxTelefone_Leave(object sender, EventArgs e)
        {
            maskedTextBoxTelefone.BackColor = Color.White;
        }

        private void maskedTextBoxTelefone_Enter(object sender, EventArgs e)
        {
            maskedTextBoxTelefone.BackColor = Color.Aqua;
        }

        private void maskedTextBoxCelular_Enter(object sender, EventArgs e)
        {
            maskedTextBoxCelular.BackColor = Color.Aqua;
        }

        private void maskedTextBoxCelular_Leave(object sender, EventArgs e)
        {
            maskedTextBoxCelular.BackColor = Color.White;
        }
    }
}
