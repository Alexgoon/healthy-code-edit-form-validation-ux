using System;
using System.Runtime;
using System.Windows;
using DevExpress.Xpf.Core;


namespace EditFormValidationDx;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    static App()
    {
        CompatibilitySettings.UseLightweightThemes = true;
        ApplicationThemeHelper.Preload(PreloadCategories.Core);
        ApplicationThemeHelper.ApplicationThemeName = LightweightTheme.Win11Light.Name;

        //Enable Multi Core JIT to improve startup performance
        ProfileOptimization.SetProfileRoot(AppContext.BaseDirectory);
        ProfileOptimization.StartProfile("Startup.Profile");
    }
}
