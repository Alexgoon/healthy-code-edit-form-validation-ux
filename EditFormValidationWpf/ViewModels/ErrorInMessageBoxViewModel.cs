using System.Windows;

namespace EditFormValidationWpf.ViewModels;

public class ErrorInMessageBoxViewModel : EditFormViewModelBase
{
    protected override void Save() {
        base.Save();
        MessageBox.Show(string.Join("\n", PlainErrors), "Fix validtion errors");
    }
}