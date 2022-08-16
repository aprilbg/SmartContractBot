using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction_Logs
{
    [Key]
    public long id { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? CallHashFrom { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? transactionHash { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? address { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? blockHash { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? blockNumber { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? data { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? logIndex { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string? transactionIndex { get; set; }
}