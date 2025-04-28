namespace EditFormValidationWpf.ViewModels;

public class HiddenErrorTooltipViewModel : EditFormViewModelBase
{
    protected override bool CanSave => !HasErrors;
    public override void ValidateProperty(string propertyName, object value) {
        base.ValidateProperty(propertyName, value);
        SaveCommand.NotifyCanExecuteChanged();
    }
}
