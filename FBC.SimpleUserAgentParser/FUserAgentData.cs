using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace FBC.SimpleUserAgentParser
{
    public partial class FUserAgentData
    {
        #region Members
        private string? rawData;
        private ESystem systemName;
        private string systemNameString = string.Empty;
        private string systemVersion = string.Empty;
        private List<string>? systemInformation;
        private List<FAgentPlatform>? platforms;
        private string commentData = string.Empty;
        private string errorMessage = string.Empty;
        private FBCUACompiledData? compiledData { get; set; }

        public string? RawData
        {
            get => rawData;
            set { rawData = value; parseData(); }
        }
        public ESystem SystemName
        {
            get => systemName;
            private set => systemName = value;
        }
        public string SystemNameString
        {
            get => systemNameString ?? (systemNameString = "");
            private set => systemNameString = value ?? "";
        }
        public string SystemVersion
        {
            get => systemVersion ?? (systemVersion = "");
            private set => systemVersion = value ?? "";
        }
        public List<string> SystemInformation
        {
            get => systemInformation ?? (systemInformation = new List<string>());
            private set => systemInformation = value ?? new List<string>();
        }

        public List<FAgentPlatform> Platforms
        {
            get => platforms ?? (platforms = new List<FAgentPlatform>());
            private set => platforms = value ?? new List<FAgentPlatform>();
        }

        public string CommentData
        {
            get => commentData ?? (commentData = "");
            private set => commentData = value ?? "";
        }
        #endregion

        public FBCUACompiledData CompiledData
        {
            get => compiledData ?? (compiledData = new FBCUACompiledData());
            private set => compiledData = value ?? new FBCUACompiledData();
        }

        public FUserAgentData()
        {
            clearData();
        }
        public FUserAgentData(string userAgentString)
        {
            RawData = userAgentString;
        }
    }
    public partial class FUserAgentData
    {
        private void clearData(bool keepRawData = false)
        {

            if (!keepRawData) rawData = null;
            SystemName = ESystem.Unknown;
            SystemNameString = string.Empty;
            SystemVersion = string.Empty;
            SystemInformation = new List<string>();
            Platforms = new List<FAgentPlatform>();
            CommentData = string.Empty;
            CompiledData = new FBCUACompiledData();
        }
        public override string ToString()
        {
            return this.ToJson();
        }
        private void parseData()
        {
            clearData(true);
            if (!string.IsNullOrEmpty(this.RawData))
            {
                string userAgent = this.RawData!;
                userAgent = (userAgent ?? "").Trim();
                if (userAgent.StartsWith("User-Agent:"))
                {
                    userAgent = userAgent.Substring("User-Agent:".Length).Trim();
                }
                /*
                Syntax
                User-Agent: <product> / <product-version> <comment>

                Common format for web browsers:
                    User-Agent: Mozilla/5.0 (<system-information>) <platform> (<platform-details>) <extensions>
                Directives
                - <product>
                  A product identifier — its name or development codename.
                - <product-version>
                  Version number of the product.
                - <comment>
                  Zero or more comments containing more details. For example, sub-product information.

                Firefox UA string
                    Mozilla/5.0 (platform; rv:geckoversion) Gecko/geckotrail Firefox/firefoxversion
                    1. `Mozilla/5.0` is the general token that says that the browser is Mozilla-compatible. For historical reasons, almost every browser today sends it.
                    2. ***platform\*** describes the native platform that the browser is running on (Windows, Mac, Linux, Android, etc.) and if it is a mobile phone. 
                    3. **rv:\*geckoversion\*** indicates the release version of Gecko (such as "*17.0*"). In recent browsers, ***geckoversion\*** is the same as ***firefoxversion\***.
                    4. ***Gecko/geckotrail\*** indicates that the browser is based on Gecko. (On the desktop, ***geckotrail\*** is always the fixed string `20100101`.)
                    5. ***Firefox/firefoxversion\*** indicates that the browser is Firefox and provides the version (such as "*17.0"*).
                 */

                bool mainAssigned = false;
                while (Regex.Match(userAgent, @"^([^\(\)\s]+)\/([^\(\)\s]+)\s?(.*)$") is Match m && m.Success)
                {
                    var product = m.Groups[1].Value.Trim();
                    var version = m.Groups[2].Value.Trim();
                    var details = "";
                    //var all = $"{product}/{version}";
                    userAgent = m.Groups[3].Value.Trim();
                    if (userAgent.StartsWith("("))
                    {
                        var eIndex = userAgent.IndexOf(")");
                        details = userAgent.Substring(1, eIndex - 1).Trim();
                        if (eIndex < userAgent.Length)
                        {
                            userAgent = userAgent.Substring(eIndex + 1).Trim();
                        }
                        else
                        {
                            userAgent = "";
                        }
                    }
                    if (!mainAssigned)
                    {
                        SystemName = ESystem.Unknown;
                        SystemNameString = product;
                        SystemVersion = version;
                        SystemInformation = (details ?? "").Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
                        switch (SystemNameString)
                        {
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/20.0 Chrome/106.0.5249.126 Safari/537.36
                            //Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)
                            case "Mozilla": SystemName = ESystem.Mozilla; break;
                            //Twitterbot/1.0
                            case "Twitterbot": SystemName = ESystem.Twitterbot; break;
                            //WhatsApp/2.23.4.79 A
                            case "WhatsApp": SystemName = ESystem.WhatsApp; break;
                            //LivelapBot/0.2 (http://site.livelap.com/crawler)
                            case "LivelapBot": SystemName = ESystem.LivelapBot; break;
                            //Apache-HttpClient/UNAVAILABLE (java 1.4)
                            case "Apache-HttpClient": SystemName = ESystem.ApacheHttpClient; break;
                            //Googlebot-Image/1.0
                            case "Googlebot-Image": SystemName = ESystem.GooglebotImage; break;
                            default:
                                break;
                        }
                        mainAssigned = true;
                    }
                    else
                    {
                        var sub = new FAgentPlatform();
                        sub.Product = EFBCUAProductChildItem.Unknown;
                        sub.ProductAsStr = product;
                        sub.ProductVersion = version;
                        sub.Details = (details ?? "").Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
                        switch (sub.ProductAsStr)
                        {
                            case "AppleWebKit": sub.Product = EFBCUAProductChildItem.AppleWebKit; break;
                            case "Chrome": sub.Product = EFBCUAProductChildItem.Chrome; break;
                            case "Safari": sub.Product = EFBCUAProductChildItem.Safari; break;
                            case "Gecko": sub.Product = EFBCUAProductChildItem.Gecko; break;
                            case "Firefox": sub.Product = EFBCUAProductChildItem.Firefox; break;
                            case "Mobile": sub.Product = EFBCUAProductChildItem.Mobile; break;
                            case "Edg": sub.Product = EFBCUAProductChildItem.Edg; break;
                            case "CriOS": sub.Product = EFBCUAProductChildItem.CriOS; break;
                            case "OPR": sub.Product = EFBCUAProductChildItem.OPR; break;
                            case "Version": sub.Product = EFBCUAProductChildItem.Version; break;
                            case "EdgiOS": sub.Product = EFBCUAProductChildItem.EdgiOS; break;
                            case "SamsungBrowser": sub.Product = EFBCUAProductChildItem.SamsungBrowser; break;
                            case "Silk": sub.Product = EFBCUAProductChildItem.Silk; break;
                            case "GSA": sub.Product = EFBCUAProductChildItem.GSA; break;
                            case "Ubuntu": sub.Product = EFBCUAProductChildItem.Ubuntu; break;
                            case "facebookexternalhit": sub.Product = EFBCUAProductChildItem.facebookexternalhit; break;
                            case "Twitterbot": sub.Product = EFBCUAProductChildItem.Twitterbot; break;
                            case "XiaoMi": sub.Product = EFBCUAProductChildItem.XiaoMi; break;
                            case "KAIOS": sub.Product = EFBCUAProductChildItem.KAIOS; break;
                        }
                        Platforms.Add(sub);
                    }
                }
                if (userAgent?.Length > 0)
                {
                    if (mainAssigned)
                    {
                        CommentData = (CommentData ?? "").Trim() + userAgent.Trim();
                    }
                    else
                    {
                        //switch(userAgent)
                        //{
                        //    case "Google":
                        //    SystemName = ESystem.bo
                        //    default: 
                        //        break;
                        //}
                        clearData();
                        SystemName = ESystem.Unknown;
                        SystemNameString = "Invalid";
                        SystemVersion = "";
                        CommentData = userAgent;

                    }
                }

                CompileProduct();
                //Trace.WriteLine($"{r.CompiledData}");
            }
        }

        private void FillPlatformDetails()
        {
            int detailPos = 0;
            FBCUACompiledData cData = this.CompiledData;
            List<string> details = this.SystemInformation;
            switch (cData.Platform)
            {
                case EUAPlatform.Linux:
                    if (details[0] == "Linux")
                    {
                        detailPos = 1;
                    }
                    else
                    {
                        detailPos = 0;
                    }
                    break;
                case EUAPlatform.Android:
                    //Mozilla/5.0 (Android 10; Mobile; rv:109.0) Gecko/110.0 Firefox/110.0
                    if (details[0].StartsWith("Android"))
                    {
                        detailPos = 0;
                    }
                    else
                    {
                        detailPos = 1;
                    }
                    break;
                case EUAPlatform.Windows:
                case EUAPlatform.Unix:
                case EUAPlatform.Macintosh:
                case EUAPlatform.iPhone:
                case EUAPlatform.iPad:
                case EUAPlatform.BotCrawler:
                case EUAPlatform.OtherMobile:
                    detailPos = 0;
                    break;
                case EUAPlatform.Unknown:
                    break;
            }
            if (details.Count > detailPos)
            {
                cData.PlatformString = details[detailPos];
                if (cData.PlatformString.Contains(' '))
                {
                    cData.PlatformVersion = cData.PlatformString.Split(' ', 2, StringSplitOptions.TrimEntries)[1];
                }
                else
                {
                    if (details.Count > detailPos + 1)
                    {
                        detailPos++;
                        cData.PlatformVersion = details[detailPos];

                    }
                }
                cData.PlatformDetails = details.Skip(detailPos + 1).ToArray();

            }
            else
            {
                cData.PlatformString = "Unknown";
            }

            if (cData.Platform == EUAPlatform.Unknown)
            {
                if (cData.PlatformVersion.StartsWithOneOfThese(
                    "SemrushBot",
                    "YandexBot",
                    "Googlebot",
                    "SeznamBot",
                    "PaperLiBot",
                    "Baiduspider"

                    ))
                {
                    cData.Platform = EUAPlatform.BotCrawler;
                }
                else if (cData.PlatformString == "compatible")
                {
                    var exists = details.Where(x => x.StartsWith("Windows")).FirstOrDefault();
                    if (!string.IsNullOrEmpty(exists))
                    {
                        cData.Platform = EUAPlatform.Windows;
                        cData.PlatformString = exists;
                        if (cData.PlatformString.Contains(' '))
                        {
                            cData.PlatformVersion = cData.PlatformString.Split(' ', 2, StringSplitOptions.TrimEntries)[1];
                        }
                        else
                        {
                            cData.PlatformVersion = "";
                        }
                    }
                }
            }
        }

        private void CompileProduct()
        {

            var cData = this.CompiledData;
            if (this.SystemName == ESystem.Mozilla)
            {
                if (this.SystemInformation.Count > 0)
                {
                    switch (this.SystemInformation[0])
                    {
                        case "Linux":
                            if (this.SystemInformation.Count > 1 && this.SystemInformation[1].StartsWith("Android"))
                            {
                                cData.Platform = EUAPlatform.Android;
                            }
                            else
                            {
                                cData.Platform = EUAPlatform.Linux;
                            }
                            break;
                        case "X11":
                            cData.Platform = EUAPlatform.Linux;
                            break;
                        case "Macintosh":
                            cData.Platform = EUAPlatform.Macintosh;
                            break;

                        case "iPhone":
                            cData.Platform = EUAPlatform.iPhone;
                            break;

                        case "iPad":
                            cData.Platform = EUAPlatform.iPad;
                            break;
                        case "Mobile":
                            cData.Platform = EUAPlatform.OtherMobile;
                            break;
                        default:
                            if (this.SystemInformation[0].StartsWith("Windows"))
                            {
                                cData.Platform = EUAPlatform.Windows;
                            }
                            else if (this.SystemInformation[0].StartsWith("Android"))
                            {
                                //Mozilla/5.0 (Android 10; Mobile; rv:109.0) Gecko/110.0 Firefox/110.0

                                cData.Platform = EUAPlatform.Android;
                            }

                            break;
                    }
                    FillPlatformDetails();

                }
            }
            else
            {
                switch (this.SystemName)
                {
                    case ESystem.Unknown:
                        break;
                    case ESystem.Mozilla:
                        break;
                    case ESystem.Twitterbot:
                    case ESystem.WhatsApp:
                    case ESystem.LivelapBot:
                    case ESystem.GooglebotImage:
                    case ESystem.ApacheHttpClient:
                        this.CompiledData.Platform = EUAPlatform.BotCrawler;
                        FillPlatformDetails();
                        break;
                }
            }
        }
    }

}
