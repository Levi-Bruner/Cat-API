using System.Collections.Generic;
using catApi.Models;

namespace catApi.DB
{
  static class FakeDB
  {
    public static List<Cat> cats = new List<Cat>()
    {
      new Cat("Harry", "Tabby", 3),
      new Cat("Diamond", "Siamese", 2),
      new Cat("Marge", "Persian", 5)
    };
  }
}