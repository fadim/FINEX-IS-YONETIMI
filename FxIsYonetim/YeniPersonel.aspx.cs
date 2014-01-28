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
    public partial class Personel : System.Web.UI.Page
    {
        public List<string> VwResimler
        {
            get
            {
                if (ViewState["VwResimler"] == null)
                    ViewState["VwResimler"] = new List<string>();
                return ViewState["VwResimler"] as List<string>;
            }
            set
            {
                ViewState["VwResimler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnKAYDET_Click(object sender, EventArgs e)
        { //KAYDET

            enPersonel per = new enPersonel();

            per.Adi = txtper_adi.Text;
            per.Soyadi = txtper_soyadi.Text;
            per.Tel = txtper_tel.Text;
            per.Cep = txtper_cep.Text;
            per.Eposta = txtper_ePosta.Text;
            per.Tc = txtper_tc.Text;
            per.DogumTarihi = txtper_dogumTar.Text.xToDateTimeDefault();
            per.Memleket = txtper_memleket.Text;
            per.Sehir = txtper_sehir.Text;
            per.Foto = "~/Personeller/" + VwResimler[0];

            per.Id = bllPersonel.YeniPersonelEkle(per);

            foreach (string resimUrl in VwResimler)
            {
                enPersonelResim resim = new enPersonelResim();

                resim.PersonelId = per.Id;
                resim.Url = "~/Personeller/" + resimUrl;
                resim.Sira = bllPersonelResimleri.SonSiraNoGetir(resim.PersonelId) + 1;
                bllPersonelResimleri.YeniResimEkle(resim);
            }
           
        }

        protected void btnSEC_Click(object sender, EventArgs e)
        { // RESİM UPLOAD


            if (perRESIM.HasFile == true)
            {
                string uzanti = Path.GetExtension(perRESIM.FileName);
                if (uzanti.ToUpper() == ".JPG" || uzanti.ToUpper() == ".BMP" || uzanti.ToUpper() == ".PNG")
                {
                    string resimUrl = DateTime.Now.Year + "." + DateTime.Now.Month + "." +
                                      DateTime.Now.Day + "." + DateTime.Now.Hour + "." +
                                      DateTime.Now.Minute + "." + DateTime.Now.Second + "." +
                                      DateTime.Now.Millisecond + uzanti;
                    perRESIM.SaveAs(Request.PhysicalApplicationPath + "Personeller/" + resimUrl);
                    imgPersonel.ImageUrl = "~/Personeller/" + resimUrl;
                    VwResimler.Add(resimUrl);
                    
                }
            }
        }
    }
}
