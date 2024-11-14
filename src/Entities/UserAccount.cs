using SQLite;

namespace MauiHybridAuthentication.Entities;

[Table("user_account")]
public class UserAccount
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [MaxLength(50)]
    public string? FirstName { get;set; }

    [Column("last_name")]
    [MaxLength(50)]
    public string? LastName { get;set; }

    [Column("user_name")]
    [MaxLength(50)]
    [Indexed(Name = "idx_user_name", Unique = true)]
    public string? UserName { get;set; }

    [Column("password")]
    [MaxLength(50)]
    public string? Password { get;set; }

    [Column("role")]
    [MaxLength(20)]
    public string? Role { get; set; }
}
