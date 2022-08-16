using Microsoft.EntityFrameworkCore;

public class Transaction_DB_klaytn : DbContext
{
    public DbSet<Transaction_Logs> transaction_data { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(connectionString, _serverVersion);
    }
    public string connectionString { get; protected set;} ="server=localhost;user=root;password=Dstamp~!23;database=Transaction_DB_Klaytn;";
    private MySqlServerVersion _serverVersion = new MySqlServerVersion(new System.Version(8, 0, 29));
}