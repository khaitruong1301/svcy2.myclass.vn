using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bookingticketAPI
{
    public class Common
    {
        //public static readonly string Domain = "http://movie0706.cybersoft.edu.vn/";
        public static readonly string Domain = "https://localhost:44370/";
        //public static readonly string DomainImage = "https://localhost:44370/hinhanh/";
        public static readonly string DomainImage = "http://movie0706.cybersoft.edu.vn/hinhanh/";

        public class DateTimes
        {
            public static DateTime Now()
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime d = new DateTime();
                if (date != "")
                {
                    d = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    d = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                return d;
            }
            public static DateTime NowHouse()
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                DateTime d = new DateTime();
                if (date != "")
                {
                    d = DateTime.ParseExact(date, "dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    d = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), "dd/MM/yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                return d;
            }
            public static DateTime ConvertDateHour(string date = "")
            {
                DateTime d = new DateTime();
                if (date.Split('-').Count() > 1)
                {
                    if (!string.IsNullOrEmpty(date))
                    {
                        d = DateTime.ParseExact(date, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        d = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    return d;
                }
                if (!string.IsNullOrEmpty(date))
                {
                    d = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    d = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                return d;
            }

            public static DateTime ConvertDate(string date = "")
            {
                DateTime d = new DateTime();
                if (date.Split('-').Count() > 1)
                {
                    if (!string.IsNullOrEmpty(date))
                    {
                        d = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        d = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    return d;
                }
                if (!string.IsNullOrEmpty(date))
                {
                    d = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    d = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                return d;
            }
        }
        public class LoaiBoKyTu
        {
            public static string bestLower(string input)
            {
                input = input.Trim();
                for (int i = 0x20; i < 0x30; i++)
                {
                    input = input.Replace(((char)i).ToString(), " ");
                }
                input = input.Replace(".", "-");
                input = input.Replace(" ", "-");
                input = input.Replace(",", "-");
                input = input.Replace(";", "-");
                input = input.Replace(":", "-");
                input = input.Replace("  ", "-");
                Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
                string str = input.Normalize(NormalizationForm.FormD);
                string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
                while (str2.IndexOf("?") >= 0)
                {
                    str2 = str2.Remove(str2.IndexOf("?"), 1);
                }
                while (str2.Contains("--"))
                {
                    str2 = str2.Replace("--", "-").ToLower();
                }
                return str2.ToLower();
            }
        }
    }
}
