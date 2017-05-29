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
    public class FhotoViewModel
    {
        public ObservableCollection<FhotoModel> Images { get; set; } = new ObservableCollection<FhotoModel>();



        void AddFhoto(FhotoModel Img)
        {
            Images.Add(Img);
        }
    }
    
}
