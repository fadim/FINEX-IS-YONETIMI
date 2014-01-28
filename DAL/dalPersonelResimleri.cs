using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public class dalPersonelResimleri
    {
      
        public void YeniResimEkle(enPersonelResim resim)
        {
         
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("pRes_personel_id"); degerList.Add(resim.PersonelId);
            prmList.Add("pRes_url"); degerList.Add(resim.Url);
            prmList.Add("pRes_sira"); degerList.Add(resim.Sira);

            dalManager.MakeAnDbInsert(prmList, "PersonelResimleri", degerList, "");

        }

        public void ResimSil(int personelId)
        {
            dalManager.MakeAnDbDelete("PersonelResimleri", "pRes_personel_id", personelId);
        }

        public List<enPersonelResim> ResimleriGetir(int PersonelId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM PersonelResimleri WHERE pRes_personel_id = @id ");

            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());

            adp.SelectCommand.Parameters.AddWithValue("@id", PersonelId);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            List<enPersonelResim> resimler = new List<enPersonelResim>();
            foreach (DataRow rw in dt.Rows)
            {
                enPersonelResim resim = new enPersonelResim();


                resim.Url = rw["pRes_url"].ToString();
                resim.PersonelId = rw["pRes_personel_id"].xToIntDefault();
                resim.Id = rw["pRes_id"].xToIntDefault();
                resim.Sira = rw["pRes_sira"].xToIntDefault();

                resimler.Add(resim);
            }

            return resimler;

        }
        public enPersonelResim ResimGetir(int resimId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM PersonelResimleri WHERE pRes_id = @id ");

            OleDbDataAdapter adp = new OleDbDataAdapter(sb.ToString(), dalManager.Connection());

            adp.SelectCommand.Parameters.AddWithValue("@id", resimId);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            enPersonelResim resim = new enPersonelResim();

            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[0];

                resim.Url = rw["pRes_url"].ToString();
                resim.PersonelId = rw["pRes_personel_id"].xToIntDefault();
                resim.Id = rw["pRes_id"].xToIntDefault();
                resim.Sira = rw["pRes_sira"].xToIntDefault();
            }

            return resim;
        }

        public void ResimSiraGuncelle(enPersonelResim resim)
        {
            List<string> prmList = new List<string>();
            List<object> degerList = new List<object>();

            prmList.Add("pRes_sira"); degerList.Add(resim.Sira);
            prmList.Add("pRes_url"); degerList.Add(resim.Url);
            
           dalManager.MakeAnDbUpdate(prmList, "PersonelResimleri", "pRes_id", resim.Id, degerList);
        }

        public int SonSiraNoGetir(int ResimId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT TOP 1 pRes_sira FROM PersonelResimleri 
                        WHERE pRes_personel_id = @resimId 
                        ORDER BY pRes_sira DESC");

            OleDbCommand cmd = new OleDbCommand(sb.ToString(), dalManager.Connection());

            cmd.Parameters.AddWithValue("@resimId", ResimId);

            cmd.Connection.Open();

            int sayi = cmd.ExecuteScalar().xToIntDefault();

            cmd.Connection.Close();

            return sayi;
        }

        public string PersonelProfilResmiGetir(string personelFoto)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT TOP 1 pRes_url FROM PersonelResimleri WHERE pRes_url = @personelFoto  ORDER BY pRes_sira ");

            OleDbCommand cmd = new OleDbCommand(sb.ToString(), dalManager.Connection());

            cmd.Parameters.AddWithValue("@personelFoto", personelFoto);
            
            cmd.Connection.Open();

            string url = "";

            try
            {
                url = cmd.ExecuteScalar().ToString();
                
            }
            catch
            {
                url = "/Personeller/empty_profile.png";
            }
            

            cmd.Connection.Close();

            return url;
        }

    }
}
