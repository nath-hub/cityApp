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
    public partial class locataire : Form
    {

        public static MySqlConnection con = new MySqlConnection("database=max; datasource=localhost;user Id=root;password =");
        public MySqlConnection chaine = con;
        DataTable data = new DataTable();
        BindingSource bs = new BindingSource();
        public locataire()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string requette = "insert into locataire(CODE_LOCATAIRE,NOM_LOCATAIRE,TELEPHONE_LOCATAIRE,DATE_DU_JOUR) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + DateTimePicker1.Text + "')";
            MySqlCommand cm = new MySqlCommand(requette, con);
            cm.ExecuteNonQuery();
            MessageBox.Show("ajouter avec succes");
            con.Close();
        }



        public void lier()
        {
           
            string re = "select * from locataire";
            MySqlDataAdapter  ad = new MySqlDataAdapter (re, con);
            ad.Fill(data);
            ad.FillSchema(data, SchemaType.Source);
            //TextBox1.DataBindings.Add("text", bs, "CODE_LOCATAIRE");
            //TextBox2.DataBindings.Add("text", bs, "nom_locataire");
            //TextBox3.DataBindings.Add("text", bs, "telephone_locataire");
            //DateTimePicker1.DataBindings.Add("text", bs, "date_du_jour");
            ad.Update(data);
            bs.DataSource = data;
            DataGridView1.DataSource = bs;
        }
    
        private void locataire_Load(object sender, EventArgs e)
        {
            lier();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public void save()
        {
            MySqlDataAdapter ad = new MySqlDataAdapter();
            MySqlCommandBuilder cd = new MySqlCommandBuilder(ad);
            bs.EndEdit();
            ad.Update(data );
            MessageBox.Show("modifier avec succes");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            bs.RemoveCurrent();
            save();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            DateTimePicker1.Text = "";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("voulez-vous vraiment fermer cette page?", "fermer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) {

            }
            else
            {
                this.Hide();
            }
        }
    }
}
