using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.Domain.Concretes;
using AG.Domain.Abstracts;

namespace AG.Common.Tests.Contretes
{
  [TestClass]
  public class UserRepositoryTests
  {
    private IUserRepository userRepository = new UserRepository();   

    [TestMethod]
    public void GetFollowerByLine_GivenInputEmptyString_ReturnEmptyString()
    {
      // Arrange
      string line = string.Empty;

      string expectedFollower = string.Empty;

      // Act
      string actualFollower = userRepository.GetFollowerByLine(line);
      // Assert
      Assert.AreEqual(expectedFollower, actualFollower);
    }

    [TestMethod]
    public void GetFollowedByLine_GivenInputEmptyString_ReturnEmptyString()
    {
      // Arrange
      string line = string.Empty;
      string expectedFollowing = string.Empty;
      // Act
      string actualFollowing = userRepository.GetFollowedByLine(line);
      // Assert
      Assert.AreEqual(expectedFollowing, actualFollowing);

    }
   
    [TestMethod]
    public void GetFollowerByLine_InputIsNull_ReturnEmptyString()
    {
      // Arrange
      string line = null;
      string expectedFollower = string.Empty;
      // Act
      string actualFollower = userRepository.GetFollowerByLine(line);
      // Assert
      Assert.AreEqual(expectedFollower, actualFollower);
    }

    [TestMethod]
    public void GetFollowedByLine_InputIsNull_ReturnEmptyString()
    {
      // Arrange
      string line = null;
      string expectedFollowing = string.Empty;
      // Act
      string actualFollowing = userRepository.GetFollowedByLine(line);
      // Assert
      Assert.AreEqual(expectedFollowing, actualFollowing);

    }

    [TestMethod]
    public void GetFollowerByLine_InputIsValidString_ReturnFollowerTwitterHandler()
    {
      // Arrange
      string line = "Alan follows Martin";
      string expectedFollower = "Alan";
      // Act
      string actualFollower = userRepository.GetFollowerByLine(line);
      // Assert
      Assert.AreEqual(expectedFollower, actualFollower);
    }

    [TestMethod]
    public void GetFollowedByLinee_InputValidString_ReturnCommaDelimitedFollowedUsers()
    {
      // Arrange
      string line = "Ward follows Martin, Alan";
      string expectedFollowed = "Martin, Alan";
      // Act
      string actualFollowed = userRepository.GetFollowedByLine(line);
      // Assert
      Assert.AreEqual(expectedFollowed, actualFollowed);

    }

    [TestMethod]
    public void GetFollowedByLinee_InputValidStringWithTrailingWhiteSpaces_ReturnCommaDelimitedFollowedUsers()
    {
      // Arrange
      string line = "Ward follows Martin,Alan     ";
      string expectedFollowed = "Martin,Alan";
      // Act
      string actualFollowed = userRepository.GetFollowedByLine(line);
      // Assert
      Assert.AreEqual(expectedFollowed, actualFollowed);

    }  

