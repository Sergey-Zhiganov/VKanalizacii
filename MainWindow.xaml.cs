using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;

namespace ВКанализации
{
    public partial class MainWindow
    {
        private const string EmptyField = "";
        public static User user;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        //Имя != sys
        //Имя только из букв и цифр
        //Уникальное имя
        //Проверки на IP (по возможности)
        private void CreateChat(object sender, RoutedEventArgs e)
        {
            if (Username.Text == EmptyField) MessageBox.Show("Заполните имя пользователя!");
            else
            { 
                user = new User(Username.Text);
                var server = new Server();
                server.Show();
                Close();
            }
        }
        private void JoinChat(object sender, RoutedEventArgs e)
        {
            if (Username.Text == EmptyField || IpAddress.Text == "") MessageBox.Show("Проверьте заполненность имени или введенный IP адрес");
            else
            {
                user = new User(Username.Text, IpAddress.Text);
                Client.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    Client.socket.Connect(IpAddress.Text, 7000);
                    var client = new Client();
                    client.Show();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось подключиться к серверу");
                }
            }
        }
    }
}