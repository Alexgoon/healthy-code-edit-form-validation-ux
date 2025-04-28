using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace EditFormValidationWpf.ViewModels;


public partial class EditFormViewModelBase : ObservableObject, INotifyDataErrorInfo {
    [ObservableProperty]
    string firstName;

    [ObservableProperty]
    string lastName;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string phone;

    [ObservableProperty]
    protected List<string> plainErrors;

    [RelayCommand(CanExecute = nameof(CanSave))]
    protected virtual void Save() {
        ValidateAll();
        OnPropertyChanged(nameof(HasErrors));
    }
    protected virtual bool CanSave => true;
    public bool ValidateAll() {
        ValidateProperty(nameof(FirstName), FirstName);
        ValidateProperty(nameof(LastName), LastName);
        ValidateProperty(nameof(Email), Email);
        ValidateProperty(nameof(Phone), Phone);

        PlainErrors = _errors.Values.SelectMany(e => e).ToList();
        return !HasErrors;
    }

    partial void OnFirstNameChanged(string? oldValue, string newValue) => ValidateProperty(nameof(FirstName), newValue);
    partial void OnLastNameChanged(string? oldValue, string newValue) => ValidateProperty(nameof(LastName), newValue);
    partial void OnEmailChanged(string? oldValue, string newValue) => ValidateProperty(nameof(Email), newValue);
    partial void OnPhoneChanged(string? oldValue, string newValue) => ValidateProperty(nameof(Phone), newValue);

    #region INotifyDataErrorInfo
    private readonly Dictionary<string, List<string>> _errors = new();
    public virtual void ValidateProperty(string propertyName, object value) {
        bool oldHasErrors = HasErrors;
        var errors = new List<string>();

        switch (propertyName) {
            case nameof(FirstName):
                if (string.IsNullOrWhiteSpace((string)value))
                    errors.Add("First name is required");
                break;

            case nameof(LastName):
                if (string.IsNullOrWhiteSpace((string)value))
                    errors.Add("Last name is required");
                break;

            case nameof(Email):
                var email = (string)value;
                if (string.IsNullOrWhiteSpace(email)) {
                    errors.Add("Email is required");
                }
                else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) {
                    errors.Add("Email format is invalid");
                }
                break;

            case nameof(Phone):
                var phone = (string)value;
                if (string.IsNullOrWhiteSpace(phone)) {
                    errors.Add("Phone is required");
                }
                else if (!Regex.IsMatch(phone, @"^\+?\d{10,15}$")) {
                    errors.Add("Phone number format is invalid");
                }
                break;
        }

        if (errors.Count > 0) {
            _errors[propertyName] = errors;
        }
        else {
            _errors.Remove(propertyName);
        }

        RaiseErrorsChanged(propertyName);
        if (oldHasErrors && !HasErrors)
            OnPropertyChanged(nameof(HasErrors));
    }
    protected void RaiseErrorsChanged(string propertyName) {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    public bool HasErrors => _errors.Count > 0;

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName) {
        if (string.IsNullOrEmpty(propertyName))
            return null;

        _errors.TryGetValue(propertyName, out var errors);
        return errors;
    }
    #endregion
}
