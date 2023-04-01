
namespace FBC.SimpleUserAgentParser {
    public class FBCUACompiledData {
        public EUAPlatform Platform { get; set; }
        public string PlatformString { get; set; } = string.Empty;
        public string PlatformVersion { get; set; } = string.Empty;
        private string[]? platformDetails;
        public string[] PlatformDetails { get => platformDetails ?? (platformDetails = new string[0]); set => platformDetails = value ?? new string[0]; }

        public override string ToString() {
            return this.ToJson();
        }
    }
}