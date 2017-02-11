# ColorPickerWPF

![screenshot](https://raw.githubusercontent.com/drogoganor/ColorPickerWPF/master/images/Picker1.png)

A simple color picker control for WPF licensed under MIT. 

You can invoke it as a dialog using: 

`Color color;
bool ok = ColorPickerWPF.ColorPickerWindow.ShowDialog(out color);`

Or use the user control itself in your application: `ColorPickerWPF.ColorPickerControl`

![screenshot](https://raw.githubusercontent.com/drogoganor/ColorPickerWPF/master/images/Picker2.png)

Contains two color gradient images to sample from, and custom palette support.

The user can define their own palette by selecting a color and ctrl+clicking a swatch in the custom colors section (lower right).

The custom palette can be saved to an XML file in the application folder or loaded from the same. 

The dialog won't load the custom palette automatically by default, but you can tell it to with the optional arguments to `ColorPickerWindow.ShowDialog(out Color color, bool loadCustomPalette = false, string customPaletteName = null)` or with the control methods `ColorPickerControl.LoadDefaultCustomPalette()` or `ColorPickerControl.LoadCustomPalette(string filename)`.

The palette file, default "CustomPalette.xml", contains both the custom palette colors and the inbuilt colors. You can create your own inbuilt palette if you create an instance of `ColorPickerWPF.Code.ColorPalette`, populate its data accordingly, and save to file using `ColorPalette.SaveToXml(string filename)`. You can then distribute your application with this custom palette.

Unfortunately there is no mechanism for customizing the color gradient sample images at this time, or indeed any other customization. If you require further customization I recommend cloning the repo and adding ColorPickerWPF to your solution.

[ColorPickerWPF on Nuget Gallery](https://www.nuget.org/packages/ColorPickerWPF)

## Thanks to

[Fatcow Icons](http://www.fatcow.com/free-icons) for the dialog window icon.

[WriteableBitmapEx](https://github.com/teichgraf/WriteableBitmapEx/) for image manipulation code.

