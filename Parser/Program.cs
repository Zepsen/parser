using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            //Test2();
        }

        private static void Test1()
        {
            var letters = new[] {'a', 'b', 'c'};
            var url = "https://www.xing.com/people/pages/";
            try
            {
                foreach (var let in letters)
                {
                    var u = url + let + "/1/";

                    GetInfo(u);
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Web connection problems");
                Console.WriteLine(webEx.Message);
            }
        }

        private static void GetInfo(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url + "1/");

            var paginate = doc.DocumentNode.SelectNodes("//*[@id=\"maincontent\"]/div/div/div[3]/section/nav/ul/li[3]/ul/li");
            var last = paginate.LastOrDefault();

            var total = Convert.ToInt32(last?.InnerText.Trim());
            Console.WriteLine(url);

            for (int i = 1; i <= total; i++)
            {
                Console.WriteLine("Page #" + i);
                Console.WriteLine();

                // try to avoid first time
                doc = web.Load(url + "/" + i); 

                // Get attributes with anchor
                var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"maincontent\"]/div/div/div[3]/section/ul/li/div/div/a");

                // Get id from attribute
                foreach (var node in nodes)
                {
                    var id = node.Attributes.FirstOrDefault()?.Value.Split("/").LastOrDefault() ?? "not found";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(id);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Test2(id);

                }

                Console.WriteLine();
            }

        }

        /// <summary>
        /// Html agility pack
        /// </summary>
        private static void Test2(string id)
        {
            try
            {
                string Url = "https://www.xing.com/profile/" + id;
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);

                
                GetName(doc);
                GetLangs(doc);
                GetEducations(doc);
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Web connection problems");
                Console.WriteLine(webEx.Message);
            }
        }

        private static void GetEducations(HtmlDocument doc)
        {
            Console.WriteLine("Educations is:");
            var all = doc.DocumentNode.SelectNodes("//*[@id=\"maincontent\"]/div/div/div[2]/div/div[3]/ul/li/div[2]/div");
            if (all != null)
            {
                foreach (var ed in all)
                {
                    if (ed.GetClasses().Contains("Educations-dateRange"))
                    {
                        Console.WriteLine("date: " + ed.InnerText.Trim());
                    }

                    else if (ed.GetClasses().Contains("Educations-schoolName"))
                    {
                        Console.WriteLine("school: " + ed.InnerText.Trim());
                    }

                    else if (ed.GetClasses().Contains("Educations-notes"))
                    {
                        Console.WriteLine("notes: " + ed.InnerText.Trim());
                        Console.WriteLine();
                    }
                }
            } else Console.WriteLine("No educations");
            
            Console.WriteLine(new string('-', 50));
        }

        private static void GetName(HtmlDocument doc)
        {
            Console.WriteLine("Name is:");
            var res = doc.DocumentNode.SelectSingleNode("//*[@id=\"person\"]/div/div[1]/div[2]/div[2]/div[1]/h1");
            Console.WriteLine(res != null ? res.InnerHtml.Trim() : "No name");
            Console.WriteLine(new string('-', 50));
        }

        private static void GetLangs(HtmlDocument doc)
        {
            var langs = doc.DocumentNode.SelectNodes(
                "//*[@id=\"maincontent\"]/div/div/div[2]/div/div[4]/ul/li/div");

            if (langs != null)
            {
                Console.WriteLine("Languages is:");
                foreach (var s in langs.Select(i => i.GetDirectInnerText().Trim()))
                {
                    if (!string.IsNullOrEmpty(s))
                        Console.WriteLine(s);
                }
            } else Console.WriteLine("No langs");

            Console.WriteLine(new string('-', 50));
        }

    }
}
