using diary_api.Models;
namespace diary_api.Services;

public static class PersonService{
  static List<Person> Persons { get; }
  static int nextId = 3;
  static PersonService(){
    Persons = [
      new() {Id = 1, FirstName = "Anna", LastName = "Smith"},
      new() {Id = 3, FirstName = "John", LastName = "Smith"}
    ];
  }

  public static List<Person> GetAll() => Persons;

  public static Person? Get(int id) => Persons.FirstOrDefault(p => p.Id == id);

  public static void Add(Person person){
      person.Id = nextId++;
      Persons.Add(person);
    }

  public static void Delete(int id){
    var person = Get(id);
    if (person is null)
      return;

    Persons.Remove(person);
  }

  public static void Update(Person person){
    var index = Persons.FindIndex(p => p.Id == person.Id);
    if (index == -1)
      return;

    Persons[index] = person;
  }

}