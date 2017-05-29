using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhotosApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // public PhotosApp.photoViewModel VM { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            //DataContext = new photoViewModel();
            //  VM = new PhotosApp.photoViewModel();
        }
        public void HmburgerMenu()
        {
            mySplit.IsPaneOpen = !mySplit.IsPaneOpen;

        }
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

            if (MainAppFrame.CanGoForward)
            {
                MainAppFrame.GoForward();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                ListBox lb = sender as ListBox;

                switch (lb.SelectedIndex)
                {
                    case 0:
                        {
                            // MainAppFrame.Navigate(typeof(Home));
                            break;
                        }

                    case 1:
                        {
                            VM.Camera();
                            break;
                        }
                    case 2:
                        {
                            // MainAppFrame.Navigate(typeof(FavoritePage));
                            break;
                        }
                    case 3:
                        {
                           // Toggle_Click();
                            break;
                        }
                    case 4:
                        {
                            RunAsyncDialog();
                            break;
                        }
                }
            }
        }
        private async void RunAsyncDialog()
        {
            MessageDialog closDilog = new MessageDialog("");
            closDilog.Title = "Closing Confirmation";
            closDilog.Content = "are you sure about it ?";
            closDilog.Commands.Add(new UICommand() { Id = 0, Label = "Yes" });
            closDilog.Commands.Add(new UICommand() { Id = 1, Label = "No" });

            IUICommand res = await closDilog.ShowAsync();
            if ((int)res.Id == 0)
            {
                Application.Current.Exit();
            }

        }
        private async void Border_Drop(object sender, DragEventArgs e)
        {
            // dataview is snoop in to the file..
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                //any file (>0)
                if (items.Any())
                {
                    StorageFile selected = items[0] as StorageFile;
                    var type = selected.ContentType;
                    //if image
                    if (type == "image/jpeg")
                    {
                        var imgCopy = await selected.CopyAsync(ApplicationData.Current.LocalFolder, selected.Name, NameCollisionOption.ReplaceExisting);
                        img.Source = new BitmapImage(new Uri(imgCopy.Path));

                        VM.Images.Add(new photoModel() { Path = new BitmapImage(new Uri(imgCopy.Path)) });
                        //Images.Add(imgCopy );
                        //VM.Images.Add(imgCopy.Path);
                    }
                }
            }
        }

        private void Border_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

       

        private void Toggle_Toggled(object sender, RoutedEventArgs e)
        {

            if (this.RequestedTheme.ToString() == ElementTheme.Light.ToString())
            {
                this.RequestedTheme = ElementTheme.Dark;

            }
            else
            {
                this.RequestedTheme = ElementTheme.Light;

            }
        }
    }
}
