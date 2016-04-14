using System;
using DotGather.GatherContent.Objects;
using DotGather.Json;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace DotGather.Test.Tests.JSONSerialization
{
    public class GatherContentWrapperConverterTest
    {
        [Fact]
        [Trait("NotNull / Null", "GCWrapperConverter_CanConvert_Test()")]
        public void GCWrapperConverter_CanConvert_Test()
        {
            //Arrange
            string jsonString;
            using (var r = new StreamReader("./TestContent/objectWithDataWrapper.json"))
            {
                jsonString = r.ReadToEnd();
            }

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new GatherContentWrapperConverter<NonDecoratedGCConverterTestObj>());

            //Act
            var obj = JsonConvert.DeserializeObject<NonDecoratedGCConverterTestObj>(jsonString, settings);

            //Assert
            Assert.NotNull(obj);
            Assert.Null(obj.Email);
        }

        [Theory]
        [InlineData("./TestContent/objectWithDataWrapper.json")]
        [InlineData("./TestContent/objectWithNoDataWrapper.json")]
        [Trait("Equal", "GCWrapperConverter_DeserializeJson_Test(string jsonPath)")]
        public void GCWrapperConverter_DeserializeJson_Test(string jsonPath)
        {
            //Arrange
            string jsonString;
            using (var r = new StreamReader(jsonPath))
            {
                jsonString = r.ReadToEnd();
            }

            //Act
            var obj = JsonConvert.DeserializeObject<GCConverterTestObj>(jsonString);

            //Assert
            Assert.Equal(obj.Email, "test@test.com");
        }

        [Fact]
        [Trait("Equal", "GCWrapperConverter_SerializeJson_Test()")]
        public void GCWrapperConverter_SerializeJson_Test()
        {
            //Arrange
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ContractResolver = new GatherContentContractResolver() };
            string jsonString;
            using (var r = new StreamReader("./TestContent/objectWithNoDataWrapper.json"))
            {
                jsonString = r.ReadToEnd();
            }

            var obj = new GCConverterTestObj() { Email= "test@test.com"};

            //Act
            var serializedJson = JsonConvert.SerializeObject(obj);

            //Assert
            Assert.Equal(Regex.Replace(serializedJson, @"\s+", string.Empty), Regex.Replace(jsonString, @"\s+", string.Empty));
        }
    }

    [JsonConverter(typeof(GatherContentWrapperConverter<GCConverterTestObj>))]
    public class GCConverterTestObj
    {
        public string Email { get; set; }
    }

    public class NonDecoratedGCConverterTestObj
    {
        public string Email { get; set; }
    }
}
