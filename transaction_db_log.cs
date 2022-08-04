using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction_Logs
{
    [Key]
    public long id { get; set; }

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


[Table("Apple_Transaction_Logs")]
public class Apple_Transaction_Logs : Transaction_Logs
{

}

[Table("Ham_Transaction_Logs")]
public class Ham_Transaction_Logs : Transaction_Logs
{

}

[Table("Matic_Transaction_Logs")]
public class Matic_Transaction_Logs : Transaction_Logs
{

}

[Table("ETH_Transaction_Logs")]
public class ETH_Transaction_Logs : Transaction_Logs
{

}

[Table("HARD_Transaction_Logs")]
public class HARD_Transaction_Logs : Transaction_Logs
{

}

[Table("RAM_Transaction_Logs")]
public class RAM_Transaction_Logs : Transaction_Logs
{

}

[Table("SOFT_Transaction_Logs")]
public class SOFT_Transaction_Logs : Transaction_Logs
{

}

[Table("SSD_Transaction_Logs")]
public class SSD_Transaction_Logs : Transaction_Logs
{

}

[Table("one_Transaction_Logs")]
public class one_Transaction_Logs : Transaction_Logs
{

}

[Table("two_Transaction_Logs")]
public class two_Transaction_Logs : Transaction_Logs
{

}

[Table("three_Transaction_Logs")]
public class three_Transaction_Logs : Transaction_Logs
{

}


[Table("four_Transaction_Logs")]
public class four_Transaction_Logs : Transaction_Logs
{

}

[Table("five_Transaction_Logs")]
public class five_Transaction_Logs : Transaction_Logs
{

}

[Table("six_Transaction_Logs")]
public class six_Transaction_Logs : Transaction_Logs
{

}

[Table("seven_Transaction_Logs")]
public class seven_Transaction_Logs : Transaction_Logs
{

}

[Table("eight_Transaction_Logs")]
public class eight_Transaction_Logs : Transaction_Logs
{

}

