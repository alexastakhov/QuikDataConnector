using System.Windows;

namespace QuikDataConnectorSample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

            if (this.ddeServer == null)
            {
                this.ddeServer = new QDde.Server(this.ServiceName);
            }

            this.isStarted = true;

            this.ddeServer.Register();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.isStarted)
            {
                MessageBox.Show("Service alredy stopped", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            this.isStarted = false;
        }
    }
}
