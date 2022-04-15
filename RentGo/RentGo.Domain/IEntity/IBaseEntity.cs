using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentGo.Domain.IEntity
{
    internal interface IBaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
