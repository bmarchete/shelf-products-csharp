using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProdutoPrateleira.Forms;
using ProdutoPrateleira.Models;

namespace ProdutoPrateleira
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Home;


        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adicionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prateleiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FrmActionsPrateleira();
            f.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FrmActionsProduto();
            f.Show();
        }

        private void adicionarPrateleiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddPrateleira.GetInstance.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            atualizaStatus();

        }

        private void atualizaStatus()
        {

            using (var context = new Db())
            {
                int totalPrateleiras = context.Prateleiras.ToList().Count;
                int totalProdutos = context.Produtos.ToList().Count;

                

                toolStripStatusLabel1.Text = "Total de prateleiras: ";
                toolStripStatusLabel1.Text += totalPrateleiras + " em ";
                toolStripStatusLabel1.Text += DateTime.Now.ToString();

                toolStripStatusLabel2.Text = "Total de produtos: ";
                toolStripStatusLabel2.Text += totalProdutos + " em ";
                toolStripStatusLabel2.Text += DateTime.Now.ToString();
            }


        }
    }
}
