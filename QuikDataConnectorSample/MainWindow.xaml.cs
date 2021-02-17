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
                this.IsStarted = true;

                this.PrintLog($"DDE Server Server Started. Service Name : \"{this.ServiceName}\"");
            }
            else
            {
                this.ddeServer.Disconnect();
                this.ddeServer.Dispose();
                this.ddeServer = null;
                this.IsStarted = false;

                this.PrintLog("DDE Server Server Stopped. Service Name : \"{this.ServiceName}\"");
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
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void PrintLog(string message)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            this.commonLogOutBox.AppendText(timestamp + " | " + message + "\n");
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
    }
}
