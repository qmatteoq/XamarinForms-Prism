using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using InfoSeries.Droid.Services;
using InfoSeries.Services;
using Xamarin.Forms;
using Environment = Android.OS.Environment;

[assembly: Dependency(typeof(AndroidShareService))]
namespace InfoSeries.Droid.Services
{
    public class AndroidShareService : IShareService
    {
        public async Task ShareShirt(string title, string image)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("image/png");
            Guid guid = Guid.NewGuid();
            var path = Environment.GetExternalStoragePublicDirectory(Environment.DataDirectory
                                                                + Java.IO.File.Separator + guid + ".png");

            HttpClient client = new HttpClient();
            var httpResponse = await client.GetAsync(image);
            byte[] imageBuffer = await httpResponse.Content.ReadAsByteArrayAsync();

            if (File.Exists(path.AbsolutePath))
            {
                File.Delete(path.AbsolutePath);
            }

            using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
            {
                await os.WriteAsync(imageBuffer, 0, imageBuffer.Length);
            }

            intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));

            var intentChooser = Intent.CreateChooser(intent, "Share via");

            Activity activity = Forms.Context as Activity;
            activity.StartActivityForResult(intentChooser, 100);
        }
    }
}