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
    public partial class PersonelDuzenle : System.Web.UI.Page
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
                PersonelGetir();
             
            }
        }


        protected void PersonelGetir()
        {
            int? PersonelId = Request.QueryString["id"].xToInt();

                if (PersonelId != null)
                {
                    enPersonel per = bllPersonel.PersonelGetir(PersonelId.Value);
                  
                    txtper_adi.Text = per.Adi;
                    txtper_soyadi.Text = per.Soyadi;
                    txtper_tel.Text = per.Tel;
                    txtper_cep.Text = per.Cep;
                    txtper_ePosta.Text = per.Eposta;
                    txtper_tc.Text = per.Tc;
                    txtper_dogumTar.Text = per.DogumTarihi.ToShortDateString();
                    txtper_memleket.Text = per.Memleket;
                    txtper_sehir.Text = per.Sehir;
                    imgPersonel.ImageUrl = per.Foto;
                }
        }

        protected void btnKAYDET_Click(object sender, EventArgs e)
        {

            enPersonel per = new enPersonel();
            enPersonelResim resim = new enPersonelResim();

            per.Id = Request.QueryString["id"].xToIntDefault();
            per.Adi = txtper_adi.Text;
            per.Soyadi = txtper_soyadi.Text;
            per.Tel = txtper_tel.Text;
            per.Cep = txtper_cep.Text;
            per.Eposta = txtper_ePosta.Text;
            per.Tc = txtper_tc.Text;
            per.DogumTarihi = txtper_dogumTar.Text.xToDateTimeDefault();
            per.Memleket = txtper_memleket.Text;
            per.Sehir = txtper_sehir.Text;
            foreach (string resimUrl in VwResimler)
            {
                per.Foto = "~/Personeller/" + resimUrl;
            }

            resim.Id = Request.QueryString["id"].xToIntDefault();
            resim.PersonelId = per.Id;
            resim.Url = per.Foto;
            resim.Sira = bllPersonelResimleri.SonSiraNoGetir(resim.PersonelId) + 1;
                
            bllPersonel.PersonelGuncelle(per);
            bllPersonelResimleri.ResimSiraGuncelle(resim);
        }

        protected void btnSEC_Click(object sender, EventArgs e)
        {

            enPersonelResim resim = new enPersonelResim();

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

                    resim.Url = "~/Personeller/" + resimUrl;
                    resim.Sira = bllPersonelResimleri.SonSiraNoGetir(resim.Id) + 1;
                }
            }

            bllPersonelResimleri.ResimSiraGuncelle(resim);

        }

    }
}