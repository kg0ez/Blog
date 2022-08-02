using System.Collections;
using System.Text;
using Blog.Common.DTOs;
using HtmlAgilityPack;

namespace Blog.Parser
{
	public class NewsParser
	{
		public List<TopicDto> Parser()
        {
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = web.Load("https://www.belta.by/all_news");

            ArrayList list = GetLink(document);

            List<TopicDto> news = new List<TopicDto>();
            foreach (string item in list)
            {
                document = web.Load(item);

                string title = string.Empty;
                string subtitle = string.Empty;

                Console.ForegroundColor = ConsoleColor.Green;
                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//div[contains(@class, 'content_margin')]//h1"))
                    title = link.InnerText;

                Console.ForegroundColor = ConsoleColor.White;
                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//div[contains(@class, 'js-mediator-article')]//p"))
                    subtitle = link.InnerText;
                news.Add(new TopicDto { Title = title, Subtitle = subtitle.Split('.').First() });
            }
            return news;
        }
        private ArrayList GetLink(HtmlDocument document)
        {
            ArrayList list = new ArrayList();
            int count = 0;

            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[contains(@class, 'lenta_inner')]//a[@href]"))
            {
                count++;
                Console.WriteLine(node.GetAttributeValue("href", null));
                if (count > 2)
                    list.Add(node.GetAttributeValue("href", null));
                if (count == 12) break;
            }
            return list;
        }
    }
}

