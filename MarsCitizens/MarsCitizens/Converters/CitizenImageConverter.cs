using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace MarsCitizens.Converters
{
    public class CitizenImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = new Uri(value.ToString());
            string imageName = Path.GetFileName(uri.LocalPath);
            string imagePath = Task.Run(() => FileSystem.Current.LocalStorage.GetFileAsync(imageName)).Result.Path;

            return ImageSource.FromFile(imagePath);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }     
    }
}
