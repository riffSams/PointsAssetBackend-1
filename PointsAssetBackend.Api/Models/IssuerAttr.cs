using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class IssuerAttr
    {
        public Guid IstId { get; set; }
        public Guid? IstClient { get; set; }
        public Guid? IsId { get; set; }
        public string IstCode { get; set; }
        public string IstName { get; set; }
        public string IstValueString { get; set; }
        public decimal? IstValueNumeric { get; set; }
        public short? IstActive { get; set; }
        public Guid? IstLock { get; set; }
        public string IstStampToken { get; set; }
        public string IstUser { get; set; }

        public virtual Issuer Is { get; set; }

    }
}
