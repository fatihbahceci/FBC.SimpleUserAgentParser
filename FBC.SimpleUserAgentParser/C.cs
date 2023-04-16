using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBC.SimpleUserAgentParser
{
    internal class C
    {
        public static readonly string[] BotCrawlerPrefixes = {
            "SemrushBot",
            "YandexBot",
            "Googlebot",
            "SeznamBot",
            "PaperLiBot",
            "Baiduspider",
            "BLEXBot",
            "Discordbot",
            "DotBot",
            "AhrefsBot"
        };


        //https://aka.ms/MicrosoftPreview
        //https://www.bing.com/webmasters/help/which-crawlers-does-bing-use-8c184ec0
        /*
        ## Bingbot

        Bingbot is our standard crawler and handles most of our crawling needs each day. Bingbot uses different types of user agent strings.

        ```
        Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm) Chrome/

        Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)
        W.X.Y.Z Safari/537.36

        Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36  (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)
 
        ```

        We regularly update our web page rendering engine to the most recent stable version of Microsoft Edge. Thus, "W.X.Y.Z" will be substituted with the latest Microsoft Edge version we are using, for example “80.0.345.0".

        ## AdIdxBot

        AdIdxBot is the crawler used by Bing Ads. AdIdxBot crawls ads and follows the websites from those ads for quality control. Just like Bingbot, AdIdxBot has both “desktop” and “mobile” variants.

        ```
        Mozilla/5.0 (compatible; adidxbot/2.0; +http://www.bing.com/bingbot.htm)

        Mozilla/5.0 (iPhone; CPU iPhone OS 7_0 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Version/7.0 Mobile/11A465 Safari/9537.53 (compatible; adidxbot/2.0; +http://www.bing.com/bingbot.htm)

        Mozilla/5.0 (Windows Phone 8.1; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 530) like Gecko (compatible; adidxbot/2.0; +http://www.bing.com/bingbot.htm)
        ```

        ## BingPreview

        BingPreview generates page snapshots for Bing. You can find more details about BingPreview [here](http://blogs.bing.com/webmaster/2012/10/26/page-snapshots-in-bing-windows-8-app-to-bring-new-crawl-traffic-to-sites/). Note that BingPreview has "desktop" and "mobile" variants.

        ```
        Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm) Chrome/W.X.Y.Z Safari/537.36

        Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36  (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)
        ```

        ## MicrosoftPreview

        MicrosoftPreview generates page snapshots for Microsoft products. Note that MicrosoftPreview has "desktop" and "mobile" variants.

        ```
        Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; MicrosoftPreview/2.0; +https://aka.ms/MicrosoftPreview) Chrome/W.X.Y.Z Safari/537.36

        Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36  (compatible; MicrosoftPreview/2.0; +https://aka.ms/MicrosoftPreview)
        ```        
         */
        public static readonly string[] BingBotPrefixes =
        {
            "bingbot", "adidxbot", "MicrosoftPreview"
        };

        public const string CONTAINS_HTTP_OR_HTTPS_URL_PATTERN = @"https?:\/\/(?:www\.)?([-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b)*(\/[\/\d\w\.-]*)*(?:[\?])*(.+)*";
        public const string HTTP_OR_HTTPS_URL_PATTERN =  $"^{CONTAINS_HTTP_OR_HTTPS_URL_PATTERN}$";
        //public const string HTTP_OR_HTTPS_URL_PATTERN = @"^(https?:\/\/)([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";
    }
}
