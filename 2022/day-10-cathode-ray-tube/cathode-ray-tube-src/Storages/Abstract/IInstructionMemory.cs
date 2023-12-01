using System.Collections.Generic;
using cathode_ray_tube_src.Instructions.Abstract;

namespace cathode_ray_tube_src.Storages.Abstract
{
    public interface IInstructionMemory
    {
        IEnumerable<IInstruction> All();
    }
}