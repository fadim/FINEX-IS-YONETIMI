using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;


namespace DAL
{
    
    public class dalPersonel
    {
        public int YeniPersonelEkle(enPersonel per)
        { //EKLE

            
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("per_adi"); degerList.Add(per.Adi);
            prmList.Add("per_soyadi"); degerList.Add(per.Soyadi);
            prmList.Add("per_tc"); degerList.Add(per.Tc);
            prmList.Add("per_dogumTar"); degerList.Add(per.DogumTarihi);
            prmList.Add("per_memleket"); degerList.Add(per.Memleket);
            prmList.Add("per_sehir"); degerList.Add(per.Sehir);
            prmList.Add("per_tel"); degerList.Add(per.Tel);
            prmList.Add("per_cep"); degerList.Add(per.Cep);
            prmList.Add("per_ePosta"); degerList.Add(per.Eposta);
            prmList.Add("per_foto"); degerList.Add(per.Foto);

            return dalManager.MakeAnDbInsert(prmList, "Personel", degerList, "per_id");
        }

        public void PersonelSil(int personelId)
        { //SİL 

            dalManager.MakeAnDbDelete("Personel", "per_id", personelId);
        }

        public void PersonelGuncelle(enPersonel per)
        { // UPDATE

           List<string> prmList =new List<string> ();
           List<object> degerList = new List<object> ();

           prmList.Add("per_adi"); degerList.Add(per.Adi);
           prmList.Add("per_soyadi"); degerList.Add(per.Soyadi);
           prmList.Add("per_tc"); degerList.Add(per.Tc);
           prmList.Add("per_dogumTar"); degerList.Add(per.DogumTarihi);
           prmList.Add("per_memleket"); degerList.Add(per.Memleket);
           prmList.Add("per_sehir"); degerList.Add(per.Sehir);
           prmList.Add("per_tel"); degerList.Add(per.Tel);
           prmList.Add("per_cep"); degerList.Add(per.Cep);
           prmList.Add("per_ePosta"); degerList.Add(per.Eposta);
           prmList.Add("per_foto"); degerList.Add(per.Foto);

           dalManager.MakeAnDbUpdate(prmList, "Personel", "per_id",per.Id, degerList);
        }
        public List<enPersonel> PersonelleriGetir()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM Personel");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(),dalManager.Connection());
            DataTable dt = new DataTable();
            adp.Fill(dt);

           List< enPersonel> Personeller = new List<enPersonel>();

            foreach (DataRow rw in dt.Rows)
            {
                enPersonel per = new enPersonel();

                per.Id = rw["per_id"].xToInt32Default();
                per.Adi = rw["per_adi"].ToString();
                per.Soyadi = rw["per_soyadi"].ToString();
                per.Tc = rw["per_tc"].ToString();
                per.DogumTarihi = rw["per_dogumTar"].xToDateTimeDefault();
                per.Memleket = rw["per_memleket"].ToString();
                per.Sehir = rw["per_sehir"].ToString();
                per.Tel = rw["per_tel"].ToString();
                per.Cep = rw["per_cep"].ToString();
                per.Eposta = rw["per_ePosta"].ToString();
                per.Foto = rw["per_foto"].ToString();
                per.Foto = new dalPersonelResimleri().PersonelProfilResmiGetir(per.Foto);

                Personeller.Add(per);

            }

            return Personeller;
        }
        public enPersonel PersonelGetir(int personelId)
        {
           StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT * FROM Personel WHERE per_id = @id ");

            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());

            adp.SelectCommand.Parameters.AddWithValue("@id", personelId);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            enPersonel per = new enPersonel();         

            if (dt.Rows.Count > 0)
            {

                DataRow rw = dt.Rows[0];

                per.Id = rw["per_id"].xToInt32Default();
                per.Adi = rw["per_adi"].ToString();
                per.Soyadi = rw["per_soyadi"].ToString();
                per.Tc = rw["per_tc"].ToString();
                per.DogumTarihi = rw["per_dogumTar"].xToDateTimeDefault();
                per.Memleket = rw["per_memleket"].ToString();
                per.Sehir = rw["per_sehir"].ToString();
                per.Tel = rw["per_tel"].ToString();
                per.Cep = rw["per_cep"].ToString();
                per.Eposta = rw["per_ePosta"].ToString();
                per.Foto = rw["per_Foto"].ToString();
                per.Foto = new dalPersonelResimleri().PersonelProfilResmiGetir(per.Foto);

            }

            return per;
        }

      
        public enPersonel PersonelGetir(string adi, string soyadi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Personel WHERE per_adi=@adi AND per_soyadi=@soyadi");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(),dalManager.Connection());
            adp.SelectCommand.Parameters.AddWithValue("@adi",adi);
            adp.SelectCommand.Parameters.AddWithValue("@soyadi", soyadi);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            enPersonel per = new enPersonel();
            if (dt.Rows.Count>0)
            {
                DataRow rw =dt.Rows[0];
                per.Id = rw["per_id"].xToInt32Default();
                per.Adi = rw["per_adi"].ToString();
                per.Soyadi = rw["per_soyadi"].ToString();
                per.Tc = rw["per_tc"].ToString();
                per.DogumTarihi = rw["per_dogumTar"].xToDateTimeDefault();
                per.Memleket = rw["per_memleket"].ToString();
                per.Sehir = rw["per_sehir"].ToString();
                per.Tel=rw["per_tel"].ToString();
                per.Cep=rw["per_cep"].ToString();
                per.Eposta = rw["per_ePosta"].ToString();
                per.Foto = rw["per_Foto"].ToString();
                per.Foto = new dalPersonelResimleri().PersonelProfilResmiGetir(per.Foto);

            }
            return per;
        }

    }
}
