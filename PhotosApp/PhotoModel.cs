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
    public class photoModel
    {
        public photoModel()
        {

        }
        public int Id { get; set; }
        public Geolocator Location { get; set; }
        public string Comment { get; set; }
        public DateTime DateTaken { get; set; }
        public BitmapImage Path { get; set; }
       
    }

}