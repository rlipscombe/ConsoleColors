ConsoleColors
=============

C# Library for modifying console colours, used in my PowerShell profile.

```
# Console Colours
Add-Type -Path (Join-Path $ProfilePath "ConsoleColors.dll")

# Note: This assumes that you're using the default PowerShell background/foreground colour slots.
[ConsoleColors.ConsoleEx]::SetColor('DarkMagenta', 'Black')
[ConsoleColors.ConsoleEx]::SetColor('DarkYellow', 'Orange')
```
