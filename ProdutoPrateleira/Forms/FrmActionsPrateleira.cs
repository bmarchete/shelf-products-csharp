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


    public partial class FrmActionsPrateleira : Form
    {


        public FrmActionsPrateleira()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Organization;
            FrmAddPrateleira.Attach(updatePrateleira);
        }

        private void FrmActionsPrateleira_Load(object sender, EventArgs e)
        {
            updatePrateleira();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            updatePrateleira();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Prateleira p = (Prateleira)dataGridView1.SelectedRows[0].DataBoundItem;
            textBox2.Text = p.Id.ToString();
            textBox3.Text = p.Setor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new Db())
            {
                var prateleira = context.Prateleiras.Find(int.Parse(textBox2.Text));

                prateleira.Setor = textBox3.Text;

                context.Entry(prateleira).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();


            }

            updatePrateleira();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new Db())
            {

                try
                {
                    var prateleira = context.Prateleiras.Find(int.Parse(textBox2.Text));


                    context.Entry(prateleira).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    MessageBox.Show("Erro");
                }




            }

            updatePrateleira();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddPrateleira.GetInstance.Show();
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
            using (var context = new Db())
            {

                var filtro = context.Prateleiras
                        .Where(r => r.Setor.Contains(textBox1.Text))
                        .ToList();


                dataGridView1.DataSource = filtro;


            }
        }

        public void updatePrateleira()
        {
            using (var context = new Db())
            {
                var p = context.Prateleiras.ToList();
                dataGridView1.DataSource = p;
            }

            dataGridView1.ClearSelection();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox1_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}
