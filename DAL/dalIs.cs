using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public class dalIs
    {
        public int YeniIsEkle(enIs Is)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("is_musteri_id"); degerList.Add(Is.MusteriId);
            prmList.Add("is_tur_id"); degerList.Add(Is.TurId);
            prmList.Add("is_tahminiFiyat"); degerList.Add(Is.TahminiFiyat);
            prmList.Add("is_fiyat"); degerList.Add(Is.Fiyat);
            prmList.Add("is_kapora"); degerList.Add(Is.Kapora);
            prmList.Add("is_ilkGorusmeTar"); degerList.Add(Is.IlkGorusmeTarihi);
            prmList.Add("is_not"); degerList.Add(Is.Not);
            prmList.Add("is_sonGorusmeTar"); degerList.Add(Is.SonGorusmeTarihi);
            prmList.Add("is_durum"); degerList.Add(Is.Durumu);
            prmList.Add("is_per_id"); degerList.Add(Is.PersonelId);
            prmList.Add("is_hosting"); degerList.Add(Is.Hosting);
            prmList.Add("is_yayinTar"); degerList.Add(Is.YayinTarihi);
            prmList.Add("is_yayinSur"); degerList.Add(Is.YayinSuresi);

            return dalManager.MakeAnDbInsert(prmList,"Isler",degerList,"is_id");
        }

        public void IsSil(int IsId)
        {
            dalManager.MakeAnDbDelete("Isler","is_id",IsId);
        }

        public void IsGuncelle(enIs Is)
        {

            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("is_musteri_id"); degerList.Add(Is.TurId);
            prmList.Add("is_tur_id"); degerList.Add(Is.TurId);
            prmList.Add("is_tahminiFiyat"); degerList.Add(Is.TahminiFiyat);
            prmList.Add("is_fiyat"); degerList.Add(Is.Fiyat);
            prmList.Add("is_kapora"); degerList.Add(Is.Kapora);
            prmList.Add("is_not"); degerList.Add(Is.Not);
            prmList.Add("is_ilkGorusmeTar"); degerList.Add(Is.IlkGorusmeTarihi);
            prmList.Add("is_sonGorusmeTar"); degerList.Add(Is.SonGorusmeTarihi);
            prmList.Add("is_durum"); degerList.Add(Is.Durumu);
            prmList.Add("is_per_id"); degerList.Add(Is.PersonelId);
            prmList.Add("is_hosting"); degerList.Add(Is.Hosting);
            prmList.Add("is_yayinTar"); degerList.Add(Is.YayinTarihi);
            prmList.Add("is_yayinSur"); degerList.Add(Is.YayinSuresi);

            dalManager.MakeAnDbUpdate(prmList, "Isler", "is_id",Is.Id,degerList);
        }

        public enIs IsGetir(int IsId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM Isler WHERE is_id=@id");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(),dalManager.Connection());
            adp.SelectCommand.Parameters.AddWithValue("@id",IsId);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            enIs Is = new enIs();

            if (dt.Rows.Count>0)
            {
                DataRow rw = dt.Rows[0];

                Is.Id = rw["is_id"].xToInt32Default();
                Is.MusteriId = rw["is_musteri_id"].xToInt32Default();
                Is.TurId = rw["is_tur_id"].xToInt32Default();
                Is.TahminiFiyat = rw["is_tahminiFiyat"].xToDecimalDefault();
                Is.Fiyat = rw["is_fiyat"].xToDecimalDefault();
                Is.Kapora = rw["is_kapora"].xToDecimalDefault();
                Is.Not = rw["is_not"].ToString();
                Is.IlkGorusmeTarihi = rw["is_ilkGorusmeTar"].xToDateTimeDefault();
                Is.SonGorusmeTarihi = rw["is_sonGorusmeTar"].xToDateTimeDefault();
                Is.Durumu = rw["is_durum"].xToBooleanDefault();
                Is.PersonelId = rw["is_per_id"].xToInt32Default();
                Is.Hosting = rw["is_hosting"].ToString();
                Is.YayinTarihi = rw["is_yayinTar"].ToString();
                Is.YayinSuresi = rw["is_yayinSur"].ToString();
            }

            return Is;
        }

        public List<enIs> IsleriGetir()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM Isler");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(),dalManager.Connection());
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<enIs> Isler = new List<enIs>();

            foreach (DataRow rw in dt.Rows)
            {
                enIs Is = new enIs();
                Is.Id = rw["is_id"].xToInt32Default();
                Is.MusteriId = rw["is_musteri_id"].xToInt32Default();
                Is.TurId = rw["is_tur_id"].xToInt32Default();
                Is.TahminiFiyat = rw["is_tahminiFiyat"].xToDecimalDefault();
                Is.Fiyat = rw["is_fiyat"].xToDecimalDefault();
                Is.Kapora = rw["is_kapora"].xToDecimalDefault();
                Is.Not = rw["is_not"].ToString();
                Is.IlkGorusmeTarihi = rw["is_ilkGorusmeTar"].xToDateTimeDefault();
                Is.SonGorusmeTarihi = rw["is_sonGorusmeTar"].xToDateTimeDefault();
                Is.Durumu = rw["is_durum"].xToBooleanDefault();
                Is.PersonelId = rw["is_per_id"].xToInt32Default();
                Is.Hosting = rw["is_hosting"].ToString();
                Is.YayinTarihi = rw["is_yayinTar"].ToString();
                Is.YayinSuresi = rw["is_yayinSur"].ToString();

                Isler.Add(Is);
            }

            return Isler;
        }
    }
}
