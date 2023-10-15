using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CurrentMoonPhase
{
    public class Moon
    {
        static string[] Monthes = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public static string phase { get; set; }
        public static string phase_name { get; set; }
        public static string moon_rise { get; set; }
        public static string moon_set { get; set;}
        public static string constellation { get; set; }

        public static void SetMoonPhase(DateTime dateTime)
        {
            string day = dateTime.Day.ToString();
            string month = Monthes[dateTime.Month - 1];
            string year = dateTime.Year.ToString();
            string url = $"https://phasesmoon.com/moonday{day}{month}{year}.html";
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            phase = doc.DocumentNode.SelectSingleNode("//div[@class='phasename']").GetDirectInnerText().Replace("% Visible", "");
            phase_name = doc.DocumentNode.SelectNodes("//div[@class='col4']/ul/li[@class='phasename']/strong")[0].GetDirectInnerText(); ;
            moon_rise = doc.DocumentNode.SelectNodes("//div[@class='col4']/ul/li")[1].GetDirectInnerText().Replace("Moonrise today: ", "");
            moon_set = doc.DocumentNode.SelectNodes("//div[@class='col4']/ul/li")[2].GetDirectInnerText().Replace("Moon set today: ", "");
            constellation = doc.DocumentNode.SelectNodes("//div[@class='col4']/div")[1].GetDirectInnerText().Split(' ')[3];
        }
    }
}
