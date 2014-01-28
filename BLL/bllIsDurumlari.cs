using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
   public class bllIsDurumlari
    {
        public static int YeniDurumEkle(enIsDurumlari durum)
        {
            return new dalIsDurumlari().YeniDurumEkle(durum);
        }

        public static void DurumSil(int durum)
        {
            new dalIsDurumlari().DurumSil(durum);
        }

        public static List<enIsDurumlari> DurumlariGetir()
        {
            return new dalIsDurumlari().DurumlariGetir();
        }

        public static enIsDurumlari DurumGetir(int durumId)
        {
            return new dalIsDurumlari().DurumGetir(durumId);
        }

        public static void DurumSiraGuncelle(enIsDurumlari durum)
        {
            new dalIsDurumlari().DurumSiraGuncelle(durum);
        }

    }
}
