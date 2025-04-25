using System.Windows;

namespace EditFormValidationWpf.ViewModels;

public class OneSharedErrorInMessageBoxViewModel : EditFormViewModel
{
    protected override void Save() {
        base.Save();
        MessageBox.Show(string.Join("\n", PlainErrors), "Fix validtion errors");
    }
}