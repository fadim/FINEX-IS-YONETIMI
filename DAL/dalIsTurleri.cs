using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public class dalIsTurleri
    {
        public int YeniIsTuruEkle(enIsTurleri tur)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("tur_adi"); degerList.Add(tur.Adi);
            prmList.Add("tur_statu"); degerList.Add(tur.Statu);
            return dalManager.MakeAnDbInsert(prmList, "IsTurleri", degerList, "tur_id");
        }
        public void IsTuruSil(int TurId)
        {
            dalManager.MakeAnDbDelete("IsTurleri", "tur_id", TurId);
        }
        public void IsTuruSiraGuncelle(enIsTurleri tur)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("tur_adi"); degerList.Add(tur.Adi);
            prmList.Add("tur_statu"); degerList.Add(tur.Statu);
            dalManager.MakeAnDbUpdate(prmList, "IsTurleri", "tur_id", tur.Id, degerList);
        }
        public enIsTurleri IsTuruGetir(int turId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM IsTurleri WHERE tur_id=@id");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            adp.SelectCommand.Parameters.AddWithValue("@id", turId);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            enIsTurleri tur = new enIsTurleri();

            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[0];

                tur.Id = rw["tur_id"].xToInt32Default();
                tur.Adi = rw["tur_adi"].ToString();
                tur.Statu = rw["tur_statu"].xToBooleanDefault();
            }

            return tur;
        }
        public List<enIsTurleri> IsTurleriniGetir()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM IsTurleri");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<enIsTurleri> isTurleri = new List<enIsTurleri>();

            foreach (DataRow rw in dt.Rows)
            {
                enIsTurleri tur = new enIsTurleri();
                tur.Id = rw["tur_id"].xToInt32Default();
                tur.Adi = rw["tur_adi"].ToString();
                tur.Statu = rw["tur_statu"].xToBooleanDefault();

                isTurleri.Add(tur);
            }

            return isTurleri;
        }
    }
}
