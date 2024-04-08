namespace diary_api.Models;

public class Person {
  public int Id { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
}