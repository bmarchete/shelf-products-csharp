using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProdutoPrateleira.Models;


namespace ProdutoPrateleira.Forms
{

    public delegate void UpdatePrateleira();

    public partial class FrmAddPrateleira : Form
    {




        #region  //singleton pattern

        private static FrmAddPrateleira instance;

        public static FrmAddPrateleira GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmAddPrateleira();
                    return instance;
                }

                return instance;
            }

            
        }

        #endregion



        #region //observer pattern
        public delegate void Notificador();

        static Notificador _notificador;

        public static void Attach(Notificador notificador)
        {
             _notificador += notificador;
        }

        public static void Remove(Notificador notifier)
        {
            _notificador -= notifier;
        }

        public static void UpdatePrateleira()
        {
            if (_notificador != null)
                _notificador();
        }

        
        #endregion


        

        private FrmAddPrateleira()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Addons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

       
        public void cadastrar()
        {

            using (var db = new Db())
            {
                db.Prateleiras.Add(new Prateleira()
                {
                    Setor = textBox1.Text
                });

                db.SaveChanges();
            }

            UpdatePrateleira();




        }

        private void FrmAddPrateleira_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cadastrar();
            textBox1.Clear();
        }
    }
}
