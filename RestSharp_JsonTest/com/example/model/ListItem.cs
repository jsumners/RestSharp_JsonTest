using System;
using System.Runtime.Serialization;

namespace com.example.model
{
  [DataContract]
  public class ListItem
  {
    [DataMember(Name = "foo1")]
    public Foo foo1 { get; set; }
    [DataMember(Name = "foo2")]
    public Foo foo2 { get; set; }

    public ListItem () {}
  }
}

