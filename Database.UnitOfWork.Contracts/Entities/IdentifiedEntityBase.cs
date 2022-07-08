namespace Database.UnitOfWork.Contracts.Entities
{
    public abstract class IdentifiedEntityBase<TIdentifier> : EntityBase
    {
        public TIdentifier ID { get; set; }
    }
}
