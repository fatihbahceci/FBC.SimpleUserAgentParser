using System.Text;

namespace FBC.SimpleUserAgentParser {
    public struct FAgentPlatform {
        public EFBCUAProductChildItem Product { get; set; }
        public string ProductAsStr { get; set; }
        public string ProductVersion { get; set; }

        public string Comment { get; set; }

        private List<string> details;
        public List<string> Details { get => details ?? (details = new List<string>()); set => details = value ?? new List<string>(); }
        public override string ToString() {
            return this.ToJson();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Child");
            //sb.AppendLine($"    {nameof(Product)}: {Product + (Product == EFBCUAProductChildItem.Unknown ? $" ({ProductAsStr})" : "")}");
            //sb.AppendLine($"    {nameof(ProductVersion)}: {ProductVersion}");
            //sb.AppendLine($"    {nameof(Comment)}: {Comment}");

            //sb.AppendLine($"    {nameof(Details)}: [" + string.Join(",", Details) + "]");

            //if (!string.IsNullOrEmpty(ErrorMessage)) {
            //    sb.AppendLine($"    {nameof(ErrorMessage)}: {ErrorMessage}");
            //}
            //return sb.ToString().Trim(' ', '\r', '\n');
        }
    }

}
