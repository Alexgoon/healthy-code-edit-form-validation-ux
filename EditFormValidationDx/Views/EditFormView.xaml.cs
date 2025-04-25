using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace EditFormValidationDx.Views; 
/// <summary>
/// Interaction logic for EditFormView.xaml
/// </summary>
public partial class EditFormView : UserControl {
    public EditFormView() {
        InitializeComponent();
    }

    private void DateEdit_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e) {
        e.IsValid = e.Value is DateTime;
        Debug.WriteLine($"Is Valid: {e.IsValid}");
    }

    private void editor_LostFocus(object sender, RoutedEventArgs e) {
        
    }

    private void editor_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
        if (!editor.IsKeyboardFocusWithin) {
            editor.CausesValidation = true;
            editor.DoValidate();
        }
        else
            editor.CausesValidation = false;
        //editor.CausesValidation = !editor.IsKeyboardFocusWithin;

        Debug.WriteLine($"CausesValidation: {editor.CausesValidation}");
    }
}
