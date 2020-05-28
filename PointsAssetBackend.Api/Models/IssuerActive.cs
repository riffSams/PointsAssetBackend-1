using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class IssuerActive
    {
        public Guid IsaId { get; set; }
        public Guid? IsaClient { get; set; }
        public Guid? IsId { get; set; }
        public string IsaStatus { get; set; }
        public DateTimeOffset? IsaDate { get; set; }
        public string IsaNote { get; set; }
        public short? IsaActive { get; set; }
        public string IsaStampToken { get; set; }
        public string IsaUser { get; set; }

        public virtual Issuer Is { get; set; }
    }
}
