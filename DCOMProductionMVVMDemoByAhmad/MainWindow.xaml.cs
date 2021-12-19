using DCOMProduction.MVVMDemo.byAhmad.ViewModels;
using System.Windows;

namespace DCOMProduction.MVVMDemo.byAhmad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
        }
    }
}
