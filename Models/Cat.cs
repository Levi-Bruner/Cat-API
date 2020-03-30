using System;
using System.ComponentModel.DataAnnotations;

namespace catApi.Models
{
  public class Cat
  {
    [Required]
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }

    public Cat()
    {
      Id = Guid.NewGuid().ToString();
    }
    public Cat(string name, string breed, int age)
    {
      Name = name;
      Breed = breed;
      Id = Guid.NewGuid().ToString();
    }
  }
}