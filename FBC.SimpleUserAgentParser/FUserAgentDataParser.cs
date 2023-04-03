using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FBC.SimpleUserAgentParser
{
    public partial class FUserAgentData
    {
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
                    //Mozilla/5.0 (Linux; Android 10) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/110.0.5481.153 Mobile DuckDuckGo/5 Safari/537.36
                    //                                                                                                         ^^^^^^
                    //                                                                                                          THAT
                    while (userAgent?.Length > 0 && userAgent.IndexOf(' ') is int iSpace && iSpace >= 0 && iSpace < userAgent.IndexOf('/'))
                    {
                        this.CommentData = (this.CommentData + " " + userAgent.Substring(0, iSpace)).Trim();
                        userAgent = userAgent.Substring(iSpace + 1).Trim();
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
                        sub.Product = EProductChildItem.Unknown;
                        sub.ProductAsStr = product;
                        sub.ProductVersion = version;
                        sub.Details = (details ?? "").Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
                        EProductChildItem tryParse;
                        if (Enum.TryParse<EProductChildItem>(sub.ProductAsStr, out tryParse))
                        {
                            sub.Product = tryParse;
                        }
                        if (sub.Product == EProductChildItem.Unknown)
                        {
                            // XiaoMi/MiuiBrowser  Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/534.24 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/534.24 XiaoMi/MiuiBrowser/13.22.1-gn
                            if (sub.ProductAsStr.StartsWith("XiaoMi/MiuiBrowser"))
                            {
                                sub.Product = EProductChildItem.XiaoMiMiuiBrowser;
                            }
                        }
                        Platforms.Add(sub);
                    }
                }
                if (userAgent?.Length > 0)
                {
                    if (mainAssigned)
                    {
                        CommentData = ((CommentData ?? "").Trim() + " " + userAgent.Trim()).Trim();
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
                        clearData(true);
                        SystemName = ESystem.Unknown;
                        SystemNameString = "Invalid";
                        SystemVersion = "";
                        CommentData = userAgent;

                    }
                }
            }
        }
    }
}
