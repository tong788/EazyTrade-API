namespace EazyTrade.ConfigurationModels
{
    public class AwsS3Configuration
    {
        public const string Section = "AwsS3Settings";
        public string BucketName { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}