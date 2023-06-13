using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

         private void service_start_Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            
            
            
            var response = client.GetStringAsync("http://localhost:12577/Square?value=5");
                          
            //service_start_Button.Content = "Stop";
            textbox_number.Text = response.Result;
        }
    }
}
