using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEpiViewModel
{
    public abstract class SitePageData
    {
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public IEnumerable<string> MetaKeywords { get; set; }
    }

    public class NormalClass : SitePageData
    {
        public string OtherStuff { get; set; }
    }

    public interface IPageViewModel<out T> where T: SitePageData
    {
        T CurrentPage { get; }
    }

    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
        public T CurrentPage { get; }

    }

    public class PreviewModel : PageViewModel<SitePageData>
    {
        public PreviewModel(SitePageData currentPage) : base(currentPage)
        {
        }
        public IContent PreviewContent { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
