using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PolicijskaStanica
{
    public partial class Form2 : Form   //Dinamicna CRUD forma
    {
        #region SQL Classes
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=PolicijskaStanicaDB;Integrated Security=true;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        #endregion

        #region Public promenljive za prenos izmedju formi
        public string Operacija;
        public string Tabela;
        public string dgvName;
        public List<string> _imenaKolona = new List<string>();
        public List<string> _SelectedRowValues = new List<string>();
        public int cLeft = 1;
        public string SelectedRowID;
        public string _PronadjenEntitet;
        #endregion

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) //Ucitavanje Forme 2
        {
            foreach(var item in _imenaKolona)
            {
                novoPolje(item);
            }
            if (Operacija == "Izmeni")
            {
                ValuesForInsertMethod();
            }

            btn_Operacija.Text = Operacija;
        }
        
        public TextBox novoPolje(string imeKol) //Metoda za dodavanje novog textboxa i labele
        {
            
            TextBox txt = new TextBox();
            Label lbl = new Label();
            
            this.panel1.Controls.Add(txt);
            this.panel1.Controls.Add(lbl);

            lbl.Name = "lbl_"+imeKol;
            lbl.Text = imeKol;
            lbl.Top = cLeft * 27;
            lbl.Left = 10;
            
            txt.Top = cLeft * 26;
            txt.Left = 175;
            txt.Name = "txt_"+imeKol;
            txt.Width = 500;
            
            cLeft = cLeft + 1;
            return txt;
        }

        public void ValuesForInsertMethod() //Upisuje prvobitne vrednosti za entitet koji se menja
        {
            int i = 0;
            foreach (var item in _imenaKolona)
            {
                //i = _imenaKolona.IndexOf(item);
                panel1.Controls["txt_" + item.ToString()].Text = _SelectedRowValues[i];
                i++;
            }
        }

        #region CRUD
        private void OperacijaINSERT() //Metoda za Insert
        {
            con.Close();

            try
            {
                string set = "(";
                string values = "(@";
                int br = 0;

                foreach (var item in _imenaKolona)
                {
                    if (panel1.Controls["txt_" + item.ToString()].Text != "" && panel1.Controls["txt_" + item.ToString()].Text != null)
                    {
                        values = values + item + ",@";
                        set = set + item + ", ";
                        br++;
                    }
                }

                values = values.Substring(0, values.Length - 2);
                values = values + ")";

                set = set.Substring(0, set.Length - 2);
                set = set + ")";

                con.Open();
                cmd.CommandText = "INSERT INTO " + Tabela + set + " VALUES" + values;

                foreach (var item in _imenaKolona)
                {
                    if (panel1.Controls["txt_" + item.ToString()].Text != "" && panel1.Controls["txt_" + item.ToString()].Text != null)
                    {
                        cmd.Parameters.AddWithValue("@" + item + "", panel1.Controls["txt_" + item.ToString()].Text);
                    }
                }
            
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Uspeshno dodat entitet");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greshka: " + ex);
            }
        }
        
        private void OperacijaUPDATE() //Metoda za Update
        {
            con.Close();

            try
            {
                string s = " WHERE ";
                int br = 0;
                foreach (var item in _SelectedRowValues)
                {
                    if (item != null && item != "")
                    {
                        br = _SelectedRowValues.IndexOf(item);
                        s = s + _imenaKolona[br] + " = '" + item + "' AND ";
                        br++;
                    }
                }

                s = s.Substring(0, s.Length - 5);

                string x = " SET ";
                int j = 0;
                for (int i = 0; i < _imenaKolona.Count*2; i += 2)
                {
                    if (panel1.Controls[i].Text != _SelectedRowValues[j])
                    {
                        x += _imenaKolona[j] + " = '" + panel1.Controls[i].Text + "' , ";
                    }
                    j++;
                }
                x = x.Substring(0, x.Length - 3);
                
                con.Open();
                cmd.CommandText = "UPDATE " + Tabela + x + s;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Uspeshno izmenjen entitet");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greshka: " + ex);
            }
        }

        private void OperacijaSELECT() //Metoda za Select
        {

            con.Close();

            try
            {
                string s= " WHERE ";
                int j = 0;
                for (int i = 0; i < _imenaKolona.Count * 2; i += 2)
                {
                    if (panel1.Controls[i].Text != "" && panel1.Controls[i].Text != null)
                    {
                        s += _imenaKolona[j] + " = '" + panel1.Controls[i].Text + "' AND ";
                    }
                    j++;
                }
                s = s.Substring(0, s.Length - 5);
                
                _PronadjenEntitet = "SELECT * FROM " + Tabela + s;
                
                //MessageBox.Show(_PronadjenEntitet);

                MessageBox.Show("Uspeshno pronadjen entitet");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greshka: " + ex);
            }
        }
        #endregion

        private void btn_Operacija_Click(object sender, EventArgs e) //Dugme za izvrsenje CRUD naredbe
        {
            switch (Operacija)
            {
                case "Dodaj": OperacijaINSERT(); break;
                case "Izmeni": OperacijaUPDATE(); break;
                case "Nadji": OperacijaSELECT();break;
                default: break;
            }
        }
    }
}
