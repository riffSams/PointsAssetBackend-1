using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class PointsTypeAttr
    {
        public Guid PttId { get; set; }
        public Guid? PttClient { get; set; }
        public Guid? PtId { get; set; }
        public string PttCode { get; set; }
        public string PttName { get; set; }
        public string PttValueString { get; set; }
        public decimal? PttValueNumeric { get; set; }
        public short? PttActive { get; set; }
        public Guid? PttLock { get; set; }
        public string PttStampToken { get; set; }
        public string PttUser { get; set; }
    }
}
