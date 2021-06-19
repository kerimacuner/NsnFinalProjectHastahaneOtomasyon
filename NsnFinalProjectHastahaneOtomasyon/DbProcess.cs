using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using NsnFinalProjectHastahaneOtomasyon.Models;

namespace NsnFinalProjectHastahaneOtomasyon
{
    public class DbProcess
    {
        private OleDbConnection connection;
        private OleDbCommand oleDbCommand;
        private OleDbDataReader oleDbDataReader;
        private OleDbDataAdapter oleDbDataAdapter;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Hastahane.accdb";

        public DataTable GetLiDataTable()
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();

            oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Hastalar", connection);
            DataTable tablo = new DataTable();
            oleDbDataAdapter.Fill(tablo);
            connection.Close();
            return tablo;

        }

        public DataTable GetCalisanTable()
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();

            oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar", connection);
            DataTable tablo = new DataTable();
            oleDbDataAdapter.Fill(tablo);
            connection.Close();
            return tablo;

        }
        public DataTable GetCalisanTable(string Ad,string Soyad,string Telefon,string TC,string KullaniciAdi)
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
            if (!String.IsNullOrEmpty(Ad)&& !String.IsNullOrEmpty(Soyad))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar where Ad='" + Ad + "' and Soyad='" + Soyad + "'", connection);
            }
            else if (!String.IsNullOrEmpty(Ad))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar where Ad='" + Ad + "'", connection);

            }
            else if (!String.IsNullOrEmpty(Soyad))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar where Soyad='" + Soyad + "'", connection);

            }
            else if (!String.IsNullOrEmpty(Telefon))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar where Telefon='" + Telefon + "'", connection);

            }
            else if (!String.IsNullOrEmpty(TC))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar where TC='" + TC + "'", connection);

            }
            else if (!String.IsNullOrEmpty(KullaniciAdi))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar where KullaniciAdi='" + KullaniciAdi + "'", connection);

            }
            DataTable tablo = new DataTable();
            oleDbDataAdapter.Fill(tablo);
            connection.Close();
            return tablo;

        }

        public DataTable GetHastaTable(string Ad, string Soyad, string Telefon, string TC)
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
            if (!String.IsNullOrEmpty(Ad) && !String.IsNullOrEmpty(Soyad))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Hastalar where Ad='" + Ad + "' and Soyad='" + Soyad + "'", connection);
            }
            else if (!String.IsNullOrEmpty(Ad))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Hastalar where Ad='" + Ad + "'", connection);

            }
            else if (!String.IsNullOrEmpty(Soyad))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Hastalar where Soyad='" + Soyad + "'", connection);

            }
            else if (!String.IsNullOrEmpty(Telefon))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Hastalar where Telefon='" + Telefon + "'", connection);

            }
            else if (!String.IsNullOrEmpty(TC))
            {
                oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Hastalar where TC='" + TC + "'", connection);

            }
            DataTable tablo = new DataTable();
            oleDbDataAdapter.Fill(tablo);
            connection.Close();
            return tablo;

        }

        public bool SetHastaTable(HastaModel hastaModel)
        {
            connection = new OleDbConnection(connectionString);
            oleDbCommand = new OleDbCommand();
            connection.Open();
            oleDbCommand.Connection = connection;
            oleDbCommand.CommandText = "insert into Hastalar (KayitTarihi,TC,Ad,Soyad,Telefon) values ('" + hastaModel.Kayıtarihi + "','" + hastaModel.TC + "','" + hastaModel.Ad + "','" + hastaModel.Soyad + "','" + hastaModel.Telefon + "')";
            if (oleDbCommand.ExecuteNonQuery()!=0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;

        }

        public bool UpdateHastaTable(HastaModel hastaModel)
        {
            connection = new OleDbConnection(connectionString);
            oleDbCommand = new OleDbCommand();
            connection.Open();
            oleDbCommand.Connection = connection;
            oleDbCommand.CommandText = "update Hastalar set TC='"+hastaModel.TC+ "',Ad='" + hastaModel.Ad + "',Soyad='" + hastaModel.Soyad + "',Telefon='" + hastaModel.Telefon + "' where HastaID="+hastaModel.HastaID+"";
            if (oleDbCommand.ExecuteNonQuery() != 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;

        }

        public bool UpdateCalisanTable(CalisanModel calisanModel)
        {
            connection = new OleDbConnection(connectionString);
            oleDbCommand = new OleDbCommand();
            connection.Open();
            oleDbCommand.Connection = connection;
            oleDbCommand.CommandText = "update Calisanlar set KullaniciAdi='" + calisanModel.KullaniciAdi + "',Sifresi='" + calisanModel.Sifresi + "',TC='" + calisanModel.TC + "',Ad='" + calisanModel.Ad + "',Soyad='" + calisanModel.Soyad + "',Telefon='" + calisanModel.Telefon + "' where CalisanID=" + calisanModel.CalisanID + "";
            if (oleDbCommand.ExecuteNonQuery() != 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;

        }


        public bool SetCalisanTable(CalisanModel calisanModel)
        {
            connection = new OleDbConnection(connectionString);
            oleDbCommand = new OleDbCommand();
            connection.Open();
            oleDbCommand.Connection = connection;
            oleDbCommand.CommandText = "insert into Calisanlar (KullaniciAdi,Sifresi,TC,Ad,Soyad,Telefon) values ('" + calisanModel.KullaniciAdi + "','" + calisanModel.Sifresi + "','" + calisanModel.TC + "','" + calisanModel.Ad + "','" + calisanModel.Soyad + "','" + calisanModel.Telefon + "')";
            if (oleDbCommand.ExecuteNonQuery() != 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;

        }

        public bool DeleteCalisanTable(int id)
        {
            connection = new OleDbConnection(connectionString);
            oleDbCommand = new OleDbCommand();
            connection.Open();
            oleDbCommand.Connection = connection;
            oleDbCommand.CommandText = "delete from Calisanlar where CalisanID="+id+"";
            if (oleDbCommand.ExecuteNonQuery() != 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;


            return false;
        }

        public bool DeleteHastaTable(int id)
        {
            connection = new OleDbConnection(connectionString);
            oleDbCommand = new OleDbCommand();
            connection.Open();
            oleDbCommand.Connection = connection;
            oleDbCommand.CommandText = "delete from Hastalar where HastaID=" + id + "";
            if (oleDbCommand.ExecuteNonQuery() != 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;


            return false;
        }


        public int Login(string kullaniciAdi, string password)
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
            oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM Calisanlar WHERE (((Calisanlar.KullaniciAdi)='" + kullaniciAdi + "') AND ((Calisanlar.Sifresi)='" + password + "'))", connection);
            DataTable dt = new DataTable();
            oleDbDataAdapter.Fill(dt);
            var dtList = ConvertToList<LoginModel>(dt);

            if (dtList.Count != 0)
            {
                var model = ConvertToModel(dtList);
                connection.Close();
                return model.CalisanID;
            }

            connection.Close();
            return 0;
        }





        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }

        public static T ConvertToModel<T>(List<T> list)
        {
            return list.Single();
        }


    }
}
