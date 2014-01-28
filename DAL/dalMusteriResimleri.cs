using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
   public class dalMusteriResimleri
    {
       public void YeniResimEkle(enMusteriResim resim)
        {

            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("mRes_musteri_id"); degerList.Add(resim.MusteriId);
            prmList.Add("mRes_url");         degerList.Add(resim.Url);
            prmList.Add("mRes_sira");        degerList.Add(resim.Sira);

            dalManager.MakeAnDbInsert(prmList, "MusteriResimleri", degerList, "");

        }

        public void ResimSil(int MusteriId)
        {
            dalManager.MakeAnDbDelete("MusteriResimleri", "mRes_musteri_id", MusteriId);
        }

        public List<enMusteriResim> ResimleriGetir(int MusteriId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM MusteriResimleri WHERE mRes_musteri_id = @id ");

            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());

            adp.SelectCommand.Parameters.AddWithValue("@id", MusteriId);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            List<enMusteriResim> resimler = new List<enMusteriResim>();
            foreach (DataRow rw in dt.Rows)
            {
                enMusteriResim resim = new enMusteriResim();


                resim.Url = rw["mRes_url"].ToString();
                resim.MusteriId = rw["mRes_musteri_id"].xToIntDefault();
                resim.Id = rw["mRes_id"].xToIntDefault();
                resim.Sira = rw["mRes_sira"].xToIntDefault();

                resimler.Add(resim);
            }

            return resimler;

        }
        public enMusteriResim ResimGetir(int ResimId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM MusteriResimleri WHERE mRes_id = @id ");

            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());

            adp.SelectCommand.Parameters.AddWithValue("@id", ResimId);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            enMusteriResim resim = new enMusteriResim();

            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[0];

                resim.Url = rw["mRes_url"].ToString();
                resim.MusteriId = rw["mRes_musteri_id"].xToIntDefault();
                resim.Id = rw["mRes_id"].xToIntDefault();
                resim.Sira = rw["mRes_sira"].xToIntDefault();
            }

            return resim;
        }

        public void ResimSiraGuncelle(enMusteriResim resim)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("mRes_sira"); degerList.Add(resim.Sira);
            prmList.Add("mRes_url"); degerList.Add(resim.Url);

            dalManager.MakeAnDbUpdate(prmList, "MusteriResimleri", "mRes_id", resim.Id, degerList);
        }

        public int SonSiraNoGetir(int ResimId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT TOP 1 mRes_sira FROM MusteriResimleri 
                        WHERE mRes_musteri_id = @ResimId 
                        ORDER BY mRes_sira DESC");

            OleDbCommand cmd = new OleDbCommand(sb.ToString(), dalManager.Connection());

            cmd.Parameters.AddWithValue("@ResimId", ResimId);

            cmd.Connection.Open();

            int sayi = cmd.ExecuteScalar().xToIntDefault();

            cmd.Connection.Close();

            return sayi;
        }

        public string MusteriProfilResmiGetir(string musteriFoto)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT TOP 1 mRes_url FROM MusteriResimleri WHERE mRes_url = @musteriFoto  ORDER BY mRes_sira ");

            OleDbCommand cmd = new OleDbCommand(sb.ToString(), dalManager.Connection());

            cmd.Parameters.AddWithValue("@musteriFoto", musteriFoto);

            cmd.Connection.Open();

            string url = "";

            try
            {
                url = cmd.ExecuteScalar().ToString();

            }
            catch
            {
                url = "/FirmaLogo/empty_profile.png";
            }


            cmd.Connection.Close();

            return url;
        }

    }
}
