using cathode_ray_tube_src.Instructions.Abstract;
using cathode_ray_tube_src.Logic.Abstract;

namespace cathode_ray_tube_src.Instructions
{
    public class NoOperationInstruction : IInstruction
    {
        public InstructionResult Execute(IRegisterFile cpu) =>
            InstructionResult.Finished;
    }
}