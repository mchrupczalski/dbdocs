using dbdocs.lib.Models;
using Moq;
using System.IO;
using Xunit;
using dbdocs.lib.Interfaces;
using dbdocs.lib.Providers;
using System.Collections.Generic;
using dbdocs.lib.Serializers;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace dbdocs.tests.Providers
{
    public class ConfigProviderTests
    {
        private readonly Mock<IFileSystem> _fileSystemMock;

        private readonly string _configJ;
        private readonly string _noConfigJ;
        private readonly string _validJson;
        private readonly string _invalidJson;

        private readonly Mock<IConfigModel> _configModel;



        public ConfigProviderTests()
        {
            #region setup config strings

            _configJ = "config.json";
            _validJson = "{" +
                        "  \"Server Connection Info\": {" +
                        "    \"Data Source\": \"server\"," +
                        "    \"Integrated Security\": true," +
                        "    \"User ID\": null," +
                        "    \"Password\": null," +
                        "    \"Connect Timeout\": 60," +
                        "    \"Encrypt\": false," +
                        "    \"Trust Server Certificate\": false," +
                        "    \"Application Intent\": null," +
                        "    \"Multi Subnet Failover\": false" +
                        "  }," +
                        "  \"Databases\": [" +
                        "    \"db1\"," +
                        "    \"db2\"" +
                        "  ]" +
                        "}";

            _noConfigJ = "noconfig.json";
            _invalidJson = "";

            #endregion setup config strings

            var dbConnectionModel = new Mock<IServerConnectionModel>();
            dbConnectionModel.SetupGet(x => x.DataSource).Returns("server");


            _configModel = new Mock<IConfigModel>();
            _configModel.SetupGet(x => x.ServerConnectionInfo).Returns(dbConnectionModel.Object);

            _fileSystemMock = new Mock<IFileSystem>();
            _fileSystemMock.Setup(f => f.ReadTextFile(_configJ)).Returns(_validJson);
            _fileSystemMock.Setup(f => f.ReadTextFile(_noConfigJ)).Returns(_invalidJson);
        }

        [Fact]
        public void Should_ReturnConfigModel_When_ValidJsonString()
        {
            // Arrange
            var json = _fileSystemMock.Object.ReadTextFile(_configJ);
            var serializer = new JsonSerializer();
            var provider = new ConfigProvider<JsonConfigModel>(json, serializer);

            // Act
            IConfigModel configModel = provider.GetConfig();

            // Assert
            Assert.Equal(_configModel.Object.ServerConnectionInfo.DataSource, configModel.ServerConnectionInfo.DataSource);
        }

        [Fact]
        public void Should_ThrowError_When_MyIntNotDefined()
        {
            var tm = new TestMe() { MyString = "sssss" };

            ValidationContext context = new ValidationContext(tm);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(tm, context, results, true);

            Assert.True(results.Any());
        }
    }

    public class TestMe
    {
        [Required(ErrorMessage = nameof(MyInt) + " is required.")]
        public int MyInt { get; set; }

        [StringLength(2, ErrorMessage = "{0} cannot be more than 2.")]
        public string MyString { get; set; }
    }
}