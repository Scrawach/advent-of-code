using System;
using System.IO;
using cathode_ray_tube_src.Logic;
using cathode_ray_tube_src.Logic.Abstract;
using cathode_ray_tube_src.Logic.Strengths;
using cathode_ray_tube_src.Storages;

namespace cathode_ray_tube_src.Factory
{
    public class SolvesFactory
    {
        private static readonly string Directory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];

        private readonly string _fileName;

        public SolvesFactory(string fileName) =>
            _fileName = fileName;
        
        public Processor CreateProcessor(IWaitCycle waitCycle)
        {
            var path = Path.Combine(Directory, _fileName);
            var instructions = new InstructionTextMemory(new Text(path));
            return new Processor(instructions, waitCycle);
        }

        public StrengthCounter CreateCounter()
        {
            var accumulate = new SumCalculatePolicies(new MultiplyByNumberOfCycle(20), new MultiplyByNumberOfCycle(60), 
                new MultiplyByNumberOfCycle(100), new MultiplyByNumberOfCycle(140), new MultiplyByNumberOfCycle(180),
                new MultiplyByNumberOfCycle(220));
            var counter = new StrengthCounter(accumulate);
            return counter;
        }

        public Tube CreateTube() =>
            new Tube();
    }
}