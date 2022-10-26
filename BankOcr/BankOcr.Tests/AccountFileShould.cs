using FluentAssertions;
using Xunit;

namespace BankOcr.Tests;

public class AccountFileShould
{
    [Fact]
    public void Read_One_Account_Number_From_A_File()
    {
        using Stream stream = TestUtils.ReadEmbeddedResourceStream(@"TestData\OneAccountNumber.txt");
        var accountFile = AccountFile.Read(stream);

        accountFile.Entries.Should().HaveCount(1);
        accountFile.Entries[0].AccountNumber.Should().BeEquivalentTo("123456789");
    }
    
    [Fact]
    public void Read_Two_Account_Numbers_From_A_File()
    {
        using Stream stream = TestUtils.ReadEmbeddedResourceStream(@"TestData\TwoAccountNumbers.txt");
        var accountFile = AccountFile.Read(stream);

        accountFile.Entries.Should().HaveCount(2);
        accountFile.Entries[0].AccountNumber.Should().BeEquivalentTo("123456789");
        accountFile.Entries[1].AccountNumber.Should().BeEquivalentTo("012345678");
    }
    
    [Fact]
    public void Read_Multiple_Account_Numbers_From_A_File()
    {
        using Stream stream = TestUtils.ReadEmbeddedResourceStream(@"TestData\MultipleAccountNumbers.txt");
        var accountFile = AccountFile.Read(stream);

        accountFile.Entries.Should().HaveCount(11);
        accountFile.Entries[0].AccountNumber.Should().BeEquivalentTo("000000000");
        accountFile.Entries[1].AccountNumber.Should().BeEquivalentTo("111111111");
        accountFile.Entries[2].AccountNumber.Should().BeEquivalentTo("222222222");
        accountFile.Entries[3].AccountNumber.Should().BeEquivalentTo("333333333");
        accountFile.Entries[4].AccountNumber.Should().BeEquivalentTo("444444444");
        accountFile.Entries[5].AccountNumber.Should().BeEquivalentTo("555555555");
        accountFile.Entries[6].AccountNumber.Should().BeEquivalentTo("666666666");
        accountFile.Entries[7].AccountNumber.Should().BeEquivalentTo("777777777");
        accountFile.Entries[8].AccountNumber.Should().BeEquivalentTo("888888888");
        accountFile.Entries[9].AccountNumber.Should().BeEquivalentTo("999999999");
        accountFile.Entries[10].AccountNumber.Should().BeEquivalentTo("123456789");
    }
    
    [Fact]
    public void Output_Result_File()
    {
        using Stream inputStream = TestUtils.ReadEmbeddedResourceStream(@"TestData\GoodBadIllegalAccountNumbers.txt");
        var accountFile = AccountFile.Read(inputStream);

        var outputPath = Path.GetTempFileName();
        accountFile.CreateResultFile(outputPath);
        
        string expectedOutput = TestUtils.ReadEmbeddedResourceText(@"TestData\GoodBadIllegalAccountNumbers-ExpectedOutput.txt");
        string actualOutput = File.ReadAllText(outputPath);

        actualOutput.Should().BeEquivalentTo(expectedOutput);
    }
}