using System;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerWPF
{
    /// <summary>
    /// Interaction logic for ColorPickerWindow.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        protected readonly int WidthMax = 574;
        protected readonly int WidthMin = 342;
        protected bool Collapsed = false;

        public static bool ShowDialog(out Color color)
        {
            var instance = new ColorPickerWindow();
            color = instance.ColorPicker.Color;
            
            var result = instance.ShowDialog();
            if (result.HasValue && result.Value)
            {
                color = instance.ColorPicker.Color;
                return true;
            }

            return false;
        }

        


        public ColorPickerWindow()
        {
            InitializeComponent();
        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Hide();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Hide();
        }

        private void MinMaxViewButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Collapsed)
            {
                Collapsed = false;
                MinMaxViewButton.Content = "<< Collapse";
                Width = WidthMax;
            }
            else
            {
                Collapsed = true;
                MinMaxViewButton.Content = "Expand >>";
                Width = WidthMin;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var text = FilenameTextBox.Text;
            if (!String.IsNullOrEmpty(text))
            {
                ColorPicker.SaveCustomPalette(text);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var text = FilenameTextBox.Text;
            if (!String.IsNullOrEmpty(text))
            {
                ColorPicker.LoadCustomPalette(text);
            }
        }
    }
}
