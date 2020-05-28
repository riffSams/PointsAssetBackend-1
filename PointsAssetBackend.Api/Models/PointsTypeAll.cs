using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAssetBackend.Api.Models
{
    public class PointsTypeAll 
    {
        public Guid PtId { get; set; }
        public PointsType PointsType { get; set; }
        public List <PointsTypeAttr> PtAttr{ get; set; }
    }


}
