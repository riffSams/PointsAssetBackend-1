using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAssetBackend.Api.Models
{
    public class IssuerAll
    {
        public Guid IsId { get; set; }
        public Issuer Issuer { get; set; }
        //public virtual ICollection<IssuerAttr> IssuerAttr { get; set; }
        public List<IssuerAttr> IssuerAttrs { get; set; }
    }
}
