using Microsoft.EntityFrameworkCore;

public class Transaction_DB_eth : DbContext
{
    public DbSet<ETH_Transaction_Logs> ETH_transaction_data { get; set; } = null!;
    public DbSet<SSD_Transaction_Logs> SSD_transaction_data { get; set; } = null!;
    public DbSet<RAM_Transaction_Logs> RAM_transaction_data { get; set; } = null!;
    public DbSet<HARD_Transaction_Logs> HARD_transaction_data { get; set; } = null!;
    public DbSet<SOFT_Transaction_Logs> SOFT_transaction_data { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(connectionString, _serverVersion);
    }
    public string connectionString { get; protected set;} ="server=localhost;user=root;password=Dstamp~!23;database=Transaction_DB_Ethereum;";
    private MySqlServerVersion _serverVersion = new MySqlServerVersion(new System.Version(8, 0, 29));
}