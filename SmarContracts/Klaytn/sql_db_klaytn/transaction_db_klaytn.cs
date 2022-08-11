using Microsoft.EntityFrameworkCore;

public class Transaction_DB_klaytn : DbContext
{
    public DbSet<one_Transaction_Logs> one_transaction_data { get; set; } = null!;
    public DbSet<two_Transaction_Logs> two_transaction_data { get; set; } = null!;
    public DbSet<three_Transaction_Logs> three_transaction_data { get; set; } = null!;
    public DbSet<four_Transaction_Logs> four_transaction_data { get; set; } = null!;
    public DbSet<five_Transaction_Logs> five_transaction_data { get; set; } = null!;
    public DbSet<six_Transaction_Logs> six_transaction_data { get; set; } = null!;
    public DbSet<seven_Transaction_Logs> seven_transaction_data { get; set; } = null!;
    public DbSet<eight_Transaction_Logs> eight_transaction_data { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(connectionString, _serverVersion);
    }
    public string connectionString { get; protected set;} ="server=localhost;user=root;password=Dstamp~!23;database=Transaction_DB_Klaytn;";
    private MySqlServerVersion _serverVersion = new MySqlServerVersion(new System.Version(8, 0, 29));
}