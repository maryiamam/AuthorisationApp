using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthApp.Core.Interfaces;

namespace AuthApp.Core.RuChildip
{
    public class RuChildipParserSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://www.ru-chipdip.by";
        public string Prefix { get; set; } = "search?searchtext=";
    }
}