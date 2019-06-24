using System;
namespace HacarusVisualInspectionApi.Models
{
    public class LicenseData
    {
        public string customer_id { get; set; }
        public string status { get; set; }
    }

    public class LicenseResponse : Response
    {
        public LicenseData data { get; set; }
    }
}
