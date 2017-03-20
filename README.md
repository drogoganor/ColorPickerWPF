# ColorPickerWPF

A simple WPF color picker control for .NET 4.5.2 licensed under MIT. Contains two color gradient images to sample from, and custom palette support.

![screenshot](https://raw.githubusercontent.com/drogoganor/ColorPickerWPF/master/images/Picker1.png)

You can invoke it as a dialog using: 

`Color color;`

`bool ok = ColorPickerWindow.ShowDialog(out color);`

Or use the user control itself in your application: `ColorPickerWPF.ColorPickerControl`

![screenshot](https://raw.githubusercontent.com/drogoganor/ColorPickerWPF/master/images/Picker2.png)

The user can define their own palette by selecting a color and ctrl+clicking a swatch in the custom colors section (lower right).

The custom palette can be saved to an XML file in the application folder or loaded from the same. 

The dialog won't load the custom palette automatically by default, but you can tell it to with the optional flags to `ColorPickerWindow.ShowDialog([...], ColorPickerDialogOptions flags, string customPaletteName)`

You can specify to show the simple (collapsed) view with `flags = ColorPickerDialogOptions.SimpleView`

Or you can load the default palette file (specified in the app.config setting DefaultColorPaletteFilename) with `flags = ColorPickerDialogOptions.LoadCustomPalette`.

Or both using `flags = ColorPickerDialogOptions.SimpleView | ColorPickerDialogOptions.LoadCustomPalette`

Finally, you can specify a palette filename to load instead of the default with the final optional argument `string customPaletteName`

An example showing the simple view and loading a custom palette file:

`ColorPickerWindow.ShowDialog(out color, ColorPickerDialogOptions.SimpleView | ColorPickerDialogOptions.LoadCustomPalette, "MyPalette.xml");`

This would show the dialog in simple view, and load the palette file "MyPalette.xml".

If you are using the `ColorPickerControl` instead of the dialog, you can load custom palettes with: `LoadDefaultCustomPalette()` or `LoadCustomPalette(string filename)`.

The palette file, default "ColorPalette.xml", contains both the custom palette colors and the inbuilt colors. You can create your own inbuilt palette if you create an instance of `ColorPickerWPF.Code.ColorPalette`, populate its data accordingly, and save to file using `ColorPalette.SaveToXml(string filename)`. You can then distribute your application with this custom palette file.

Unfortunately there is no mechanism for customizing the color gradient sample images at this time, or indeed any other customization. If you require further customization I recommend cloning the repo and adding ColorPickerWPF to your solution.

[ColorPickerWPF on Nuget Gallery](https://www.nuget.org/packages/ColorPickerWPF)

## Thanks to

[Fatcow Icons](http://www.fatcow.com/free-icons) for the dialog window icon.

[WriteableBitmapEx](https://github.com/teichgraf/WriteableBitmapEx/) for image manipulation code.

