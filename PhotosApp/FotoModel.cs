using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotosApp
{
    public class FotoModel
    {
        public FotoModel()
        {

        }
        public int Id { get; set; }
        public Geolocator Location { get; set; }
        public string Comment { get; set; }
        public DateTime DateTaken { get; set; }
        public ObservableCollection<string> Images { get; set; } = new ObservableCollection<string>();

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

                        //  Images.Add(new Image() {Height=100, Width=100,  Source = new BitmapImage(new Uri(imgCopy.Path)) });
                        //Images.Add(imgCopy );
                        Images.Add(imgCopy.Path);
                    }

                    //if mp3
                    if (type == "audio/wav" || type == "audio/mpeg")
                    {
                        StorageFile musicFile = await selected.CopyAsync(ApplicationData.Current.LocalFolder);
                        player.SetSource(await musicFile.OpenAsync(FileAccessMode.Read), type);
                        player.AutoPlay = true;
                        //player.SetSource()
                    }

                }
            }
        }

        private void Border_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }
    }
}
    
}