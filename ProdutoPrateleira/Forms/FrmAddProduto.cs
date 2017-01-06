using ProdutoPrateleira.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdutoPrateleira.Forms
{
    public partial class FrmAddProduto : Form
    {
        Db db = new Db();
        List<Prateleira> Prateleiras;
        public FrmAddProduto()
        {
            InitializeComponent();

            carregaPrateleiras();




        }

        private void carregaPrateleiras()
        {
            Prateleiras = db.Prateleiras.ToList();
            listBox1.DataSource = Prateleiras;
            listBox1.DisplayMember = "Setor";

        }

        private void FrmAddProduto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prateleira prateleira = (Prateleira) listBox1.SelectedItem;

            db.Produtos.Add(new Produto()
            {

                Nome = textBox1.Text,
                Quantidade = int.Parse(textBox2.Text),
                Prateleira = prateleira
                
            });
            
            db.SaveChanges();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
