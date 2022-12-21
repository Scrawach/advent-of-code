using monkey_in_the_middle_src.Logic.Modifiers.Abstract;

namespace monkey_in_the_middle_src.Logic.Modifiers
{
    public class ModuleWorryModifier : IWorryLevelModifier
    {
        private readonly long _module;

        public ModuleWorryModifier(long module) =>
            _module = module;
        
        public long Calculate(long worry) =>
            worry % _module;
    }
}