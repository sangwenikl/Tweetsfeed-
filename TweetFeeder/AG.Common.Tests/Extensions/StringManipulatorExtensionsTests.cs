using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AG.Common.Extensions;
using AG.Common.Globals;

namespace AG.Common.Tests.Extensions
{
  /// <summary>
  /// Summary description for StringManipulatorExtensionsTests
  /// </summary>
  [TestClass]
  public class StringManipulatorExtensionsTests
  {
    public StringManipulatorExtensionsTests()
    {
      //
      // TODO: Add constructor logic here
      //
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
    public void GetFirstWord_InputStringIsEmpty_ReturnEmptyString()
    {
      // Arrange
      string expectedResult = string.Empty;
      // Act
      string actualResult = expectedResult.GetFirstWord(new[] { ' ' });
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetFirstWord_InputStringIsNull_ReturnEmptyString()
    {
      // Arrange
      string expectedResult = null;
      // Act
      string actualResult = expectedResult.GetFirstWord(null);
      // Assert
      Assert.AreEqual(string.Empty, actualResult);
    }

    [TestMethod]
    public void GetFirstWord_InputStringHasAWhiteSpaceDelimiter_ReturnFirstOccurrenceOfWordPrecedingWhiteSpaceDelimiter()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      // Act
      string actualResult = expectedResult.GetFirstWord(new[] { ' ' });
      // Assert
      Assert.AreEqual("Alan", actualResult);
    }

    [TestMethod]
    public void GetFirstWord_InputStringHasLeadingWhiteSpaceDelimiter_ReturnFirstOccurrenceOfWordPrecedingWhiteSpaceDelimiter()
    {
      // Arrange
      string expectedResult = " Alan follows Martin";
      // Act
      string actualResult = expectedResult.GetFirstWord(new[] { ' ' });
      // Assert
      Assert.AreEqual("Alan", actualResult);
    }

    [TestMethod]
    public void GetFirstWord_InputStringHasTrailingWhiteSpaceDelimiter_ReturnFirstOccurrenceOfWordPrecedingWhiteSpaceDelimiter()
    {
      // Arrange
      string expectedResult = "Alan ";
      // Act
      string actualResult = expectedResult.GetFirstWord(new[] { ' ' });
      // Assert
      Assert.AreEqual("Alan", actualResult);
    }

    [TestMethod]
    public void GetFirstWord_InputStringHasBackslashWhiteSpaceDelimiterArrayWith_ReturnFirstOccurrenceOfWordPrecedingWhiteSpaceDelimiter()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      // Act
      string actualResult = expectedResult.GetFirstWord(new[] { '\\', ' ' });
      // Assert
      Assert.AreEqual("Alan", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsEmpty_ReturnEmptyString()
    {
      // Arrange
      string expectedResult = string.Empty;
      // Act
      string actualResult = expectedResult.GetSubstringByKey("KeyDoesNotMatter", SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNull_ReturnEmptyString()
    {
      // Arrange
      string result = null;
      // Act
      string actualResult = result.GetSubstringByKey("KeyDoesNotMatter", SubstringOptions.BeforeKey);
      // Assert
      Assert.IsNull(actualResult);
    }    

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_keyIsEmpty_ReturnOriginalString()
    {
      // Arrange
      string expectedResult = "Does not matter what string you have provided";
      string key = string.Empty;
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_keyIsNull_ReturnOriginalString()
    {
      // Arrange
      string expectedResult = "Does not matter what string you have provided";
      string key = null; 
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotFound_ReturnOriginalString()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      string key = "Ward";
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyHasLeadingWhitespaceAndIsNotFound_ReturnOriginalString()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      string key = " Ward";
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyHasTrailingWhitespaceAndIsNotFound_ReturnOriginalString()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      string key = "Ward ";
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_keyHasLeadingAndTrailingWhitespaceAndKeyIsNotFound_ReturnOriginalString()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      string key = " Ward ";
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }
    

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotEmptyAndIsFound_SubstringOptionsIsAfterKey_ReturnSubstringSuccedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows Martin.";
      string key = "follows";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.AfterKey);
      // Assert
      Assert.AreEqual(" Martin.", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotEmptyAndIsFoundAndHasLeadingAndTrailingWhiteSpaces_SubstringOptionsIsBeforeKey_ReturnSubstringPrecedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows Martin";
      string key = " follows ";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual("Alan ", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotEmptyAndIsFoundAndHasLeadingAndTrailingWhiteSpaces_SubstringOptionsIsAfterKey_ReturnSubstringSuccedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows Martin.";
      string key = " follows ";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.AfterKey);
      // Assert
      Assert.AreEqual(" Martin.", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmptyAndHasLeadingAndTrailingWhitespaces_KeyIsNotEmptyAndIsFound_SubstringOptionsIsBeforeKey_ReturnSubstringPrecedingTheKey()
    {
      // Arrange
      string stringToSubstring = " Alan follows Martin ";
      string key = "follows";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual("Alan ", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmptyAndHasLeadingAndTrailingWhitespaces_KeyIsNotEmptyAndIsFound_SubstringOptionsIsAfterKey_ReturnSubstringSucceedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows Martin.";
      string key = "follows";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.AfterKey);
      // Assert
      Assert.AreEqual(" Martin.", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmptyAndHasComma_KeyIsNotEmptyAndIsFound_SubstringOptionsIsBeforeKey_ReturnSubstringPrecedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan, follows Martin ";
      string key = "follows";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual("Alan, ", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmptyAndHasComma_KeyIsNotEmptyAndIsFound_SubstringOptionsIsAfterKey_ReturnSubstringSucceedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows, Martin. ";
      string key = "follows";
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.AfterKey);
      // Assert
      Assert.AreEqual(", Martin.", actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotEmptyAndIsFoundAndIsAtBeginning_SubstringOptionsIsBeforeKey_ReturnEmptySubstringPrecedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows Martin";
      string key = "Alan";
      string expectedResult = string.Empty;
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.BeforeKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotEmptyAndIsFoundAndIsAtEnd_SubstringOptionsIsAfterKey_ReturnEmptySubstringSucceedingTheKey()
    {
      // Arrange
      string stringToSubstring = "Alan follows Martin";
      string key = "Martin";
      string expectedResult = string.Empty;
      // Act
      string actualResult = stringToSubstring.GetSubstringByKey(key, SubstringOptions.AfterKey);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void GetSubstringByKey_InputStringIsNotEmpty_KeyIsNotEmptyAndIsFound_SubstringOptionsIsNotDefined_ReturnOriginalSubstring()
    {
      // Arrange
      string expectedResult = "Alan follows Martin";
      string key = "follows";
      SubstringOptions optionIsInvalid = (SubstringOptions)2;
      // Act
      string actualResult = expectedResult.GetSubstringByKey(key, optionIsInvalid);
      // Assert
      Assert.AreEqual(expectedResult, actualResult);
    }
  }
}
