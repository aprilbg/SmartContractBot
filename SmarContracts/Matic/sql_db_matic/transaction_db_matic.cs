using Microsoft.EntityFrameworkCore;

public class Transaction_DB_matic : DbContext
{
    public DbSet<Matic_Transaction_Logs> matic_transaction_data { get; set; } = null!;
    public DbSet<Apple_Transaction_Logs> apple_transaction_data { get; set; } = null!;
    public DbSet<Ham_Transaction_Logs> ham_transaction_data { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(connectionString, _serverVersion);
    }
    
    public string connectionString { get; protected set;} ="server=10.120.10.109;user=root;password=Dstamp~!23;pooling=True;min pool size=50;database=Transaction_DB_Matic;";
    private MySqlServerVersion _serverVersion = new MySqlServerVersion(new System.Version(8, 0, 29));
}