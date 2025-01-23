namespace diary_api.Models;

public class Person {
  public virtual int Id { get; set; }
  public virtual required string FirstName { get; set; }
  public virtual required string LastName { get; set; }
}