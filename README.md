[![Build status](https://ci.appveyor.com/api/projects/status/1gboagwsvdkxuiy9?svg=true)](https://ci.appveyor.com/project/GrumpyBusted/grumpy-json)
[![codecov](https://codecov.io/gh/GrumpyBusted/Grumpy.Json/branch/master/graph/badge.svg)](https://codecov.io/gh/GrumpyBusted/Grumpy.Json)
[![nuget](https://img.shields.io/nuget/v/Grumpy.Json.svg)](https://www.nuget.org/packages/Grumpy.Json/)
[![downloads](https://img.shields.io/nuget/dt/Grumpy.Json.svg)](https://www.nuget.org/packages/Grumpy.Json/)

# Grumpy.Json
Extending the magnificent Newtonsoft.Json, with a few extension methods I always end up needing.

```csharp
public class TestPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
}

const string str = "{\"Name\": \"MyName\", \"Age\": 200}";

var person = str.DeserializeFromJson<TestPerson>();

person.Name.Should().Be("MyName");
person.Age.Should().Be(200);

var obj = new TestPerson
{
    Name = "MyName",
    Age = 200
};

var result = obj.SerializeToJson();
```