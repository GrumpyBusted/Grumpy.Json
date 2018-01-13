using FluentAssertions;
using Grumpy.Json.UnitTests.Helper;
using Newtonsoft.Json;
using Xunit;

namespace Grumpy.Json.UnitTests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void PersonShouldDeserializeFromJson()
        {
            const string str = "{\"Name\": \"MyName\",\"Age\": 200}";

            var person = str.DeserializeFromJson<TestPerson>();

            person.Name.Should().Be("MyName");
            person.Age.Should().Be(200);
        }

        [Fact]
        public void PersonShouldDeserializeWithSettingsFromJson()
        {
            const string str = "{\"Name\": \"MyName\",\"Age\": 200}";

            var person = str.DeserializeFromJson<TestPerson>(new JsonSerializerSettings());

            person.Name.Should().Be("MyName");
            person.Age.Should().Be(200);
        }
    }
}