using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace com.example.model
{
  [DataContract]
  public class ObjectList : SortedDictionary<String, ListItem>
  {
    public ObjectList () {}
  }
}

