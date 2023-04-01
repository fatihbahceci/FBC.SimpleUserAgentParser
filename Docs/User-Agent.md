[TOC]

# User-Agent

[Source](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent)

The **User-Agent** [request header](https://developer.mozilla.org/en-US/docs/Glossary/Request_header) is a characteristic string that lets servers and network peers identify the application, operating system, vendor, and/or version of the requesting [user agent](https://developer.mozilla.org/en-US/docs/Glossary/User_agent).

**Warning:** Please read [Browser detection using the user agent](https://developer.mozilla.org/en-US/docs/Web/HTTP/Browser_detection_using_the_user_agent) for why serving different Web pages or services to different browsers is usually a bad idea.

| Header type                                                  | [Request header](https://developer.mozilla.org/en-US/docs/Glossary/Request_header) |
| :----------------------------------------------------------- | ------------------------------------------------------------ |
| [Forbidden header name](https://developer.mozilla.org/en-US/docs/Glossary/Forbidden_header_name) | no                                                           |

## [Syntax](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#syntax)

```
User-Agent: <product> / <product-version> <comment>
```

Copy to ClipboardCopy to Clipboard

Common format for web browsers:

```
User-Agent: Mozilla/5.0 (<system-information>) <platform> (<platform-details>) <extensions>
```

Copy to ClipboardCopy to Clipboard

### [Directives](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#directives)

- <product>

  A product identifier — its name or development codename.

- <product-version>

  Version number of the product.

- <comment>

  Zero or more comments containing more details. For example, sub-product information.

## [Firefox UA string](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#firefox_ua_string)

For more on Firefox- and Gecko-based user agent strings, see the [Firefox user agent string reference](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent/Firefox). The UA string of Firefox is broken down into 4 components:

```
Mozilla/5.0 (platform; rv:geckoversion) Gecko/geckotrail Firefox/firefoxversion
```

Copy to ClipboardCopy to Clipboard

1. `Mozilla/5.0` is the general token that says that the browser is Mozilla-compatible. For historical reasons, almost every browser today sends it.
2. ***platform\*** describes the native platform that the browser is running on (Windows, Mac, Linux, Android, etc.) and if it is a mobile phone. [Firefox OS](https://developer.mozilla.org/en-US/docs/Glossary/Firefox_OS) phones say `Mobile` — the web is the platform. Note that ***platform\*** can consist of multiple "`;`"-separated tokens. See below for further details and examples.
3. **rv:\*geckoversion\*** indicates the release version of Gecko (such as "*17.0*"). In recent browsers, ***geckoversion\*** is the same as ***firefoxversion\***.
4. ***Gecko/geckotrail\*** indicates that the browser is based on Gecko. (On the desktop, ***geckotrail\*** is always the fixed string `20100101`.)
5. ***Firefox/firefoxversion\*** indicates that the browser is Firefox and provides the version (such as "*17.0"*).

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples)

```
Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0
Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:42.0) Gecko/20100101 Firefox/42.0
```

Copy to ClipboardCopy to Clipboard

## [Chrome UA string](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#chrome_ua_string)

The Chrome (or Chromium/Blink-based engines) user agent string is similar to Firefox's. For compatibility, it adds strings like `KHTML, like Gecko` and `Safari`.

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples_2)

```
Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36
```

Copy to ClipboardCopy to Clipboard

## [Opera UA string](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#opera_ua_string)

The Opera browser is also based on the Blink engine, which is why it almost looks the same as the Chrome UA string, but adds `"OPR/<version>"`.

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples_3)

```
Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36 OPR/38.0.2220.41
```

Copy to ClipboardCopy to Clipboard

Older, Presto-based Opera releases used:

```
Opera/9.80 (Macintosh; Intel Mac OS X; U; en) Presto/2.2.15 Version/10.00
Opera/9.60 (Windows NT 6.0; U; en) Presto/2.1.1
```

Copy to ClipboardCopy to Clipboard

## [Microsoft Edge UA string](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#microsoft_edge_ua_string)

The Edge browser is also based on the Blink engine. It adds `"Edg/<version>"`.

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples_4)

```
Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36 Edg/91.0.864.59
```

Copy to ClipboardCopy to Clipboard

## [Safari UA string](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#safari_ua_string)

In this example, the user agent string is mobile Safari's version. It contains the word `"Mobile"`.

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples_5)

