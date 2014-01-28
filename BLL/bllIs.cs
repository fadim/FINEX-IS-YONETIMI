using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
        public static class bllIs
        {
            public static int YeniIsEkle(enIs Is)
            {
                return new dalIs().YeniIsEkle(Is);
            }

            public static void IsSil(int IsId)
            {
               new dalIs().IsSil(IsId);
            }

            public static void IsGuncelle(enIs Is)
            {
               new dalIs().IsGuncelle(Is);
            }

            public static enIs IsGetir(int IsId)
            {
                return new dalIs().IsGetir(IsId);
            }

            public static List<enIs> IsleriGetir()
            {
                return new dalIs().IsleriGetir();
            }

        }
}
