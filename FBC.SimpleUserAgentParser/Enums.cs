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
        SA,
    }
    public enum ESystem
    {
        Unknown,
        Mozilla,
        Twitterbot,
        WhatsApp,
        LivelapBot,
        ApacheHttpClient,
        GooglebotImage,
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
    }

}