    [TestMethod]
    public void CreateFollowAssociationByLine_InputEmptyString_ReturnNullDictionary()
    {
      // Arrange
      string line = string.Empty;
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNull(actualFollowAssociation);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsNUll_ReturnNullDictionary()
    {
      // Arrange
      string line = null;
      // Act
      var actualFollowingHandler = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNull(actualFollowingHandler);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValidLine_ReturnDictionaryWithOneFollowed()
    {
      // Arrange
      string line = "Alan follows Martin";
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNotNull(actualFollowAssociation);
      Assert.IsTrue(actualFollowAssociation.Count == 1);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputFollowerIsNull_ReturnNUllDictionary()
    {
      // Arrange
      string expectedFollower = null;
      string expectedFollowed = "Martin";
      string line = $"{expectedFollower} follows {expectedFollowed}";
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNull(actualFollowAssociation);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputFollowerIsEmpty_ReturnNUllDictionary()
    {
      // Arrange
      string expectedFollower = string.Empty;
      string expectedFollowed = "Martin";
      string line = $"{expectedFollower} follows {expectedFollowed}";
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNull(actualFollowAssociation);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputFollowedIsNull_ReturnNUllDictionary()
    {
      // Arrange
      string expectedFollower = "Alan";
      string expectedFollowed = null;
      string line = $"{expectedFollower} follows {expectedFollowed}";
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNull(actualFollowAssociation);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputFollowedIsEmpty_ReturnNUllDictionary()
    {
      // Arrange
      string expectedFollower = "Alan";
      string expectedFollowed = string.Empty;
      string line = $"{expectedFollower} follows {expectedFollowed}";
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert
      Assert.IsNull(actualFollowAssociation);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValid_TryAddKeyValuePairThatAlreadyExists_ReturnDictionaryUnchanged()
    {
      // Arrange
      string expectedFollower = "Alan";
      string expectedFollowed = "Martin";
      string line = $"{expectedFollower} follows {expectedFollowed}";
      int expectedCount = userRepository.CreateFollowAssociationByLine(line).Count;
      // Precondition 
      Assert.IsTrue(expectedCount > 0);
      // Act
      int actualCount = userRepository.CreateFollowAssociationByLine(line).Count;
      // Assert
      Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValid_TryAddKeyValuePairThatAlreadyButWithLowerCasesExists_ReturnDictionaryUnchanged()
    {
      // Arrange
      string expectedFollower = "Alan";
      string expectedFollowed = "Martin";
      string line = $"{expectedFollower} follows {expectedFollowed}";
      int expectedCount = userRepository.CreateFollowAssociationByLine(line).Count;      
      // Precondition 
      Assert.IsTrue(expectedCount > 0);
      // Act
      int actualCount = userRepository.CreateFollowAssociationByLine(line.ToLower()).Count;
      // Assert
      Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValid_TryAddNewValueToExistingKey_ReturnDictionaryWithCommaDelimitedFollowed()
    {
      // Arrange
      string expectedFollower = "Alan";
      string followedOne = "Martin";      
      string lineOne = $"{expectedFollower} follows {followedOne}";
      var initialAssociation = userRepository.CreateFollowAssociationByLine(lineOne);

      string followedTwo = "Ward";
      string lineTwo = $"{expectedFollower} follows {followedTwo}";

      string expectedFollowedByKey = $"{followedOne},{followedTwo}";
      // Precondition 
      Assert.IsTrue(initialAssociation.ContainsKey(expectedFollower));
      // Act
      var actualAssociation = userRepository.CreateFollowAssociationByLine(lineTwo);
      // Assert
      string actualFollowedByKey;
      Assert.IsTrue(actualAssociation.TryGetValue(expectedFollower, out actualFollowedByKey));
      Assert.AreEqual(expectedFollowedByKey, actualFollowedByKey);

    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValid_TryAddTwoCommaDelimitedValuesToExistingKeyWithOneValueAlreadyExisting_ReturnDictionaryWithCommaDelimitedFollowedUnioned()
    {
      // Arrange
      string expectedFollower = "Ward";
      string followedOne = "Alan";
      string lineOne = $"{expectedFollower} follows {followedOne}"; // Ward follows Alan
      var initialAssociation = userRepository.CreateFollowAssociationByLine(lineOne);

      string followedTwo = $"Martin, {followedOne}";
      string lineTwo = $"{expectedFollower} follows {followedTwo}"; // Ward follows Martin, Alan

      string expectedFollowedByKey = $"{followedOne},Martin"; // Alan,Martin
      // Precondition 
      Assert.IsTrue(initialAssociation.ContainsKey(expectedFollower));
      // Act
      var actualAssociation = userRepository.CreateFollowAssociationByLine(lineTwo);
      // Assert
      string actualFollowedByKey;
      Assert.IsTrue(actualAssociation.TryGetValue(expectedFollower, out actualFollowedByKey));
      Assert.AreEqual(expectedFollowedByKey, actualFollowedByKey);

    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValidWithTwoCommaDelimitedFollowed_ReturnDictionaryWithKeyPairAssociation()
    {
      // Arrange
      string expectedFollower = "Ward";
      string expectedFollowed = "Martin, Alan";
      string line = $"{expectedFollower} follows {expectedFollowed}";

      string value;
      // Act
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(line);
      // Assert 
      Assert.IsTrue(actualFollowAssociation.TryGetValue(expectedFollower, out value) == true);
      Assert.IsTrue(value == expectedFollowed);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValid_AddThreeNewFollowed_ReturnDictionaryWithKeyAssociatedToThreeFollowe()
    {
      // Arrange
      string expectedFollower = "Ward";
      string expectedFollowedOne = "Martin";
      string expectedFollowedTwo = "Alan";
      string expectedFollowedThree = "Mpha";

      string lineOne = $"{expectedFollower} follows {expectedFollowedOne}";
      string lineTwo = $"{expectedFollower} follows {expectedFollowedTwo}";
      string lineThree = $"{expectedFollower} follows {expectedFollowedThree}";

      string expectedResult = $"{expectedFollowedOne},{expectedFollowedTwo},{expectedFollowedThree}";
      // Act
      userRepository.CreateFollowAssociationByLine(lineOne);
      userRepository.CreateFollowAssociationByLine(lineTwo);
      var actualFollowAssociation = userRepository.CreateFollowAssociationByLine(lineThree);
      // Assert 
      string actualFollowed;
      Assert.IsTrue(actualFollowAssociation.TryGetValue(expectedFollower, out actualFollowed) == true);
      Assert.IsTrue(expectedResult == actualFollowed);
    }

    [TestMethod]
    public void CreateFollowAssociationByLine_InputIsValid_AddThreeNewFollowed_ReturnDictionaryKeysInAscendingOrder()
    {
      // Arrange
      string expectedFollowerOne = "Ward";
      string expectedFollowerTwo = "Alan";
      string expectedFollowerThree = "Ben";
      string expectedFollowed = "Martin";      

      string lineOne = $"{expectedFollowerOne} follows {expectedFollowed}";
      string lineTwo = $"{expectedFollowerTwo} follows {expectedFollowed}";
      string lineThree = $"{expectedFollowerThree} follows {expectedFollowed}";

      string expectedFirstKey = expectedFollowerTwo; //Alan
      string expectedSecondKey = expectedFollowerThree; //Ben
      string expectedThirdKey = expectedFollowerOne; //Ward
      // Act
      userRepository.CreateFollowAssociationByLine(lineOne);
      userRepository.CreateFollowAssociationByLine(lineTwo);
      var actualFollowKeys = userRepository.CreateFollowAssociationByLine(lineThree).Keys;
      // Assert 
      Assert.AreEqual(expectedFirstKey, actualFollowKeys.ElementAt(0));
      Assert.AreEqual(expectedSecondKey,actualFollowKeys.ElementAt(1));
      Assert.AreEqual(expectedThirdKey, actualFollowKeys.ElementAt(2));
    }    
  }
}


