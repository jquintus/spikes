namespace FunWithNinject
{
    public interface IMyServiceFactory
    {
        MyService Create(string name);
    }
}