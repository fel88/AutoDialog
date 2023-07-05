# AutoDialog

Library for creating custom dialog boxes for WinForms

Available as NuGet package https://www.nuget.org/packages/AutoDialog

## Samples
**Min/Max selector:**
```csharp
var d = DialogHelpers.StartDialog();
d.AddNumericField("min", "Minimum", 128, min: 0, max: 255, decimalPlaces: 0);
d.AddNumericField("max", "Maximum", 255, min: 0, max: 255, decimalPlaces: 0);

if (!d.ShowDialog())
    return;

 MessageBox.Show($"Entered values: {d.GetIntegerNumericField("min")}  {d.GetIntegerNumericField("max")}");
```
![image](https://github.com/fel88/AutoDialog/assets/15663687/7cbc2064-3ca9-49a8-94a9-8f3faa53ed30)

---
**ComboBox selector:**
```csharp
var d = DialogHelpers.StartDialog();
d.AddOptionsField("color", "Color", new string[] { "Red", "Green", "Blue" }, "Green");

if (!d.ShowDialog())
  return;

MessageBox.Show(d.GetOptionsField("color"));
```
![image](https://github.com/fel88/AutoDialog/assets/15663687/e948ccf3-ef76-4aad-9496-94fbe51d5cd9)
