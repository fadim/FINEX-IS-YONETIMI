using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public class dalIsDurumlari
    {
        public int YeniDurumEkle(enIsDurumlari Is)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("durum_adi"); degerList.Add(Is.Adi);
            return dalManager.MakeAnDbInsert(prmList,"IsDurumlari",degerList,"durum_id");
        }
        public void DurumSil(int DurumId)
        {
            dalManager.MakeAnDbDelete("IsDurumlari", "durum_id", DurumId);
        }
        public void DurumSiraGuncelle(enIsDurumlari Is)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("durum_adi"); degerList.Add(Is.Adi);
             dalManager.MakeAnDbUpdate(prmList, "IsDurumlari","durum_id",Is.Id,degerList);
        }
        public enIsDurumlari DurumGetir(int durumId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM IsDurumlari WHERE durum_id=@id");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            adp.SelectCommand.Parameters.AddWithValue("@id", durumId);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            enIsDurumlari durum = new enIsDurumlari();

            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[0];

                durum.Id = rw["durum_id"].xToInt32Default();
                durum.Adi = rw["durum_adi"].ToString();
            }

            return durum;
        }
        public List<enIsDurumlari> DurumlariGetir()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM IsDurumlari");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<enIsDurumlari> IsDurumlari = new List<enIsDurumlari>();

            foreach (DataRow rw in dt.Rows)
            {
                enIsDurumlari durum = new enIsDurumlari();
                durum.Id = rw["durum_id"].xToInt32Default();
                durum.Adi = rw["durum_adi"].ToString();

                IsDurumlari.Add(durum);
            }

            return IsDurumlari;
        }
    }
}
