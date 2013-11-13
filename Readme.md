This repository shows an example of [RestSharp](http://restsharp.org)'s JSON serialization and deserialization failing. It also shows that ReshSharp is unable to deserialize the expected JSON into the correct object while [JSON.NET](http://json.codeplex.com) does so successfully.

The output of this test program is as follows:

```
Constructing example data ...
Serializing data ...
Expected JSON: `{ "item1":{"foo1":{"bar":"foobar","answer":"42"},"foo2":{"bar":"barfoo","answer":"none"}},"item2":{"foo1":{"bar":"foobar","answer":"42"},"foo2":{"bar":"barfoo","answer":"none"}} }`
RestSharp JSON: `[{"Key":"item1","Value":{"foo1":{"bar":"foobar","answer":"42"},"foo2":{"bar":"barfoo","answer":"none"}}},{"Key":"item2","Value":{"foo1":{"bar":"foobar","answer":"42"},"foo2":{"bar":"barfoo","answer":"none"}}}]`
Deserializing data ...
Attempting to deserialize RestSharp JSON ...
Deserialization failed:
Cannot cast from source type to destination type.
  at RestSharp.Deserializers.JsonDeserializer.FindRoot (System.String content) [0x00000] in <filename unknown>:0 
  at RestSharp.Deserializers.JsonDeserializer.Deserialize[ObjectList] (IRestResponse response) [0x00000] in <filename unknown>:0 
  at com.example.RestSharpExample.Main (System.String[] args) [0x000f7] in /Volumes/Spinner/Users/jsumners/Programming Projects/DotNet/RestSharp_JsonTest/RestSharp_JsonTest/com/example/RestSharpExample.cs:49 
Attempting to deserialize expected JSON with RestSharp ...
Deserialization failed:
Array index is out of range.
  at RestSharp.Deserializers.JsonDeserializer.BuildDictionary (System.Type type, System.Object parent) [0x00000] in <filename unknown>:0 
  at RestSharp.Deserializers.JsonDeserializer.Deserialize[ObjectList] (IRestResponse response) [0x00000] in <filename unknown>:0 
  at com.example.RestSharpExample.Main (System.String[] args) [0x0015f] in /Volumes/Spinner/Users/jsumners/Programming Projects/DotNet/RestSharp_JsonTest/RestSharp_JsonTest/com/example/RestSharpExample.cs:62 
Attempting to deserialize RestSharp JSON with JSON.NET ...
Deserialization failed:
Cannot deserialize the current JSON array (e.g. [1,2,3]) into type 'com.example.model.ObjectList' because the type requires a JSON object (e.g. {"name":"value"}) to deserialize correctly.
To fix this error either change the JSON to a JSON object (e.g. {"name":"value"}) or change the deserialized type to an array or a type that implements a collection interface (e.g. ICollection, IList) like List<T> that can be deserialized from a JSON array. JsonArrayAttribute can also be added to the type to force it to deserialize from a JSON array.
Path '', line 1, position 1.
  at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.EnsureArrayContract (Newtonsoft.Json.JsonReader reader, System.Type objectType, Newtonsoft.Json.Serialization.JsonContract contract) [0x00000] in <filename unknown>:0 
  at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateList (Newtonsoft.Json.JsonReader reader, System.Type objectType, Newtonsoft.Json.Serialization.JsonContract contract, Newtonsoft.Json.Serialization.JsonProperty member, System.Object existingValue, System.String id) [0x00000] in <filename unknown>:0 
  at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateValueInternal (Newtonsoft.Json.JsonReader reader, System.Type objectType, Newtonsoft.Json.Serialization.JsonContract contract, Newtonsoft.Json.Serialization.JsonProperty member, Newtonsoft.Json.Serialization.JsonContainerContract containerContract, Newtonsoft.Json.Serialization.JsonProperty containerMember, System.Object existingValue) [0x00000] in <filename unknown>:0 
  at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.Deserialize (Newtonsoft.Json.JsonReader reader, System.Type objectType, Boolean checkAdditionalContent) [0x00000] in <filename unknown>:0 
Attempting to deserialize expected JSON with JSON.NET ...
Success ...
```