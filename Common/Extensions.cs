using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Extensions
{
    #region DropDownList

    [System.Diagnostics.DebuggerStepThrough]
    public static void DataBind(this DropDownList ddl, object dataSource, string valueFieldName, string textFieldName)
    {
        DataBind(ddl, dataSource, valueFieldName, textFieldName, null);
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static void DataBind(this DropDownList ddl, object dataSource, string valueFieldName, string textFieldName, string secinizText)
    {
        ddl.DataSource = dataSource;
        ddl.DataTextField = textFieldName;
        ddl.DataValueField = valueFieldName;
        ddl.DataBind();

        if (secinizText != null)
        {
            ddl.Items.Insert(0, new ListItem(secinizText, ""));
        }
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static void xAylariDoldur(this DropDownList ddl)
    {
        ddl.xAylariDoldur(null);
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static void xAylariDoldur(this DropDownList ddl, string secinizText)
    {
        string[] aylar = new string[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

        ddl.Items.Clear();

        for (int i = 0; i < aylar.Length; i++)
        {
            ddl.Items.Add(new ListItem(aylar[i], (i + 1).ToString()));
        }

        if (string.IsNullOrEmpty(secinizText) == false)
        {
            ddl.Items.Insert(0, new ListItem(secinizText, ""));
        }
    }

    /// <summary>
    /// eğer dropdownun itemları içinde belirtilen değer varsa ilgili item seçilir, yoksa herhangi bir değişiklik olmaz
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static void xDegerSec(this DropDownList ddl, string deger)
    {
        ListItem item = ddl.Items.FindByValue(deger);
        if (item != null)
            ddl.SelectedIndex = ddl.Items.IndexOf(item);
    }

    #endregion

    [System.Diagnostics.DebuggerStepThrough]
    public static void xDegerSec(this ListBox lst, string deger)
    {
        ListItem item = lst.Items.FindByValue(deger);
        if (item != null)
            lst.SelectedIndex = lst.Items.IndexOf(item);
    }


    [System.Diagnostics.DebuggerStepThrough]
    public static void xDataBind(this ListBox lst, object dataSource, string valueFieldName, string textFieldName)
    {
        lst.DataSource = dataSource;
        lst.DataTextField = textFieldName;
        lst.DataValueField = valueFieldName;
        lst.DataBind();
    }

    #region DataTable

    [System.Diagnostics.DebuggerStepThrough]
    public static DataTable xSort(this DataTable dt, string sort)
    {
        if (dt == null) return null;
        dt.DefaultView.Sort = sort;
        return dt.DefaultView.ToTable();
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DataTable xSatirSil(this DataTable dt, string kriter)
    {
        if (dt == null) return null;

        try
        {
            DataRow[] rwSilinecekler = dt.Select(kriter);
            foreach (DataRow rw in rwSilinecekler)
            {
                rw.Delete();
            }
            dt.AcceptChanges();
        }
        catch { }
        return dt;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static bool xSatirGuncelle(this DataTable dt, string vKolonAdi, object vValue, string vKriter)
    {
        try
        {
            DataRow[] satirlar = dt.Select(vKriter, "");
            foreach (DataRow satir in satirlar)
            {
                satir[vKolonAdi] = vValue;
            }
        }
        catch
        {
            return false;
        }
        return true;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DataTable xRowFilter(this DataTable dt, string filter)
    {
        if (dt == null) return null;
        dt.DefaultView.RowFilter = filter;
        return dt.DefaultView.ToTable();
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static void xKeyFieldEkle(this DataTable dt, string columnName)
    {
        if (!dt.Columns.Contains(columnName))
        {
            DataColumn col = new DataColumn(columnName, typeof(Int32));
            dt.Columns.Add(col);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i][columnName] = i + 1;
        }
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DataTable xSelectAsDataTable(this DataTable dt, string vSelectString, string vOrderString)
    {
        DataTable dtSonuc = dt.Clone();
        try
        {
            DataRow[] satirlar = dt.Select(vSelectString, vOrderString);
            foreach (DataRow rw in satirlar)
            {
                DataRow rwSonuc = dtSonuc.NewRow();
                rwSonuc.ItemArray = rw.ItemArray;
                dtSonuc.Rows.Add(rwSonuc);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Tablo select işleminde hata oluştu. ", ex);
        }
        dtSonuc.AcceptChanges();
        return dtSonuc;
    }

    /// <summary>
    /// eğer eklenecek satırın sütunları tabloda yoksa uygun sütunları ekler
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static void xSatirEkle(this DataTable dt, DataRow rw)
    {
        if (dt == null || rw == null) return;

        foreach (DataColumn col in rw.Table.Columns)
        {
            if (dt.Columns.Contains(col.ColumnName) == false)
            {
                dt.Columns.Add(col.ColumnName, col.DataType);
            }
        }

        dt.ImportRow(rw);
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DataTable xTopNRecords(this DataTable dt, int count)
    {
        if (dt == null) return null;

        if (count >= dt.Rows.Count) return dt;

        DataTable dtSonuc = dt.Clone();
        for (int i = 0; i < count; i++)
        {
            DataRow rw = dt.Rows[i];
            dtSonuc.ImportRow(rw);
        }
        dtSonuc.AcceptChanges();

        return dtSonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DataRow xFirst(this DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0) return null;

        return dt.Rows[0];
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DataRow xLast(this DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0) return null;

        return dt.Rows[dt.Rows.Count - 1];
    }

    #endregion

    #region DataRow

    public static void xToClass(this DataRow rw, object o)
    {
        if (o == null) return;

        Type t = o.GetType();

        foreach (DataColumn col in rw.Table.Columns)
        {
            FieldInfo fi = t.GetField(col.ColumnName);
            if (fi != null)
            {
                try
                {
                    object deger = null;
                    try
                    {
                        deger = Convert.ChangeType(rw[col.ColumnName], fi.FieldType);
                    }
                    catch { }
                    if (deger == null) deger = rw[col.ColumnName];
                    fi.SetValue(o, deger);
                }
                catch { }
            }
            else
            {
                PropertyInfo pi = t.GetProperty(col.ColumnName);
                if (pi != null)
                {
                    try
                    {
                        object deger = null;
                        try
                        {
                            deger = Convert.ChangeType(rw[col.ColumnName], pi.PropertyType);
                        }
                        catch { }
                        if (deger == null) deger = rw[col.ColumnName];
                        pi.SetValue(o, deger, null);
                    }
                    catch { }
                }
            }
        }

        //TemelVeriSinifi classını parse et
        foreach (PropertyInfo pi in t.GetProperties())
        {
            if (pi.PropertyType.Name.Contains("KayitBilgisi"))
            {
                try
                {
                    object o2 = pi.GetValue(o, null);
                    xToClass(rw, o2);
                    pi.SetValue(o, o2, null);
                }
                catch { }
            }
        }
    }

    public static Dictionary<string, object> xToDictionary(this DataRow rw)
    {
        if (rw == null) return null;

        Dictionary<string, object> dic = new Dictionary<string, object>();

        foreach (DataColumn col in rw.Table.Columns)
        {
            string key = col.ColumnName;
            object val = null;
            if (rw[key] != DBNull.Value)
            {
                val = rw[key];
            }
            dic.Add(key, val);
        }

        return dic;
    }

    public static SortedDictionary<string, object> xToSortedDictionary(this DataRow rw)
    {
        if (rw == null) return null;

        SortedDictionary<string, object> dic = new SortedDictionary<string, object>();

        foreach (DataColumn col in rw.Table.Columns)
        {
            string key = col.ColumnName;
            object val = null;
            if (rw[key] != DBNull.Value)
            {
                val = rw[key];
            }
            dic.Add(key, val);
        }

        return dic;
    }

    #endregion

    #region Object

    [System.Diagnostics.DebuggerStepThrough]
    public static byte[] xToBytes(this object o)
    {
        byte[] sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = (byte[])o;
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DateTime? xToDateTime(this object o)
    {
        DateTime? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToDateTime(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static DateTime xToDateTimeDefault(this object o)
    {
        DateTime sonuc = new DateTime(1900, 1, 1);
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToDateTime(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int32? xToInt(this object o)
    {
        Int32? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt32(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int32 xToIntDefault(this object o)
    {
        Int32 sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt32(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int16? xToInt16(this object o)
    {
        Int16? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt16(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int16 xToInt16Default(this object o)
    {
        Int16 sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt16(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int32? xToInt32(this object o)
    {
        Int32? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt32(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int32 xToInt32Default(this object o)
    {
        Int32 sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt32(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int64? xToInt64(this object o)
    {
        Int64? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt64(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Int64 xToInt64Default(this object o)
    {
        Int64 sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt64(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static decimal? xToDecimal(this object o)
    {
        decimal? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToDecimal(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static decimal xToDecimalDefault(this object o)
    {
        decimal sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToDecimal(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static double? xToDouble(this object o)
    {
        double? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToDouble(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static double xToDoubleDefault(this object o)
    {
        double sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToDouble(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static long? xToLong(this object o)
    {
        long? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt64(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static long xToLongDefault(this object o)
    {
        long sonuc = 0;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToInt64(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static bool? xToBoolean(this object o)
    {
        bool? sonuc = null;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToBoolean(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static bool xToBooleanDefault(this object o)
    {
        bool sonuc = false;
        try
        {
            if (o != null && o != DBNull.Value)
                sonuc = Convert.ToBoolean(o);
        }
        catch { }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static object xSinifKopyala(this object o)
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(ms, o);

        ms.Position = 0;

        object obj = bf.Deserialize(ms);

        ms.Close();

        return obj;
    }

    /// <summary>
    /// belirtilen değerin dizide dizide olup olmadığını kontrol eder
    /// </summary>
    public static bool xIn(this object o, params object[] prms)
    {
        return prms.Contains(o);
    }

    /// <summary>
    /// belirtilen değerin sayısal olup olmadığını kontrol eder
    /// </summary>
    public static bool xIsNumeric(this object o)
    {
        decimal deger = 0;
        if (decimal.TryParse(o.ToString(), out deger))
            return true;
        else
            return false;
    }

    #endregion

    #region String

    public static string xToRemoveHTMLTags(this object o)
    {
        return System.Text.RegularExpressions.Regex.Replace(
          o.ToString(), "<[^>]*>", "");
    }

    /// <summary>
    /// string başına GUID ekler
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static string xToGuid(this object o)
    {
        string sonuc = "";
        try
        {
            if (o != null && o != DBNull.Value)
            {
                sonuc = o.ToString();
                sonuc = System.Guid.NewGuid().ToString() + sonuc;
            }
        }
        catch
        {
            sonuc = "";
        }
        return sonuc;
    }

    /// <summary>
    /// Kullanılmaması gereken veya türkçe karakterleri çevirir.
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static string xToUrl(this object o)
    {

        string sonuc = "";
        try
        {
            if (o != null && o != DBNull.Value)
            {
                sonuc = o.ToString();
                sonuc = sonuc.Replace(" ", "-");
                sonuc = sonuc.Replace("ç", "c");
                sonuc = sonuc.Replace("ş", "s");
                sonuc = sonuc.Replace("ı", "i");
                sonuc = sonuc.Replace("ö", "o");
                sonuc = sonuc.Replace("ü", "u");
                sonuc = sonuc.Replace("ğ", "g");
                sonuc = sonuc.Replace("Ç", "C");
                sonuc = sonuc.Replace("Ş", "S");
                sonuc = sonuc.Replace("İ", "I");
                sonuc = sonuc.Replace("Ö", "O");
                sonuc = sonuc.Replace("Ü", "U");
                sonuc = sonuc.Replace("Ğ", "G");

                sonuc = sonuc.Replace('?', '-');
                sonuc = sonuc.Replace('/', '-');
                sonuc = sonuc.Replace('\\', '-');
                sonuc = sonuc.Replace('(', '-');
                sonuc = sonuc.Replace(')', '-');
                sonuc = sonuc.Replace("&", "");
                sonuc = sonuc.Replace("'", "");

                return sonuc;
            }

        }
        catch
        {
            sonuc = "";
        }
        return sonuc;
    }

    /// <summary>
    /// bir sql komutu içindeki parametreleri listeler
    /// </summary>
    /// <param name="komut"></param>
    /// <returns></returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static List<string> xToParameterList(this string komut)
    {
        List<string> sonuc = new List<string>();

        komut = komut.Replace(" ", "|").Replace("(", "|").Replace(")", "|").Replace(",", "|").Replace("=", "|");
        while (komut.Contains("||"))
            komut = komut.Replace("||", "|");

        string[] kelimeler = komut.Split('|');

        foreach (string kelime in kelimeler)
        {
            if (kelime.StartsWith("@") && !sonuc.Contains(kelime))
            {
                sonuc.Add(kelime);
            }
        }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xToMD5(this string giris)
    {
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(giris);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2"));
        }
        return sb.ToString();
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xToMD5(this string giris, bool? buyukHarf)
    {
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(giris);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            if (buyukHarf == null || buyukHarf.Value == false)
                sb.Append(hashBytes[i].ToString("x2"));
            else
                sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }

    /// <summary>
    /// belirtilen stringi ters çevirir
    /// </summary>
    /// <param name="giris"></param>
    /// <returns></returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static string xReverse(this string giris)
    {
        char[] c = giris.ToCharArray();
        Array.Reverse(c);
        string sonuc = new string(c);
        return sonuc;
    }

    /// <summary>
    /// Gönderilen stringin geçerli bi saat olup olmadığını kontrol ediyor
    /// </summary>
    /// <param name="giris"></param>
    /// <returns></returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static bool xSaatMi(this string giris)
    {
        if (giris.Length != 5) return false;

        if (giris[2] != ':') return false;

        int? saat = giris.xLeft(2).xToInt();

        int? dakika = giris.xRight(2).xToInt();

        if (saat == null || dakika == null) return false;

        if (saat < 0 || saat > 23) return false;

        if (dakika < 0 || dakika > 59) return false;

        return true;


    }

    [System.Diagnostics.DebuggerStepThrough]
    public static Guid xToGuid(this string giris)
    {
        Guid sonuc = new Guid();
        try
        {
            sonuc = new Guid(giris);
        }
        catch { }
        return sonuc;
    }

    /// <summary>
    /// belirtilen stringin içinde diğer kelimelerin olup olmadığını kontrol eder
    /// </summary>
    /// <param name="giris"></param>
    /// <param name="texts"></param>
    /// <returns></returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static bool xCheckStrings(this string giris, params string[] texts)
    {
        bool sonuc = false;

        foreach (string text in texts)
        {
            if (giris.Contains(text) == false) return sonuc;
        }

        sonuc = true;
        return sonuc;
    }

    /// <summary>
    /// belirtilen stringin sol tarafından belli sayıda karakteri alır
    /// </summary>
    /// <param name="giris"></param>
    /// <param name="vUzunluk"></param>
    /// <returns></returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static string xLeft(this string giris, int vUzunluk)
    {
        string sonuc = "";

        if (string.IsNullOrEmpty(giris) || giris.Length <= vUzunluk)
        {
            sonuc = giris;
        }
        else
        {
            sonuc = giris.Substring(0, vUzunluk);
        }
        return sonuc;
    }

    /// <summary>
    /// belirtilen stringin sol tarafından belli sayıda karakteri alır
    /// </summary>
    /// <param name="giris"></param>
    /// <param name="vUzunluk"></param>
    /// <returns></returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static string xRight(this string giris, int vUzunluk)
    {
        string sonuc = "";
        if (string.IsNullOrEmpty(giris) || giris.Length <= vUzunluk)
        {
            sonuc = giris;
        }
        else
        {
            sonuc = giris.Substring(giris.Length - vUzunluk, vUzunluk);
        }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xSoldanKarakterAt(this string giris, int vAtilacakKarakterSayisi)
    {
        string sonuc = "";
        if (vAtilacakKarakterSayisi < giris.Length)
        {
            sonuc = giris.Substring(vAtilacakKarakterSayisi, giris.Length - vAtilacakKarakterSayisi);
        }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xSagdanKarakterAt(this string giris, int vAtilacakKarakterSayisi)
    {
        string sonuc = "";
        if (vAtilacakKarakterSayisi < giris.Length)
        {
            sonuc = giris.Substring(0, giris.Length - vAtilacakKarakterSayisi);
        }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static bool xBosMu(this string giris)
    {
        return string.IsNullOrEmpty(giris);
    }

    /// <summary>
    /// stringin içinde taglanmış parametreleri bulur
    /// örnek: bir string içinde $$$AdSoyad$$$ şeklinde geçen tagları liste halinde verir
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static List<string> xFindTags(this string text, string tagDefinition)
    {
        List<string> parameters = new List<string>();

        while (text.IndexOf(tagDefinition) != -1 && text.IndexOf(tagDefinition) != text.LastIndexOf(tagDefinition))
        {
            int index = text.IndexOf(tagDefinition);
            string temp = text.Substring(index, tagDefinition.Length);
            for (int i = index + tagDefinition.Length; i < text.Length; i++)
            {
                temp += text.Substring(i, 1);
                if (temp.EndsWith(tagDefinition))
                    break;
            }
            text = text.Replace(temp, "");
            parameters.Add(temp);
        }

        return parameters;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xSablonaBilgiYaz(this string sablon, string tag, string tagAyrac, string bilgi)
    {
        return sablon.xSablonaBilgiYaz(tag, tagAyrac, bilgi, false);
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xSablonaBilgiYaz(this string sablon, string tag, string tagAyrac, string bilgi, bool sagaYasla)
    {
        //tag ayraç ile başlar ve ayraç ile biter örnek : @Adi   @
        string sonuc = sablon;

        if (tag == null) return sonuc;

        if (bilgi == null) bilgi = "";

        int uzunluk = tag.Length - tagAyrac.Length * 2;

        bilgi = bilgi.xLeft(uzunluk); // bilgi uzunsa tag dan fazla kısmını kes

        if (bilgi.Length < uzunluk)//eğer bilgi kısaysa tag uzunluğuna tamamla
        {
            if (sagaYasla == false)
                bilgi = bilgi.PadRight(uzunluk, ' ');
            else
                bilgi = bilgi.PadLeft(uzunluk, ' ');
        }

        sonuc = sonuc.Replace(tag, bilgi);

        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xTurkceKarakterleriDegistir(this string text)
    {
        if (text == null) return text;

        text = text.Replace("Ü", "U").Replace("Ğ", "G").Replace("İ", "I").Replace("Ş", "S").Replace("Ç", "C").Replace("Ö", "O");
        text = text.Replace("ü", "u").Replace("ğ", "g").Replace("ı", "i").Replace("ş", "s").Replace("ç", "c").Replace("ö", "o");

        return text;
    }

    #endregion

    #region Decimal

    [System.Diagnostics.DebuggerStepThrough]
    public static decimal xTruncate(this decimal giris)
    {
        return Math.Truncate(giris);
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string xToSQLString(this decimal giris)
    {
        return giris.ToString().Replace(",", ".");
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static decimal xRound(this decimal giris, int ondalik)
    {
        return Math.Round(giris, ondalik);
    }

    #endregion

    /// <summary>
    /// eğer tarihin saat kısmı 0 ile 5 arasındaysa bu durumda tarihe göre x i y ye bağlayan gece ifadesi döner
    /// örnek : ÇARŞAMBAYI PERŞEMBEYE BAĞLAYAN GECE gibi
    /// </summary>
    /// <param name="tarih"></param>
    [System.Diagnostics.DebuggerStepThrough]
    public static string xSaatAciklama(this DateTime tarih)
    {
        string sonuc = "";
        if (tarih.Hour >= 0 && tarih.Hour <= 5)
        {
            string gun1 = tarih.AddDays(-1).ToString("dddd").ToUpper();
            string gun2 = tarih.ToString("dddd").ToUpper();

            switch (gun1)
            {
                case "PAZARTESİ": gun1 = "PAZARTESİYİ";
                    break;
                case "SALI": gun1 = "SALIYI";
                    break;
                case "ÇARŞAMBA": gun1 = "ÇARŞAMBAYI";
                    break;
                case "PERŞEMBE": gun1 = "PERŞEMBEYİ";
                    break;
                case "CUMA": gun1 = "CUMAYI";
                    break;
                case "CUMARTESİ": gun1 = "CUMARTESİYİ";
                    break;
                case "PAZAR": gun1 = "PAZARI";
                    break;
            }

            switch (gun2)
            {
                case "PAZARTESİ": gun2 = "PAZARTESİYE";
                    break;
                case "SALI": gun2 = "SALIYA";
                    break;
                case "ÇARŞAMBA": gun2 = "ÇARŞAMBAYA";
                    break;
                case "PERŞEMBE": gun2 = "PERŞEMBEYE";
                    break;
                case "CUMA": gun2 = "CUMAYA";
                    break;
                case "CUMARTESİ": gun2 = "CUMARTESİYE";
                    break;
                case "PAZAR": gun2 = "PAZARA";
                    break;
            }

            sonuc = gun1 + " " + gun2 + " BAĞLAYAN GECE";
        }
        return sonuc;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public static string ToSQLString(this DateTime giris)
    {
        return string.Format("{0:yyyy.MM.dd HH:mm:ss}", giris);
    }

    /// <summary>
    /// belirtilen kontrolün parentlerinin tamamında UpdatePanel arar ve bulduğu tüm UpdatePanelleri günceller
    /// bunun için UpdateMode = Conditional olmalıdır
    /// </summary>
    /// <param name="control"></param>
    public static void xUpdateAjax(this System.Web.UI.Control control)
    {
        //eğer kontrol bir update panelse ilk önce kontrolü güncelle
        if (control.GetType() == typeof(UpdatePanel))
        {
            UpdatePanel udp = (UpdatePanel)control;
            if (udp.UpdateMode == UpdatePanelUpdateMode.Conditional)
            {
                udp.Update();
            }
        }

        if (control.Parent == null) return;

        if (control.Parent.GetType() == typeof(UpdatePanel))
        {
            UpdatePanel udp = (UpdatePanel)control.Parent;
            if (udp.UpdateMode == UpdatePanelUpdateMode.Conditional)
            {
                udp.Update();
            }
        }

        control.Parent.xUpdateAjax();
    }

    /// <summary>
    /// eğer kontrol bir GridViewRow un içindeyse satırı geri verir
    /// </summary>
    public static GridViewRow xFindParentRow(this System.Web.UI.Control control)
    {
        if (control.Parent == null)
        {
            return null;
        }
        else
        {
            if (control.Parent.GetType() == typeof(GridViewRow))
            {
                return control.Parent as GridViewRow;
            }
            else
            {
                return xFindParentRow(control.Parent);
            }
        }
    }

    /// <summary>
    /// belirtilen kontrolün parentlerinden id sine göre arama yapar
    /// </summary>
    public static System.Web.UI.Control xFindParentControlById(this System.Web.UI.Control control, string parentControlId)
    {
        if (control.Parent == null)
        {
            return null;
        }
        else
        {
            if (control.Parent.ID == parentControlId)
            {
                return control.Parent;
            }
            else
            {
                return xFindParentControlById(control.Parent, parentControlId);
            }
        }
    }

    public static string xBirlestir(this List<string> dizi, string ayrac)
    {
        if (dizi == null || dizi.Count == 0) return null;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dizi.Count; i++)
        {
            if (i > 0) sb.Append(ayrac);
            sb.Append(dizi[i]);
        }

        return sb.ToString();
    }

}
