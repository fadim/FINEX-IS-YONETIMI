using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using System.IO;
using BLL;

namespace FxIsYonetim
{
    public partial class YeniIs : System.Web.UI.Page
    {
        public List<string> VwEkler
        {
            get
            {
                if (ViewState["VwEkler"] == null)
                    ViewState["VwEkler"] = new List<string>();
                return ViewState["VwEkler"] as List<string>;
            }
            set
            {
                ViewState["VwEkler"] = value;
            }
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
    
            Panel1.Visible = true;
            Panel2.Visible = false;

            if (!IsPostBack)
            {
                MusterileriDoldur();
                IsTuruDoldur();
                IsDurumuDoldur();
                IlgiliPersonelDoldur();
            }

        }
        protected void IsDurumuDoldur()
        {
            List<enIsDurumlari> isDurumlari = bllIsDurumlari.DurumlariGetir();
            ddlIsDurumu.DataBind(isDurumlari, "Id", "Adi");
        }
        protected void IsTuruDoldur()
        {
            List<enIsTurleri> isTurleri = bllIsTurleri.IsTurleriniGetir();
            ddlIsTuru.DataBind(isTurleri,"Id","Adi");
        }
        protected void MusterileriDoldur()
        {
            List<enMusteri> musteriler = bllMusteri.MusterileriGetir();
            ddlMusteri.DataBind(musteriler,"Id","Unvan");
        }

        protected void IlgiliPersonelDoldur()
        {
           
            List<enPersonel> personeller = bllPersonel.PersonelleriGetir();
            dllIlgiliPersonel.DataBind(personeller,"Id","Adi");
        }

        protected void btnKAYDET_Click(object sender, EventArgs e)
        {
            enIs Is = new enIs();
            enIsTurleri tur=new enIsTurleri();
            Is.MusteriId = ddlMusteri.SelectedValue.xToInt32Default();
            Is.IlkGorusmeTarihi = txtIlkGorusmeTar.xToDateTimeDefault();
            Is.TahminiFiyat = txtTahminiFiyat.xToDecimalDefault();
            Is.Fiyat = txtFiyat.xToDecimalDefault();
            Is.Kapora = txtKapora.xToDecimalDefault();
            Is.Not = txtNot.ToString();
            Is.TurId = ddlIsTuru.SelectedValue.xToInt32Default();
            Is.SonGorusmeTarihi = txtSonGorusmeTar.xToDateTimeDefault();
            Is.Durumu = ddlIsDurumu.SelectedValue.xToBooleanDefault();
            Is.PersonelId = dllIlgiliPersonel.SelectedValue.xToInt32Default();
            
            Is.Id=bllIs.YeniIsEkle(Is);
            foreach (string ekUrl in VwEkler)
            {
                enIsEkleri ek = new enIsEkleri();
                ek.EkIsId = Is.Id;
                ek.Url = "~/Ekler/" + ekUrl;
                bllIsEkleri.YeniEkEkle(ek);
            }
        }

        protected void btnSEC_Click(object sender, EventArgs e)
        {

            if (perRESIM.HasFile == true)
            {
                string dosyaAdi = Path.GetFileName(perRESIM.FileName);
                string uzanti = Path.GetExtension(perRESIM.FileName);

                string ekUrl = dosyaAdi + "." + DateTime.Now.Year + "." + DateTime.Now.Month + "." +
                                  DateTime.Now.Day + "." + DateTime.Now.Hour + "." +
                                  DateTime.Now.Minute + "." + DateTime.Now.Second + "." +
                                  DateTime.Now.Millisecond + uzanti;
                perRESIM.SaveAs(Request.PhysicalApplicationPath + "Ekler/" + ekUrl);
                VwEkler.Add(ekUrl);
                
            }
        }

        protected void ddlIsTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlIsTuru.SelectedValue.xToInt32Default() == enEnumaration.enmIsTurleri.WebSitesi)
            //{

            //    Panel1.Visible = false;
            //    Panel2.Visible = true;

            //}
            //Panel2.Visible = true;
            if (ddlIsTuru.SelectedIndex==2)
            {
                  
            }
        }

        protected void txtAlanAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}