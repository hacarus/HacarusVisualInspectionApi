using System;
namespace HacarusVisualInspectionApi.Models
{
    public class AccessTokenData
    {
        public string access_token { get; set; }
        public int expires { get; set; }
    }

    public class AccessTokenResponse: Response
    {
        public AccessTokenData data { get; set; }
    }
}
