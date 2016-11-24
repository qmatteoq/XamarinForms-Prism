using Android.Content;
using InfoSeries.Droid.Services;
using InfoSeries.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidShareService))]
namespace InfoSeries.Droid.Services
{
    public class DroidShareService : IShareService
    {
        public void Share(string title, string url)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, url);

            if (title != null)
            {
                intent.PutExtra(Intent.ExtraSubject, title);
            }

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.ClearTop);
            chooserIntent.SetFlags(ActivityFlags.NewTask);
            Forms.Context.StartActivity(chooserIntent);
        }
    }
}