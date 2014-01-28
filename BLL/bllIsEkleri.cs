using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class bllIsEkleri
    {
        public static void YeniEkEkle(enIsEkleri resim)
        {
            new dalIsEkleri().YeniEkEkle(resim);
        }

        public static void EkSil(int ekId)
        {
            new dalIsEkleri().EkSil(ekId);
        }

        public static List<enIsEkleri> EkleriGetir()
        {
            return new dalIsEkleri().EkleriGetir();
        }

        public static enIsEkleri EkGetir(int ekId)
        {
            return new dalIsEkleri().EkGetir(ekId);
        }

        public static void EkSiraGuncelle(enIsEkleri ek)
        {
            new dalIsEkleri().EkSiraGuncelle(ek);
        }

        public static int SonSiraNoGetir(int isId)
        {
            return new dalIsEkleri().SonSiraNoGetir(isId);
        }
    }
}
