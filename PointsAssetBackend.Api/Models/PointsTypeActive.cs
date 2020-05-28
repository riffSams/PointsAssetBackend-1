using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class PointsTypeActive
    {
        public Guid PtaId { get; set; }
        public Guid? PtaClient { get; set; }
        public Guid? PtId { get; set; }
        public string PtaStatus { get; set; }
        public DateTimeOffset? PtaDate { get; set; }
        public string PtaNote { get; set; }
        public short? PtaActive { get; set; }
        public string PtaStampToken { get; set; }
        public string PtaUser { get; set; }
    }
}
