using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public static class bllPersonelResimleri
    {
        public static void YeniResimEkle(enPersonelResim resim)
        {
            new dalPersonelResimleri().YeniResimEkle(resim);
        }

        public static void ResimSil(int personelId)
        {
            new dalPersonelResimleri().ResimSil(personelId);
        }

        public static List<enPersonelResim> ResimleriGetir(int PersonelId)
        {
            return new dalPersonelResimleri().ResimleriGetir(PersonelId);
        }

        public static enPersonelResim ResimGetir(int PersonelId)
        {
            return new dalPersonelResimleri().ResimGetir(PersonelId);
        }
     
        public static void ResimSiraGuncelle(enPersonelResim resim)
        {
            new dalPersonelResimleri().ResimSiraGuncelle(resim);
        }

        public static int SonSiraNoGetir(int PersonelId)
        {
            return new dalPersonelResimleri().SonSiraNoGetir(PersonelId);
        }
    }
}
