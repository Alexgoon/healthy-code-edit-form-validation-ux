using EditFormValidationWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditFormValidationWpf.Views {
    /// <summary>
    /// Interaction logic for HiddenErrorTooltipView.xaml
    /// </summary>
    public partial class HiddenErrorTooltipView : UserControl {
        public HiddenErrorTooltipView() {
            InitializeComponent();
        }

        private void OnLastNameIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if ((bool)e.NewValue)
                return;
            EditFormViewModel viewModel = (EditFormViewModel)DataContext;
            viewModel.ValidateProperty(nameof(EditFormViewModel.LastName), viewModel.LastName);
        }
        private void OnFirstNameIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if ((bool)e.NewValue)
                return;
            EditFormViewModel viewModel = (EditFormViewModel)DataContext;
            viewModel.ValidateProperty(nameof(EditFormViewModel.FirstName), viewModel.FirstName);
        }

        private void OnPhoneIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if (!(bool)e.NewValue)
                return;
            EditFormViewModel viewModel = (EditFormViewModel)DataContext;
            viewModel.ValidateProperty(nameof(EditFormViewModel.Phone), viewModel.Phone);
        }

        private void TextBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) {
            var textBox = (TextBox)sender;

            if (Validation.GetHasError(textBox)) {
                e.Handled = true;
            }
        }
    }
}
