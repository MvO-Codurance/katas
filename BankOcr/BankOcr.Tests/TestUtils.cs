using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace BankOcr.Tests;

public static class TestUtils
{
    public static Stream ReadEmbeddedResourceStream(string filePath)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Stream? stream = new EmbeddedFileProvider(assembly).GetFileInfo(filePath)?.CreateReadStream();
        if (stream == null)
        {
            throw new FileNotFoundException("Could not retrieve embedded file resource from " + assembly.FullName, filePath);
        }

        return stream;
    }
    
    public static string ReadEmbeddedResourceText(string filePath)
    {
        using Stream expectedOutputStream = ReadEmbeddedResourceStream(filePath);
        using StreamReader expectedOutputReader = new StreamReader(expectedOutputStream);
        return expectedOutputReader.ReadToEnd();
    }
}