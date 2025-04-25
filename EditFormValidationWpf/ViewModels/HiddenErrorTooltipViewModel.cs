using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditFormValidationWpf.ViewModels
{
    public class HiddenErrorTooltipViewModel : EditFormViewModel
    {
        protected override bool CanSave => !HasErrors;
        public override void ValidateProperty(string propertyName, object value) {
            base.ValidateProperty(propertyName, value);
            SaveCommand.NotifyCanExecuteChanged();
        }
    }
}
