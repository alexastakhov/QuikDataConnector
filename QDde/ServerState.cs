namespace QDde
{
    /// <summary>
    /// Состояние сервера.
    /// </summary>
    public enum ServerState
    {
        /// <summary>
        /// Не определен.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// Сервер не подключен.
        /// </summary>
        Disconnected = 1,

        /// <summary>
        /// Сервер подключен.
        /// </summary>
        Connected = 2,

        /// <summary>
        /// Сервер зарегистрирован.
        /// </summary>
        Registered = 3,

        /// <summary>
        /// Сервер не зарегистрирован.
        /// </summary>
        Unregistered = 4,

        /// <summary>
        /// Сервер приостановлен.
        /// </summary>
        Paused = 5,
    }
}