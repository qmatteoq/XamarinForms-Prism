using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Web.Http;
using InfoSeries.Services;
using InfoSeries.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpShareService))]
namespace InfoSeries.UWP.Services
{
    public class UwpShareService: IShareService
    {
        private string _title;
        private string _image;

        public async Task ShareShirt(string title, string image)
        {
            _title = title;
            _image = image;

            DataTransferManager.GetForCurrentView().DataRequested += UwpShareService_DataRequested;
            DataTransferManager.ShowShareUI();
            
            await Task.CompletedTask;
        }

        private async void UwpShareService_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var deferral = args.Request.GetDeferral();
            HttpClient client = new HttpClient();
            var buffer = await client.GetBufferAsync(new Uri(_image));
            string fileName = $"{Guid.NewGuid()}.png";
            var file = await ApplicationData.Current.LocalCacheFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBufferAsync(file, buffer);

            args.Request.Data.Properties.Title = _title;
            args.Request.Data.Properties.Description = _title;
            List<StorageFile> files = new List<StorageFile> {file};
            args.Request.Data.SetStorageItems(files);

            deferral.Complete();

        }
    }
}
