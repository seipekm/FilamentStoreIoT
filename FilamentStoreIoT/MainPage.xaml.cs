using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace FilamentStoreIoT
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Start Task that updates time
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Low,
                    () =>
                    {
                        Lbl_Time.Text = DateTime.Now.ToString("HH:mm");
                        Lbl_Date.Text = DateTime.Now.ToString("dd.MMMM.yyyy");
                    });
                    await Task.Delay(1000);
                }
            });
        }

        private void Btn_Home_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame_Main.Visibility = Visibility.Collapsed;
            Lbl_Time.Visibility = Visibility.Visible;
            Lbl_Date.Visibility = Visibility.Visible;
        }

        private void Btn_ShowRooms_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Btn_ShowConfiguration_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame_Main.Visibility = Visibility.Visible;
            Lbl_Time.Visibility = Visibility.Collapsed;
            Lbl_Date.Visibility = Visibility.Collapsed;

            Pages.Page_Configuration _PC = new Pages.Page_Configuration();
            Frame_Main.Navigate(_PC.GetType());
        }

        private void Frame_Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Frame_Main_Navigating(object sender, NavigatingCancelEventArgs e)
        {

        }
    }
}
