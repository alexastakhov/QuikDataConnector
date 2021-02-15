using NDde.Server;

namespace QDde
{
    public class Server : DdeServer
    {
        public Server(string serviceName) : base(serviceName)
        {
        }

        public override string Service => base.Service;

        public override bool IsRegistered => base.IsRegistered;

        public override void Advise(string topic, string item)
        {
            base.Advise(topic, item);
        }

        public override void Disconnect(DdeConversation conversation)
        {
            base.Disconnect(conversation);
        }

        public override void Disconnect()
        {
            base.Disconnect();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Pause(DdeConversation conversation)
        {
            base.Pause(conversation);
        }

        public override void Pause()
        {
            base.Pause();
        }

        public override void Register()
        {
            base.Register();
        }

        public override void Resume(DdeConversation conversation)
        {
            base.Resume(conversation);
        }

        public override void Resume()
        {
            base.Resume();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Unregister()
        {
            base.Unregister();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override byte[] OnAdvise(string topic, string item, int format)
        {
            return base.OnAdvise(topic, item, format);
        }

        protected override void OnAfterConnect(DdeConversation conversation)
        {
            base.OnAfterConnect(conversation);
        }

        protected override bool OnBeforeConnect(string topic)
        {
            return base.OnBeforeConnect(topic);
        }

        protected override void OnDisconnect(DdeConversation conversation)
        {
            base.OnDisconnect(conversation);
        }

        protected override ExecuteResult OnExecute(DdeConversation conversation, string command)
        {
            return base.OnExecute(conversation, command);
        }

        protected override PokeResult OnPoke(DdeConversation conversation, string item, byte[] data, int format)
        {
            return base.OnPoke(conversation, item, data, format);
        }

        protected override RequestResult OnRequest(DdeConversation conversation, string item, int format)
        {
            return base.OnRequest(conversation, item, format);
        }

        protected override bool OnStartAdvise(DdeConversation conversation, string item, int format)
        {
            return base.OnStartAdvise(conversation, item, format);
        }

        protected override void OnStopAdvise(DdeConversation conversation, string item)
        {
            base.OnStopAdvise(conversation, item);
        }
    }
}