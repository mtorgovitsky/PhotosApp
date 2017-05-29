using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotosApp
{
    public class photoViewModel
    {
        public ObservableCollection<photoModel> Images { get; set; } = new ObservableCollection<photoModel>();
        
      

      public  void AddPhoto(string  img)
        {
           // Images.Add();
        }
    }
    
}
