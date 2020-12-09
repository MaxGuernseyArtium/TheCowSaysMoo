using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Tests
{
  [Binding]
  public class AnimalBindings
  {
    RenderingType Rendering;
    Animal Animal;
    string Output;

    [Given("rendering to (.*)")]
    public void GivenRenderingTo(string Type)
    {
      Rendering = ParseEnum<RenderingType>(Type);
    }

    [Given("the animal is a (.*)")]
    public void GivenTheAnimalIsA(string Name)
    {
      Animal = ParseEnum<Animal>(Name);
    }
    
    [When(@"the animal speaks")]
    public void WhenTheAnimalSpeaks()
    {
      Speak();
    }

    [Then(@"the output is:")]
    public void ThenTheOutputIs(string Text)
    {
      Assert.AreEqual(Text, Output);
    }

    private void Speak()
    {
      var WhatItSays = Animal switch
      {
        Animal.Cat => "meow",
        Animal.Dog => "woof",
        Animal.Cow => "moo"
      };

      switch (Rendering)
      {
        case RenderingType.Text:
          Output = $"The {Animal.ToString().ToLowerInvariant()} says '{WhatItSays}'.";
          break;
        case RenderingType.Json:
          Output = $@"{{
  ""animal"":""{Animal}"",
  ""says"":""{WhatItSays}""
}}";
          break;
      }
    }

    private static T ParseEnum<T>(string AsString) where T : Enum 
      => (T) Enum.Parse(typeof(T), AsString, true);
  }
}