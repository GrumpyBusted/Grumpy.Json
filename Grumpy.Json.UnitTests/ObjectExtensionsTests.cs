using System;
using System.Runtime.CompilerServices;
using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;
using Grumpy.Json.UnitTests.Helper;
using Newtonsoft.Json;
using Xunit;

namespace Grumpy.Json.UnitTests
{
    [UseReporter(typeof(DiffReporter))]
    public class ObjectExtensionsTests
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        [Fact]
        public void PersonShouldSerializeToJson()
        {
            var obj = new TestPerson
            {
                Name = "MyName",
                Age = 200
            };

            var result = obj.SerializeToJson();

            Approvals.Verify(result);
        }

        [Fact]
        public void NullShouldTrySerializeToJson()
        {
            var result = ((object) null).TrySerializeToJson();

            result.Should().Be("null");
        }

        [Fact]
        public void PersonShouldSerializeUnformattedToJson()
        {
            var obj = new TestPerson
            {
                Name = "MyName",
                Age = 200
            };

            var result = obj.SerializeToJson(false);

            result.Should().Be("{\"Name\":\"MyName\",\"Age\":200}");
        }

        [Fact]
        public void ObjectShouldSerializeWithDateSettingsToJson()
        {
            var obj = new
            {
                Name = "MyName",
                Date = DateTimeOffset.Parse("2017-12-03")
            };

            var result = obj.SerializeToJson(new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd" } );

            result.Should().Contain("\"Date\": \"2017-12-03\"");
        }
    }
}
