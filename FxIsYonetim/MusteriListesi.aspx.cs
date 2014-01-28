using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;
using DAL;
using System.Text;

namespace FxIsYonetim
{
    public partial class MusteriListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                MusterileriGetir();
            }
        }

        protected void MusterileriGetir()
        {
            List<enMusteri> musteriler = bllMusteri.MusterileriGetir();
            grvMusteri.DataSource = musteriler;
            grvMusteri.DataBind();

        }

        protected void lnkSil_Click(object sender, EventArgs e)
        {
            enMusteri mus = new enMusteri();
            LinkButton lnk = sender as LinkButton;

            int id = lnk.CommandArgument.xToIntDefault();
            bllMusteri.MusteriSil(id);

            MusterileriGetir();
        }
        protected void lnkDuzenle_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int? id = lnk.CommandArgument.xToInt();

            Response.Redirect("MusteriDuzenle.aspx?id=" + id);
        }
    }
}