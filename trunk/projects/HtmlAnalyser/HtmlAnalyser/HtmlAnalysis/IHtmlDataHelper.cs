using HtmlAgilityPack;

namespace HtmlAnalyser.HtmlAnalysis
{
    public interface IHtmlDataHelper
    {
        void ReadLine(HtmlNode node, ref DataProcessTask task);
    }
}
