using LinqToDB.Mapping;

namespace LinqToSqlDbAccess.Data
{
    public abstract class BaseEntity
    {
        [PrimaryKey, Column, Identity]
        public int Id { get; set; }

        [Column]
        public Guid Uid { get; set; } = Guid.NewGuid();
    }
}
