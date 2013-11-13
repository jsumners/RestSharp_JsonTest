using System;
using System.Runtime.Serialization;

namespace com.example.model
{
  [DataContract]
  public class Foo
  {
    [DataMember(Name = "bar")]
    public String bar { get; set; }
    [DataMember(Name = "answer")]
    public String answer { get; set; }

    public Foo () {}
  }
}

