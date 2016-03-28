ConsoleColors
=============

C# Library for modifying console colours, used in my PowerShell profile.

```
# Console Colours
Add-Type -Path (Join-Path $ProfilePath "ConsoleColors.dll")

# Note: This assumes that you're using the default PowerShell background/foreground colour slots.
[ConsoleColors.ConsoleEx]::SetColor('DarkMagenta', 'Black')
[ConsoleColors.ConsoleEx]::SetColor('DarkYellow', 'Orange')

# You can set colours by index (this is the same as above):
[ConsoleColors.ConsoleEx]::SetColor(5, 'Black')
[ConsoleColors.ConsoleEx]::SetColor(6, 'Orange')

# Or to ARGB values (this is also the same as above):
[ConsoleColors.ConsoleEx]::SetColor(5, [System.Drawing.Color]::FromArgb(255, 0, 0, 0))
[ConsoleColors.ConsoleEx]::SetColor(6, [System.Drawing.Color]::FromArgb(255, 255, 165, 0))
```
