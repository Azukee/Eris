namespace ErisLib.Interfaces
{
    public interface IPlugin
    {
        string Author();
        string Name();
        string Description();
        string[] Commands();

        void Initialize(Proxy proxy);
    }
}