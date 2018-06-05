using AsyncAwaitSample.Helpers;
using AsyncAwaitSample.Models;
using AsyncAwaitSample.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncAwaitSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            TextBoxTraceListener listener = new TextBoxTraceListener(txtLog);

            Debug.Listeners.Add(listener);

            //Debug.WriteLine($"Start app on thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private void OnGetDataWithTaskClicked(object sender, RoutedEventArgs e)
        {
            var task = DataService.Instance.GetData("http://www.yahoo.com");

            
            task.ContinueWith(prevTask =>
            {
                
                var result = prevTask.Result;

                AddListBoxItem(result);

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void OnGetDataWithAsyncClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await DataService.Instance.GetData("http://www.yahoo.com");

                AddListBoxItem(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void OnRunLongOperationClicked(object sender, RoutedEventArgs e)
        {
            DataService.Instance.RunLongOperations();

        }


        private void AddListBoxItem(WebResult result)
        {
            Debug.WriteLine($"Add items on thread: {Thread.CurrentThread.ManagedThreadId}");
            listBox.Items.Add(result);
        }
    }
}
