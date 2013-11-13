using System;

using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

using com.example.model;

namespace com.example
{
  public class RestSharpExample
  {
    static void Main(string[] args)
    {
      Console.WriteLine ("Constructing example data ...");
      Foo foo1 = new Foo ();
      foo1.bar = "foobar";
      foo1.answer = "42";

      Foo foo2 = new Foo ();
      foo2.bar = "barfoo";
      foo2.answer = "none";

      ListItem listItem = new ListItem ();
      listItem.foo1 = foo1;
      listItem.foo2 = foo2;

      ObjectList objectList = new ObjectList ();
      objectList.Add ("item1", listItem);
      objectList.Add ("item2", listItem);

      String realJson = "{ \"item1\":{\"foo1\":{\"bar\":\"foobar\",\"answer\":\"42\"},\"foo2\":{\"bar\":\"barfoo\",\"answer\":\"none\"}},";
      realJson = realJson + "\"item2\":{\"foo1\":{\"bar\":\"foobar\",\"answer\":\"42\"},\"foo2\":{\"bar\":\"barfoo\",\"answer\":\"none\"}} }";

      Console.WriteLine ("Serializing data ...");
      Console.WriteLine (String.Format("Expected JSON: `{0}`", realJson));

      JsonSerializer serializer = new JsonSerializer ();
      String json1 = serializer.Serialize (objectList);
      Console.WriteLine (String.Format ("RestSharp JSON: `{0}`", json1));

      Console.WriteLine ("Deserializing data ...");

      // Does not work.
      try {
        Console.WriteLine("Attempting to deserialize RestSharp JSON ...");
        JsonDeserializer deserializer = new JsonDeserializer();
        RestResponse response = new RestResponse();
        response.Content = json1;
        var decoded = deserializer.Deserialize<ObjectList>(response);
        Console.WriteLine("Success ...");
      } catch (Exception ex) {
        Console.WriteLine ("Deserialization failed:");
        Console.WriteLine (ex.Message);
        Console.WriteLine (ex.StackTrace);
      }

      // Does not work.
      try {
        Console.WriteLine("Attempting to deserialize expected JSON with RestSharp ...");
        JsonDeserializer deserializer = new JsonDeserializer();
        RestResponse response = new RestResponse();
        response.Content = realJson;
        var decoded = deserializer.Deserialize<ObjectList>(response);
        Console.WriteLine("Success ...");
      } catch (Exception ex) {
        Console.WriteLine ("Deserialization failed:");
        Console.WriteLine (ex.Message);
        Console.WriteLine (ex.StackTrace);
      }

      // Does not work.
      try {
        Console.WriteLine("Attempting to deserialize RestSharp JSON with JSON.NET ...");
        ObjectList list = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectList>(json1);
        Console.WriteLine("Success ...");
      } catch (Exception ex) {
        Console.WriteLine ("Deserialization failed:");
        Console.WriteLine (ex.Message);
        Console.WriteLine (ex.StackTrace);
      }

      // Works.
      try {
        Console.WriteLine("Attempting to deserialize expected JSON with JSON.NET ...");
        ObjectList list = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectList>(realJson);
        Console.WriteLine("Success ...");
      } catch (Exception ex) {
        Console.WriteLine ("Deserialization failed:");
        Console.WriteLine (ex.Message);
        Console.WriteLine (ex.StackTrace);
      }
    }
  }
}

