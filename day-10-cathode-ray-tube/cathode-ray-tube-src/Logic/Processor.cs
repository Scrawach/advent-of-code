using cathode_ray_tube_src.Instructions;
using cathode_ray_tube_src.Logic.Abstract;
using cathode_ray_tube_src.Storages.Abstract;

namespace cathode_ray_tube_src.Logic
{
    public class Processor : IRegisterFile
    {
        private readonly IInstructionMemory _memory;
        private readonly IWaitCycle _waitCycle;

        public Processor(IInstructionMemory memory, IWaitCycle waitCycle)
        {
            _memory = memory;
            _waitCycle = waitCycle;
            RegisterX = 1;
        }

        public int RegisterX { get; set; }

        public void Execute()
        {
            var numberOfCycle = 1;
            _waitCycle.OnCycleDone(numberOfCycle, RegisterX);
            
            foreach (var instruction in _memory.All())
            {
                var result = InstructionResult.Unknown;
                
                while (result != InstructionResult.Finished)
                {
                    result = instruction.Execute(this);
                    numberOfCycle++;
                    _waitCycle.OnCycleDone(numberOfCycle, RegisterX);
                }
            }
        }
    }
}