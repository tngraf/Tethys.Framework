namespace TestTgLibParsing
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///This is a test class for TextParseTest and is intended
    ///to contain all TextParseTest Unit Tests
    ///</summary>
    [TestClass()]
  public class TextParseTest
  {
#if false

        private const double Delta = 0.000001D;
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

    public TextParseTest()
    {
    } // TextParseTest()

        #region PROPERTY TESTS
    /// <summary>
    /// A test for WhiteSpaceList.
    ///</summary>
    [TestMethod()]
    public void WhitespaceListTest()
    {
      TextParse target = new TextParse();
      string expected = TextParse.DefaultWhiteSpaceList;
      string actual;
      Assert.AreEqual(expected, target.WhiteSpaceList);

      expected = ".,:;";
      target.WhiteSpaceList = expected;
      actual = target.WhiteSpaceList;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for Text.
    ///</summary>
    [TestMethod()]
    public void TextTest()
    {
      TextParse target = new TextParse();
      string expected = "";
      string actual;
      actual = target.Text;
      Assert.AreEqual(expected, actual);
          
      expected = "1124124 dsfghlkjnlkjg LKJHLKJH öäÖÜÄ";
      target.Init(expected);
      actual = target.Text;
      Assert.AreEqual(expected, actual);

      target = new TextParse(expected);
      actual = target.Text;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for Location.
    ///</summary>
    [TestMethod()]
    public void LocationTest()
    {
      TextParse target = new TextParse();
      int actual;
      int expected = 0;
      actual = target.Location;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for SetLocation1
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void SetLocationTest1()
    {
      TextParse target = new TextParse();
      int location = 1;
      target.SetLocation(location);
    }

    /// <summary>
    /// A test for SetLocation2
    ///</summary>
    [TestMethod()]
    public void SetLocationTest2()
    {
      TextParse target = new TextParse("123");
      int location = 0;
      target.SetLocation(location);
      Assert.AreEqual(location, target.Location);

      location = 1;
      target.SetLocation(location);
      Assert.AreEqual(location, target.Location);

      location = 2;
      target.SetLocation(location);
      Assert.AreEqual(location, target.Location);
    }

    /// <summary>
    /// A test for SetLocation3
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void SetLocationTest3()
    {
      TextParse target = new TextParse("123");
      int location = 0;
      target.SetLocation(location);
      Assert.AreEqual(location, target.Location);

      location = 3;
      target.SetLocation(location);
      Assert.AreEqual(location, target.Location);

      location = 4;
      target.SetLocation(location);
    }

    /// <summary>
    /// A test for TextAtLocation.
    ///</summary>
    [TestMethod()]
    public void TextAtLocationTest()
    {
      TextParse target = new TextParse();
      string expected = "";
      string actual;
      actual = target.TextAtLocation;
      Assert.AreEqual(expected, actual);

      target.Init(" 123 ABC !!!");
      expected = "123 ABC !!!";
      Assert.AreEqual(0, target.Location);
      target.MoveLocation(1);
      actual = target.TextAtLocation;
      Assert.AreEqual(expected, actual);

      expected = "ABC !!!";
      target.MoveLocation(4);
      actual = target.TextAtLocation;
      Assert.AreEqual(expected, actual);

      expected = " ABC !!!";
      target.MoveLocation(-1);
      actual = target.TextAtLocation;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for TextAtLocation.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TextAtLocationTest1()
    {
      TextParse target = new TextParse();
      Assert.AreEqual(0, target.Location);
      target.MoveLocation(-1);
    }

    /// <summary>
    /// A test for TextAtLocation.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TextAtLocationTest2()
    {
      TextParse target = new TextParse();
      Assert.AreEqual(0, target.Location);
      target.MoveLocation(1);
    }

    /// <summary>
    /// A test for TextAtLocation.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TextAtLocationTest3()
    {
      TextParse target = new TextParse("123");
      Assert.AreEqual(0, target.Location);
      target.MoveLocation(1);
      string expected = "23";
      Assert.AreEqual(expected, target.TextAtLocation);

      target.MoveLocation(3);
    }
        #endregion // PROPERTY TESTS

    /// <summary>
    /// A test for MoveLocation
    ///</summary>
    [TestMethod()]
    public void MoveLocationTest()
    {
      // see TextAtLocationTests
    }

    /// <summary>
    /// A test for GetLastToken.
    ///</summary>
    [TestMethod()]
    public void GetLastTokenTest()
    {
      TextParse target = new TextParse();
      string expected = string.Empty;
      string actual;
      actual = target.GetLastToken();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetLastToken.
    ///</summary>
    [TestMethod()]
    public void GetLastTokenTest1()
    {
      string text = "123 ABC";
      TextParse target = new TextParse(text);
      string expected = string.Empty;
      string actual;
      actual = target.GetLastToken();
      Assert.AreEqual(expected, actual);

      target = new TextParse(text);
      actual = target.GetLastToken(ParseOptions.ToSpace);
      Assert.AreEqual(expected, actual);

      expected = "12";
      target = new TextParse(text);
      target.MoveLocation(2);
      actual = target.GetLastToken(ParseOptions.ToLocation);
      Assert.AreEqual(expected, actual);

      target = new TextParse(text);
      expected = string.Empty;
      actual = target.GetLastToken(ParseOptions.ToSpace|ParseOptions.ToLocation);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for SetLastToken.
    ///</summary>
    [TestMethod()]
    [DeploymentItem("TgLibParsingTest.exe")]
    public void SetLastTokenTest3()
    {
      TextParse_Accessor target = new TextParse_Accessor();
      target.Init("123 ABC");
      Assert.AreEqual(0, target.Location);
      int start = 3;
      target.MoveLocation(start);
      target.SetLastToken();
      Assert.AreEqual(start, target._tokenStart);
      string expected = "";
      string actual = target.GetLastToken();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for SetLastToken.
    ///</summary>
    [TestMethod()]
    [DeploymentItem("TgLibParsingTest.exe")]
    public void SetLastTokenTest1()
    {
      // TODO
      return;

      TextParse_Accessor target = new TextParse_Accessor();
      int start = 0;
      ParseOptions flags = new ParseOptions();
      target.SetLastToken(start, flags);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    /// A test for SetLastToken.
    ///</summary>
    [TestMethod()]
    [DeploymentItem("TgLibParsingTest.exe")]
    public void SetLastTokenTest2()
    {
      // TODO
      return;

      TextParse_Accessor target = new TextParse_Accessor(); // TODO: Initialize to an appropriate value
      ParseOptions flags = new ParseOptions(); // TODO: Initialize to an appropriate value
      target.SetLastToken(flags);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    /// A test for SetLastToken
    ///</summary>
    [TestMethod()]
    public void SetLastTokenTest()
    {
      // TODO
      return;

      TextParse target = new TextParse(); // TODO: Initialize to an appropriate value
      target.SetLastToken();
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    /// A test for GetChar.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetCharTest()
    {
      TextParse target = new TextParse();
      char actual = target.GetChar();
    }

    /// <summary>
    /// A test for GetChar.
    ///</summary>
    [TestMethod()]
    public void GetCharTest1()
    {
      TextParse target = new TextParse("123ÖäÜ");
      char expected = '1';
      char actual = target.GetChar();
      Assert.AreEqual(expected, actual);

      actual = target.GetChar();
      Assert.AreEqual(expected, actual);

      target.MoveLocation(3);
      expected = 'Ö';
      actual = target.GetChar();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetChar.
    ///</summary>
    [TestMethod()]
    public void GetCharTest2()
    {
      TextParse target = new TextParse("1    23");
      ParseOptions flags = ParseOptions.SkipSpace;
      char expected = '1';
      char actual;
      actual = target.GetChar(flags);
      Assert.AreEqual(expected, actual);

      expected = '2';
      target.MoveLocation(1);
      actual = target.GetChar(flags);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetChar.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetCharTest3()
    {
      TextParse target = new TextParse("12   ");
      ParseOptions flags = ParseOptions.SkipSpace;
      target.MoveLocation(2);
      char actual = target.GetChar(flags);
    }

    /// <summary>
    /// A test for SkipSpace.
    ///</summary>
    [TestMethod()]
    public void SkipSpaceTest()
    {
      TextParse target = new TextParse();
      Assert.AreEqual(0, target.Location);
      target.SkipSpace();
      Assert.AreEqual(0, target.Location);

      target = new TextParse("123");
      Assert.AreEqual(0, target.Location);
      target.SkipSpace();
      Assert.AreEqual(0, target.Location);

      target = new TextParse("     3    ");
      Assert.AreEqual(0, target.Location);
      target.SkipSpace();
      Assert.AreEqual(5, target.Location);
    }

    /// <summary>
    /// A test for IsSpace.
    ///</summary>
    [TestMethod()]
    public void IsSpaceTest()
    {
      TextParse target = new TextParse();
      Assert.AreEqual(TextParse.DefaultWhiteSpaceList, target.WhiteSpaceList);
      char ch = '\0';
      bool expected = false;
      bool actual;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = 'X';
      expected = false;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = ' ';
      expected = true;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = '\t';
      expected = true;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for IsSpace.
    ///</summary>
    [TestMethod()]
    public void IsSpaceTest1()
    {
      TextParse target = new TextParse();
      target.WhiteSpaceList = "\r\n.";
      char ch = '\0';
      bool expected = false;
      bool actual;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = '\t';
      expected = false;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = ' ';
      expected = false;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = '.';
      expected = true;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = '\r';
      expected = true;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);

      ch = '\n';
      expected = true;
      actual = target.IsSpace(ch);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for IsSpace.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void IsSpaceTest2()
    {
      TextParse target = new TextParse();
      bool actual;
      actual = target.IsSpace();
    }

    /// <summary>
    /// A test for IsSpace.
    ///</summary>
    [TestMethod()]
    public void IsSpaceTest3()
    {
      TextParse target = new TextParse("1 23");
      bool expected = false;
      bool actual;
      Assert.AreEqual(0, target.Location);
      actual = target.IsSpace();
      Assert.AreEqual(expected, actual);

      expected = true;
      target.MoveLocation(1);
      Assert.AreEqual(1, target.Location);
      actual = target.IsSpace();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for IsNumber.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void IsNumberTest()
    {
      TextParse target = new TextParse();
      bool actual;
      actual = target.IsNumber();
    }

    /// <summary>
    /// A test for IsNumber.
    ///</summary>
    [TestMethod()]
    public void IsNumberTest1()
    {
      TextParse target = new TextParse("3");
      bool expected = true;
      bool actual;
      actual = target.IsNumber();
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("kkkk");
      actual = target.IsNumber();
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("-");
      actual = target.IsNumber();
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("a");
      actual = target.IsNumber();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for IsNumber.
    ///</summary>
    [TestMethod()]
    public void IsNumberTest2()
    {
      TextParse target = new TextParse("     4");
      ParseOptions flags = ParseOptions.SkipSpace;
      bool expected = true;
      bool actual;
      actual = target.IsNumber(flags);
      Assert.AreEqual(expected, actual);

      expected = true;
      target.Init("  \t\t\t    6");
      actual = target.IsNumber(flags);
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("  \t\t\t    c");
      actual = target.IsNumber(flags);
      Assert.AreEqual(expected, actual);

      expected = true;
      flags = ParseOptions.SkipSpace | ParseOptions.Signed;
      target.Init("  \t\t\t    -");
      actual = target.IsNumber(flags);
      Assert.AreEqual(expected, actual);

      expected = true;
      flags = ParseOptions.SkipSpace | ParseOptions.Hex;
      target.Init("  \t\t\t    F");
      actual = target.IsNumber(flags);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetNextChar.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetNextCharTest()
    {
      TextParse target = new TextParse();
      char actual;
      actual = target.GetNextChar();
    }

    /// <summary>
    /// A test for GetNextChar.
    ///</summary>
    [TestMethod()]
    public void GetNextCharTest1()
    {
      string expected = "x123";
      TextParse target = new TextParse(expected);
      char actual;

      Assert.AreEqual(expected[0], target.GetChar());
      for (int i = 1; i < expected.Length; i++)
      {
        actual = target.GetNextChar();
        Assert.AreEqual(expected[i], actual);
      } // for
    }

    /// <summary>
    /// A test for GetNextChar.
    ///</summary>
    [TestMethod()]
    public void GetNextCharTest2()
    {
      string expected = "x123";
      TextParse target = new TextParse("x   1 \t\t 2\t3");
      ParseOptions flags = ParseOptions.SkipSpace;
      char actual;

      Assert.AreEqual(expected[0], target.GetChar());
      for (int i = 1; i < expected.Length; i++)
      {
        actual = target.GetNextChar(flags);
        Assert.AreEqual(expected[i], actual);
      } // for
    }

    /// <summary>
    /// A test for GetNextChar.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetNextCharTest3()
    {
      TextParse target = new TextParse("x     ");
      ParseOptions flags = ParseOptions.SkipSpace;
      char actual;

      Assert.AreEqual('x', target.GetChar());
      actual = target.GetNextChar(flags);
    }

    /// <summary>
    /// A test for LookNextChar.
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LookNextCharTest()
    {
      TextParse target = new TextParse();
      char actual;
      actual = target.LookNextChar();
    }

    /// <summary>
    /// A test for LookNextChar.
    ///</summary>
    [TestMethod()]
    public void LookNextCharTest1()
    {
      TextParse target = new TextParse("x1   23");
      char actual;
      char expected = '1';
      actual = target.LookNextChar();
      Assert.AreEqual(expected, actual);

      target.MoveLocation(1);

      expected = ' ';
      actual = target.LookNextChar();
      Assert.AreEqual(expected, actual);

      expected = '2';
      actual = target.LookNextChar(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for IsEndOfLine.
    ///</summary>
    [TestMethod()]
    public void IsEndOfLineTest1()
    {
      TextParse target = new TextParse();
      bool expected = true;
      bool actual;
      actual = target.IsEndOfLine();
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("123");
      actual = target.IsEndOfLine();
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("1           3");
      actual = target.IsEndOfLine();
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("1           3");
      target.MoveLocation(1);
      actual = target.IsEndOfLine();
      Assert.AreEqual(expected, actual);

      expected = true;
      target.Init("1           ");
      target.MoveLocation(1);
      actual = target.IsEndOfLine(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("1           ");
      target.MoveLocation(1);
      actual = target.IsEndOfLine(ParseOptions.None);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for CheckEndOfLine.
    ///</summary>
    [TestMethod()]
    public void CheckEndOfLineTest1()
    {
      TextParse target = new TextParse();
      target.CheckEndOfLine(ParseOptions.None);

      target.Init("123");
      target.MoveLocation(3);
      target.CheckEndOfLine(ParseOptions.None);

      target.Init("  ");
      target.CheckEndOfLine(ParseOptions.SkipSpace);
    }

    /// <summary>
    /// A test for CheckEndOfLine.
    ///</summary>
    [TestMethod()]
    public void CheckEndOfLineTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      target.CheckEndOfLine(flags);

      try
      {
        target.Init("123");
        target.CheckEndOfLine(flags);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.EndExpected, pex.Error);
      } // catch

      try
      {
        target.Init("   ");
        target.CheckEndOfLine(flags);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.EndExpected, pex.Error);
      } // catch

      target.Init("   ");
      target.CheckEndOfLine(ParseOptions.SkipSpace);
    }

    /// <summary>
    /// A test for IsFixChar.
    ///</summary>
    [TestMethod()]
    public void IsFixCharTest()
    {
      TextParse target = new TextParse();
      bool actual;
      bool expected = false;
      char ch = 'x';
      actual = target.IsFixChar(ch);
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("1");
      Assert.AreEqual(0, target.Location);
      ch = 'x';
      actual = target.IsFixChar(ch);
      Assert.AreEqual(0, target.Location);
      Assert.AreEqual(expected, actual);

      expected = true;
      target.Init("x");
      Assert.AreEqual(0, target.Location);
      ch = 'x';
      actual = target.IsFixChar(ch);
      Assert.AreEqual(1, target.Location);
      Assert.AreEqual(expected, actual);

      expected = false;
      target.Init("    x");
      Assert.AreEqual(0, target.Location);
      ch = 'x';
      actual = target.IsFixChar(ch, ParseOptions.None);
      Assert.AreEqual(0, target.Location);
      Assert.AreEqual(expected, actual);

      expected = true;
      target.Init("    x");
      Assert.AreEqual(0, target.Location);
      ch = 'x';
      actual = target.IsFixChar(ch, ParseOptions.SkipSpace);
      Assert.AreEqual(5, target.Location);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetFixChar.
    ///</summary>
    [TestMethod()]
    public void GetFixCharTest()
    {
      TextParse target = new TextParse();
      int expected = 0;
      string charlist = string.Empty;
      int actual;
      actual = target.GetFixChar(charlist);
      Assert.AreEqual(expected, actual);

      expected = 0;
      charlist = "xyz";
      Assert.AreEqual(0, target.Location);
      actual = target.GetFixChar(charlist);
      Assert.AreEqual(0, target.Location);
      Assert.AreEqual(expected, actual);

      expected = 1;
      target.Init("x34634636365");
      charlist = "xyz";
      Assert.AreEqual(0, target.Location);
      actual = target.GetFixChar(charlist);
      Assert.AreEqual(1, target.Location);
      Assert.AreEqual(expected, actual);

      expected = 0;
      target.Init("Y34634636365");
      charlist = "xyz";
      Assert.AreEqual(0, target.Location);
      actual = target.GetFixChar(charlist);
      Assert.AreEqual(0, target.Location);
      Assert.AreEqual(expected, actual);

      expected = 3;
      target.Init("Z34634636365");
      charlist = "xyZ";
      Assert.AreEqual(0, target.Location);
      actual = target.GetFixChar(charlist);
      Assert.AreEqual(1, target.Location);
      Assert.AreEqual(expected, actual);

      expected = 2;
      target.Init("     y\t\t   34634636365");
      charlist = "xyz";
      Assert.AreEqual(0, target.Location);
      actual = target.GetFixChar(charlist, ParseOptions.SkipSpace);
      Assert.AreEqual(11, target.Location);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for CheckFixChar.
    ///</summary>
    [TestMethod()]
    public void CheckFixCharTest()
    {
      TextParse target = new TextParse();
      string charlist = string.Empty;
      int actual;
      try
      {
        actual = target.CheckFixChar(charlist);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.SpecNotFound, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      int expected = 2;
      target.Init("ERT");
      charlist = "XEY";
      actual = target.CheckFixChar(charlist);
      Assert.AreEqual(expected, actual);

      target.Init("132ERT");
      target.MoveLocation(3);
      charlist = "XZY";
      try
      {
        actual = target.CheckFixChar(charlist);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.SpecNotFound, pex.Error);
        Assert.AreEqual("ERT", pex.LastToken);
      } // catch

      expected = 5;
      target.Init("ER     T");
      target.MoveLocation(2);
      charlist = "XEYUT";
      try
      {
        actual = target.CheckFixChar(charlist);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.SpecNotFound, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      actual = target.CheckFixChar(charlist, ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for CheckSpace.
    ///</summary>
    [TestMethod()]
    public void CheckSpaceTest()
    {
      TextParse target = new TextParse();
      target.CheckSpace();

      target = new TextParse("sdfglkjhdsglsdjg");
      try
      {
        target.CheckSpace();
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.SpecNotFound, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      target = new TextParse("   \t\t   ");
      Assert.AreEqual(0, target.Location);
      target.CheckSpace();
      Assert.AreEqual(8, target.Location);
    }

    // XXXXXXXXXXXXXX

    /// <summary>
    /// A test for GetFixName.
    ///</summary>
    [TestMethod()]
    public void GetFixNameTest()
    {
      string namelist = "asdf\tqqwweerr\t123\töäü\t98xx09\tf_-k";

      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      int expected = -1;
      int actual;

      actual = target.GetFixName(namelist, flags);
      Assert.AreEqual(expected, actual);

      expected = 0;
      target.Init("asdf");
      actual = target.GetFixName("", flags);
      Assert.AreEqual(expected, actual);

      expected = 1;
      target.Init("asdf");
      actual = target.GetFixName(namelist, flags);
      Assert.AreEqual(expected, actual);

      expected = 2;
      target.Init("qqwweerr");
      actual = target.GetFixName(namelist, flags);
      Assert.AreEqual(expected, actual);

      expected = -1;
      target.Init("123");
      actual = target.GetFixName(namelist, flags);
      Assert.AreEqual(expected, actual);

      expected = 3;
      target.Init("123");
      actual = target.GetFixName(namelist, ParseOptions.Digits);
      Assert.AreEqual(expected, actual);

      expected = -1;
      target.Init("öäü");
      actual = target.GetFixName(namelist, flags);
      Assert.AreEqual(expected, actual);

      expected = 4;
      target.Init("öäü");
      actual = target.GetFixName(namelist, ParseOptions.Umlaute);
      Assert.AreEqual(expected, actual);

      expected = 5;
      target.Init("98xx09");
      actual = target.GetFixName(namelist, ParseOptions.Digits);
      Assert.AreEqual(expected, actual);

      expected = -1;
      target.Init("F_-k");
      actual = target.GetFixName(namelist, ParseOptions.FullName);
      Assert.AreEqual(expected, actual);

      expected = 6;
      target.Init("F_-k");
      actual = target.GetFixName(namelist, ParseOptions.ExtraChar);
      Assert.AreEqual(expected, actual);

      expected = 2;
      target.Init("qqww");
      actual = target.GetFixName(namelist, flags);
      Assert.AreEqual(expected, actual);

      expected = -1;
      target.Init("qqww");
      actual = target.GetFixName(namelist, ParseOptions.FullName);
      Assert.AreEqual(expected, actual);

      expected = -1;
      target.Init("   qqww   ");
      actual = target.GetFixName(namelist, ParseOptions.None);
      Assert.AreEqual(expected, actual);

      expected = 2;
      target.Init("   qqww   ");
      actual = target.GetFixName(namelist, ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetHexDigit.
    ///</summary>
    [TestMethod()]
    public void GetHexDigitTest()
    {
      string text = "0123456789abCDEf";
      int expected = 0;
      char ch = text[0];
      int actual;

      for (int i = 0; i < text.Length; i++)
      {
        expected = i;
        actual = TextParse.GetHexDigit(text[i]);
        Assert.AreEqual(expected, actual);
      } // for

      expected = -1;
      actual = TextParse.GetHexDigit('x');
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for IsHexDigit.
    ///</summary>
    [TestMethod()]
    public void IsHexDigitTest()
    {
      string text = "0123456789abCDEf";
      bool expected = true;
      bool actual;

      for (int i = 0; i < text.Length; i++)
      {
        actual = TextParse.IsHexDigit(text[i]);
        Assert.AreEqual(expected, actual);
      } // for

      expected = false;
      actual = TextParse.IsHexDigit('x');
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetUnsignedNumber.
    ///</summary>
    [TestMethod()]
    public void GetUnsignedNumberTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      uint maxValue = 0;
      uint expected = 0;
      uint actual;

      try
      {
        actual = target.GetUnsignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 1;
      target.Init("1");
      actual = target.GetUnsignedNumber(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 1234567890;
      target.Init("1234567890");
      actual = target.GetUnsignedNumber(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 4294967295;
      target.Init("4294967295");
      actual = target.GetUnsignedNumber(flags, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        expected = 0;
        target.Init("4294967296");
        actual = target.GetUnsignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 5;
        target.Init("5");
        actual = target.GetUnsignedNumber(flags, 4);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 0;
        target.Init("-1");
        actual = target.GetUnsignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      try
      {
        expected = 0x12;
        target.Init("0x12");
        actual = target.GetUnsignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 0x12;
      target.Init("0x12");
      actual = target.GetUnsignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 0x20;
      target.Init("20");
      actual = target.GetUnsignedNumber(ParseOptions.Hex|ParseOptions.HexOnly, maxValue);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetUnsignedNumber.
    ///</summary>
    [TestMethod()]
    public void GetUnsignedNumberTest2()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      uint maxValue = 0;
      uint expected = 0;
      uint actual;

      expected = 0xffffffff;
      target.Init("0xffffffff");
      actual = target.GetUnsignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        expected = 12;
        target.Init("0x0E");
        actual = target.GetUnsignedNumber(ParseOptions.Hex, 12);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      expected = 0xff;
      target.Init("0xfftttttt");
      actual = target.GetUnsignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 0xff;
      target.Init("    0xfftttttt");
      actual = target.GetUnsignedNumber(ParseOptions.Hex|ParseOptions.SkipSpace, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("ff");
        actual = target.GetUnsignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      try
      {
        target.Init("0xff");
        actual = target.GetUnsignedNumber(ParseOptions.Hex|ParseOptions.HexOnly, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 0xff;
      target.Init("ff");
      actual = target.GetUnsignedNumber(ParseOptions.Hex | ParseOptions.HexOnly, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("xff");
        actual = target.GetUnsignedNumber(ParseOptions.Hex, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      try
      {
        target.Init("0x");
        actual = target.GetUnsignedNumber(ParseOptions.Hex, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch
    }

    /// <summary>
    /// A test for GetSignedNumber.
    ///</summary>
    [TestMethod()]
    public void GetSignedNumberTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      int maxValue = 0;
      int expected = 0;
      int actual;

      try
      {
        actual = target.GetSignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 1;
      target.Init("1");
      actual = target.GetSignedNumber(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 1234567890;
      target.Init("1234567890");
      actual = target.GetSignedNumber(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 2147483647;
      target.Init("2147483647");
      actual = target.GetSignedNumber(flags, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        expected = 0;
        target.Init("4294967296");
        actual = target.GetSignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 5;
        target.Init("5");
        actual = target.GetSignedNumber(flags, 4);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 0x12;
        target.Init("0x12");
        actual = target.GetSignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 0x12;
      target.Init("0x12");
      actual = target.GetSignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetSignedNumber.
    ///</summary>
    [TestMethod()]
    public void GetSignedNumberTest2()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      int maxValue = 0;
      int expected = 0;
      int actual;

      expected = 0xfffffff;
      target.Init("0xfffffff");
      actual = target.GetSignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        expected = 12;
        target.Init("0x0E");
        actual = target.GetSignedNumber(ParseOptions.Hex, 12);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      expected = 0xff;
      target.Init("0xfftttttt");
      actual = target.GetSignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 0xff;
      target.Init("    0xfftttttt");
      actual = target.GetSignedNumber(ParseOptions.Hex | ParseOptions.SkipSpace, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("ff");
        actual = target.GetSignedNumber(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      try
      {
        target.Init("0xff");
        actual = target.GetSignedNumber(ParseOptions.Hex | ParseOptions.HexOnly, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 0xff;
      target.Init("ff");
      actual = target.GetSignedNumber(ParseOptions.Hex | ParseOptions.HexOnly, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("xff");
        actual = target.GetSignedNumber(ParseOptions.Hex, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      try
      {
        target.Init("0x");
        actual = target.GetSignedNumber(ParseOptions.Hex, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch
    }

    /// <summary>
    /// A test for GetSignedNumber.
    ///</summary>
    [TestMethod()]
    public void GetSignedNumberTest3()
    {
      TextParse target = new TextParse();
      int maxValue = 0;
      int expected = 0;
      int actual;

      expected = -1;
      target.Init("-1");
      actual = target.GetSignedNumber(ParseOptions.None, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("-");
        actual = target.GetSignedNumber(ParseOptions.None, 12);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.NumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = -99999999;
      target.Init("-99999999");
      actual = target.GetSignedNumber(ParseOptions.None, maxValue);
      Assert.AreEqual(expected, actual);

      expected = -255;
      target.Init("-0x00ff");
      actual = target.GetSignedNumber(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      expected = -32;
      target.Init("-20");
      actual = target.GetSignedNumber(ParseOptions.Hex|ParseOptions.HexOnly, maxValue);
      Assert.AreEqual(expected, actual);
    } 

    /// <summary>
    /// A test for GetUnsignedDecimal.
    ///</summary>
    [TestMethod()]
    public void GetUnsignedDecimalTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      uint maxValue = 0;
      uint expected = 0;
      uint actual;

      try
      {
        actual = target.GetUnsignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 1;
      target.Init("1");
      actual = target.GetUnsignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 1234567890;
      target.Init("1234567890");
      actual = target.GetUnsignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 4294967295;
      target.Init("4294967295");
      actual = target.GetUnsignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        expected = 0;
        target.Init("4294967296");
        actual = target.GetUnsignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 5;
        target.Init("5");
        actual = target.GetUnsignedDecimal(flags, 4);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 0;
        target.Init("-1");
        actual = target.GetUnsignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 0; // not 0x12, because we can't handle hex numbers
      target.Init("0x12");
      actual = target.GetUnsignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);
      Assert.AreEqual(1, target.Location);
    }

    /// <summary>
    /// A test for GetUnsignedDecimal.
    ///</summary>
    [TestMethod()]
    public void GetUnsignedDecimalTest2()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      uint maxValue = 0;
      uint expected = 0;
      uint actual;

      expected = 00;
      target.Init("0xffffffff");
      actual = target.GetUnsignedDecimal(ParseOptions.None, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 0; // not 0x0e
      target.Init("0x0E");
      actual = target.GetUnsignedDecimal(ParseOptions.None, 12);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("ff");
        actual = target.GetUnsignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch
    }

    /// <summary>
    /// A test for GetSignedDecimal.
    ///</summary>
    [TestMethod()]
    public void GetSignedDecimalTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      int maxValue = 0;
      int expected = 0;
      int actual;

      try
      {
        actual = target.GetSignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 1;
      target.Init("1");
      actual = target.GetSignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 1234567890;
      target.Init("1234567890");
      actual = target.GetSignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);

      expected = 2147483647;
      target.Init("2147483647");
      actual = target.GetSignedDecimal(flags, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        expected = 0;
        target.Init("4294967296");
        actual = target.GetSignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch

      try
      {
        expected = 5;
        target.Init("5");
        actual = target.GetSignedDecimal(flags, 4);
        Assert.Fail("must throw exception");
      }
      catch (OverflowException)
      {
      } // catch
    }

    /// <summary>
    /// A test for GetSignedDecimal.
    ///</summary>
    [TestMethod()]
    public void GetSignedDecimalTest2()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      int maxValue = 0;
      int expected = 0;
      int actual;

      expected = 0;
      target.Init("0xfffffff");
      actual = target.GetSignedDecimal(ParseOptions.Hex, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("ff");
        actual = target.GetSignedDecimal(flags, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      try
      {
        target.Init("xff");
        actual = target.GetSignedDecimal(ParseOptions.Hex, maxValue);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch
    }

    /// <summary>
    /// A test for GetSignedDecimal.
    ///</summary>
    [TestMethod()]
    public void GetSignedDecimalTest3()
    {
      TextParse target = new TextParse();
      int maxValue = 0;
      int expected = 0;
      int actual;

      expected = -1;
      target.Init("-1");
      actual = target.GetSignedDecimal(ParseOptions.None, maxValue);
      Assert.AreEqual(expected, actual);

      try
      {
        target.Init("-");
        actual = target.GetSignedDecimal(ParseOptions.None, 12);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        // exception, because 
        Assert.AreEqual(ParsingError.DecimalNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = -99999999;
      target.Init("-99999999");
      actual = target.GetSignedDecimal(ParseOptions.None, maxValue);
      Assert.AreEqual(expected, actual);
    } 

    /// <summary>
    /// A test for GetDouble.
    ///</summary>
    [TestMethod()]
    public void GetDoubleTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      double expected = 0F;
      double actual;
      double dx;

      try
      {
        actual = target.GetDouble(flags);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.FloatNumberExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = 0D;
      target.Init("0.0");
      actual = target.GetDouble(flags);
      Assert.AreEqual(expected, actual);

      expected = 12.34D;
      target.Init("12.34");
      actual = target.GetDouble(flags);
      dx = Math.Abs(expected - actual);
      Assert.IsTrue(dx < Delta);

      expected = 0.00001D;
      target.Init("0.00001");
      actual = target.GetDouble(flags);
      dx = Math.Abs(expected - actual);
      Assert.IsTrue(dx < Delta);

      expected = 12345678.54321D;
      target.Init("12345678.54321");
      actual = target.GetDouble(flags);
      dx = Math.Abs(expected - actual);
      Assert.IsTrue(dx < Delta);

      expected = -56.78D;
      target.Init("-56.78");
      actual = target.GetDouble(flags);
      dx = Math.Abs(expected - actual);
      Assert.IsTrue(dx < Delta);
    }

    /// <summary>
    /// A test for GetQuotedString.
    ///</summary>
    [TestMethod()]
    public void GetQuotedStringTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      string expected = string.Empty;
      string actual;

      try
      {
        actual = target.GetQuotedString(flags);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.StringExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = "123";
      target.Init("123");
      actual = target.GetQuotedString(flags);
      Assert.AreEqual(expected, actual);

      expected = "123";
      target.Init("123     twetwet");
      actual = target.GetQuotedString(flags);
      Assert.AreEqual(expected, actual);

      expected = "";
      target.Init("   123     twetwet");
      actual = target.GetQuotedString(flags);
      Assert.AreEqual(expected, actual);

      expected = "123";
      target.Init("   123     twetwet");
      actual = target.GetQuotedString(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      expected = "123";
      target.Init("\"123\"");
      actual = target.GetQuotedString(flags);
      Assert.AreEqual(expected, actual);

      try
      {
        // no closing quote
        target.Init("\"123");
        actual = target.GetQuotedString(flags);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.StringEndExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = "123";
      target.Init("\"123\"     twetwet");
      actual = target.GetQuotedString(flags);
      Assert.AreEqual(expected, actual);

      expected = "";
      target.Init("   \"123\"     twetwet");
      actual = target.GetQuotedString(flags);
      Assert.AreEqual(expected, actual);

      expected = "123";
      target.Init("   \"123\"     twetwet");
      actual = target.GetQuotedString(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      expected = "123";
      target.Init("123");
      try
      {
        actual = target.GetQuotedString(ParseOptions.Quoted);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.StringExpected, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch

      expected = "123";
      target.Init("\"123\"");
      actual = target.GetQuotedString(ParseOptions.Quoted);
      Assert.AreEqual(expected, actual);

      expected = "12345";
      target.Init("\"123\"\"45\"");
      actual = target.GetQuotedString(ParseOptions.Quoted);
      Assert.AreEqual(expected, actual);

      expected = "12345";
      target.Init(" \"123\"  \"45\"  ");
      actual = target.GetQuotedString(ParseOptions.Quoted|ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      expected = "123\n45";
      target.Init(" \"123\r\n45\"  ");
      actual = target.GetQuotedString(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      expected = "123\n45";
      target.Init(" \"123\n\r45\"  ");
      actual = target.GetQuotedString(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// A test for GetNextToken.
    ///</summary>
    [TestMethod()]
    public void GetNextTokenTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      string expected = string.Empty;
      string actual;
      actual = target.GetNextToken(flags);
      Assert.AreEqual(expected, actual);

      actual = target.GetNextToken();
      Assert.AreEqual(expected, actual);

      string text = "123  456\tAsdf   ";
      target.Init(text);
      expected = "123";
      actual = target.GetNextToken();
      Assert.AreEqual(expected, actual);

      expected = "";
      actual = target.GetNextToken();
      Assert.AreEqual(expected, actual);

      expected = "456";
      actual = target.GetNextToken(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      expected = "Asdf";
      actual = target.GetNextToken(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      Assert.AreEqual(text.Length, target.Location);
    }

    /// <summary>
    /// A test for SkipNextToken.
    ///</summary>
    [TestMethod()]
    public void SkipNextTokenTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;

      Assert.AreEqual(0, target.Location);
      target.SkipNextToken(flags);
      Assert.AreEqual(0, target.Location);

      string text = "\t\tÖ'ÄÜÖ'Ü***   3463465  ";
      target.Init(text);
      Assert.AreEqual(0, target.Location);
      target.SkipNextToken(flags);
      Assert.AreEqual(0, target.Location);

      target.SkipNextToken(ParseOptions.SkipSpace);
      Assert.AreEqual(15, target.Location);

      target.SkipNextToken(ParseOptions.SkipSpace);
      Assert.AreEqual(text.Length, target.Location);
    }

    /// <summary>
    /// A test for GetNextLine.
    ///</summary>
    [TestMethod()]
    public void GetNextLineTest()
    {
      TextParse target = new TextParse();
      ParseOptions flags = ParseOptions.None;
      string expected = string.Empty;
      string actual;
      actual = target.GetNextLine(flags);
      Assert.AreEqual(expected, actual);

      string text = "1234567890";
      expected = text;
      target.Init(text);
      actual = target.GetNextLine(flags);
      Assert.AreEqual(expected, actual);

      text = "  1234567890  ";
      expected = text;
      target.Init(text);
      actual = target.GetNextLine(flags);
      Assert.AreEqual(expected, actual);

      expected = "1234567890  ";
      target.Init(text);
      actual = target.GetNextLine(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      text = "1234567890\r\n  ljkhgalfjhasldfkj";
      expected = "1234567890";
      target.Init(text);
      actual = target.GetNextLine(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      text = "1234567890\n\r  ljkhgalfjhasldfkj";
      expected = "1234567890";
      target.Init(text);
      actual = target.GetNextLine(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      text = "1234\r 567";
      expected = "1234\n 567";
      target.Init(text);
      actual = target.GetNextLine(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      text = "1234\n 567";
      expected = "1234\n 567";
      target.Init(text);
      actual = target.GetNextLine(ParseOptions.SkipSpace);
      Assert.AreEqual(expected, actual);

      text = "    ";
      target.Init(text);
      try
      {
        actual = target.GetNextLine(ParseOptions.SkipSpace);
        Assert.Fail("must throw exception");
      }
      catch (ParsingException pex)
      {
        Assert.AreEqual(ParsingError.SpecNotFound, pex.Error);
        Assert.AreEqual("", pex.LastToken);
      } // catch
    }

    /// <summary>
    /// A test for DetermineLastTokenEnd.
    ///</summary>
    [TestMethod()]
    [DeploymentItem("TgLibParsingTest.exe")]
    public void DetermineLastTokenEndTest()
    {
      TextParse_Accessor target = new TextParse_Accessor();
      ParseOptions flags = ParseOptions.None;
      target.DetermineLastTokenEnd(flags);
      target.DetermineLastTokenEnd(ParseOptions.SkipSpace);
    }

    /// <summary>
    /// A test for DetermineLastTokenEnd.
    ///</summary>
    [TestMethod()]
    [DeploymentItem("TgLibParsingTest.exe")]
    public void DetermineLastTokenEndTest1()
    {
      TextParse_Accessor target = new TextParse_Accessor("123");
      ParseOptions flags = ParseOptions.None;
      int expected = 2;
      target.DetermineLastTokenEnd(flags);
      Assert.AreEqual(0, target._tokenStart);
      Assert.AreEqual(expected, target._tokenEnd);
    }
#endif
    }
}
