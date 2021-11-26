namespace Autofac.EasyPropInject.Testing.mocks
{
    public interface IMock4
    {
        bool Ok();
    }

    public class Mock4 : IMock4
    {
        public bool Ok()
        {
            return true;
        }
    }
}