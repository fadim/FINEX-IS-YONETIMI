using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;

namespace BLL
{
    public static class bllMusteri
    {
        public static int YeniMusteriEkle(enMusteri musteri)
        {
            return new dalMusteri().YeniMusteriEkle(musteri);
        }

        public static void MusteriSil(int personelId)
        {
            bllMusteriResimleri.ResimSil(personelId);

            new dalMusteri().MusteriSil(personelId);
        }

        public static void MusteriGuncelle(enMusteri musteri)
        {
            new dalMusteri().MusteriGuncelle(musteri);
        }

        public static enMusteri MusteriGetir(int personelId)
        {
            bllMusteriResimleri.ResimGetir(personelId);
            return new dalMusteri().MusteriGetir(personelId);
        }

        public static List<enMusteri> MusterileriGetir()
        {
            return new dalMusteri().MusterileriGetir();
        }
    }
}
