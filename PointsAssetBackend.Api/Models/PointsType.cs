using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class PointsType
    {
        public Guid PtId { get; set; }
        public Guid? PtClient { get; set; }
        public Guid? PtOrganization { get; set; }
        public string PtCode { get; set; }
        public string PtName { get; set; }
        public short? PtStatus { get; set; }
        public DateTimeOffset? PtDate { get; set; }
        public string PtStampToken { get; set; }
        public string PtUser { get; set; }
    }
}
