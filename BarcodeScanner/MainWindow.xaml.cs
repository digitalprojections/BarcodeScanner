using System.Windows;
using System.Diagnostics;
using BarcodeScanner.DATABASE;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using BarcodeScanner.Views;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

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
            
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CustomerWindow();
            dlg.Show();
        }


    }

    [System.Windows.Localizability(System.Windows.LocalizationCategory.None, Readability = System.Windows.Readability.Unreadable)]
    [System.Windows.Markup.DictionaryKeyProperty("TargetType")]
    public class ControlTemplate : FrameworkTemplate
    {

    }
}
