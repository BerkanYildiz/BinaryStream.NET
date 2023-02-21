namespace BinaryStream.NET.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using global::BinaryStream.NET;
    using global::BinaryStream.NET.Extensions;

    internal static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="InArgs">The arguments.</param>
        private static void Main(string[] InArgs)
        {
            using var Stream = new FileStream(Path.GetTempFileName(), FileMode.Create, FileAccess.ReadWrite);
            Stream.WriteArray<int>(Enumerable.Range(1, 10).ToArray(), (Stream, Value) => Stream.WriteInteger(Value));
            Stream.WriteEnumerable<int>(Enumerable.Range(1, 15), (Stream, Value) => Stream.WriteInteger(Value));
            Stream.WriteCollection<int>(Enumerable.Range(1, 20).ToList(), (Stream, Value) => Stream.WriteInteger(Value));

            Stream.Seek(0, SeekOrigin.Begin);
            var ArrayOfNumbers = Stream.ReadArray<int>(_ => _.ReadInteger());
            var EnumerableOfNumbers = Stream.ReadEnumerable<int>(_ => _.ReadInteger());

            var OldPosition = Stream.Position;
            var CollectionOfNumbers = Stream.ReadCollection<int>(_ => _.ReadInteger());
            Stream.Position = OldPosition;
            var ListOfNumbers = Stream.ReadCollection<List<int>, int>(_ => _.ReadInteger());

            Console.WriteLine($"Array      [{ArrayOfNumbers.LongLength}] => {{ " + string.Join(", ", ArrayOfNumbers) + " }");
            Console.WriteLine($"Enumerable [{EnumerableOfNumbers.Count()}] => {{ " + string.Join(", ", EnumerableOfNumbers) + " }");
            Console.WriteLine($"Collection [{CollectionOfNumbers.Count}] => {{ " + string.Join(", ", CollectionOfNumbers) + " }");
            Console.WriteLine($"List       [{ListOfNumbers.Count}] => {{ " + string.Join(", ", ListOfNumbers) + " }");
            Console.WriteLine();
            Console.WriteLine($"Array      [{ArrayOfNumbers.LongLength}] => " + ArrayOfNumbers.GetType().Name);
            Console.WriteLine($"Enumerable [{EnumerableOfNumbers.Count()}] => " + EnumerableOfNumbers.GetType().Name);
            Console.WriteLine($"Collection [{CollectionOfNumbers.Count}] => " + CollectionOfNumbers.GetType().Name);
            Console.WriteLine($"List       [{ListOfNumbers.Count}] => " + ListOfNumbers.GetType().Name);
            
            Console.ReadKey();
        }
    }
}
