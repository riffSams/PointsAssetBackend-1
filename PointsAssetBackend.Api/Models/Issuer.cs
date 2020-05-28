using System;
using System.Collections.Generic;

namespace PointsAssetBackend.Api.Models
{
    public partial class Issuer
    {
        public Issuer() { }
        //{
        //    IssuerActive = new HashSet<IssuerActive>();
        //    IssuerAttr = new HashSet<IssuerAttr>();
        //}

        public Guid IsId { get; set; }
        public Guid? IsClientId { get; set; }
        public Guid? IsOrganization { get; set; }
        public string IsName { get; set; }
        public short? IsActive { get; set; }
        public string IsStampToken { get; set; }
        public string IsUser { get; set; }

        //public virtual ICollection<IssuerActive> IssuerActive { get; set; }
        //public virtual ICollection<IssuerAttr> IssuerAttr { get; set; }
    }
}
