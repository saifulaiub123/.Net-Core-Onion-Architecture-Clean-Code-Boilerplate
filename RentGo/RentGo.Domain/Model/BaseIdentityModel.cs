using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentGo.Application.Constant;
using RentGo.Domain.IEntity;

namespace RentGo.Domain.Model
{
    public class BaseIdentityModel<TId> : IBaseEntity<TId>
    {
        public TId Id { get; set; }
        [Column(TypeName = DbDataType.DateTime)]
        public DateTime DateCreated { get; set; }
    }
}
