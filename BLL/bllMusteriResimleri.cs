using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;


namespace BLL
{
   public static class bllMusteriResimleri
    {
        public static void YeniResimEkle(enMusteriResim resim)
        {
            new dalMusteriResimleri().YeniResimEkle(resim);
        }

        public static void ResimSil(int personelId)
        {
            new dalMusteriResimleri().ResimSil(personelId);
        }

        public static List<enMusteriResim> ResimleriGetir(int PersonelId)
        {
            return new dalMusteriResimleri().ResimleriGetir(PersonelId);
        }

        public static enMusteriResim ResimGetir(int PersonelId)
        {
            return new dalMusteriResimleri().ResimGetir(PersonelId);
        }

        public static void ResimSiraGuncelle(enMusteriResim resim)
        {
            new dalMusteriResimleri().ResimSiraGuncelle(resim);
        }

        public static int SonSiraNoGetir(int PersonelId)
        {
            return new dalMusteriResimleri().SonSiraNoGetir(PersonelId);
        }
    }
}
