using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cityapp
{
    public partial class Form1 : Form
    {
        public static MySqlConnection con = new MySqlConnection("database=max; datasource=localhost;user Id=root;password =");
        public MySqlConnection chainecon = con;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void connecter()
        {
          con.Open();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM connexion WHERE `login` = '" + TextBox1.Text + "'AND `mot_de_passe`='" + TextBox2.Text + "'", con);
            MySqlDataReader dr = cm.ExecuteReader();
            dr.Read();
            TextBox1 .Text = ""+dr[0];
            TextBox2.Text = "" + dr[1];
             ouvrir();
          if (dr.Read())
            {
                Console.WriteLine("bienvenue", MessageBoxButtons.YesNo , "connexion");
                
            }
           else
            {
                Console.WriteLine("echec de connexion");
            }
            
        }
        public void ouvrir()
        {
            acceuille po = new acceuille();
            po.Show();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked = true)
            {
                TextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                TextBox2.UseSystemPasswordChar = true;
            }
            
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            connecter();
        }
    }
}
