using System;
using System.Collections.Generic;
using System.Linq;
using supply_stacks_src.Storages.Abstract;

namespace supply_stacks_src.Storages
{
    public class InitialTextStorage
    {
        private readonly IText _text;
        
        public InitialTextStorage(IText text) =>
            _text = text;

        public Stack<char>[] InitialState()
        {
            var listOfSymbols = new List<List<char>>();
            
            foreach (var line in _text.Lines())
            {
                if (string.IsNullOrWhiteSpace(line))
                    break;
                
                var content = ParseLine(line);
                UpdateListOfSymbols(content, listOfSymbols);
            }

            return listOfSymbols
                .PerItemReverse()
                .Select(list => new Stack<char>(list))
                .ToArray();
        }

        private static void UpdateListOfSymbols(IReadOnlyList<char> content, List<List<char>> listOfSymbols)
        {
            for (var i = 0; i < content.Count; i++)
            {
                if (listOfSymbols.Count == 0)
                    listOfSymbols.FillEmpties(content.Count);

                if (char.IsLetter(content[i]))
                    listOfSymbols[i].Add(content[i]);
            }
        }

        private static char[] ParseLine(string line)
        {
            var symbols = new List<char>();
            var whitespaces = 0;

            foreach (var symbol in line)
            {
                switch (symbol)
                {
                    case '[':
                    case ']':
                        continue;
                    case ' ':
                        whitespaces++;

                        if (whitespaces == 4)
                        {
                            symbols.Add(new char());
                            whitespaces = 0;
                        }

                        break;
                    default:
                        whitespaces = 0;
                        symbols.Add(symbol);
                        break;
                }
            }

            return symbols.ToArray();
        }
    }
}