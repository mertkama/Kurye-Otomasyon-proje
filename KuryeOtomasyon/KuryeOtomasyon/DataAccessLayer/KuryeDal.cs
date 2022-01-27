using KuryeOtomasyon.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuryeOtomasyon.DataAccessLayer
{
    public class KuryeDal:BaseDal
    {
        SqlConnection connection = new SqlConnection();
        public int KuryeEkle(KuryeModel kurye)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Kurye VALUES(@KuryeAd,@KuryeSoyad,@DogumTarihi,@EhliyetTarihi,@YuklenmeTarihi,@GuncellenmeTarihi)", connection);
                command.Parameters.AddWithValue("@KuryeAd", kurye.KuryeAd);
                command.Parameters.AddWithValue("@KuryeSoyad", kurye.KuryeSoyad);
                command.Parameters.AddWithValue("@DogumTarihi", kurye.DogumTarihi);
                command.Parameters.AddWithValue("@EhliyetTarihi", kurye.EhliyetTarihi);
                command.Parameters.AddWithValue("@YuklenmeTarihi", kurye.YuklenmeTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", kurye.GuncellenmeTarihi);

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

        public int KuryeGuncelle(KuryeModel kurye)
        {
            int sonuc = 0;
            connection = Connect();
            try
            {
                SqlCommand command = new SqlCommand(@"UPDATE Kurye SET
                                                      KuryeAd = @KuryeAd,
                                                      KuryeSoyad = @KuryeSoyad,
                                                      DogumTarihi = @DogumTarihi,
                                                      EhliyetTarihi = @EhliyetTarihi,
                                                      GuncellenmeTarihi = @GuncellenmeTarihi
                                                      WHERE KuryeId = @KuryeId", connection);


                command.Parameters.AddWithValue("@KuryeAd", kurye.KuryeAd);
                command.Parameters.AddWithValue("@KuryeSoyad", kurye.KuryeSoyad);
                command.Parameters.AddWithValue("@DogumTarihi", kurye.DogumTarihi);
                command.Parameters.AddWithValue("@EhliyetTarihi", kurye.EhliyetTarihi);
                command.Parameters.AddWithValue("@GuncellenmeTarihi", kurye.GuncellenmeTarihi);
                command.Parameters.AddWithValue("@KuryeId", kurye.KuryeId);

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

        public int KuryeSil(int kuryeId)
        {
            int sonuc = 0;
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Kurye WHERE KuryeId=@KuryeId", connection);
                command.Parameters.AddWithValue("@KuryeId", kuryeId);

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

        public List<KuryeModel> KuryeListele()
        {
            connection = Connect();
            List<KuryeModel> kuryeListesi = new List<KuryeModel>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Kurye", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KuryeModel kurye = new KuryeModel();

                    kurye.KuryeAd = reader["KuryeAd"].ToString();
                    kurye.KuryeSoyad = reader["KuryeSoyad"].ToString();
                    kurye.KuryeId = Convert.ToInt32(reader["KuryeId"]);
                    kurye.DogumTarihi = Convert.ToDateTime(reader["DogumTarihi"]);
                    kurye.EhliyetTarihi = Convert.ToDateTime(reader["EhliyetTarihi"]);


                    kuryeListesi.Add(kurye);
                }

            }
            catch (Exception)
            {

                KuryeModel kurye = new KuryeModel();
                kurye.KuryeAd = "HATA";

                kuryeListesi.Add(kurye);
            }


            return kuryeListesi;
        }


        public KuryeModel KuryeGetir(int id)
        {
            KuryeModel kurye = new KuryeModel();
            connection = Connect();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Kurye WHERE KuryeId=@KuryeId", connection);
                command.Parameters.AddWithValue("@KuryeId", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {                  

                    kurye.KuryeAd = reader["KuryeAd"].ToString();
                    kurye.KuryeSoyad = reader["KuryeSoyad"].ToString();
                    kurye.KuryeId = Convert.ToInt32(reader["KuryeId"]);
                    kurye.DogumTarihi = Convert.ToDateTime(reader["DogumTarihi"]);
                    kurye.EhliyetTarihi = Convert.ToDateTime(reader["EhliyetTarihi"]);
                }

            }
            catch (Exception)
            {

                kurye.KuryeAd = "HATA";
            }


            return kurye;
        }

    }
}
