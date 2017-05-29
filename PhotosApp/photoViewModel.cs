using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotosApp
{
    public class PhotoViewModel
    {
        public ObservableCollection<photoModel> Images { get; set; } = new ObservableCollection<photoModel>();



        public void AddPhoto()
        {
            // Images.Add();
        }
        public async void Camera()
        {
            // initiate camera app
            CameraCaptureUI cam = new CameraCaptureUI();
            cam.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
          //cam.PhotoSettings.CroppedAspectRatio = new Size(200, 200);
            StorageFile imageFile = await cam.CaptureFileAsync(CameraCaptureUIMode.Photo);
           //  img.Source = new BitmapImage(new Uri(imageFile.Path));
            // locationTxt.Text = imageFile.Path;
        }

    }
}
