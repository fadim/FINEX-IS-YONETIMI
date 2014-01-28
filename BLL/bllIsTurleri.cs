using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
   public  class bllIsTurleri
    {
       public static int YeniIsTuruEkle(enIsTurleri tur)
        {
            return new dalIsTurleri().YeniIsTuruEkle(tur);
        }

        public static void IsTuruSil(int turId)
        {
            new dalIsTurleri().IsTuruSil(turId);
        }

        public static List<enIsTurleri> IsTurleriniGetir()
        {
            return new dalIsTurleri().IsTurleriniGetir();
        }

        public static enIsTurleri IsTuruGetir(int turId)
        {
            return new dalIsTurleri().IsTuruGetir(turId);
        }

        public static void IsTuruSiraGuncelle(enIsTurleri tur)
        {
            new dalIsTurleri().IsTuruSiraGuncelle(tur);
        }
    }
}
