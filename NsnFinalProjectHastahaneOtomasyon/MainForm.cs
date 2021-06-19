using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using NsnFinalProjectHastahaneOtomasyon.Models;

namespace NsnFinalProjectHastahaneOtomasyon
{
    public partial class MainForm : Form
    {
        private static int KullaniciID;
        private static DbProcess db = new DbProcess();
        public MainForm(int id)
        {
            KullaniciID = id;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDAtaView();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnHastaEkle_Click(object sender, EventArgs e)
        {
            HastaModel model = new HastaModel();

            model.Ad = txtHastaAd.Text;
            model.Kayıtarihi = DateTime.Now;
            model.Soyad = txtHastaSoyad.Text;
            model.TC = txtHastaTC.Text;
            model.Telefon = txtHastaTelefon.Text;
            if (String.IsNullOrEmpty(model.Ad)|| String.IsNullOrEmpty(model.Soyad) || String.IsNullOrEmpty(model.TC) || String.IsNullOrEmpty(model.Telefon))
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
            }
            else
            {
                var result = db.SetHastaTable(model);
                if (result)
                {
                    RefreshDAtaView();
                    tabControl1.SelectedTab = tabControl1.TabPages["Liste"];
                }
                else
                {
                    MessageBox.Show("Hasta ekelme başarısız");
                }
            }

        }

