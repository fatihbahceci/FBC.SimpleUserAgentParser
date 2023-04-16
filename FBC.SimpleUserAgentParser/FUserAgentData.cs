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


        public FUserAgentData()
        {
            clearData();
        }
        public FUserAgentData(string userAgentString)
        {
            RawData = userAgentString;
        }

        private void clearData(bool keepRawData = false)
        {

            if (!keepRawData) rawData = null;
            SystemName = ESystem.Unknown;
            SystemNameString = string.Empty;
            SystemVersion = string.Empty;
            SystemInformation = new List<string>();
            Platforms = new List<FAgentPlatform>();
            CommentData = string.Empty;
        }
        public override string ToString()
        {
            return this.ToJson();
        }

        public IEnumerable<string> CheckErrors()
        {
            if (this.SystemName == ESystem.Unknown)
                yield return $"{nameof(this.SystemName)} is Unknown";

            foreach (var platform in this.Platforms.Where(x => x.Product == EProductChildItem.Unknown))
            {
                yield return "There is unhandled plaform: " + platform;
            }
            if (!string.IsNullOrEmpty(this.CommentData) && this.CommentData.Contains('/'))
            {
                var urlsCleaned = Regex.Replace(this.CommentData, C.CONTAINS_HTTP_OR_HTTPS_URL_PATTERN, string.Empty);
                if (urlsCleaned.Contains("/"))
                {
                    yield return $"{nameof(CommentData)} contains unhandled string";
                }
            }
        }
    }


}
