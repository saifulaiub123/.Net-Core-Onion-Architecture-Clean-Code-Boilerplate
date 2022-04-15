using System.ComponentModel.DataAnnotations.Schema;
using RentGo.Domain.IEntity;
using RentGo.Application.Constant;

namespace RentGo.Domain.Model
{
    public class BaseModel<TId> : IBaseEntity<TId>, IAuditable
    {
        public TId Id { get; set; }
        [Column(TypeName = DbDataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = DbDataType.DateTime)]
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
