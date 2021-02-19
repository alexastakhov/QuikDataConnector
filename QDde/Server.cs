using NDde.Server;
using System;

namespace QDde
{
    /// <summary>
    /// Делегат обратного вызова изменения состояния сервера.
    /// </summary>
    /// <param name="oldState"></param>
    /// <param name="newState"></param>
    public delegate void ServerStateChangedCallback(ServerState oldState, ServerState newState);

    /// <summary>
    /// Делегат обратного вызова получения данных.
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="isPaused"></param>
    /// <param name="serviceName"></param>
    /// <param name="topic"></param>
    /// <param name="tag"></param>
    /// <param name="item"></param>
    /// <param name="data"></param>
    public delegate void PokeCallback(IntPtr handle, bool isPaused, string serviceName, string topic, object tag, string item, byte[] data);

    /// <summary>
    /// Класс DDE сервера.
    /// </summary>
    public class Server : DdeServer
    {
        /// <summary>
        /// Обратный вызов изменения состояния сервера.
        /// </summary>
        private ServerStateChangedCallback serverStateChangedCallback = null;

        /// <summary>
        /// Обратный вызов получения данных.
        /// </summary>
        private PokeCallback pokeCallback = null;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        /// <param name="serviceName">Имя сервиса.</param>
        public Server(string serviceName) : base(serviceName)
        {
            this.State = ServerState.Unspecified;
        }

        /// <summary>
        /// Имя сервиса.
        /// </summary>
        public string ServiceName => base.Service;

        /// <summary>
        /// Флаг регистрации сервиса.
        /// </summary>
        public override bool IsRegistered => base.IsRegistered;

        /// <summary>
        /// Состояние сервера.
        /// </summary>
        public ServerState State { get; private set; }

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

        /// <summary>
        /// Установить обратный вызов изменения состояния сервера.
        /// </summary>
        /// <param name="callback">Обратный вызов.</param>
        public void SetServerStateChangedCallback(ServerStateChangedCallback callback)
        {
            if (callback == null)
            {
                throw new ArgumentException("ServerStateChangedCallback cannot be NULL");
            }

            this.serverStateChangedCallback = callback;
        }

        /// <summary>
        /// Установить обратный вызов получения данных.
        /// </summary>
        /// <param name="callback">Обратный вызов.</param>
        public void SetPokeCallback(PokeCallback callback)
        {
            if (callback == null)
            {
                throw new ArgumentException("PokeCallback cannot be NULL");
            }

            this.pokeCallback = callback;
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

            this.SetState(ServerState.Connected);
        }

        protected override bool OnBeforeConnect(string topic)
        {
            return base.OnBeforeConnect(topic);
        }

        protected override void OnDisconnect(DdeConversation conversation)
        {
            base.OnDisconnect(conversation);

            this.SetState(ServerState.Disconnected);
        }

        protected override ExecuteResult OnExecute(DdeConversation conversation, string command)
        {
            return base.OnExecute(conversation, command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="item"></param>
        /// <param name="data"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        protected override PokeResult OnPoke(DdeConversation conversation, string item, byte[] data, int format)
        {
            if (this.pokeCallback != null)
            {
                this.pokeCallback.Invoke(
                    conversation.Handle,
                    conversation.IsPaused,
                    conversation.Service,
                    conversation.Topic,
                    conversation.Tag,
                    item,
                    data);
            }
            
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

        /// <summary>
        /// Установить состояние сервера.
        /// </summary>
        /// <param name="state">Новое состояние сервера.</param>
        private void SetState(ServerState newState)
        {
            if (this.serverStateChangedCallback != null)
            {
                this.serverStateChangedCallback.Invoke(this.State, newState);
            }

            this.State = newState;
        }
    }
}