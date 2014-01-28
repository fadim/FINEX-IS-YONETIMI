using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public class dalIsEkleri
    {
        public int YeniEkEkle(enIsEkleri ek)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("isEk_is_id"); degerList.Add(ek.EkIsId);
            prmList.Add("isEk_url"); degerList.Add(ek.Url);
            return dalManager.MakeAnDbInsert(prmList, "IsEkleri", degerList, "isEk_id");
        }
        public void EkSil(int ekId)
        {
            dalManager.MakeAnDbDelete("IsEkleri", "isEk_id", ekId);
        }
        public void EkSiraGuncelle(enIsEkleri ek)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("isEk_is_id"); degerList.Add(ek.EkIsId);
            prmList.Add("isEk_url"); degerList.Add(ek.Url);
            dalManager.MakeAnDbUpdate(prmList, "IsEkleri", "isEk_id", ek.Id, degerList);
        }
        public enIsEkleri EkGetir(int ekId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM IsEkleri WHERE isEk_id=@id");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            adp.SelectCommand.Parameters.AddWithValue("@id", ekId);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            enIsEkleri ek = new enIsEkleri();

            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[0];

                ek.Id = rw["isEk_id"].xToInt32Default();
                ek.EkIsId = rw["isEk_is_id"].xToInt32Default();
                ek.Url = rw["isEk_url"].ToString();
            }

            return ek;
        }
        public List<enIsEkleri> EkleriGetir()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM IsEkleri");
            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<enIsEkleri> IsEkleri = new List<enIsEkleri>();

            foreach (DataRow rw in dt.Rows)
            {
                enIsEkleri ek = new enIsEkleri();
                ek.Id = rw["isEk_id"].xToInt32Default();
                ek.EkIsId = rw["isEk_id"].xToInt32Default();
                ek.Url= rw["isEk_adi"].ToString();

                IsEkleri.Add(ek);
            }

            return IsEkleri;
        }

        public int SonSiraNoGetir(int isId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT TOP 1 isEk_id FROM IsEkleri 
                        WHERE isEk_is_id = @isId 
                        ORDER BY pRes_sira DESC");

            OleDbCommand cmd = new OleDbCommand(sb.ToString(), dalManager.Connection());

            cmd.Parameters.AddWithValue("@isId", isId);

            cmd.Connection.Open();

            int sayi = cmd.ExecuteScalar().xToIntDefault();

            cmd.Connection.Close();

            return sayi;
        }
    }
}
