using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class enIs
    {

        public int Id { get; set; }
        public int MusteriId{ get; set; }
        public int TurId { get; set; }
        public decimal TahminiFiyat { get; set; }
        public decimal Fiyat{ get; set; }
        public decimal Kapora { get; set; }
        public string Not { get; set; }
        public DateTime IlkGorusmeTarihi { get; set; }
        public DateTime SonGorusmeTarihi { get; set; }
        public bool Durumu { get; set; }
        public int PersonelId { get; set; }
        public string AlanAdi { get; set; }
        public string Hosting { get; set; }
        public string YayinTarihi { get; set; }
        public string YayinSuresi { get; set; }
    }
}
