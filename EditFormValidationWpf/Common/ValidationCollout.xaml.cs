using System.Windows;
using System.Windows.Controls;

namespace EditFormValidationWpf.Views {
    /// <summary>
    /// Interaction logic for ValidationCollout.xaml
    /// </summary>
    public partial class ValidationCollout : UserControl {
        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ValidationCollout), null);

        public ValidationCollout() {
            InitializeComponent();
        }

        private void OnMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            expander.IsExpanded = !expander.IsExpanded;
        }
    }
}
