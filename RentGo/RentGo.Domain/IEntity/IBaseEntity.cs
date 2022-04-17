namespace RentGo.Domain.IEntity
{
    internal interface IBaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
