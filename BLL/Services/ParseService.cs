﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Repositories;
using HtmlAgilityPack;

namespace BLL.Services
{
    public class ParseService
    {
        private readonly HtmlWeb _web = new HtmlWeb()
        {
            UseCookies = true,
            OverrideEncoding = Encoding.Default,
        };

        private readonly PersonRepo _personRepo = new PersonRepo();
        
        public async Task Run()
        {
            try
            {
                // todo: dunno how to end loops?
                while (true) 
                {
                    var let = ParserHelper.GetNextChar();
                    var url = $"{ParserHelper.PeopleUrl}{let}/1/";
                    await ParseProfilesPaginationPage(url);
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Web connection problems");
                Console.WriteLine(webEx.Message);
            }
        }

        private async Task ParseProfilesPaginationPage(string url)
        {
            var doc = await _web.LoadFromWebAsync(url + "1/");
            var total = GetTotalPaginate(doc);
            
            for (var i = 1; i <= total; i++)
            {
                Console.WriteLine("Page #" + i);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(url + "/" + i);
                Console.ForegroundColor = ConsoleColor.Red;

                doc = _web.Load(url + "/" + i);

                var nodes = doc.DocumentNode.SelectNodes("//*[contains(@class,'Card-link see-more')]");

                foreach (var node in nodes)
                {
                    await ParseProfilesAttributes(node);
                }

                Console.WriteLine();
            }
        }

        private async Task ParseProfilesAttributes(HtmlNode node)
        {
            var link = node.Attributes.FirstOrDefault(j => j.Name == "href")?.Value;
            if (link == null) return;

            var id = link.Split("/").LastOrDefault();

            var model = new ProfileModel() {Id = id, Link = link};
            await ParseProfile(model);

            // For test
            Console.WriteLine(model.ToString());
        }

        private static int GetTotalPaginate(HtmlDocument doc)
        {
            var paginate = doc.DocumentNode
                .SelectSingleNode("//*[contains(@class,'component-navigation-pagination')]")
                .SelectNodes(".//ul/li[3]/ul/li");

            var last = paginate.LastOrDefault();
            var total = Convert.ToInt32(last?.InnerText.Trim());
            return total;
        }


        public async Task ParseProfile(ProfileModel profile)
        {
            try
            {
                var url = ParserHelper.ProfileUrl + profile.Id;
                var doc = await _web.LoadFromWebAsync(url);

                profile.Name = GetName(doc);
                profile.Photo = GetPhoto(doc);
                profile.Languages = GetLangs(doc);
                profile.Educations = GetEducations(doc);
                profile.CurrentJob = GetCurrentJob(doc);
                profile.Works = GetWorks(doc);
                profile.Interests = GetInterests(doc);
                profile.Wants = GetWants(doc);
                profile.Haves = GetHaves(doc);

                await _personRepo.UpsertProfile(profile);
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Web connection problems");
                Console.WriteLine(webEx.Message);
            }
        }

        private string GetPhoto(HtmlDocument doc)
        {
            var res = doc.DocumentNode.SelectSingleNode("//*[contains(@class,'photo ProfilesvCard-photo')]");
            return res?.Attributes.FirstOrDefault(i => i.Name == "src")?.Value;
        }
        

        private List<Education> GetEducations(HtmlDocument doc)
        {
            var all = doc.DocumentNode.SelectNodes("//*[contains(@class,'Educations-description')]");
            var list = new List<Education>();
            if (all == null) return list;

            foreach (var ed in all)
            {
                var education = new Education();
                education.Date = ed.ChildNodes.FirstOrDefault(i => i.HasClass("Educations-dateRange"))?.InnerText.Trim();
                education.School = ed.ChildNodes.FirstOrDefault(i => i.HasClass("Educations-schoolName"))?.InnerText.Trim();
                education.Notes = ed.ChildNodes.FirstOrDefault(i => i.HasClass("Educations-notes"))?.InnerText.Trim();
                list.Add(education);
            }

            return list;
        }

        private List<Work> GetWorks(HtmlDocument doc)
        {
            var workNodes = doc.DocumentNode.SelectNodes("//*[contains(@class,'WorkExperience-jobInfo')]");
            var works = new List<Work>();
            if (workNodes == null) return works;

            foreach (var ed in workNodes)
            {
                var work = new Work();
                work.Date = ed.ChildNodes.FirstOrDefault(i => i.HasClass("WorkExperience-dateRange"))?.InnerText.Trim();
                work.Title = ed.ChildNodes.FirstOrDefault(i => i.HasClass("WorkExperience-jobTitle"))?.InnerText.Trim();
                works.Add(work);
            }

            return works;
        }

        private string GetName(HtmlDocument doc)
        {
            var res = doc.DocumentNode.SelectSingleNode("//*[contains(@class,'fn ProfilesvCard-userName')]");
            return res != null ? res.InnerHtml.Trim() : "John Doe";
        }

        private List<string> GetLangs(HtmlDocument doc)
        {
            var langs = doc.DocumentNode.SelectNodes("//*[contains(@class,'Languages-name')]");
            return langs != null ? langs.Select(i => i.GetDirectInnerText().Trim()).ToList() : new List<string>();
        }

        private JobModel GetCurrentJob(HtmlDocument doc)
        {
            var jobNode = doc.DocumentNode.SelectSingleNode("//*[contains(@class,'ProfilesvCard-jobDetail')]");
            var job = new JobModel();
            if (jobNode == null) return job;
            job.Title = jobNode.ChildNodes.FirstOrDefault(i => i.HasClass("ProfilesvCard-jobTitle"))?.InnerText.Trim();
            job.Status = jobNode.ChildNodes.FirstOrDefault(i => i.HasClass("ProfilesvCard-employmentStatus"))?.GetDirectInnerText().Trim();

            return job;
        }

        private List<string> GetInterests(HtmlDocument doc)
        {
            var nodes = doc.GetElementbyId(ParserHelper.InterestsId)?.SelectNodes(".//li/span");
            return nodes != null ? nodes.Select(i => i.GetDirectInnerText().Trim()).ToList() : new List<string>();
        }

        private List<string> GetWants(HtmlDocument doc)
        {
            var nodes = doc.GetElementbyId(ParserHelper.WantsId)?.SelectNodes(".//li/span");
            return nodes != null ? nodes.Select(i => i.GetDirectInnerText().Trim()).ToList() : new List<string>();
        }

        private List<string> GetHaves(HtmlDocument doc)
        {
            var nodes = doc.GetElementbyId(ParserHelper.HavesId)?.SelectNodes(".//li/span");
            return nodes != null ? nodes.Select(i => i.GetDirectInnerText().Trim()).ToList() : new List<string>();
        }
    }
}
