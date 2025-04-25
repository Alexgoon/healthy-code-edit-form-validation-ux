using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EditFormValidationWpf.Common {

    public class ValidatedPropertyUpdateBehavior : Behavior<TextBox> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.TextChanged += OnTextChanged;
            AssociatedObject.IsKeyboardFocusWithinChanged += OnIsKeyboardFocusWithinChanged;
        }

        private void OnIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if (!AssociatedObject.IsKeyboardFocusWithin) {
                UpdateSource();
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e) {
            if (Validation.GetHasError(AssociatedObject))
                UpdateSource();
        }

        public void UpdateSource() {
            BindingExpression textBinding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            textBinding?.UpdateSource();
        }
    }
}
