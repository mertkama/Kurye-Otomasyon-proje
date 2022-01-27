using KuryeOtomasyon.Model;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.DataAccessLayer
{
    public class SiparisDal:BaseDal
    {
        SqlConnection connection = new SqlConnection();
        public int SiparisEkle(SiparisModel siparis)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Siparis VALUES(@PaketAciklama,@Agirlik,@Fiyat,@GonderiAdresi,@MusteriId,@SiparisDurumu,@YuklenmeTarihi,@GuncellenmeTarihi)", connection);

                command.Parameters.AddWithValue("@PaketAciklama", siparis.PaketAciklama);
                command.Parameters.AddWithValue("@Agirlik", siparis.Agirlik);
                command.Parameters.AddWithValue("@Fiyat", siparis.Fiyat);
                command.Parameters.AddWithValue("@GonderiAdresi", siparis.GonderiAdresi);
                command.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                command.Parameters.AddWithValue("@SiparisDurumu", siparis.SiparisDurumu);
                command.Parameters.AddWithValue("@YuklenmeTarihi", siparis.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", siparis.GuncellenmeTarihi);

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


        public int SiparisGuncelle (SiparisModel siparis)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand("UPDATE Siparis SET PaketAciklama=@PaketAciklama,Agirlik=@Agirlik,Fiyat=@Fiyat,GonderiAdresi=@GonderiAdresi,MusteriId=@MusteriId,SiparisDurumu=@SiparisDurumu,GuncellenmeTarihi=@GuncellenmeTarihi WHERE SiparisId=@SiparisId", connection);
                command.Parameters.AddWithValue("@PaketAciklama", siparis.PaketAciklama);
                command.Parameters.AddWithValue("@Agirlik", siparis.Agirlik);
                command.Parameters.AddWithValue("@Fiyat", siparis.Fiyat);
                command.Parameters.AddWithValue("@GonderiAdresi", siparis.GonderiAdresi);
                command.Parameters.AddWithValue("@MusteriId", siparis.MusteriId);
                command.Parameters.AddWithValue("@SiparisDurumu", siparis.SiparisDurumu);
                command.Parameters.AddWithValue("@SiparisId", siparis.SiparisId);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", siparis.GuncellenmeTarihi);

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


        public int SiparisSil(int id)
        {
            int sonuc = 0;
            connection = Connect();


            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Siparis WHERE SiparisId=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);


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

        public List<SiparisModel> SiparisListele()
        {
            connection = Connect();
            List<SiparisModel> siparisListesi = new List<SiparisModel>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Siparis", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SiparisModel siparis = new SiparisModel();

                    siparis.SiparisId = Convert.ToInt32(reader["SiparisId"]);
                    siparis.Agirlik = Convert.ToDouble(reader["Agirlik"]);
                    siparis.Fiyat = Convert.ToDouble(reader["Fiyat"]);
                    siparis.GonderiAdresi = reader["GonderiAdresi"].ToString();
                    siparis.GuncellenmeTarihi = Convert.ToDateTime(reader["GuncellenmeTarihi"]);
                    siparis.MusteriId = Convert.ToInt32(reader["MusteriId"]);
                    siparis.PaketAciklama = reader["PaketAciklama"].ToString();
                    siparis.YuklenmeTarihi = Convert.ToDateTime(reader["YuklenmeTarihi"]);
                    siparis.SiparisDurumu = Convert.ToInt32(reader["SiparisDurumu"]);


                    siparisListesi.Add(siparis);
                }

            }
            catch (Exception)
            {

                SiparisModel siparis = new SiparisModel();
                siparis.PaketAciklama = "Hata";

                siparisListesi.Add(siparis);
            }


            return siparisListesi;
        }

        public SiparisModel SiparisGetir(int id)
        {
            connection = Connect();
            SiparisModel siparis = new SiparisModel();


            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Siparis WHERE SiparisId=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    siparis.Agirlik = Convert.ToDouble(reader["Agirlik"]);
                    siparis.Fiyat = Convert.ToDouble(reader["Fiyat"]);
                    siparis.GonderiAdresi = reader["GonderiAdresi"].ToString();
                    siparis.GuncellenmeTarihi = Convert.ToDateTime(reader["GuncellenmeTarihi"]);
                    siparis.MusteriId = Convert.ToInt32(reader["MusteriId"]);
                    siparis.PaketAciklama = reader["PaketAciklama"].ToString();
                    siparis.YuklenmeTarihi = Convert.ToDateTime(reader["YuklenmeTarihi"]);
                    siparis.SiparisDurumu = Convert.ToInt32(reader["SiparisDurumu"]);


                }


            }
            catch (Exception ex)
            {

                siparis.PaketAciklama = "Hata";
            }


            return siparis;
        }
    }
}
