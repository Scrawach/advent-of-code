using System;
using System.IO;
using System.Linq;
using monkey_in_the_middle_src.Extensions;
using monkey_in_the_middle_src.Factory.Abstract;
using monkey_in_the_middle_src.Logic;
using monkey_in_the_middle_src.Logic.Modifiers;
using monkey_in_the_middle_src.Storages;
using monkey_in_the_middle_src.Storages.Abstract;

namespace monkey_in_the_middle_src.Factory
{
    public class MonkeyBusinessFactory : IMonkeyBusinessFactory
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
        
        private readonly string _fileName;

        public MonkeyBusinessFactory(string fileName) =>
            _fileName = fileName;
        
        public MonkeyBusiness FirstTask() =>
            CreateBusiness(new MonkeyParser(new DivideWorryModifier(3)));

        public MonkeyBusiness SecondTask()
        {
            var text = CreateText();
            var gcd = FindGreatestCommonDivisor("Test", text);
            return CreateBusiness(new MonkeyParser(new ModuleWorryModifier(gcd)));
        }

        private MonkeyBusiness CreateBusiness(IMonkeyParser parser)
        {
            var text = CreateText();
            var storage = new MonkeyTextStorage(text, parser);
            var business = new MonkeyBusiness(storage.All().ToArray(), 2);
            return business;
        }

        private Text CreateText()
        {
            var path = Path.Combine(WorkingDirectory, _fileName);
            var text = new Text(path);
            return text;
        }

        private static long FindGreatestCommonDivisor(string tag, IText text) =>
            text
                .Lines()
                .Where(line => line.Contains(tag))
                .Select(line => line.Split(' ').Last())
                .Multiply(line => int.Parse((string) line));
    }
}