using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class PointsAsset
    {
        public Guid PaId { get; set; }
        public Guid? PaClientId { get; set; }
        public Guid? PaOwner { get; set; }
        public Guid? PaPointsType { get; set; }
        public short? PaStatus { get; set; }
        public decimal? PaValue { get; set; }
        public decimal? PaValueFloat { get; set; }
        public decimal? PaValueHold { get; set; }
        public DateTimeOffset? PaExpired { get; set; }
        public decimal? PaPointsValue { get; set; }
        public string PaCurrency { get; set; }
        public Guid? PaTrx { get; set; }
        public string PaSerialNo { get; set; }
        public string PaStampToken { get; set; }
        public string PaUser { get; set; }
    }
}
