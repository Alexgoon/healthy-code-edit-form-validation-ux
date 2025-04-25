using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace EditFormValidationWpf.Common;

[ContentProperty("Child")]
public class ValidationControl : Control {
    static ValidationControl() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ValidationControl),
            new FrameworkPropertyMetadata(typeof(ValidationControl)));
    }

    public UIElement Child {
        get => (UIElement)GetValue(ChildProperty);
        set => SetValue(ChildProperty, value);
    }

    public static readonly DependencyProperty ChildProperty =
        DependencyProperty.Register(nameof(Child), typeof(UIElement), typeof(ValidationControl), null);
}
