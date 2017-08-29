using AuthApp.Core.Interfaces;

namespace AuthApp.Core.BelChip
{
    public class BelChipParserSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "http://belchip.by";

        public string Prefix { get; set; } = "search/?query=";
    }
}