        private void RefreshDAtaView()
        {
            DataTable tableHasta = db.GetLiDataTable();
            var tableCalisan = db.GetCalisanTable();
            dataGridView1.DataSource = tableHasta;

            dataGridView2.DataSource = tableCalisan;
        }
        private void btnCalisanEkle_Click(object sender, EventArgs e)
        {
            CalisanModel model = new CalisanModel()
            {
                Ad = txtCalisanAd.Text,
                TC = txtCalisanTC.Text,
                Soyad = txtCalisanSoyad.Text,
                Telefon = txtCalisanTelefon.Text,
                KullaniciAdi = txtCalisanKullaniciAdi.Text,
                Sifresi = txtCalisanSifre.Text
            };

            if (String.IsNullOrEmpty(model.Ad) || String.IsNullOrEmpty(model.Soyad) || String.IsNullOrEmpty(model.TC) || String.IsNullOrEmpty(model.Telefon) || String.IsNullOrEmpty(model.KullaniciAdi) || String.IsNullOrEmpty(model.Sifresi))
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
            }
            else
            {
                var result = db.SetCalisanTable(model);
                if (result)
                {
                    RefreshDAtaView();
                    tabControl1.SelectedTab = tabControl1.TabPages["Liste"];
                }
                else
                {
                    MessageBox.Show("Hasta ekelme başarısız");
                }
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name =="HGuncelle")
            {
                //MessageBox.Show("Guncelle"+dataGridView1.CurrentRow.Cells["HastaID"].Value);
                txtGHastaAd.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
                txtGHastaSoyad.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
                txtGHastaTC.Text = dataGridView1.CurrentRow.Cells["TC"].Value.ToString();
                txtGHastaTelefon.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
                tabControl1.SelectedTab = tabControl1.TabPages["Guncelleme"];
                tabControl3.SelectedTab = tabControl3.TabPages["HastaGuncelle"];
                KullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HastaID"].Value);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "HSil")
            {
                DialogResult result = MessageBox.Show("Silmek istediğinizden eminmisinz!", "Silme işlemi",
                    MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    var sonuc = db.DeleteHastaTable(Convert.ToInt32(dataGridView1.CurrentRow.Cells["HastaID"].Value));
                    if (sonuc)
                    {
                        MessageBox.Show("Silme Başarılı");
                        RefreshDAtaView();
                        tabControl1.SelectedTab = tabControl1.TabPages["Liste"];
                        tabControl4.SelectedTab = tabControl4.TabPages["Hastalar"];

                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaModel model = new HastaModel()
            {
                HastaID = KullaniciID,
                Ad = txtGHastaAd.Text,
                TC = txtGHastaTC.Text,
                Soyad = txtGHastaSoyad.Text,
                Telefon = txtGHastaTelefon.Text
            };

            var result = db.UpdateHastaTable(model);
            if (result)
            {
                MessageBox.Show("Güncelleme Başarılı");
                RefreshDAtaView();
                tabControl1.SelectedTab = tabControl1.TabPages["Liste"];
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalisanModel model = new CalisanModel()
            {
                CalisanID = KullaniciID,
                Ad = txtGCalisanAd.Text,
                TC = txtGCalisanTC.Text,
                Soyad = txtGCalisanSoyad.Text,
                Telefon = txtGCalisanTelefon.Text,
                KullaniciAdi = txtGCalisanKullaniciAdi.Text,
                Sifresi = txtGCalisanSifre.Text
            };

            var result = db.UpdateCalisanTable(model);
            if (result)
            {
                MessageBox.Show("Güncelleme Başarılı");
                RefreshDAtaView();
                tabControl1.SelectedTab = tabControl1.TabPages["Liste"];
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "CGuncelle")
            {
                //MessageBox.Show("Guncelle"+dataGridView1.CurrentRow.Cells["HastaID"].Value);
                txtGCalisanKullaniciAdi.Text = dataGridView2.CurrentRow.Cells["KullaniciAdi"].Value.ToString();
                txtGCalisanSifre.Text = dataGridView2.CurrentRow.Cells["Sifresi"].Value.ToString();
                txtGCalisanTC.Text = dataGridView2.CurrentRow.Cells["CTC"].Value.ToString();
                txtGCalisanAd.Text = dataGridView2.CurrentRow.Cells["CAd"].Value.ToString();
                txtGCalisanSoyad.Text = dataGridView2.CurrentRow.Cells["CSoyad"].Value.ToString();
                txtGCalisanTelefon.Text = dataGridView2.CurrentRow.Cells["CTelefon"].Value.ToString();
                tabControl1.SelectedTab = tabControl1.TabPages["Guncelleme"];
                tabControl3.SelectedTab = tabControl3.TabPages["CalisanGuncelle"];
                KullaniciID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["CalisanID"].Value);
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "CSil")
            {
                //MessageBox.Show("Sil" + dataGridView2.CurrentRow.Cells["HastaID"].Value);
                DialogResult result = MessageBox.Show("Silmek istediğinizden eminmisinz!", "Silme işlemi",
                    MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    var sonuc = db.DeleteCalisanTable(Convert.ToInt32(dataGridView2.CurrentRow.Cells["CalisanID"].Value));
                    if (sonuc)
                    {
                        MessageBox.Show("Silme Başarılı");
                        RefreshDAtaView();
                        tabControl1.SelectedTab = tabControl1.TabPages["Liste"];
                        tabControl4.SelectedTab = tabControl4.TabPages["Calisanlar"];

                    }
                }


            }

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAAd.Text)|| !String.IsNullOrEmpty(txtASoyad.Text) || !String.IsNullOrEmpty(txtATC.Text) || !String.IsNullOrEmpty(txtATelefon.Text))
            {
                //iki listede aranma
                DataTable table1 = db.GetCalisanTable(txtAAd.Text, txtASoyad.Text, txtATelefon.Text, txtATC.Text, txtAKullaniciAdi.Text);
                DataTable table2 = db.GetHastaTable(txtAAd.Text, txtASoyad.Text, txtATelefon.Text, txtATC.Text);
                dataGridView3.DataSource = table1;
                dataGridView4.DataSource = table2;
            }
            else if (!String.IsNullOrEmpty(txtAKullaniciAdi.Text))
            {
                //calisanlarda arama
                DataTable table = db.GetCalisanTable(txtAAd.Text,txtASoyad.Text,txtATelefon.Text,txtATC.Text,txtAKullaniciAdi.Text);
                dataGridView3.DataSource = table;
            }
            else
            {
                MessageBox.Show("Lütfen Alanlardan en az birini doldurunuz.!");
                dataGridView3.DataSource = null;
                dataGridView4.DataSource = null;
            }
        }
    }
}
