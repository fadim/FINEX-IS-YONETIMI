using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;

namespace BLL
{
    public static class bllPersonel
    {
        public static int YeniPersonelEkle(enPersonel personel)
        {
           return new dalPersonel().YeniPersonelEkle(personel);
        }

        public static void PersonelSil(int personelId)
        {
            bllPersonelResimleri.ResimSil(personelId);

            new dalPersonel().PersonelSil(personelId);
        }

        public static void PersonelGuncelle(enPersonel per)
        {
            new dalPersonel().PersonelGuncelle(per);
        }

        public static enPersonel PersonelGetir(string adi,string soyadi)
        {
            return new dalPersonel().PersonelGetir(adi,soyadi);
        }
       
        public static enPersonel PersonelGetir(int personelId)
        {
            bllPersonelResimleri.ResimGetir(personelId);
            return new dalPersonel().PersonelGetir(personelId);
        }

        public static List<enPersonel> PersonelleriGetir()
        {
            return new dalPersonel().PersonelleriGetir();
        }

    }
}
