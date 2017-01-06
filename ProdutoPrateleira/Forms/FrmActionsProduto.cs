
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
    public partial class FrmActionsProduto : Form
    {
        List<Prateleira> Prateleiras;



        public FrmActionsProduto()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Key;

            FrmAddPrateleira.Attach(carregaPrateleiras);

            carregaPrateleiras();




        }

        private void carregaPrateleiras()
        {
            using (var db = new Db())
            {
                Prateleiras = db.Prateleiras.ToList();
            }

            listBox1.DataSource = Prateleiras;
            listBox1.DisplayMember = "Setor";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            Prateleira p = (Prateleira)listBox1.SelectedItem;
            using (var db = new Db())
            {
                var prateleira = db.Prateleiras.Find(p.Id);
                db.Produtos.Add(new Produto()
                {

                    Nome = textBox1.Text,
                    Quantidade = int.Parse(textBox2.Text),
                    Prateleira = prateleira

                });

                db.SaveChanges();
            }

            limpaCampos();
            atualizaGrid();

        }

        private void limpaCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizaGrid();

        }

        private void atualizaGrid()
        {

            var p = (Prateleira)listBox1.SelectedItem;

            using (var db = new Db())
            {
                var lista = db.Prateleiras.Find(p.Id).Produtos;
                dataGridView1.DataSource = lista;

               

            }

            dataGridView1.Columns["Prateleira"].Visible = false;
            dataGridView1.Columns["Id"].ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAddPrateleira.GetInstance.Show();
        }

        private void FrmActionsProduto_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
          
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new Db())
            {
                var Produto = (Produto)dataGridView1.SelectedRows[0].DataBoundItem;



                var updateProduto = context.Produtos.Find(Produto.Id);
                updateProduto.Nome = Produto.Nome;
                context.Entry(updateProduto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                MessageBox.Show("Produto Atualizado!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var context = new Db())
            {
                var Produto = (Produto)dataGridView1.SelectedRows[0].DataBoundItem;



                var updateProduto = context.Produtos.Find(Produto.Id);
                context.Entry(updateProduto).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                atualizaGrid();

                MessageBox.Show("Produto Excluido!");
            }
        }
    }
}
