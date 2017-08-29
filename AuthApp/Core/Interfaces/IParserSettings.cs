namespace AuthApp.Core.Interfaces
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }

        string Prefix { get; set; }
    }
}
