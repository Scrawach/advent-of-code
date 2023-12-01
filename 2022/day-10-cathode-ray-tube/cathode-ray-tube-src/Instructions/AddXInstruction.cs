using cathode_ray_tube_src.Instructions.Abstract;
using cathode_ray_tube_src.Logic.Abstract;

namespace cathode_ray_tube_src.Instructions
{
    public class AddXInstruction : IInstruction
    {
        private const int Duration = 2;
        
        private readonly int _value;
        private int _elapsedCycles;

        public AddXInstruction(int value) =>
            _value = value;
        
        public InstructionResult Execute(IRegisterFile cpu)
        {
            _elapsedCycles++;

            if (_elapsedCycles < Duration) 
                return InstructionResult.Processed;
            
            cpu.RegisterX += _value;
            return InstructionResult.Finished;
        }
    }
}