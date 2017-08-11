using System;
using System.Windows;
using System.Windows.Media;
using ColorPickerWPF.Code;
using ColorPickerWPF.Properties;

namespace ColorPickerWPF
{
    /// <summary>
    /// Interaction logic for ColorPickerWindow.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        protected readonly int WidthMax = 574;
        protected readonly int WidthMin = 342;
        protected bool SimpleMode { get; set; }



        public ColorPickerWindow()
        {
            InitializeComponent();

            FilenameTextBox.Text = Settings.Default.DefaultColorPaletteFilename;
        }


        public static bool ShowDialog(out Color color, ColorPickerDialogOptions flags = ColorPickerDialogOptions.None, string customPaletteName = null, ColorPickerControl.ColorPickerChangeHandler customPreviewEventHandler = null)
        {
            var instance = new ColorPickerWindow();
            color = instance.ColorPicker.Color;

            if ((flags & ColorPickerDialogOptions.SimpleView) == ColorPickerDialogOptions.SimpleView)
            {
                instance.ToggleSimpleAdvancedView();
            }

            if ((flags & ColorPickerDialogOptions.LoadCustomPalette) == ColorPickerDialogOptions.LoadCustomPalette)
            {
                if (!String.IsNullOrEmpty(customPaletteName))
                {
                    instance.ColorPicker.LoadCustomPalette(customPaletteName);
                    instance.FilenameTextBox.Text = customPaletteName;
                }
                else
                {
                    instance.ColorPicker.LoadDefaultCustomPalette();
                }
            }

            if (customPreviewEventHandler != null)
            {
                instance.ColorPicker.OnPickColor += customPreviewEventHandler;
            }
            
            var result = instance.ShowDialog();
            if (result.HasValue && result.Value)
            {
                color = instance.ColorPicker.Color;
                return true;
            }

            return false;
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
            if (SimpleMode)
            {
                SimpleMode = false;
                MinMaxViewButton.Content = "<< Collapse";
                Width = WidthMax;
            }
            else
            {
                SimpleMode = true;
                MinMaxViewButton.Content = "Expand >>";
                Width = WidthMin;
            }
        }

        public void ToggleSimpleAdvancedView()
        {
            if (SimpleMode)
            {
                SimpleMode = false;
                MinMaxViewButton.Content = "<< Collapse";
                Width = WidthMax;
            }
            else
            {
                SimpleMode = true;
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
