using System.ComponentModel;

namespace FBC.SimpleUserAgentParser
{

    public enum EPlatform
    {
        Unknown,
        BotCrawler,
        Windows,
        Linux,
        Unix,
        Android,
        Macintosh,
        iPhone,
        iPad,
        OtherMobile,
        Apple,
        ChromeOS
    }

    public enum EProductChildItem
    {
        Unknown,
        AppleWebKit,
        Chrome,
        Safari,
        Gecko,
        Firefox,
        Mobile,
        Edg,
        CriOS,
        OPR,
        Version,
        EdgiOS,
        SamsungBrowser,
        Silk,
        GSA,
        Ubuntu,
        facebookexternalhit,
        XiaoMi,
        Twitterbot,
        KAIOS,
        DuckDuckGo,
        HuaweiBrowser,
        EdgA,
        Puffin,
        FxiOS,
        OPT,
        EdgW,
        /// <summary>
        /// it's probably pdf viewer
        /// </summary>
        Viewer,
        /// <summary>
        /// Mozilla/5.0 (Windows NT 6.1; WOW64) SkypeUriPreview Preview/0.5 skype-url-preview@microsoft.com
        /// </summary>
        Preview,
        XiaoMiMiuiBrowser,
        YaBrowser,
        HiBrowser,
        URL,
        SA,
        //Double agent problem. Example: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.95 Safari/537.36Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 Safari/602.1.50
        [Description("Mozilla")]
        MozillaDuplicated,
        //Universal Web View Service for Mobile
        UWS

    }
    public enum ESystem
    {
        Unknown,
        Mozilla,
        Twitterbot,
        WhatsApp,
        LivelapBot,
        //Java based HTTP client
        ApacheHttpClient,
        GoogleBot,
        TelegramBot,
        WordPress,
        OtherBot
    }

    public enum EBrowser
    {
        Unknown,
        BotCrawler,
        Chrome,
        Edge,
        Firefox,
        InternetExplorer,
        Opera,
        Safari,
        AppleWebKit,
        DuckDuckGo,
        SamsungBrowser,
        HuaweiBrowser,
        EdgeForAndroid,
        Puffin,
        /// <summary>
        /// IE For Apple
        /// </summary>
        Trident,
        FirefoxForiOS,
        OperaTouch,
        EdgeWebView,
        XiaoMiMiuiBrowser,
        YandexBrowser,
        HiBrowser,
        UniversalWebViewServiceForMobile,
    }

}
