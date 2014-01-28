using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;
using System.IO;

namespace FxIsYonetim
{
    public partial class MusteriDuzenle : System.Web.UI.Page
    {
        public List<string> VwLogolar
        {
            get
            {
                if (ViewState["VwLogolar"] == null)
                    ViewState["VwLogolar"] = new List<string>();
                return ViewState["VwLogolar"] as List<string>;
            }
            set
            {
                ViewState["VwLogolar"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              MusteriGetir();
             
            }
          }

        protected void MusteriGetir()
        {
            int? MusteriId = Request.QueryString["id"].xToInt();

            if (MusteriId != null)
            {
                enMusteri mus = bllMusteri.MusteriGetir(MusteriId.Value);

                txtmus_unvan.Text = mus.Unvan;
                txtmus_tel.Text = mus.Tel;
                txtmus_cep.Text = mus.Cep;
                txtmus_ePosta.Text = mus.Eposta;
                txtmus_adres.Text = mus.Adres;
                txtmus_yetkili.Text = mus.Yetkili;
                ImgFirmaLogo.ImageUrl = mus.Logo;
            }
        }

        protected void btnKAYDET_Click(object sender, EventArgs e)
        {
            enMusteri mus = new enMusteri();
            enMusteriResim resim = new enMusteriResim();

            mus.Id = Request.QueryString["id"].xToIntDefault();
            mus.Unvan = txtmus_unvan.Text;
            mus.Tel = txtmus_tel.Text;
            mus.Cep = txtmus_cep.Text;
            mus.Eposta = txtmus_ePosta.Text;
            mus.Adres = txtmus_adres.Text;
            mus.Yetkili = txtmus_yetkili.Text;
            foreach (string logoUrl in VwLogolar)
            {
                mus.Logo = "~/FirmaLogo/" + logoUrl;
            }
            resim.Id = Request.QueryString["id"].xToIntDefault();
            resim.MusteriId = mus.Id;
            resim.Url =mus.Logo;
            resim.Sira = bllMusteriResimleri.SonSiraNoGetir(resim.MusteriId) + 1;

            bllMusteri.MusteriGuncelle(mus);
            bllMusteriResimleri.ResimSiraGuncelle(resim);
        }

        protected void btnSEC_Click(object sender, EventArgs e)
        {

            enMusteriResim resim = new enMusteriResim();

            if (firmaLogo.HasFile == true)
            {
                string uzanti = Path.GetExtension(firmaLogo.FileName);
                if (uzanti.ToUpper() == ".JPG" || uzanti.ToUpper() == ".BMP" || uzanti.ToUpper() == ".PNG")
                {
                    string logoUrl = DateTime.Now.Year + "." + DateTime.Now.Month + "." +
                                      DateTime.Now.Day + "." + DateTime.Now.Hour + "." +
                                      DateTime.Now.Minute + "." + DateTime.Now.Second + "." +
                                      DateTime.Now.Millisecond + uzanti;
                    firmaLogo.SaveAs(Request.PhysicalApplicationPath + "FirmaLogo/" + logoUrl);
                    ImgFirmaLogo.ImageUrl = "~/FirmaLogo/" + logoUrl;
                    VwLogolar.Add(logoUrl);

                    resim.Url = "~/FirmaLogo/" + logoUrl;
                    resim.Sira = bllMusteriResimleri.SonSiraNoGetir(resim.Id) + 1;
                }
            }

            bllMusteriResimleri.ResimSiraGuncelle(resim);

        }
    }
}