
using System.Numerics;

namespace FBC.SimpleUserAgentParser
{
    public partial class FUACompiledData
    {
        public EPlatform Platform { get; set; }

        public string PlatformString { get; set; } = string.Empty;
        public string? PlatformVersion { get; set; }
        public EBrowser Browser { get; set; } = EBrowser.Unknown;
        public string? BrowserVersion { get; set; }

        private string[]? platformDetails;
        public string[] PlatformDetails { get => platformDetails ?? (platformDetails = new string[0]); set => platformDetails = value ?? new string[0]; }


        public FUACompiledData(FUserAgentData userAgentData)
        {
            CompileData(userAgentData);
        }
        public override string ToString()
        {
            return this.ToJson();
        }

        private static EPlatform[] ApplePlatforms = new EPlatform[]
        {
            EPlatform.iPad, EPlatform.iPhone, EPlatform.Macintosh, EPlatform.Apple
        };

        public IEnumerable<string> CheckErrors()
        {
            if (this.Browser == EBrowser.Unknown)
                yield return $"{nameof(this.Browser)} is Unknown";

            if (this.Platform  == EPlatform.Unknown)
            {
                yield return $"{nameof(this.Platform)} is Unknown";

            } else if (this.PlatformString == "Unknown" || string.IsNullOrEmpty(this.PlatformString))
            {
                yield return $"{nameof(this.PlatformString)} is invalid";

            }

            if (!ApplePlatforms.Contains(this.Platform) && (this.Browser == EBrowser.AppleWebKit))
            {
                yield return "This device is not an Apple device but the browser is AppleWebKit. How is it possible?!";
            }
        }
    }
}