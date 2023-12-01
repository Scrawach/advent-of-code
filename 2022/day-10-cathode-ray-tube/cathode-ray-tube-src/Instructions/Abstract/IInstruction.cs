using cathode_ray_tube_src.Logic.Abstract;

namespace cathode_ray_tube_src.Instructions.Abstract
{
    public interface IInstruction
    {
        InstructionResult Execute(IRegisterFile cpu);
    }
}