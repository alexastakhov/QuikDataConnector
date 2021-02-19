using QDde;
using System;
using System.ComponentModel;
using System.Windows;

namespace QuikDataConnectorSample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// DDE сервер.
        /// </summary>
        private QDde.Server ddeServer = null;

        /// <summary>
        /// Состояние сервиса.
        /// </summary>
        private bool isStarted = false;

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Имя сервиса DDE.
        /// </summary>
        public string ServiceName { get; set; }

        public bool IsStarted
        {
            get
            {
                return this.isStarted;
            }

            set
            {
                this.isStarted = value;
                this.OnPropertyChanged("IsStarted");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.ServiceName))
            {
                MessageBox.Show("Service Name should be filled", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (!this.IsStarted)
            {
                if (this.ddeServer == null)
                {
                    this.ddeServer = new QDde.Server(this.ServiceName);
                }

                this.ddeServer.Register();
                this.ddeServer.SetServerStateChangedCallback(OnServerStateChanged);
                this.ddeServer.SetPokeCallback(OnPoke);
                this.IsStarted = true;

                this.PrintLog($"DDE Server Server Started. Service Name : \"{this.ddeServer.ServiceName}\"");
            }
            else
            {
                this.ddeServer.Disconnect();

                this.PrintLog($"DDE Server Server Stopped. Service Name : \"{this.ddeServer.ServiceName}\"");

                this.ddeServer.Dispose();
                this.ddeServer = null;
                this.IsStarted = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Вывести сообщение в лог.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="logType">Тип логгирования.</param>
        private void PrintLog(string message, LogType logType = LogType.Common)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<string, LogType>(PrintLog), new object[] { message, logType });

                return;
            }

            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var messageToLog = timestamp + " | " + message + "\n";

            if (logType == LogType.Common)
            {
                this.commonLogOutBox.AppendText(messageToLog);
            }
            else if (logType == LogType.DataTypes)
            {
                this.dataTypesOutBox.AppendText(messageToLog);
            }
            else if (logType == LogType.DataValues)
            {
                this.dataValuesOutBox.AppendText(messageToLog);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (this.ddeServer != null)
            {
                this.ddeServer.Disconnect();
                this.ddeServer.Dispose();
            }
        }

        /// <summary>
        /// Обратный вызов изменения состояния сервера.
        /// </summary>
        /// <param name="oldState">Текущее состояние.</param>
        /// <param name="newState">Новое состояние.</param>
        private void OnServerStateChanged(ServerState oldState, ServerState newState)
        {
            this.PrintLog($"Server state changed \"{oldState}\" --> \"{newState}\"");
        }

        /// <summary>
        /// Обратный вызов получения данных.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="isPaused"></param>
        /// <param name="serviceName"></param>
        /// <param name="topic"></param>
        /// <param name="tag"></param>
        /// <param name="item"></param>
        /// <param name="data"></param>
        private void OnPoke(IntPtr handle, bool isPaused, string serviceName, string topic, object tag, string item, byte[] data)
        {
            this.PrintLog($"OnPoke", LogType.DataValues);
        }

        /// <summary>
        /// Типы логов, для выбора окна логгирования.
        /// </summary>
        private enum LogType
        {
            Common,
            DataTypes,
            DataValues
        }
    }
}
