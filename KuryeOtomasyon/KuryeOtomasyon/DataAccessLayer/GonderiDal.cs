using KuryeOtomasyon.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.DataAccessLayer
{
    public class GonderiDal : BaseDal
    {
        SqlConnection connection = new SqlConnection();
        public int GonderiEkle(Model.Gonderiler gonderi)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Gonderi VALUES(@SiparisId,@KuryeId,@YuklenmeTarihi,@GuncellenmeTarihi,@Durum)", connection);

                command.Parameters.AddWithValue("@SiparisId", gonderi.SiparisId);
                command.Parameters.AddWithValue("@KuryeId", gonderi.KuryeId);
                command.Parameters.AddWithValue("@YuklenmeTarihi", gonderi.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", gonderi.GuncellenmeTarihi);
                command.Parameters.AddWithValue("@Durum", gonderi.Durum);

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


        public int GonderiGuncelle(Model.Gonderiler gonderi)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand(@"UPDATE Siparis SET 
                                                        SiparisId=@SiparisId,
                                                        KuryeId=@KuryeId,
                                                        YuklenmeTarihi=@YuklenmeTarihi,
                                                        GuncellenmeTarihi=@GuncellenmeTarihi,
                                                        Durum=@Durum
                                                WHERE GonderiId=@GonderiId", connection);
                command.Parameters.AddWithValue("@SiparisId", gonderi.SiparisId);
                command.Parameters.AddWithValue("@KuryeId", gonderi.KuryeId);
                command.Parameters.AddWithValue("@YuklenmeTarihi", gonderi.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", gonderi.GuncellenmeTarihi);
                command.Parameters.AddWithValue("@Durum", gonderi.Durum);
                command.Parameters.AddWithValue("@GonderiId", gonderi.GonderiId);

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


        public int GonderiSil(int id)
        {
            int sonuc = 0;
            connection = Connect();


            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Gonderi WHERE GonderiId=@Id", connection);
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

        public List<Model.Gonderiler> GonderiListele()
        {
            connection = Connect();
            List<Model.Gonderiler> gonderiListesi = new List<Model.Gonderiler>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Gonderi", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Model.Gonderiler gonderi = new Model.Gonderiler();

                    gonderi.GonderiId = Convert.ToInt32(reader["GonderiId"]);
                    gonderi.KuryeId = Convert.ToInt32(reader["KuryeId"]);
                    gonderi.SiparisId = Convert.ToInt32(reader["Sipariş"]);
                    gonderi.YuklenmeTarihi = Convert.ToDateTime(reader["YuklenmeTarihi"]);
                    gonderi.GuncellenmeTarihi = Convert.ToDateTime(reader["GuncellenmeTarihi"]);
                    gonderi.Durum = Convert.ToInt32(reader["Durum"]);


                    gonderiListesi.Add(gonderi);
                }

            }
            catch (Exception)
            {

                Model.Gonderiler gonderi = new Model.Gonderiler();
                gonderi.KuryeId = -1;

                gonderiListesi.Add(gonderi);
            }


            return gonderiListesi;
        }

        public Model.Gonderiler GonderiGetir(int id)
        {
            connection = Connect();
            Model.Gonderiler gonderi = new Model.Gonderiler();


            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Gonderi WHERE GonderiId=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    gonderi.GonderiId = Convert.ToInt32(reader["GonderiId"]);
                    gonderi.KuryeId = Convert.ToInt32(reader["KuryeId"]);
                    gonderi.SiparisId = Convert.ToInt32(reader["Sipariş"]);
                    gonderi.YuklenmeTarihi = Convert.ToDateTime(reader["YuklenmeTarihi"]);
                    gonderi.GuncellenmeTarihi = Convert.ToDateTime(reader["GuncellenmeTarihi"]);
                    gonderi.Durum = Convert.ToInt32(reader["Durum"]);



                }


            }
            catch (Exception)
            {

                gonderi.GonderiId = -1;
            }


            return gonderi;
        }

        public List<GonderiModel> AktifGonderiListele()
        {
            connection = Connect();
            List<GonderiModel> gonderiListesi = new List<GonderiModel>();

            try
            {
                SqlCommand command = new SqlCommand(@"SELECT GonderiId,Agirlik,GonderiAdresi,MusteriAd +' ' + MusteriSoyad AS Musteri FROM Gonderi
                        INNER JOIN Siparis ON Gonderi.SiparisId=Siparis.SiparisId
                        INNER JOIN Musteri ON Musteri.MusteriId=Siparis.MusteriId
                        WHERE Gonderi.KuryeId=0", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GonderiModel gonderi = new GonderiModel();

                    gonderi.GonderiId = Convert.ToInt32(reader["GonderiId"]);
                    gonderi.Adres = reader["GonderiAdresi"].ToString();
                    gonderi.Agirlik = Convert.ToDouble(reader["Agirlik"]);
                    gonderi.MusteriAd = reader["Musteri"].ToString();
                    


                    gonderiListesi.Add(gonderi);
                }

            }
            catch (Exception)
            {

                GonderiModel gonderi = new GonderiModel();
                gonderi.MusteriAd = "HATA";

                gonderiListesi.Add(gonderi);
            }


            return gonderiListesi;
        }

        public int KuryeAta(int gonderiId,int kuryeId)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand(@"UPDATE Gonderi SET 
                                                        KuryeId=@KuryeId
                                                WHERE GonderiId=@GonderiId", connection);
                
                command.Parameters.AddWithValue("@KuryeId", kuryeId);
            
                command.Parameters.AddWithValue("@GonderiId", gonderiId);

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
    }
}
