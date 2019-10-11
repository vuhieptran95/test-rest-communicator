using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCovariance
{
    public class SitePageData
    {
        public SitePageData()
        {
            Name = "SitePageData";
        }
        public string Name { get; set; }
    }

    public class SitePageDataF1 : SitePageData
    {
        public SitePageDataF1()
        {
            Name = "SitePageData";
            NameF1 = "SitePageDataF1";
        }
        public string NameF1 { get; set; }
    }

    public interface IPageViewModel<out T> where T:SitePageData
    {
        T CurrentPage { get;}
    }
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
        public T CurrentPage { get; }
    }
    public class PageViewModelHelper
    {
        public static PageViewModel<T> Create<T>(T page) where T : SitePageData
        {
            return new PageViewModel<T>(page);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sitePage = new SitePageData();
            var sitePageF1 = new SitePageDataF1();

            var page = new PageViewModel<SitePageData>(sitePage);
            var page2 = PageViewModelHelper.Create(sitePageF1);

            IPageViewModel<SitePageData> page3 = page2;

            Console.WriteLine(page.CurrentPage.Name);
            Console.WriteLine(page3.CurrentPage.Name);

            Console.ReadKey();
        }
    }
}
