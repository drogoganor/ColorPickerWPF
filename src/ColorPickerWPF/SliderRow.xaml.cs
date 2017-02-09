using System.Windows;
using System.Windows.Controls;

namespace ColorPickerWPF
{
    /// <summary>
    /// Interaction logic for SliderRow.xaml
    /// </summary>
    public partial class SliderRow : UserControl
    {
        public delegate void SliderRowValueChangedHandler(double value);

        public event SliderRowValueChangedHandler OnValueChanged;

        public SliderRow()
        {
            InitializeComponent();
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Set textbox
            var value = Slider.Value;

            TextBox.Text = value.ToString("F2");

            OnValueChanged?.Invoke(value);
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = TextBox.Text;
            bool ok = false;
            double parsedValue = 0;

            ok = double.TryParse(text, out parsedValue);
            if (ok)
            {
                Slider.Value = parsedValue;

                OnValueChanged?.Invoke(parsedValue);
            }
        }
    }
}
