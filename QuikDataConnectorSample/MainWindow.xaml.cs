using QDde;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;

namespace QuikDataConnectorSample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Каталог с файлами логов двнных.
        /// </summary>
        private const string LogFolderName = "DataLog";

        /// <summary>
        /// Префикс файла логов с данными DDE.
        /// </summary>
        private const string LogFilePrefix = "DdeData";

        /// <summary>
        /// DDE сервер.
        /// </summary>
        private QDde.Server ddeServer = null;

        /// <summary>
        /// Состояние сервиса.
        /// </summary>
        private bool isStarted = false;

        /// <summary>
        /// Записывать ли данные в файл.
        /// </summary>
        private bool isSaveToFile = true;

        /// <summary>
        /// Текущее имя файла для записи логов.
        /// </summary>
        private string currentLogFileName;

        /// <summary>
        /// Активен ли поток записи в файл.
        /// </summary>
        private bool isSaveToFileActive;

        /// <summary>
        /// Поток записи логов в файл.
        /// </summary>
        private Thread savingLogToFileThread;

        /// <summary>
        /// Очередь сообщений для записи в лог.
        /// </summary>
        private ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();

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

        /// <summary>
        /// Запущен ли сервер.
        /// </summary>
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
        /// Записывать ли данные в файл.
        /// </summary>
        public bool IsSaveToFile
        {
            get
            {
                return this.isSaveToFile;
            }

            set
            {
                this.isSaveToFile = value;
            }
        }

        /// <summary>
        /// Обработка надатия кнопки Start/Stop.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Параметр вызова.</param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.ServiceName))
            {
                MessageBox.Show("Service Name should be filled", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            if (!this.IsStarted)
            {
                if (this.isSaveToFile)
                {
                    if (!Directory.Exists(LogFolderName))
                    {
                        Directory.CreateDirectory(LogFolderName);
                    }

                    this.logQueue = new ConcurrentQueue<string>();
                    this.currentLogFileName = LogFilePrefix + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                    this.isSaveToFileActive = true;
                    this.savingLogToFileThread = new Thread(new ThreadStart(SaveLogToFileThreadEntry));
                    this.savingLogToFileThread.Start();
                }
                else
                {
                    this.savingLogToFileThread = null;
                    this.isSaveToFileActive = false;
                }

                if (this.ddeServer == null)
                {
                    this.ddeServer = new QDde.Server(this.ServiceName);
                }

                this.ddeServer.Register();
                this.ddeServer.SetServerStateChangedCallback(OnServerStateChanged);
                this.ddeServer.SetPokeCallback(OnPoke);
                this.IsStarted = true;

                this.PrintLog($"DDE server Started. Service Name : \"{this.ddeServer.ServiceName}\"");

                if (this.isSaveToFile)
                {
                    this.PrintLog($"Received data will be written to file : \"{this.currentLogFileName}\"");
                }
            }
            else
            {
                if (this.savingLogToFileThread != null)
                {
                    this.isSaveToFileActive = false;

                    if (!this.savingLogToFileThread.Join(1000))
                    {
                        this.savingLogToFileThread.Abort();
                    }
                }

                this.ddeServer.Disconnect();

                this.PrintLog($"DDE Server Server Stopped. Service Name : \"{this.ddeServer.ServiceName}\"");

                this.ddeServer.Dispose();
                this.ddeServer = null;
                this.IsStarted = false;
            }
        }

        /// <summary>
        /// Сгенерировать событие обновления свойства.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Записать данные в файл.
        /// </summary>
        /// <param name="service">Имя сервиса.</param>
        /// <param name="topic">Топик сообщения.</param>
        /// <param name="item">Область таблицы.</param>
        /// <param name="data">Сырые данные таблицы.</param>
        private void SaveDataToFile(string service, string topic, string item, byte[] data)
        {
            if (!this.isSaveToFile)
            {
                return;
            }

            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var outString = $"{time} | Service: {service}, Topic: {topic} | {item} | Data: {this.BytesToString(data)}";

            this.logQueue.Enqueue(outString);
        }

        /// <summary>
        /// Преобразовать массив байт в строку.
        /// </summary>
        /// <param name="data">Массив байт.</param>
        /// <returns>Строка, представляющая массив байт.</returns>
        private string BytesToString(byte[] data)
        {
            StringBuilder hexString = new StringBuilder(data.Length * 2);

            foreach (byte b in data)
            {
                hexString.AppendFormat("{0:X2}", b);
                hexString.Append(" ");
            }

            return hexString.ToString().Trim();
        }

        /// <summary>
        /// Нить потока записи логов в файл. 
        /// </summary>
        private void SaveLogToFileThreadEntry()
        {
            using (var sw = new StreamWriter(new FileStream(Path.Combine(LogFolderName, this.currentLogFileName), FileMode.Create)))
            {
                while (this.isSaveToFileActive)
                {
                    if (this.logQueue.TryDequeue(out var itemToWrite))
                    {
                        sw.WriteLine(itemToWrite);
                    }

                    Thread.Sleep(2);
                }

                sw.Flush();
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
                this.commonLogOutBox.ScrollToEnd();
            }
            else if (logType == LogType.DataTypes)
            {
                this.dataTypesOutBox.AppendText(messageToLog);
                this.dataTypesOutBox.ScrollToEnd();
            }
            else if (logType == LogType.DataValues)
            {
                this.dataValuesOutBox.AppendText(messageToLog);
                this.dataValuesOutBox.ScrollToEnd();
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
            this.SaveDataToFile(serviceName, topic, item, data);
            this.PrintLog($"OnPoke : Topic={topic} Item={item} dataLen={data.Length}", LogType.DataValues);
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
