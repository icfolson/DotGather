using System;
using System.IO;
using DotGather.Json;
using Newtonsoft.Json;
using Xunit;

namespace DotGather.Test.Tests.JSONSerialization
{
    public class GatherContentAvatarConverterTest
    {
        [Fact]
        [Trait("Equal", "AvatarConverter_CanConvert_Test()")]
        public void AvatarConverter_CanConvert_Test()
        {
            //Arrange
            string jsonString;
            using (var r = new StreamReader("./TestContent/AvatarData.json"))
            {
                jsonString = r.ReadToEnd();
            }

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new GatherContentAvatarConverter());

            //Act
            var obj = JsonConvert.DeserializeObject<NonDecoratedAvatarTestObj>(jsonString, settings);

            //Assert
            Assert.Equal(obj.Avatar, new Uri("https://gathercontent-avatars-2.s3.amazonaws.com/43008_h1FwbS7PrqOpqNQ3fAyLrKojtJ4s3UXb18urw02qwWyWu352AVtm4sWaPc8QQoRK.jpeg"));
        }

        [Fact]
        [Trait("Equal", "AvatarConverter_DeserializeUri_Test()")]
        public void AvatarConverter_DeserializeUri_Test()
        {
            //Arrange
            string jsonString;
            using (var r = new StreamReader("./TestContent/AvatarData.json"))
            {
                jsonString = r.ReadToEnd();
            }

            //Act
            var obj = JsonConvert.DeserializeObject<AvatarTestObj>(jsonString);

            //Assert
            Assert.Equal(obj.Avatar, new Uri("https://gathercontent-avatars-2.s3.amazonaws.com/43008_h1FwbS7PrqOpqNQ3fAyLrKojtJ4s3UXb18urw02qwWyWu352AVtm4sWaPc8QQoRK.jpeg"));
        }

        [Fact]
        [Trait("NotImplementedException", "AvatarConverter_SerializeUri_Test()")]
        public void AvatarConverter_SerializeUri_Test()
        {
            //Arrange
            var obj = new AvatarTestObj() { Avatar = new Uri("https://gathercontent-avatars-2.s3.amazonaws.com/43008_h1FwbS7PrqOpqNQ3fAyLrKojtJ4s3UXb18urw02qwWyWu352AVtm4sWaPc8QQoRK.jpeg") };

            //Act and Assert
            Assert.Throws<NotImplementedException>(() => JsonConvert.SerializeObject(obj));
        }
    }

    public class AvatarTestObj
    {
        [JsonConverter(typeof(GatherContentAvatarConverter))]
        public Uri Avatar { get; set; }
    }

    public class NonDecoratedAvatarTestObj
    {
        public Uri Avatar { get; set; }
    }
}
