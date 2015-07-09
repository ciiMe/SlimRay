using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlimRay.Data.TableData;
using SlimRay.Data;
using SlimRay.DB;

namespace SlimRayUnitTest.Data
{
    /// <summary>
    /// Summary description for MSSQLAccessApp
    /// </summary>
    [TestClass]
    public class MSSQLAccessAppUnitTests
    {
        private MSSQLAccessApp _app;
        private DataRequest _dataRequestForTest;

        public MSSQLAccessAppUnitTests()
        {
            _app = new MSSQLAccessApp();
            _dataRequestForTest = initTestDataRequest();
        }

        private DataRequest initTestDataRequest()
        {
            return new DataRequest()
            {
                Address = new StorageAddress
                {
                    DataKey = "MSSQL",
                    Address ="(connection string.)"
                },

                Action = DataAction.Get,

                DataName = "Users",
                RequestFields = new string[] { "id", "name", "displayname", "isadmin", "age", "sex", "comment" },
                Parameters = new FieldValueCollection[] 
                {
                    new FieldValueCollection
                    {
                        FieldName ="id",
                        Type = FieldType.Int,
                        Values = new string[]{"9907"}
                    }
                }
            };
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TranslateRequest(DataRequest dataRq)
        {
            DBRequest result = _app.TranslateRequest(_dataRequestForTest);
            Assert.AreNotEqual(result.Command, "");
            Assert.AreNotEqual(result.Parameters.Length, 0);
        }
    }
}
