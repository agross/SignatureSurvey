using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SignatureSurvey
{
  class Program
  {
    enum ExitCode
    {
      Success = 0,
      FileNotFound = 1,
      GenericError = 2
    }

    static readonly char[] Chars = { '{', '}', ';' };

    static void Main(string[] args)
    {
      try
      {
        var path = GetPathToFile(args);
        Inspect(path);

        Environment.Exit((int) ExitCode.Success);
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
        Environment.Exit((int) ExitCode.GenericError);
      }
    }

    static string GetPathToFile(string[] args)
    {
      if (args.Length < 1)
      {
        Console.WriteLine("Please pass a file to parse as the first command line argument.");
        Environment.Exit((int) ExitCode.FileNotFound);
      }

      var path = args[0];
      if (!File.Exists(path))
      {
        Console.WriteLine("File '{0}' does not exist.", path);
        Environment.Exit((int) ExitCode.FileNotFound);
      }
      return path;
    }

    static void Inspect(string path)
    {
      using (var stream = File.OpenRead(path))
      {
        var pattern = new StringBuilder();
        var lines = 1;

        for (var i = 0; i < stream.Length; i++)
        {
          var c = (char) stream.ReadByte();
          if (Chars.Contains(c))
          {
            pattern.Append(c);
          }
          if (c == Environment.NewLine.Last())
          {
            lines = lines + 1;
          }
        }

        Console.WriteLine("{0,4} {1} {2}", lines, path, pattern);
      }
    }
  }
}
