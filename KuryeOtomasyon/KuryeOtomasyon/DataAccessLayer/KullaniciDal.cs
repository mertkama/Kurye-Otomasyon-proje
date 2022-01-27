using KuryeOtomasyon.Model;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.DataAccessLayer
{
    public class KullaniciDal:BaseDal
    {
        SqlConnection connection = new SqlConnection();

        public int KullaniciEkle(KullaniciModel kullanici)
        {
            connection = Connect();

            int sonuc = 0;
            
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Kullanici VALUES (@KullaniciAdi,@Sifre,@YuklenmeTarihi,@GuncellenmeTarihi)", connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", kullanici.Sifre);
                command.Parameters.AddWithValue("@YuklenmeTarihi", kullanici.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", kullanici.GuncellenmeTarihi);

                connection.Open();

                sonuc = command.ExecuteNonQuery();

                connection.Close();


            }
            catch (Exception ex)
            {

                sonuc = -1;
            }


            return sonuc;
        }


        public int KullaniciGuncelle(KullaniciModel kullanici)
        {
            connection = Connect();
            int sonuc = 0;

            try
            {
                SqlCommand command = new SqlCommand("UPDATE Kullanici SET KullaniciAdi=@KullaniciAdi,Sifre=@Sifre,GuncellenmeTarihi=@GuncellenmeTarihi WHERE KullaniciId=@KullaniciId", connection);

                command.Parameters.AddWithValue("@KullaniciAdi",kullanici.KullaniciAdi);
                command.Parameters.AddWithValue("@KullaniciId", kullanici.KullaniciId);
                command.Parameters.AddWithValue("@Sifre", kullanici.Sifre);               
                command.Parameters.AddWithValue("@GuncellenmeTarihi", kullanici.GuncellenmeTarihi);


                connection.Open();

                sonuc= command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {

                sonuc = -1;
            }


            return sonuc;
        }

        public int KullaniciSil(int id)
        {
            connection = Connect();
            int sonuc = 0;

            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Kullanici WHERE KullaniciId=@KullaniciId", connection);
                command.Parameters.AddWithValue("@KullaniciId", id);

                connection.Open();

                sonuc = command.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception)
            {

                sonuc = -1;
            }


            return sonuc;
        }

        public List<KullaniciModel> KullaniciListele()
        {
            connection = Connect();
            List<KullaniciModel> kullaniciListesi = new List<KullaniciModel>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Kullanici", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KullaniciModel kullanici = new KullaniciModel();

                    kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                    kullanici.Sifre = reader["Sifre"].ToString();
                    kullanici.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);


                    kullaniciListesi.Add(kullanici);
                }

            }
            catch (Exception)
            {

                KullaniciModel kullanici = new KullaniciModel();
                kullanici.KullaniciAdi = "HATA";

                kullaniciListesi.Add(kullanici);
            }

            
            return kullaniciListesi;
        }


        public KullaniciModel KullaniciGetir(int id)
        {
            connection = Connect();
            KullaniciModel kullanici = new KullaniciModel();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Kullanici Where KullaniciId=@KullaniciId", connection);
                command.Parameters.AddWithValue("@KullaniciId", id);


                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   

                    kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                    kullanici.Sifre = reader["Sifre"].ToString();


                }

            }
            catch (Exception)
            {

                kullanici.KullaniciAdi = "HATA";

            }


            return kullanici;
        }


        public KullaniciModel Giris(string kullaniciAdi,string sifre)
        {
            connection = Connect();
            KullaniciModel kullanici = new KullaniciModel();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Kullanici Where KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre", connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", sifre);


                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                    kullanici.Sifre = reader["Sifre"].ToString();
                }

            }
            catch (Exception)
            {

                kullanici.KullaniciAdi = "HATA";

            }


            return kullanici;
        }

        public bool KullaniciAdiKontrol(string kullaniciAdi)
        {
            KullaniciModel kullanici = new KullaniciModel();

            connection = Connect();

            try
            {
                SqlCommand command1 = new SqlCommand("SELECT * FROM Kullanici Where KullaniciAdi=@KullaniciAdi", connection);
                command1.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
               

                if(connection.State==System.Data.ConnectionState.Closed)
                    connection.Open();  

                SqlDataReader reader = command1.ExecuteReader();
                
              

                while (reader.Read())
                {
                    kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                    kullanici.Sifre = reader["Sifre"].ToString();
                }


                if (kullanici.KullaniciAdi != null)
                    return false;
                else
                    return true;

                //reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {

                return false;

            }
           
        }
    }
}
