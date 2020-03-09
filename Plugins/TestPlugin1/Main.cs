using ErisLib;
using ErisLib.Interfaces;
using ErisLib.Server;
using ErisLib.Utilities;

namespace TestPlugin1
{
    public class Main : IPlugin
    {
        public string Author() => "Azuki";

        public string Name() => "Test Plugin";

        public string Description() => "Supposed to test plugin implementation";

        public string[] Commands() => new[] {"/test"};

        public void Initialize(Proxy proxy)
        {
            proxy.HookCommand("/test", OnTest);
        }

        private void OnTest(Client client, string command, string[] args)
        {
            client.SendToClient(
                PluginUtilities.CreateNotification(client.ObjectId, 0x00F20A, args[0]));
        }
    }
}