```
Mozilla/5.0 (iPhone; CPU iPhone OS 13_5_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.1.1 Mobile/15E148 Safari/604.1
```

Copy to ClipboardCopy to Clipboard

## [Crawler and bot UA strings](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#crawler_and_bot_ua_strings)

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples_6)

```
Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)
```

Copy to ClipboardCopy to Clipboard

```
Mozilla/5.0 (compatible; YandexAccessibilityBot/3.0; +http://yandex.com/bots)
```

Copy to ClipboardCopy to Clipboard

## [Library and net tool UA strings](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#library_and_net_tool_ua_strings)

### [Examples](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#examples_7)

```
curl/7.64.1
```

Copy to ClipboardCopy to Clipboard

```
PostmanRuntime/7.26.5
```

Copy to ClipboardCopy to Clipboard

## [Specifications](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#specifications)

| Specification                                                |
| :----------------------------------------------------------- |
| [HTTP Semantics # field.user-agent](https://httpwg.org/specs/rfc9110.html#field.user-agent) |

## [Browser compatibility](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#browser_compatibility)

[Report problems with this compatibility data on GitHub](https://github.com/mdn/browser-compat-data/issues/new?mdn-url=https%3A%2F%2Fdeveloper.mozilla.org%2Fen-US%2Fdocs%2FWeb%2FHTTP%2FHeaders%2FUser-Agent&metadata= MDN+page+report+details<%2Fsummary> *+Query%3A+`http.headers.User-Agent` *+Report+started%3A+2023-03-15T17%3A05%3A10.750Z <%2Fdetails>&title=http.headers.User-Agent+-+&template=data-problem.yml)

### Legend

Tip: you can click/tap on a cell for more information.



## [See also](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent#see_also)

- [User-Agent detection, history and checklist](https://hacks.mozilla.org/2013/09/user-agent-detection-history-and-checklist/)
- [Firefox user agent string reference](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent/Firefox)
- [Browser detection using the user agent](https://developer.mozilla.org/en-US/docs/Web/HTTP/Browser_detection_using_the_user_agent)
- [Client hints](https://developer.mozilla.org/en-US/docs/Web/HTTP/Client_hints)

# What is the standard format for a browser's User-Agent string

[Source](https://stackoverflow.com/questions/2601372/what-is-the-standard-format-for-a-browsers-user-agent-string)

The `User-Agent` header is part of the [`RFC7231`](https://www.rfc-editor.org/rfc/rfc7231#section-5.5.3), which is an improved version of the [`RFC1945`](http://www.ietf.org/rfc/rfc1945.txt), where it states:

> The `User-Agent` request-header field contains information about the user agent originating the request. This is for statistical purposes, the tracing of protocol violations, and automated recognition of user agents for the sake of tailoring responses to avoid particular user agent limitations. User agents *SHOULD* include this field with requests. The field can contain multiple `product` tokens (section 3.8) and `comments` identifying the agent and any subproducts which form a significant part of the user agent. By convention, the `product` tokens are listed in order of their significance for identifying the application.

## EBNF Definitions:

```
   User-Agent      = "User-Agent" ":" 1*( product | comment )
```

Where `product` is defined as:

```
   product         = token ["/" product-version]
   product-version = token
   token           = 1*<any CHAR except CTLs or separators>
```

And `comment` as:

```
   comment         = "(" *( ctext | quoted-pair | comment ) ")"
   ctext           = <any TEXT excluding "(" and ")">
```

And other rules, for reference:

```
   CTL             = <control characters, e.g. ASCII 0x00 through 0x0F and 0x7F>
   separators      = "(" | ")" | "<" | ">" | "@"
                     "," | ";" | ":" | "\" | <">
                     "/" | "[" | "]" | "?" | "="
                     "{" | "}" | SP | HT
   SP              = <ASCII space 0x20, i.e. " ">
   HT              = <ASCII horizontal tab 0x09, aka '\t'>
```



# Mozilla/4.0

[Source](https://serverfault.com/questions/158995/what-does-the-useragent-mozilla-4-0-compatible-mean)
According to several resources (such as [this entry](http://johannburkard.de/blog/www/spam/Mozilla-4-0-compatible.html)), these are requests used by proxy tools that employ pre-fetching strategies (they go and download all of the pages that are linked from the page a user is visiting in order to cache them for fast retrieval). Blue Coat, Verizon, LookSmart, and others have all been found at one time or another to use that UserAgent in their tools.

Also, according to Microsoft, some versions of Internet Explorer, for historical reasons, have used variations of the Mozilla/4.0 (compatible) UserAgent. See [here](http://msdn.microsoft.com/en-us/library/ms537503(VS.85).aspx) for more details.



## Mozilla/4.0 (compatible;)

[Source](https://johannburkard.de/blog/www/spam/Mozilla-4-0-compatible.html)

When I first published this entry in May 2007, I thought this was just another web scraper.

```
… "GET / HTTP/1.1" 200 7518 "-" "Mozilla/4.0 (compatible;)" "-"
… "GET /help/copyright.html HTTP/1.1" 200 4127 "-" "Mozilla/4.0 (compatible;)" "-"
… "GET /help/sitemap.html HTTP/1.1" 200 4902 "-" "Mozilla/4.0 (compatible;)" "-"
… "GET /favicon.ico HTTP/1.1" 200 11502 "-" "Mozilla/4.0 (compatible;)" "-"
… "GET /misc/common.css HTTP/1.1" 200 894 "-" "Mozilla/4.0 (compatible;)" "-"
```

## Blue Coat proxies

With a little header analysis, I now know that these requests are caused by [Blue Coat](https://johannburkard.de/blog/www/spam/corporate-web-abuse-the-worst-offenders-from-cyveillance-to-picscout.html)’s proxy products. These proxies seem to employ a *pre-fetching* strategy, meaning they analyze pages as they download them and follow links so that future requests can be served from the proxy cache.

Who uses their proxies? I think Hewlett-Packard do, I know Citigroup and Nokia do. In fact I think a lot of companies have their proxies installed judging from the entries in my header log file.

## Blue Coat’s stealth crawling

I could live with the fact that their software makes a ton of highly speculative requests but Blue Coat also have been stealth scanning my web site (most likely for malware) – just like Symantec.



# Understanding user-agent strings (IE/Windows)

**Note** As of Internet Explorer 11, the user-agent string has [changed significantly](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/hh869301(v=vs.85)). In addition, many legacy features are [no longer supported](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/dn467852(v=vs.85)) and should not be used. Sites that rely on the user-agent string should be updated to modern techniques, such as [feature detection](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/ff986088(v=vs.85)), [adaptive layout](https://msdn.microsoft.com/en-us/library/JJ583806), and other [modern practices](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/gg130949(v=vs.85)). For more info, see the [Internet Explorer compatibility cookbook](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/dn384059(v=vs.85)).

## Introduction

When you visit a webpage, your browser sends the user-agent string to the server hosting the site that you are visiting. This string indicates which browser you're using, its version number, and details about your system, such as operating system and version. The web server can use this information to provide content that is tailored for your specific browser.

Because certain non-Microsoft sites add details to the user-agent string, it's important to understand the user-agent string. Here we'll explain the user-agent string, list the values from recent Internet Explorer versions, and document registry keys that modify the user-agent string.



## Understanding the user-agent string

When you request a webpage, your browser sends a number of headers to the server hosting the site that you're visiting, as shown here.



```
GET / HTTP/1.1
Accept: text/html, application/xhtml+xml, */*
Accept-Language: en-US
User-Agent: Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko
Accept-Encoding: gzip, deflate
Proxy-Connection: Keep-Alive
Host: microsoft.com
```

These headers occur during a negotiation process that helps the browser and the hosting server determine the best way to provide the requested information. The user-agent header identifies the application requesting the information from the server, typically a browser. This identification string is called the *user-agent string* and contains *tokens* that provide specific details about the program making the request. Tokens vary among programs; the tokens in the Internet Explorer user-agent string describe the browser, the operating system, and the current browser mode.

Starting with IE11, the user-agent string was updated to be more consistent with other popular browsers. To learn more, see [Compatibility changes in IE11](https://msdn.microsoft.com/en-us/library/Bg182625).

This table describes the tokens in a user-agent string shown in the example.

| Token            | Description                                                  |
| :--------------- | :----------------------------------------------------------- |
| `Mozilla/5.0`    | Application name and version. For historical reasons, Internet Explorer identifies itself as a Mozilla browser. |
| `Windows NT 6.3` | The Platform token identifies the operating system and version. The example token indicates Windows 8.1. |
| `Trident/7.0`    | The Trident token identifies the version of MSHTML (Trident). |
| `rv:11.0`        | The revision token indicates the version of IE11             |
| `like Gecko`     | The Gecko token has been added to highlight improved consistency with other browsers. |

 

Note that this example applies to IE11. Earlier versions of the browser reported user-agent strings like this:



```
Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)
```

The tokens here refer to the following:

| Token            | Description                                                  |
| :--------------- | :----------------------------------------------------------- |
| `Mozilla/5.0`    | Application name and version. For historical reasons, Internet Explorer identifies itself as a Mozilla browser. |
| `compatible`     | Compatibility flag token. It indicates that Internet Explorer is compatible with a set of common features. |
| `MSIE 9.0`       | The Version token identifies the browser and contains the version number, as reported by the current [browser mode](https://msdn.microsoft.com/en-us/library/Gg589500). The example value indicates Windows Internet Explorer 9. |
| `Windows NT 6.1` | The Platform token identifies the operating system and version. The example token indicates Windows 7. |
| `Trident/5.0`    | The Trident token identifies the version of MSHTML (Trident) and can be used to determine whether or not the webpage is displayed in Compatibility View. |

 

For these examples, the user-agent is Internet Explorer. Other programs also act as user-agents and provide their own user-agent strings. For example, the [Windows RSS Platform](https://msdn.microsoft.com/en-us/library/ms684701) provides the following user-agent header when requesting RSS data.



```
Windows-RSS-Platform/2.0 (IE 11.0; Windows NT 6.1)
```

Note that the user-agent string changed as of IE11. Earlier versions of the [Windows RSS Platform](https://msdn.microsoft.com/en-us/library/ms684701) returned this string:



```
Windows-RSS-Platform/2.0 (MSIE 9.0; Windows NT 6.1)
```

Like the user-agent string for Internet Explorer, this user-agent header provides details about your system.

Alternate tokens can appear in the user-agent string for a number of reasons; usually, they identify optional features installed on your system. For example, an *SV1* token appears in the user-agent string of a Windows XP user who has installed Windows XP Service Pack 2 (SP2). It's also important to note that certain non-Microsoft parties modify the user-agent string for their own purposes.

As of Internet Explorer 9, alternate tokens are handled differently from earlier versions of the browser. To learn more, see User-agent registry keys.

**Important** The user-agent string can vary greatly from version to version of the browser. As a result, it is not a reliable mechanism for determining the browser used to display a webpage. Instead, learn to [detect features instead of browsers](https://msdn.microsoft.com/en-us/library/Hh273397).

 

**Note** To protect your privacy, periodically review your user-agent string and verify its contents.

 

For info about other headers communicated to web servers, see [RFC2616, Section 14: Header Field Definitions](https://go.microsoft.com/fwlink/p/?linkid=203727).



## Viewing the user-agent string

Applications can use the [**userAgent**](https://msdn.microsoft.com/en-us/library/ms534712) property of the [**navigator**](https://msdn.microsoft.com/en-us/library/ms535867) object to determine the user-agent string.

You can use this information to view the user-agent string. To do so, type the following into the address bar of your browser.



```
javascript:alert(navigator.userAgent)
```

This code example is case sensitive.

When you do this, a dialog box displays your user-agent string.

**Tip:** If you're using a recent version of Windows, you can copy your user-agent string to the Clipboard by pressing **Ctrl+C** before you close the dialog box.

For best results, user-agent strings should not be longer than 256 characters.



## Internet Explorer user-agent tokens

This section summarizes the tokens used by recent versions of Internet Explorer, which places three tokens in the user-agent string by default.

1. Version tokens
2. Platform tokens
3. Feature tokens
4. Trident token



### Version tokens

In general, version tokens begin with MSIE and are followed by the version number of the browser. Many pre-release versions append the letter "b" to the version number.

**Note** Starting with IE11, the user-agent string no longer includes the version token.

 

Starting with Windows Internet Explorer 8, the version token reported in the user-agent string might not reflect the actual version of the browser. If [Compatibility View](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/gg699485(v=vs.85)) is enabled for a webpage or the [browser mode](https://msdn.microsoft.com/en-us/library/Gg589500) is set to an earlier version, the version token reports the earlier version.

For example, if you're using Internet Explorer 9 to view a webpage in Compatibility View, the version token is, by default, `MSIE 7.0`.

This means that the version token represents the way Internet Explorer is presenting itself to the web server. As of Internet Explorer 8, the Trident token more accurately represents the version of the browser.

This table lists the version tokens used in recent versions of Internet Explorer.

| Version token | Description                                                  |
| :------------ | :----------------------------------------------------------- |
| MSIE 10.0     | Internet Explorer 10                                         |
| MSIE 9.0      | Internet Explorer 9                                          |
| MSIE 8.0      | Internet Explorer 8 or IE8 Compatibility View/Browser Mode   |
| MSIE 7.0      | Windows Internet Explorer 7 or IE7 Compatibility View/Browser Mode |
| MSIE 6.0      | Microsoft Internet Explorer 6                                |

 



### Platform Tokens

Platform tokens describe your operating system. The following table lists Internet Explorer platform tokens for the last several versions of Windows.

| Platform token          | Description                                 |
| :---------------------- | :------------------------------------------ |
| Windows NT 6.3          | Windows 8.1                                 |
| Windows NT 6.2          | Windows 8                                   |
| Windows NT 6.1          | Windows 7                                   |
| Windows NT 6.0          | Windows Vista                               |
| Windows NT 5.2          | Windows Server 2003; Windows XP x64 Edition |
| Windows NT 5.1          | Windows XP                                  |
| Windows NT 5.01         | Windows 2000, Service Pack 1 (SP1)          |
| Windows NT 5.0          | Windows 2000                                |
| Windows NT 4.0          | Microsoft Windows NT 4.0                    |
| Windows 98; Win 9x 4.90 | Windows Millennium Edition (Windows Me)     |
| Windows 98              | Windows 98                                  |
| Windows 95              | Windows 95                                  |
| Windows CE              | Windows CE                                  |

 



### Feature tokens

Certain optional components can also modify the user-agent string; this next table shows common ones. Be aware that many other applications also modify the user-agent string. Because of this, a comprehensive list is not possible. If you find additional tokens in your user-agent string, investigate them in more detail.

| Token       | Description                                                  |
| :---------- | :----------------------------------------------------------- |
| .NET CLR    | .NET Framework common language run time, followed by the version number. |
| SV1         | Internet Explorer 6 with enhanced security features (Windows XP SP2 and Windows Server 2003 only). |
| Tablet PC   | Tablet services are installed; number indicates the version number. |
| Win64; IA64 | System has a 64-bit processor (Intel).                       |
| Win64; x64  | System has a 64-bit processor (AMD).                         |
| WOW64       | A 32-bit version of Internet Explorer is running on a 64-bit processor. |

 



### Trident token

When the F12 developer tools are used to change the [browser mode](https://msdn.microsoft.com/en-us/library/Gg589500) of Internet Explorer, the version token of the user-agent string is modified to appear so that the browser appears to be an earlier version. This is done to allow browser specific content to be served to Internet Explorer and is usually necessary only when websites have not been updated to reflect current versions of the browser.

When this happens, a Trident token is added to the user-agent string. This token includes a version number that enables you to identify the version of the browser, regardless of the current browser mode.

| Token       | Description          |
| :---------- | :------------------- |
| Trident/7.0 | IE11                 |
| Trident/6.0 | Internet Explorer 10 |
| Trident/5.0 | Internet Explorer 9  |
| Trident/4.0 | Internet Explorer 8  |

 

In general, public websites should rely on [feature detection](https://msdn.microsoft.com/en-us/library/Hh273397), rather than browser detection, in order to design their sites for browsers that don't support the features used by the website. For more info, see [Detecting Internet Explorer More Effectively](https://msdn.microsoft.com/en-us/library/ms537509).

Sites that rely on user-agent strings to generate visitation statistics should update their algorithms to account for the Trident token; otherwise, visitation metrics might not accurately reflect the true composition of browser usage.



## User-agent registry keys

When you install certain third-party programs or Windows components, such as the Microsoft .NET Framework or Windows XP SP2, feature tokens are added to the user-agent string.

This is done by adding tokens to the following registry keys.



```
HKEY_LOCAL_MACHINE (or HKEY_CURRENT_USER)
   SOFTWARE
      Microsoft
         Windows
            CurrentVersion
               Internet Settings
                  User Agent
                     Pre Platform
                        Token = Value
                     Post Platform
                        Token = Value
```

The Pre-Platform and Post-Platform keys contain values whose names appear before and after the Platform token, respectively. For example, if a string value is added to the Post-Platform key, the name appears after the platform token in the user-agent string. Multiple tokens added to either key appear in an unpredictable order.

Earlier versions of Internet Explorer included feature tokens defined using the Pre-Platform and Post-Platform keys part of the user-agent string during the HTTP negotiation process. Over time, this lead to overly long user-agent strings, which in turn created problems for certain web servers. Problems usually appeared when user-agent strings were longer than 256 characters. As of Internet Explorer 9, the user-agent string no longer includes feature tokens during HTTP negotiation. Feature tokens are included in the value returned by the [**userAgent**](https://msdn.microsoft.com/en-us/library/ms534712) property of the [**navigator**](https://msdn.microsoft.com/en-us/library/ms535867) object. Applications that rely on the earlier behavior should be modified accordingly.

**Note** The user-agent string should not be used to indicate the presence of optional software or features. Custom version vectors, which can be detected using [conditional comments](https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/compatibility/ms537512(v=vs.85)), provide a more appropriate mechanism.

 

You can also override certain tokens of the user-agent string by adding values to the following registry key.



```
HKEY_LOCAL_MACHINE (or HKEY_CURRENT_USER)
   SOFTWARE
      Microsoft
         Windows
            CurrentVersion
               Internet Settings
                  5.0
                     User Agent
                        (default) = "Mozilla/4.0"
                        Compatible = "compatible"
                        Platform = "Windows NT 5.1"
                        Version = "MSIE 6.0"
                        Pre Platform
                           Token = Value
                        Post Platform
                           Token = Value
```

The default value of the User Agent key replaces the application name and application version tokens reported in the user-agent string. Be aware that the first seven characters are used for the application name, and the remaining characters specify the application version token.

The Compatible, Platform, and Version values replace the corresponding tokens in the user-agent string.

Additional tokens can be added to the user-agent string by using the Registry Editor to create new string values under the Pre-Platform key or Post-Platform key. The value name should be the complete token; the value data is ignored. Tokens added to the Pre-Platform key appear before the platform token in the final user-agent string. Tokens added to the Post-Platform key appear after the platform token in the final user-agent string. Multiple tokens in either the Pre-Platform key or Post-Platform key are displayed in an unpredictable order.

**Note** If the browser is open when these keys are changed, the changes don't take effect until all browser windows are closed; this includes applications hosting the [WebBrowser Control](https://msdn.microsoft.com/en-us/library/Aa752040). Be aware that applications hosting the WebBrowser Control can override the Internet Explorer user-agent string without modifying it. For more info, see [PRB: WebBrowser Control Clients Share Global Settings](https://go.microsoft.com/fwlink/p/?linkid=203618).

#  Useful Links

[Browser detection using the user agent](https://developer.mozilla.org/en-US/docs/Web/HTTP/Browser_detection_using_the_user_agent)

[WikiPedia](https://en.wikipedia.org/wiki/User_agent)

[User-Agent Parser and Free Database Site](https://user-agents.net/parser)

[User Agent Parser and Paid Database](https://explore.whatismybrowser.com/)