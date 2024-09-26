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
    public partial class FormLogin : Form
    {
        cl_Login lgn = new cl_Login();   
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            if(textBoxLogin.Text=="" || textBoxSenha.Text =="")
            {
                MessageBox.Show("Digite login e Senha para acessar o sistema!!!","Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else 
            {
                try
                { 
                bool logar = lgn.Logar(textBoxLogin.Text,textBoxSenha.Text);
                    if (logar == true)
                    {
                        this.Hide();
                        Form1 Principal = new Form1();
                        Principal.Show();
                    }
                    else 
                    {
                    MessageBox.Show("Login e /ou senha invalidos!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSenha.Clear();
                        textBoxLogin.Clear();
                        textBoxLogin.Focus();
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja Fechar", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
