using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_cadastro_de_roupas
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
            listaroupa();
        }
        void listaroupa()
        {
            ConectaBanco conecta = new ConectaBanco();
            tabelaRoupas.DataSource = conecta.busca();
            tabelaResultadoAtualizacao.DataSource = conecta.busca();

        }
        void limpaCampus()
        {
            textNome.Clear();
            textCategoria.Clear();
            textTamanho.Clear();
            textCor.Clear();
            textpreco.Clear();
            textquantidade.Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {



        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Roupa roupa = new Roupa();
            roupa.nome = textNome.Text;
            roupa.categoria = textCategoria.Text;
            roupa.tamanho = textTamanho.Text;
            roupa.cor = textCor.Text;
            roupa.preco = Convert.ToDouble(textpreco.Text);
            roupa.quantidade = (int)Convert.ToInt64(textquantidade.Text);
            ConectaBanco conecta = new ConectaBanco();
            bool cadastrado = conecta.inserirRoupa(roupa);
            if (cadastrado)
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show(conecta.mensagem);
            }
            limpaCampus();
            listaroupa();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConectaBanco conecta = new ConectaBanco();
            DataTable tabela = conecta.buscaNome("%"+textBuscar.Text+"%");
            if (tabela.Rows.Count <= 0)
            {
                MessageBox.Show("roupa não encontrada!");
            }
            else
            {
                tabelaResultado.DataSource = tabela;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabelaResultadoAtualizacao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            int linha = tabelaResultadoAtualizacao.CurrentRow.Index;
            Roupa roupa = new Roupa();
            roupa.codRoupas = Convert.ToInt32(tabelaResultadoAtualizacao.Rows[linha].Cells["codRoupas"].Value.ToString());
            roupa.nome = tabelaResultadoAtualizacao.Rows[linha].Cells["nome"].Value.ToString();
            roupa.tamanho = tabelaResultadoAtualizacao.Rows[linha].Cells["tamanho"].Value.ToString();
            roupa.categoria = tabelaResultadoAtualizacao.Rows[linha].Cells["categoria"].Value.ToString();
            roupa.cor = tabelaResultadoAtualizacao.Rows[linha].Cells["cor"].Value.ToString();
            roupa.preco = Convert.ToDouble(tabelaResultadoAtualizacao.Rows[linha].Cells["preco"].Value.ToString());
            roupa.quantidade = Convert.ToInt32(tabelaResultadoAtualizacao.Rows[linha].Cells["quantidade"].Value.ToString());
            ConectaBanco conecta = new ConectaBanco();
            bool atualizado = conecta.atualiza(roupa);
            if (atualizado)
            {
                MessageBox.Show("atualizado com sucesso!");

            }
            else
            {
                MessageBox.Show(conecta.mensagem); ;


            }
            listaroupa();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
