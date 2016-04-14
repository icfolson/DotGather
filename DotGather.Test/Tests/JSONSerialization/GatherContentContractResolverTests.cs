using DotGather.GatherContent.Objects;
using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace DotGather.Test.Tests.JSONSerialization
{
    public class GatherContentContractResolverTests
    {
        [Fact]
        public void TestPropertyNameConversion()
        {
            //Arrange
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ContractResolver = new GatherContentContractResolver() };

            string jsonString;
            using (var r = new StreamReader("./TestContent/SectionData.json"))
            {
                jsonString = r.ReadToEnd();
            }

            //Act
            var section = JsonConvert.DeserializeObject<Field>(jsonString);

            //Assert
        }
    }
}
