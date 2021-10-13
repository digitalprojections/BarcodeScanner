using System.Windows;
using System.Diagnostics;

namespace BarcodeScanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();

           

            Debug.Write("button " + add_btn.Name);
        }
    }
}
