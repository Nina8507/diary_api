namespace diary_api.Models;

public class User 
{
  public required string UserName { get; set; }
  public required string Role { get; set; }
  public required string Password { get; set; }
}