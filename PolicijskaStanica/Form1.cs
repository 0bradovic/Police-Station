using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolicijskaStanica
{
    public partial class PolicijskaStanica : Form
    {
        #region SQL Classes
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=PolicijskaStanicaDB;Integrated Security=true;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        #endregion

        public string PronadjenEntitet;
        
        public PolicijskaStanica()
        {
            InitializeComponent();
        }

        private void PolicijskaStanica_Load(object sender, EventArgs e) //Form1, ucitavanje tabela
        {
            DisplayAllData();
        }
        
        private void DisplayData(string tbl, DataGridView dgvName) //Prikazivanje svih podataka iz tabele
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM "+tbl+"", con);
            adapt.Fill(dt);
            dgvName.DataSource = dt;
            con.Close();
        }

        private void DeleteRow(string tbl, DataGridView dgvName) //Metoda za Delete operaciju
        {
            if (dgvName.SelectedRows.Count>0)
            {
                var IdsToDelete = new List<string>();
                foreach (DataGridViewRow item in dgvName.SelectedRows)
                {
                    var x = item.Cells[0].Value;
                    IdsToDelete.Add(x.ToString());
                }

                try
                {
                    string s = dgvName.Columns[0].HeaderText.ToString();
                    foreach (var id in IdsToDelete)
                    {
                        con.Open();
                        cmd.CommandText = "DELETE FROM " + tbl + " WHERE " + tbl + "." + s + " = '" + id + "'";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("GRESHKA!!! : " + e);
                }

                foreach (DataGridViewRow item in dgvName.SelectedRows)
                {
                    dgvName.Rows.RemoveAt(item.Index);
                }

                MessageBox.Show("Uspeshno obrisan entitet");
                DisplayData(tbl, dgvName);
            }
            else
            {
                MessageBox.Show("Izabrati entitet(e) za brisanje");
            }
        }

        public void DisplayAllData() //Prikazivanje svih podataka svih tabela
        {
            DisplayData("UPRAVA", dgv_Uprava);
            DisplayData("POLICIJSKA_STANICA", dgv_Policijska_Stanica);
            DisplayData("POLICAJAC", dgv_Policajac);
            DisplayData("PATROLA", dgv_Patrola);
            DisplayData("POZORNIK", dgv_Pozornik);
            DisplayData("CIN", dgv_Cin);
            DisplayData("USTANOVA", dgv_Ustanova);
            DisplayData("SKOLA", dgv_Skola);
            DisplayData("SKOLSKI", dgv_Skolski);
            DisplayData("Ulica", dgv_Ulica);
            DisplayData("OBJEKAT", dgv_Objekat);
            DisplayData("OSTALI", dgv_Ostali);
            DisplayData("ALARMNI_SISTEM", dgv_AlarmniSistem);
            DisplayData("VANREDNE_SITUACIJE", dgv_VanredneSituacije);
            DisplayData("TEHNICKO_LICE", dgv_TehnickoLice);
            DisplayData("VOZILO", dgv_Vozilo);
        }

        #region CRUD methods
        private void InsertCRUD(DataGridView dgvName, Button btnOperacija, TabPage tpName) //Metoda za Insert operaciju, otvara formu 2 i prosledjuje joj parametre
        {
            Form2 f2 = new Form2();
            f2.dgvName = dgvName.Name;

            var brKolona = dgvName.Columns.Count;
            
            List<string> imenaKolona = new List<string>();
            for (var i = 0; i < dgvName.ColumnCount; i++)
            {
                imenaKolona.Add(dgvName.Columns[i].HeaderText);
            }

            f2._imenaKolona.AddRange(imenaKolona);

            f2.Tabela = tpName.Name;

            f2.Text = tpName.Name;

            f2.Operacija = btnOperacija.Text;

            f2.Closed += delegate
            {
                DisplayAllData();
            };

            f2.ShowDialog();
        }
        
        private void UpdateCRUD(DataGridView dgvName, Button btnOperacija, TabPage tpName) //Metoda za Update operaciju, otvara formu 2 i prosledjuje joj parametre
        {
            if (dgvName.SelectedRows.Count>0)
            {
                Form2 f2 = new Form2();
                f2.dgvName = dgvName.Name;

                var brKolona = dgvName.Columns.Count;

                List<string> imenaKolona = new List<string>();
                for (var i = 0; i < dgvName.ColumnCount; i++)
                {
                    imenaKolona.Add(dgvName.Columns[i].HeaderText);
                }

                List<string> SelectedRowVALUES = new List<string>();
                for (var i = 0; i < dgvName.ColumnCount; i++)
                {
                    SelectedRowVALUES.Add(dgvName.SelectedRows[0].Cells[i].Value.ToString());
                }

                f2._SelectedRowValues.AddRange(SelectedRowVALUES);

                f2._imenaKolona.AddRange(imenaKolona);

                f2.Tabela = tpName.Name;

                f2.Text = tpName.Name;

                f2.Operacija = btnOperacija.Text;

                f2.Closed += delegate
                {
                    DisplayAllData();
                };

                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Izabrati entitet(e) za izmenu");
            }
        }
        
        private void SelectCRUD(DataGridView dgvName, Button btnOperacija, TabPage tpName) //Metoda za Select operaciju, otvara formu 2 i prosledjuje joj parametre
        {
            Form2 f2 = new Form2();
            f2.dgvName = dgvName.Name;

            var brKolona = dgvName.Columns.Count;

            List<string> imenaKolona = new List<string>();
            for (var i = 0; i < dgvName.ColumnCount; i++)
            {
                imenaKolona.Add(dgvName.Columns[i].HeaderText);
            }

            f2._imenaKolona.AddRange(imenaKolona);

            f2.Tabela = tpName.Name;

            f2.Text = tpName.Name;

            f2.Operacija = btnOperacija.Text;

            f2.Closed += delegate
            {
                PronadjenEntitet = f2._PronadjenEntitet;
                if (PronadjenEntitet!="" && PronadjenEntitet!=null)
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter(PronadjenEntitet, con);
                    adapt.Fill(dt);
                    dgvName.DataSource = dt;
                }
                con.Close();
            };

            f2.ShowDialog();
        }
        #endregion
        
        #region CRUD UI Events for all tables
        
        #region Uprava CRUD Buttons
        private void btn_Nadji_Uprava_Click(object sender, EventArgs e) //SELECT za tabelu UPRAVA  [BUTTON]*
        {
            SelectCRUD(dgv_Uprava, btn_Nadji_Uprava, UPRAVA);
        }
        private void btn_Dodaj_Uprava_Click(object sender, EventArgs e) //INSERT za tabelu UPRAVA  [BUTTON]*
        {
            InsertCRUD(dgv_Uprava, btn_Dodaj_Uprava, UPRAVA);
        }
        private void btn_Izmeni_Uprava_Click(object sender, EventArgs e) //UPDATE za tabelu UPRAVA  [BUTTON]*
        {
            UpdateCRUD(dgv_Uprava, btn_Izmeni_Uprava, UPRAVA);
        }
        private void btn_Obrisi_Uprava_Click(object sender, EventArgs e) //DELETE za tabelu UPRAVA  [BUTTON]*
        {
            DeleteRow("UPRAVA", dgv_Uprava);
        }
        private void btn_Obnovi_Uprava_Click(object sender, EventArgs e) //SELECT * za tabelu UPRAVA  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Policijska_Stanica CRUD Buttons
        private void btn_Nadji_PolicijskaStanica_Click(object sender, EventArgs e) //SELECT za tabelu POLICIJSKA_STANICA  [BUTTON]*
        {
            SelectCRUD(dgv_Policijska_Stanica, btn_Nadji_PolicijskaStanica, POLICIJSKA_STANICA);
        }
        private void btn_Dodaj_PolicijskaStanica_Click(object sender, EventArgs e) //INSERT za tabelu POLICIJSKA_STANICA  [BUTTON]*
        {
             InsertCRUD(dgv_Policijska_Stanica, btn_Dodaj_PolicijskaStanica, POLICIJSKA_STANICA);
        }
        private void btn_Izmeni_PolicijskaStanica_Click(object sender, EventArgs e) //UPDATE za tabelu POLICIJSKA_STANICA  [BUTTON]*
        {
            UpdateCRUD(dgv_Policijska_Stanica, btn_Izmeni_PolicijskaStanica, POLICIJSKA_STANICA);
        }
        private void btn_Obrisi_PolicijskaStanica_Click(object sender, EventArgs e) //DELETE za tabelu POLICIJSKA_STANICA  [BUTTON]*
        {
            DeleteRow("POLICIJSKA_STANICA", dgv_Policijska_Stanica);
        }
        private void btn_Obnovi_PolicijskaStanica_Click(object sender, EventArgs e) //SELECT * za tabelu POLICIJSKA_STANICA  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Policajac CRUD Buttons
        private void btn_Nadji_Policajac_Click(object sender, EventArgs e) //SELECT za tabelu POLICAJAC  [BUTTON]*
        {
            SelectCRUD(dgv_Policajac, btn_Nadji_Policajac, POLICAJAC);
        }
        private void btn_Dodaj_Policajac_Click(object sender, EventArgs e) //INSERT za tabelu POLICAJAC  [BUTTON]*
        {
            InsertCRUD(dgv_Policajac, btn_Dodaj_Policajac, POLICAJAC);
        }
        private void btn_Izmeni_Policajac_Click(object sender, EventArgs e) //UPDATE za tabelu POLICAJAC  [BUTTON]*
        {
            UpdateCRUD(dgv_Policajac, btn_Izmeni_Policajac, POLICAJAC);
        }
        private void btn_Obrisi_Policajac_Click(object sender, EventArgs e) //DELETE za tabelu POLICAJAC  [BUTTON]*
        {
            DeleteRow("POLICAJAC", dgv_Policajac);
        }
        private void btn_Obnovi_Policajac_Click(object sender, EventArgs e) //SELECT * za tabelu POLICAJAC  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Patrola CRUD Buttons
        private void btn_Nadji_Patrola_Click(object sender, EventArgs e) //SELECT za tabelu PATROLA  [BUTTON]*
        {
            SelectCRUD(dgv_Patrola, btn_Nadji_Patrola, PATROLA);
        }

        private void btn_Dodaj_Patrola_Click(object sender, EventArgs e) //INSERT za tabelu PATROLA  [BUTTON]*
        {
            InsertCRUD(dgv_Patrola, btn_Dodaj_Patrola, PATROLA);
        }

        private void btn_Izmeni_Patrola_Click(object sender, EventArgs e) //UPDATE za tabelu PATROLA  [BUTTON]*
        {
            UpdateCRUD(dgv_Patrola, btn_Izmeni_Patrola, PATROLA);
        }

        private void btn_Obrisi_Patrola_Click(object sender, EventArgs e) //DELETE za tabelu PATROLA  [BUTTON]*
        {
            DeleteRow("PATROLA", dgv_Patrola);
        }

        private void btn_Obnovi_Patrola_Click(object sender, EventArgs e) //SELECT * za tabelu PATROLA  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Pozornik CRUD Buttons
        private void btn_Nadji_Pozornik_Click(object sender, EventArgs e) //SELECT za tabelu POZORNIK  [BUTTON]*
        {
            SelectCRUD(dgv_Pozornik, btn_Nadji_Pozornik, POZORNIK);
        }

        private void btn_Dodaj_Pozornik_Click(object sender, EventArgs e) //INSERT za tabelu POZORNIK  [BUTTON]*
        {
            InsertCRUD(dgv_Pozornik, btn_Dodaj_Pozornik, POZORNIK);
        }

        private void btn_Izmeni_Pozornik_Click(object sender, EventArgs e) //UPDATE za tabelu POZORNIK  [BUTTON]*
        {
            UpdateCRUD(dgv_Pozornik, btn_Izmeni_Pozornik, POZORNIK);
        }

        private void btn_Obrisi_Pozornik_Click(object sender, EventArgs e) //DELETE za tabelu POZORNIK  [BUTTON]*
        {
            DeleteRow("POZORNIK", dgv_Pozornik);
        }

        private void btn_Obnovi_Pozornik_Click(object sender, EventArgs e) //SELECT * za tabelu POZORNIK  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Cin CRUD Buttons
        private void btn_Nadji_Cin_Click(object sender, EventArgs e) //SELECT za tabelu CIN  [BUTTON]*
        {
            SelectCRUD(dgv_Cin, btn_Nadji_Cin, CIN);
        }
        private void btn_Dodaj_Cin_Click(object sender, EventArgs e) //INSERT za tabelu CIN  [BUTTON]*
        {
            InsertCRUD(dgv_Cin, btn_Dodaj_Cin, CIN);
        }
        private void btn_Izmeni_Cin_Click(object sender, EventArgs e) //UPDATE za tabelu CIN  [BUTTON]*
        {
            UpdateCRUD(dgv_Cin, btn_Izmeni_Cin, CIN);
        }
        private void btn_Obrisi_Cin_Click(object sender, EventArgs e) //DELETE za tabelu CIN  [BUTTON]*
        {
            DeleteRow("CIN", dgv_Cin);
        }
        private void btn_Obnovi_Cin_Click(object sender, EventArgs e) //SELECT * za tabelu CIN  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Ustanova CRUD Buttons
        private void btn_Nadji_Ustanova_Click(object sender, EventArgs e) //SELECT za tabelu USTANOVA  [BUTTON]*
        {
            SelectCRUD(dgv_Ustanova, btn_Nadji_Ustanova, USTANOVA);
        }
        private void btn_Dodaj_Ustanova_Click(object sender, EventArgs e) //INSERT za tabelu USTANOVA  [BUTTON]*
        {
            InsertCRUD(dgv_Ustanova, btn_Dodaj_Ustanova, USTANOVA);
        }
        private void btn_Izmeni_Ustanova_Click(object sender, EventArgs e) //UPDATE za tabelu USTANOVA  [BUTTON]*
        {
            UpdateCRUD(dgv_Ustanova, btn_Izmeni_Ustanova, USTANOVA);
        }
        private void btn_Obrisi_Ustanova_Click(object sender, EventArgs e) //DELETE za tabelu USTANOVA  [BUTTON]*
        {
            DeleteRow("USTANOVA", dgv_Ustanova);
        }
        private void btn_Obnovi_Ustanova_Click(object sender, EventArgs e) //SELECT * za tabelu USTANOVA  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Skola CRUD Buttons
        private void btn_Nadji_Skola_Click(object sender, EventArgs e) //SELECT za tabelu SKOLA  [BUTTON]*
        {
            SelectCRUD(dgv_Skola, btn_Nadji_Skola, SKOLA);
        }
        private void btn_Dodaj_Skola_Click(object sender, EventArgs e) //INSERT za tabelu SKOLA  [BUTTON]*
        {
            InsertCRUD(dgv_Skola, btn_Dodaj_Skola, SKOLA);
        }
        private void btn_Izmeni_Skola_Click(object sender, EventArgs e) //UPDATE za tabelu SKOLA  [BUTTON]*
        {
            UpdateCRUD(dgv_Skola, btn_Izmeni_Skola, SKOLA);
        }
        private void btn_Obrisi_Skola_Click(object sender, EventArgs e) //DELETE za tabelu SKOLA  [BUTTON]*
        {
            DeleteRow("SKOLA", dgv_Skola);
        }
        private void btn_Obnovi_Skola_Click(object sender, EventArgs e) //SELECT * za tabelu SKOLA  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Skolski CRUD Buttons
        private void btn_Nadji_Skolski_Click(object sender, EventArgs e) //SELECT za tabelu SKOLSKI  [BUTTON]*
        {
            SelectCRUD(dgv_Skolski, btn_Nadji_Skolski, SKOLSKI);
        }
        private void btn_Dodaj_Skolski_Click(object sender, EventArgs e) //INSERT za tabelu SKOLSKI  [BUTTON]*
        {
            InsertCRUD(dgv_Skolski, btn_Dodaj_Skolski, SKOLSKI);
        }
        private void btn_Izmeni_Skolski_Click(object sender, EventArgs e) //UPDATE za tabelu SKOLSKI  [BUTTON]*
        {
            UpdateCRUD(dgv_Skolski, btn_Izmeni_Skolski, SKOLSKI);
        }
        private void btn_Obrisi_Skolski_Click(object sender, EventArgs e) //DELETE za tabelu SKOLSKI  [BUTTON]*
        {
            DeleteRow("SKOLSKI", dgv_Skolski);
        }
        private void btn_Obnovi_Skolski_Click(object sender, EventArgs e) //SELECT * za tabelu SKOLSKI  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Ulica CRUD Buttons
        private void btn_Nadji_Ulica_Click(object sender, EventArgs e) //SELECT za tabelu Ulica  [BUTTON]*
        {
            SelectCRUD(dgv_Ulica, btn_Nadji_Ulica, Ulica);
        }
        private void btn_Dodaj_Ulica_Click(object sender, EventArgs e) //INSERT za tabelu Ulica  [BUTTON]*
        {
            InsertCRUD(dgv_Ulica, btn_Dodaj_Ulica, Ulica);
        }
        private void btn_Izmeni_Ulica_Click(object sender, EventArgs e) //UPDATE za tabelu Ulica  [BUTTON]*
        {
            UpdateCRUD(dgv_Ulica, btn_Izmeni_Ulica, Ulica);
        }
        private void btn_Obrisi_Ulica_Click(object sender, EventArgs e) //DELETE za tabelu Ulica  [BUTTON]*
        {
            DeleteRow("Ulica", dgv_Ulica);
        }
        private void btn_Obnovi_Ulica_Click(object sender, EventArgs e) //SELECT * za tabelu Ulica  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Objekat CRUD Buttons
        private void btn_Nadji_Objekat_Click(object sender, EventArgs e) //SELECT za tabelu OBJEKAT  [BUTTON]*
        {
            SelectCRUD(dgv_Objekat, btn_Nadji_Objekat, OBJEKAT);
        }
        private void btn_Dodaj_Objekat_Click(object sender, EventArgs e) //INSERT za tabelu OBJEKAT  [BUTTON]*
        {
            InsertCRUD(dgv_Objekat, btn_Dodaj_Objekat, OBJEKAT);
        }
        private void btn_Izmeni_Objekat_Click(object sender, EventArgs e) //UPDATE za tabelu OBJEKAT  [BUTTON]*
        {
            UpdateCRUD(dgv_Objekat, btn_Izmeni_Objekat, OBJEKAT);
        }
        private void btn_Obrisi_Objekat_Click(object sender, EventArgs e) //DELETE za tabelu OBJEKAT  [BUTTON]*
        {
            DeleteRow("OBJEKAT", dgv_Objekat);
        }
        private void btn_Obnovi_Objekat_Click(object sender, EventArgs e) //SELECT * za tabelu OBJEKAT  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Ostali CRUD Buttons
        private void btn_Nadji_Ostali_Click(object sender, EventArgs e) //SELECT za tabelu OSTALI  [BUTTON]*
        {
            SelectCRUD(dgv_Ostali, btn_Nadji_Ostali, OSTALI);
        }
        private void btn_Dodaj_Ostali_Click(object sender, EventArgs e) //INSERT za tabelu OSTALI  [BUTTON]*
        {
            InsertCRUD(dgv_Ostali, btn_Dodaj_Ostali, OSTALI);
        }
        private void btn_Izmeni_Ostali_Click(object sender, EventArgs e) //UPDATE za tabelu OSTALI  [BUTTON]*
        {
            UpdateCRUD(dgv_Ostali, btn_Izmeni_Ostali, OSTALI);
        }
        private void btn_Obrisi_Ostali_Click(object sender, EventArgs e) //DELETE za tabelu OSTALI  [BUTTON]*
        {
            DeleteRow("OSTALI", dgv_Ostali);
        }
        private void btn_Obnovi_Ostali_Click(object sender, EventArgs e) //SELECT * za tabelu OSTALI  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Alarmni_Sistem CRUD Buttons
        private void btn_Nadji_AlarmniSistem_Click(object sender, EventArgs e) //SELECT za tabelu ALARMNI_SISTEM  [BUTTON]*
        {
            SelectCRUD(dgv_AlarmniSistem, btn_Nadji_AlarmniSistem, ALARMNI_SISTEM);
        }
        private void btn_Dodaj_AlarmniSistem_Click(object sender, EventArgs e) //INSERT za tabelu ALARMNI_SISTEM  [BUTTON]*
        {
            InsertCRUD(dgv_AlarmniSistem, btn_Dodaj_AlarmniSistem, ALARMNI_SISTEM);
        }
        private void btn_Izmeni_AlarmniSistem_Click(object sender, EventArgs e) //UPDATE za tabelu ALARMNI_SISTEM  [BUTTON]*
        {
            UpdateCRUD(dgv_AlarmniSistem, btn_Izmeni_AlarmniSistem, ALARMNI_SISTEM);
        }
        private void btn_Obrisi_AlarmniSistem_Click(object sender, EventArgs e) //DELETE za tabelu ALARMNI_SISTEM  [BUTTON]*
        {
            DeleteRow("ALARMNI_SISTEM", dgv_AlarmniSistem);
        }
        private void btn_Obnovi_AlarmniSistem_Click(object sender, EventArgs e) //SELECT * za tabelu ALARMNI_SISTEM  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region VanredneSituacije CRUD Buttons
        private void btn_Nadji_VanredneSituacije_Click(object sender, EventArgs e) //SELECT za tabelu VANREDNE_SITUACIJE  [BUTTON]*
        {
            SelectCRUD(dgv_VanredneSituacije, btn_Nadji_VanredneSituacije, VANREDNE_SITUACIJE);
        }
        private void btn_Dodaj_VanredneSituacije_Click(object sender, EventArgs e) //INSERT za tabelu VANREDNE_SITUACIJE  [BUTTON]*
        {
            InsertCRUD(dgv_VanredneSituacije, btn_Dodaj_VanredneSituacije, VANREDNE_SITUACIJE);
        }
        private void btn_Izmeni_VanredneSituacije_Click(object sender, EventArgs e) //UPDATE za tabelu VANREDNE_SITUACIJE  [BUTTON]*
        {
            UpdateCRUD(dgv_VanredneSituacije, btn_Izmeni_VanredneSituacije, VANREDNE_SITUACIJE);
        }
        private void btn_Obrisi_VanredneSituacije_Click(object sender, EventArgs e) //DELETE za tabelu VANREDNE_SITUACIJE  [BUTTON]*
        {
            DeleteRow("VANREDNE_SITUACIJE", dgv_VanredneSituacije);
        }
        private void btn_Obnovi_VanredneSituacije_Click(object sender, EventArgs e) //SELECT * za tabelu VANREDNE_SITUACIJE  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region TehnickoLice CRUD Buttons
        private void btn_Nadji_TehnickoLice_Click(object sender, EventArgs e) //SELECT za tabelu TEHNICKO_LICE  [BUTTON]*
        {
            SelectCRUD(dgv_TehnickoLice, btn_Nadji_TehnickoLice, TEHNICKO_LICE);
        }
        private void btn_Dodaj_TehnickoLice_Click(object sender, EventArgs e) //INSERT za tabelu TEHNICKO_LICE  [BUTTON]*
        {
            InsertCRUD(dgv_TehnickoLice, btn_Dodaj_TehnickoLice, TEHNICKO_LICE);
        }
        private void btn_Izmeni_TehnickoLice_Click(object sender, EventArgs e) //UPDATE za tabelu TEHNICKO_LICE  [BUTTON]*
        {
            UpdateCRUD(dgv_TehnickoLice, btn_Izmeni_TehnickoLice, TEHNICKO_LICE);
        }
        private void btn_Obrisi_TehnickoLice_Click(object sender, EventArgs e) //DELETE za tabelu TEHNICKO_LICE  [BUTTON]*
        {
            DeleteRow("TEHNICKO_LICE", dgv_TehnickoLice);
        }
        private void btn_Obnovi_TehnickoLice_Click(object sender, EventArgs e) //SELECT * za tabelu TEHNICKO_LICE  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #region Vozilo CRUD Buttons
        private void btn_Nadji_Vozilo_Click(object sender, EventArgs e) //SELECT za tabelu VOZILO  [BUTTON]*
        {
            SelectCRUD(dgv_Vozilo, btn_Nadji_Vozilo, VOZILO);
        }
        private void btn_Dodaj_Vozilo_Click(object sender, EventArgs e) //INSERT za tabelu VOZILO  [BUTTON]*
        {
            InsertCRUD(dgv_Vozilo, btn_Dodaj_Vozilo, VOZILO);
        }
        private void btn_Izmeni_Vozilo_Click(object sender, EventArgs e) //UPDATE za tabelu VOZILO  [BUTTON]*
        {
            UpdateCRUD(dgv_Vozilo, btn_Izmeni_Vozilo, VOZILO);
        }
        private void btn_Obrisi_Vozilo_Click(object sender, EventArgs e) //DELETE za tabelu VOZILO  [BUTTON]*
        {
            DeleteRow("VOZILO", dgv_Vozilo);
        }
        private void btn_Obnovi_Vozilo_Click(object sender, EventArgs e) //SELECT * za tabelu VOZILO  [BUTTON]*
        {
            DisplayAllData();
        }
        #endregion
        
        #endregion
        
    }
}
