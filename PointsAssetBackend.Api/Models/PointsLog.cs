using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class PointsLog
    {
        public Guid PhId { get; set; }
        public Guid? PhClientId { get; set; }
        public string PhRequestId { get; set; }
        public string PhRequestData { get; set; }
        public DateTime? PhRequestTime { get; set; }
        public string PhResponseId { get; set; }
        public string PhResponseData { get; set; }
        public DateTime? PhResponseTime { get; set; }
        public string PhUser { get; set; }
    }
}
