using monkey_in_the_middle_src.Logic;

namespace monkey_in_the_middle_src.Factory.Abstract
{
    public interface IMonkeyBusinessFactory
    {
        MonkeyBusiness FirstTask();
        MonkeyBusiness SecondTask();
    }
}