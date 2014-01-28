using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
   public class dalMusteri
    {
        public int YeniMusteriEkle(enMusteri mus)
        { //EKLE


            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("mus_unvan"); degerList.Add(mus.Unvan);
            prmList.Add("mus_tel"); degerList.Add(mus.Tel);
            prmList.Add("mus_cep"); degerList.Add(mus.Cep);
            prmList.Add("mus_ePosta"); degerList.Add(mus.Eposta);
            prmList.Add("mus_adres"); degerList.Add(mus.Adres);
            prmList.Add("mus_yetkili"); degerList.Add(mus.Yetkili);
            prmList.Add("mus_logo"); degerList.Add(mus.Logo);

            return dalManager.MakeAnDbInsert(prmList, "Musteri", degerList, "mus_id");
        }

        public void MusteriSil(int MusteriId)
        { //SİL 

            dalManager.MakeAnDbDelete("Musteri", "mus_id", MusteriId);
        }

        public void MusteriGuncelle(enMusteri mus)
        { // UPDATE

            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("mus_unvan"); degerList.Add(mus.Unvan);
            prmList.Add("mus_tel"); degerList.Add(mus.Tel);
            prmList.Add("mus_cep"); degerList.Add(mus.Cep);
            prmList.Add("mus_ePosta"); degerList.Add(mus.Eposta);
            prmList.Add("mus_adres"); degerList.Add(mus.Adres);
            prmList.Add("mus_yetkili"); degerList.Add(mus.Yetkili);
            prmList.Add("mus_logo"); degerList.Add(mus.Logo);

            dalManager.MakeAnDbUpdate(prmList, "Musteri", "mus_id", mus.Id, degerList);
        }
        public List<enMusteri> MusterileriGetir()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM Musteri");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            DataTable dt = new DataTable();
            adp.Fill(dt);

            List<enMusteri> Musteriler = new List<enMusteri>();

            foreach (DataRow rw in dt.Rows)
            {
                enMusteri mus = new enMusteri();

                mus.Id = rw["mus_id"].xToInt32Default();
                mus.Unvan = rw["mus_unvan"].ToString();
                mus.Tel = rw["mus_tel"].ToString();
                mus.Cep = rw["mus_cep"].ToString();
                mus.Eposta = rw["mus_ePosta"].ToString();
                mus.Adres = rw["mus_adres"].ToString();
                mus.Yetkili= rw["mus_yetkili"].ToString();
                mus.Logo = rw["mus_logo"].ToString();

                Musteriler.Add(mus);

            }

            return Musteriler;
        }
        public enMusteri MusteriGetir(int MusteriId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT * FROM Musteri WHERE mus_id = @id ");

            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());

            adp.SelectCommand.Parameters.AddWithValue("@id", MusteriId);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            enMusteri mus = new enMusteri();

            if (dt.Rows.Count > 0)
            {

                DataRow rw = dt.Rows[0];
                mus.Id = rw["mus_id"].xToInt32Default();
                mus.Unvan = rw["mus_unvan"].ToString();
                mus.Tel = rw["mus_tel"].ToString();
                mus.Cep = rw["mus_cep"].ToString();
                mus.Eposta = rw["mus_ePosta"].ToString();
                mus.Adres = rw["mus_adres"].ToString();
                mus.Yetkili = rw["mus_yetkili"].ToString();
                mus.Logo = rw["mus_logo"].ToString();
            }

            return mus;
        }


    }
}
