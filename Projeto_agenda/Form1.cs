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
    public partial class Form1 : Form
    {
        cl_ControleContato controle = new cl_ControleContato();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cl_Conexao conexao = new cl_Conexao();
            MessageBox.Show(conexao.conectar());
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastro Cad = new FormCadastro();
            Cad.ShowDialog();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja Fechar","Confirmar",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormConsulta Consul = new FormConsulta();
            Consul.ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManual manual = new FormManual();
            manual.ShowDialog();    
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog(); 
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string CaminhoBackup = openFileDialog1.FileName;
                MessageBox.Show(controle.Retore(CaminhoBackup), "Restauração do BD",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }

}
