namespace DirectDbAccess.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
    }
}
