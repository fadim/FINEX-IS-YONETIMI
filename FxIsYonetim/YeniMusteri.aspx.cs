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
    public partial class YeniMusteri : System.Web.UI.Page
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

        }

        protected void btnKAYDET_Click(object sender, EventArgs e)
        {
            if (VwLogolar.Count > 0)
            {

                enMusteri mus = new enMusteri();

                mus.Unvan = txtmus_unvan.Text;
                mus.Tel = txtmus_tel.Text;
                mus.Cep = txtmus_cep.Text;
                mus.Eposta = txtmus_ePosta.Text;
                mus.Adres = txtmus_adres.Text;
                mus.Yetkili = txtmus_yetkili.Text;
                mus.Logo = "~/FirmaLogo/" + VwLogolar[0];

                mus.Id = bllMusteri.YeniMusteriEkle(mus);
                foreach (string logoUrl in VwLogolar)
                {
                    enMusteriResim resim = new enMusteriResim();

                    resim.MusteriId = mus.Id;
                    resim.Url = "~/FirmaLogo/" + logoUrl;
                    resim.Sira = bllMusteriResimleri.SonSiraNoGetir(resim.MusteriId) + 1;
                    bllMusteriResimleri.YeniResimEkle(resim);
                }

            }
            else
            {
                lblMesaj.Text = "Logo yüklenmedi...";
            }


        }

        protected void btnSEC_Click(object sender, EventArgs e)
        {
 
            if (firmaLogo.HasFile == true)
            {
                string uzanti = Path.GetExtension(firmaLogo.FileName);
                if (uzanti.ToUpper() == ".JPG" || uzanti.ToUpper() == ".BMP" || uzanti.ToUpper() == ".PNG")
                {
                    string logoUrl =  DateTime.Now.Year + "." + DateTime.Now.Month + "." +
                                      DateTime.Now.Day + "." +  DateTime.Now.Hour + "." +
                                      DateTime.Now.Minute + "." + DateTime.Now.Second + "." +
                                      DateTime.Now.Millisecond + uzanti;
                    firmaLogo.SaveAs(Request.PhysicalApplicationPath + "FirmaLogo/" + logoUrl);
                    VwLogolar.Add(logoUrl);
                }
            }
        }

        

   }
}