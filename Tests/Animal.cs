using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("YourTestAssemblyName")]

namespace Tests
{
  public enum Animal
  {
    Cat,
    Dog,
    Cow
  }
}