using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using BLL;
using DAL;
using System.Text;
using Entity;


namespace FxIsYonetim
{
    public partial class PersonelListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PersonelleriGetir();
            }
        }

        protected void PersonelleriGetir()
        {
            List<enPersonel> personeller = bllPersonel.PersonelleriGetir();
            grvPersonel.DataSource = personeller;
            grvPersonel.DataBind();

        }

        protected void lnkSil_Click(object sender, EventArgs e)
        {
            enPersonel per = new enPersonel();
            LinkButton lnk = sender as LinkButton;

            int id = lnk.CommandArgument.xToIntDefault();
            bllPersonel.PersonelSil(id);

            PersonelleriGetir();
        }

        protected void lnkDuzenle_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int? id = lnk.CommandArgument.xToInt();

            Response.Redirect("PersonelDuzenle.aspx?id=" + id);
        }
    }
}