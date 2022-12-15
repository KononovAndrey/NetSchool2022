namespace DSRNetSchool.Context;

public class DbSettings
{
    public DbType Type { get; private set; }
    public string ConnectionString { get; private set; }
}
