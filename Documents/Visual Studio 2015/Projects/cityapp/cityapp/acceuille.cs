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
    public partial class acceuille : Form
    {
        public acceuille()
        {
            InitializeComponent();
        }

        private void acceuille_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true) {
                locataire l = new locataire();
                l.Show();
            }
            if (RadioButton2.Checked == true)
            {
                chambre c = new chambre();
                c.Show();
            }
            if (RadioButton3.Checked == true)
            {
                location o = new location();
                o.Show();
            }
            if (RadioButton4.Checked == true)
            {
                versement v = new versement();
                v.Show();
            }
        }
    }
}
