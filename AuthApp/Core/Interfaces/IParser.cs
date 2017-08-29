using AngleSharp.Dom.Html;

namespace AuthApp.Core.Interfaces
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}