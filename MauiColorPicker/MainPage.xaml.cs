using CommunityToolkit.Maui.Alerts;

namespace MauiColorPicker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if(!isRandom)
            {
                var blue = SldBlue.Value;
                var green = SldGreen.Value;
                var red = SldRed.Value;

                Color color = Color.FromRgb(blue, green, red);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0,256),
                random.Next(0, 256),
                random.Next(0, 256));
            SetColor(color);

            SldRed.Value = color.Red;
            SldGreen.Value = color.Green;
            SldBlue.Value = color.Blue;
            isRandom = false;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }
    }
}
