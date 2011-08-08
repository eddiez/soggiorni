using Soggiorni.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestSoggiorni
{
    
    
    /// <summary>
    ///This is a test class for SchedineFileGeneratorTest and is intended
    ///to contain all SchedineFileGeneratorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedineFileGeneratorTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for getFileText
        ///</summary>
        [TestMethod()]
        public void getFileTextTest()
        {
            List<SchedaNotifica> scl = null; 
            SchedineFileGenerator target = new SchedineFileGenerator(scl); 
            
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.getFileText();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
