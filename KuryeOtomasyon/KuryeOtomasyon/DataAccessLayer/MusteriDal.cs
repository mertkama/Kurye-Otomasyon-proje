using KuryeOtomasyon.Model;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.DataAccessLayer
{
    public class MusteriDal:BaseDal
    {

        SqlConnection connection = new SqlConnection();
        public int MusteriEkle(MusteriModel musteri)
        {
            connection = Connect();
            int sonuc = 0;


            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Musteri VALUES(@MusteriAd,@MusteriSoyad,@Adres,@Telefon,@OzelMusteri,@YuklenmeTarihi,@GuncellenmeTarihi)", connection);

                command.Parameters.AddWithValue("@MusteriAd", musteri.MusteriAd);
                command.Parameters.AddWithValue("@MusteriSoyad", musteri.MusteriSoyad);
                command.Parameters.AddWithValue("@Adres", musteri.Adres);
                command.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                command.Parameters.AddWithValue("@OzelMusteri", musteri.OzelMusteri);
                command.Parameters.AddWithValue("@YuklenmeTarihi", musteri.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", musteri.GuncellenmeTarihi);


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

        public int MusteriGuncelle(MusteriModel musteri)
        {
            connection = Connect();
            int sonuc = 0;

            try
            {
                SqlCommand command = new SqlCommand("UPDATE Musteri SET MusteriAd=@MusteriAd,MusteriSoyad=@MusteriSoyad,Adres=@Adres,Telefon=@Telefon,OzelMusteri=@OzelMusteri,YuklenmeTarihi=@YuklenmeTarihi,GuncellenmeTarihi=@GuncellenmeTarihi WHERE MusteriId=@MusteriId", connection);

                command.Parameters.AddWithValue("@MusteriAd", musteri.MusteriAd);
                command.Parameters.AddWithValue("@MusteriSoyad", musteri.MusteriSoyad);
                command.Parameters.AddWithValue("@Adres", musteri.Adres);
                command.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                command.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);
                command.Parameters.AddWithValue("@OzelMusteri", musteri.OzelMusteri);
                command.Parameters.AddWithValue("@YuklenmeTarihi", musteri.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", musteri.GuncellenmeTarihi);


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

        public int MusteriSil(int id)
        {
            connection = Connect();
            int sonuc = 0;


            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Musteri WHERE MusteriId=@MusteriId", connection);
                command.Parameters.AddWithValue("@MusteriId", id);


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

        public List<MusteriModel> MusteriListele()
        {
            connection = Connect();
            List<MusteriModel> musteriListesi = new List<MusteriModel>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Musteri", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MusteriModel musteri = new MusteriModel();

                    musteri.MusteriAd = reader["MusteriAd"].ToString();
                    musteri.MusteriSoyad = reader["MusteriSoyad"].ToString();
                    musteri.Adres = reader["Adres"].ToString();
                    musteri.Telefon = reader["Telefon"].ToString();
                    musteri.OzelMusteri = Convert.ToBoolean(reader["OzelMusteri"]);
                    musteri.MusteriId = Convert.ToInt32(reader["MusteriId"]);


                    musteriListesi.Add(musteri);
                }

            }
            catch (Exception)
            {

                MusteriModel musteri = new MusteriModel();
                musteri.MusteriAd= "HATA";

                musteriListesi.Add(musteri);
            }


            return musteriListesi;
        }

        public MusteriModel MusteriGetir(int id)
        {
            connection = Connect();
            MusteriModel musteri = new MusteriModel();


            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Musteri WHERE MusteriId=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {                    

                    musteri.MusteriAd = reader["MusteriAd"].ToString();
                    musteri.MusteriSoyad = reader["MusteriSoyad"].ToString();
                    musteri.Adres = reader["Adres"].ToString();
                    musteri.Telefon = reader["Telefon"].ToString();
                    musteri.OzelMusteri = Convert.ToBoolean(reader["OzelMusteri"]);


              
                }


            }
            catch (Exception)
            {

                musteri.MusteriAd = "HATA";
            }


            return musteri;
        }
    }
}
