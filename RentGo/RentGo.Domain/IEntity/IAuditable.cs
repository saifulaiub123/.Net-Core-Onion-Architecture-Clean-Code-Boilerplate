using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentGo.Domain.IEntity
{
    public interface IAuditable
    {
        public int CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
