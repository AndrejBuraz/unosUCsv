using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace UpisivanjeUCsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            List<Osoba> listaOsoba = new List<Osoba>();
            try
            {
                Osoba osoba = new Osoba(textBoxIme.Text, textBoxPrezime.Text,textBoxEmail.Text, Convert.ToInt16(textBoxGodRodenja.Text));
                textBoxIme.Clear();
                textBoxPrezime.Clear();
                textBoxEmail.Clear();
                textBoxGodRodenja.Clear();
                listaOsoba.Add(osoba);

                using (var stream = File.Open("osobeFile.csv", FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(listaOsoba);
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message, "Pogrešan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

    internal class Osoba
    {
        string ime, prezime, email;
        int godRod;

        public override string ToString()
        {
            string ispis = "Ime: " + this.Ime +" Prezime: " + this.Prezime + " Godina rođenja: " + this.GodRod +" E-mail: " + this.Email;
            return ispis;
        }

        public Osoba(string ime, string prezime, string email, int godRod)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.GodRod = godRod;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Email { get => email; set => email = value; }
        public int GodRod { get => godRod; set => godRod = value; }
    }
}
