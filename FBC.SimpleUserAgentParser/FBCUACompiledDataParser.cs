using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBC.SimpleUserAgentParser
{
    public partial class FBCUACompiledData
    {
        private void CompileData(FUserAgentData userAgentData)
        {
            FillPlatform(userAgentData);
            FillBrowserData(userAgentData);
        }
        private void FillPlatform(FUserAgentData userAgentData)
        {
            this.PlatformDetails = userAgentData.SystemInformation.ToArray();
            this.PlatformString = "Unknown";
            this.Platform = EPlatform.Unknown;

            Action<EPlatform, string> parsePlatformString = (platform, platformString) =>
            {
                this.Platform = platform;
                this.PlatformString = platformString;
                if (platformString.Contains(' '))
                {
                    this.PlatformVersion = platformString.Split(' ', 2).Skip(1).FirstOrDefault();
                }
                else if (platformString.Contains('/'))
                {
                    this.PlatformVersion = platformString.Split('/', 2).Skip(1).FirstOrDefault();
                }
            };

            if (userAgentData.SystemName == ESystem.Mozilla)
            {
                if (userAgentData.SystemInformation.Count > 0)
                {
                    switch (userAgentData.SystemInformation[0])
                    {
                        case "Linux":
                            if (userAgentData.SystemInformation.AnyStartsWith("Android") is string p)
                            {
                                parsePlatformString(EPlatform.Android, p);
                            }
                            else
                            {
                                this.Platform = EPlatform.Linux;
                            }
                            break;
                        case "X11":
                            //Mozilla/5.0 (X11; CrOS x86_64 14541.0.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36
                            if (userAgentData.SystemInformation.AnyStartsWith("CrOS") is string pChromeOs)
                            {
                                this.Platform = EPlatform.ChromeOS;
                                this.PlatformString = pChromeOs;
                                this.PlatformVersion = pChromeOs.Split(" ").Skip(1).LastOrDefault();
                            }
                            //Mozilla/5.0 (X11; Linux i686; rv:47.0) Gecko/20100101 Firefox/47.0
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/534.24 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/534.24 XiaoMi/MiuiBrowser/13.22.1-gn
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36 OPR/92.0.0.0
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 Edg/110.0.1587.61
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36 OPR/96.0.0.0
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36 Google-PageRenderer Google (+https://developers.google.com/+/web/snippet/)
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/19.0 Chrome/102.0.5005.125 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/20.0 Chrome/106.0.5249.126 Safari/537.36
                            //Mozilla/5.0 (X11; Linux x86_64; rv:107.0) Gecko/20100101 Firefox/107.0
                            //Mozilla/5.0 (X11; Linux x86_64; rv:109.0) Gecko/20100101 Firefox/111.0
                            //Mozilla/5.0 (X11; Linux x86_64; rv:96.0) Gecko/20100101 Firefox/96.0
                            //Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.6) Gecko/2009020518 Ubuntu/9.04 (jaunty) Firefox/52.0.1
                            //Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9b3pre) Gecko/2008020507 Firefox/51.0
                            //Mozilla/5.0 (X11; U; Linux x86_64; de; rv:1.9.2.8) Gecko/20100723 Ubuntu/10.04 (lucid) Firefox/3.6.8
                            //Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:109.0) Gecko/20100101 Firefox/110.0
                            //Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:55.0) Gecko/20100101 Firefox/55.0
                            else if (userAgentData.SystemInformation.Contains("Ubuntu") || userAgentData.Platforms.Any(x => x.Product == EProductChildItem.Ubuntu))
                            {
                                this.Platform = EPlatform.Linux;
                                this.PlatformString = "Ubuntu";
                            }
                            else if (userAgentData.SystemInformation.AnyStartsWith("Linux") is string pLinux)
                            {
                                this.Platform = EPlatform.ChromeOS;
                                this.PlatformString = pLinux;
                                this.PlatformVersion = pLinux.Split(" ").Skip(1).LastOrDefault();
                            }
                            else
                            {
                                this.Platform = EPlatform.Linux;
                            }
                            break;
                        case "Macintosh":
                            // Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:109.0) Gecko/20100101 Firefox/111.0
                            //                         PowerPC
                            // Mozilla/5.0 (Macintosh; PPC Mac OS X 10.12; rv:47.0) Gecko/20100101 Firefox/47.0
                            this.Platform = EPlatform.Macintosh;
                            if (userAgentData.SystemInformation.AnyStartsWithOneOfThese("Intel Mac OS X", "PPC Mac OS X") is string macOSString)
                            {
                                this.PlatformString = macOSString;
                                this.PlatformVersion = macOSString.Split(" ").Skip(1).LastOrDefault();
                            }
                            break;

                        case "iPhone":
                            this.Platform = EPlatform.iPhone;
                            //Mozilla/5.0 (iPhone; CPU iPhone OS 12_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.1 Mobile/15E148 Safari/604.1
                            if (userAgentData.SystemInformation.AnyStartsWith("CPU iPhone OS") is string piPhoneOS)
                            {
                                this.PlatformString = this.Platform + " " + piPhoneOS;
                                this.PlatformVersion = piPhoneOS.Split(' ').Skip(3)?.FirstOrDefault();
                            }
                            break;

                        case "iPad":
                            this.Platform = EPlatform.iPad;
                            //Mozilla/5.0 (iPad; CPU OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1
                            if (userAgentData.SystemInformation.AnyStartsWith("CPU OS") is string piPadOS)
                            {
                                this.PlatformString = this.Platform + " " + piPadOS;
                                this.PlatformVersion = piPadOS.Split(' ').Skip(2)?.FirstOrDefault();
                            }
                            break;
                        case "Mobile":
                            this.Platform = EPlatform.OtherMobile;
                            this.PlatformString = userAgentData.SystemInformation.Skip(1).FirstOrDefault();
                            break;
                        default:
                            //Mozilla/5.0 (Apple Mac OS X v10.9.3; Trident/7.0; rv:11.0) like Gecko
                            //"Apple Mac OS X v10.9.3",
                            //"Trident/7.0",
                            //"rv:11.0"
                            if (userAgentData.SystemInformation.AnyStartsWith("Apple") is string appleString)
                            {
                                Platform = EPlatform.Apple;
                                PlatformString = appleString;
                                PlatformVersion = appleString.Split(" ").Skip(1).LastOrDefault();
                            }
                            if (userAgentData.SystemInformation.AnyStartsWith("Windows") is string pWindows)
                            {
                                parsePlatformString(EPlatform.Windows, pWindows);
                            }
                            else if (userAgentData.SystemInformation.AnyStartsWith("Android") is string pAndroid)
                            {
                                //Mozilla/5.0 (Android 10; Mobile; rv:109.0) Gecko/110.0 Firefox/110.0

                                parsePlatformString(EPlatform.Android, pAndroid);
                            }
                            else if (userAgentData.SystemInformation.AnyStartsWithOneOfThese(C.BotCrawlerPrefixes) is string pBotString)
                            {
                                parsePlatformString(EPlatform.BotCrawler, pBotString);

                            }
                            break;
                    }

                }
            }
            else
            {
                switch (userAgentData.SystemName)
                {
                    case ESystem.Unknown:
                    case ESystem.Mozilla:
                        break;
                    case ESystem.Twitterbot:
                    case ESystem.WhatsApp:
                    case ESystem.LivelapBot:
                    case ESystem.GoogleBot:
                    case ESystem.ApacheHttpClient:
                    case ESystem.TelegramBot:
                    case ESystem.WordPress:
                    case ESystem.OtherBot:
                        //parsePlatformString(EPlatform.Android, pAndroid);

                        this.Platform = EPlatform.BotCrawler;
                        this.PlatformString = userAgentData.SystemNameString;
                        this.PlatformVersion = userAgentData.SystemVersion;
                        break;
                }
            }

            if (this.Platform == EPlatform.Unknown)
            {


                var bindBotPlatform = userAgentData.Platforms?.Where(x =>
                x.Details.Contains("compatible") &&

                (x.Details.AnyStartsWithOneOfThese(C.BingBotPrefixes) is string str && !string.IsNullOrEmpty(str))

                ).FirstOrDefault();
                if (bindBotPlatform is FAgentPlatform platform)
                {
                    var bindBotStr = platform.Details.AnyStartsWithOneOfThese(C.BingBotPrefixes);
                    parsePlatformString(EPlatform.BotCrawler, bindBotStr!);
                }

            }
        }

        //Mozilla/5.0 (Linux; Android 10) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/110.0.5481.153 Mobile DuckDuckGo/5 Safari/537.36

        private KeyValuePair<EProductChildItem, EBrowser>[] browsersByPriority = new KeyValuePair<EProductChildItem, EBrowser>[]
        {
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.HiBrowser, EBrowser.HiBrowser),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.XiaoMiMiuiBrowser, EBrowser.XiaoMiMiuiBrowser),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.YaBrowser, EBrowser.YandexBrowser),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.DuckDuckGo, EBrowser.DuckDuckGo),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.SamsungBrowser, EBrowser.SamsungBrowser),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.HuaweiBrowser, EBrowser.HuaweiBrowser),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.UWS, EBrowser.UniversalWebViewServiceForMobile),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.Edg, EBrowser.Edge),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.EdgA, EBrowser.EdgeForAndroid),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.EdgW, EBrowser.EdgeWebView),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.Puffin, EBrowser.Puffin),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.OPT, EBrowser.OperaTouch),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.OPR, EBrowser.Opera),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.FxiOS, EBrowser.FirefoxForiOS),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.Firefox, EBrowser.Firefox),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.Chrome, EBrowser.Chrome),
            new KeyValuePair<EProductChildItem, EBrowser>(EProductChildItem.Safari, EBrowser.Safari),
        };
        private void FillBrowserData(FUserAgentData userAgentData)
        {

            Action<EBrowser, FAgentPlatform> selectBrowser = (browser, pfm) =>
            {
                this.Browser = browser;
                this.BrowserVersion = pfm.ProductVersion;

            };
            Func<KeyValuePair<EProductChildItem, EBrowser>[], bool> checkInOrder = (items) =>
            {
                foreach (var item in items)
                {
                    if (userAgentData.Platforms.FirstOrDefault(x => x.Product == item.Key) is FAgentPlatform p && p.Product != EProductChildItem.Unknown)
                    {
                        selectBrowser(item.Value, p);
                        return true;
                    }
                }
                return false;
            };

            if (!checkInOrder(browsersByPriority))
            {
                foreach (var platform in userAgentData.Platforms)
                {
                    switch (platform.Product)
                    {
                        case EProductChildItem.Safari:
                        case EProductChildItem.Chrome:
                        case EProductChildItem.DuckDuckGo:
                        case EProductChildItem.Firefox:
                        case EProductChildItem.SamsungBrowser:
                        case EProductChildItem.OPR:
                        case EProductChildItem.HuaweiBrowser:
                        case EProductChildItem.EdgA:
                        case EProductChildItem.Puffin:
                        case EProductChildItem.FxiOS:
                        case EProductChildItem.XiaoMiMiuiBrowser:
                            //skip
                            break;
                        case EProductChildItem.Gecko:
                        case EProductChildItem.Version:
                        case EProductChildItem.Ubuntu:
                        case EProductChildItem.facebookexternalhit:
                        case EProductChildItem.Twitterbot:
                        case EProductChildItem.Unknown:
                        case EProductChildItem.Viewer:
                        case EProductChildItem.Preview:
                        case EProductChildItem.SA:
                            //skip
                            break;
                        case EProductChildItem.Mobile:
                        case EProductChildItem.Edg:
                        case EProductChildItem.CriOS:
                        case EProductChildItem.EdgiOS:
                        case EProductChildItem.Silk:
                        case EProductChildItem.GSA:
                        case EProductChildItem.XiaoMi:
                        case EProductChildItem.KAIOS:
                            //not decided yet
                            break;

                        case EProductChildItem.AppleWebKit:
                            if (this.Browser == EBrowser.Unknown)
                            {
                                selectBrowser(EBrowser.AppleWebKit, platform);
                            }
                            break;
                    }
                }
            }

            if (this.Browser == EBrowser.Unknown)
            {
                //Mozilla/5.0 (Apple Mac OS X v10.9.3; Trident/7.0; rv:11.0) like Gecko
                if (userAgentData.SystemInformation.AnyStartsWith("Trident") is string tridentString)
                {
                    this.Browser = EBrowser.Trident;
                    BrowserVersion = tridentString.Split("/").LastOrDefault();
                }
                else if (userAgentData.SystemInformation.AnyStartsWith("MSIE") is string msieString)
                {
                    this.Browser = EBrowser.InternetExplorer;
                    this.BrowserVersion = msieString.Split(' ', 2, StringSplitOptions.TrimEntries).Skip(1).FirstOrDefault();
                }
                else
                {
                    if (this.Platform == EPlatform.BotCrawler)
                    {
                        this.Browser = EBrowser.BotCrawler;
                        this.BrowserVersion = this.PlatformVersion;
                    }
                    else
                    {
                        if (userAgentData.Platforms.Any(x => x.Product == EProductChildItem.Preview))
                        {
                            if (userAgentData.CommentData.Contains("SkypeUriPreview"))
                            {
                                this.Browser = EBrowser.BotCrawler;
                            }
                        }
                    }
                }

            }
        }

    }
}
