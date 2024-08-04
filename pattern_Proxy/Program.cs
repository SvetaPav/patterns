using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_Proxy
{
    public interface ISite
    {
        string GetPage(int num);
    }

    public class Site : ISite 
    { 
        public string GetPage(int num)
        {
            return "Это страница " + num;
        }
    }

    public class SiteProxy : ISite 
    {
        private ISite site;
        private Dictionary<int, string> cache;  // здесь хранятся страницы, которые мы открывали
        public SiteProxy(ISite site)
        {
            this.site = site;
            cache = new Dictionary<int, string>();
        }
        public string GetPage(int num)
        {
            string page;
            if (cache.ContainsKey(num)) { page = "Из кэша: " + cache[num]; }
            else { 
                page = site.GetPage(num);
                cache.Add(num, page); }
            return page;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISite firstSite = new SiteProxy(new Site());
            Console.WriteLine(firstSite.GetPage(1)); // "Это страница 1"
            Console.WriteLine(firstSite.GetPage(2)); // "Это страница 2"
            Console.WriteLine(firstSite.GetPage(3)); // "Это страница 3"
            Console.WriteLine(firstSite.GetPage(4)); // "Это страница 4"

            Console.WriteLine(firstSite.GetPage(1)); // "Из кэша: Это страница 1"
        }
    }
}
