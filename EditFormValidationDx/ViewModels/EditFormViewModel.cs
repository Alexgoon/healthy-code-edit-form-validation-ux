
using System.Collections.Generic;
using DevExpress.Mvvm.CodeGenerators;
using System.Threading.Tasks;
using DevExpress.Xpf.Core;
using EditFormValidationDx.Infrastructure;

namespace EditFormValidationDx.ViewModels;

//Properties and commands are generated automatically for the following class when compiling:
//Refer to the following help topic for details: https://docs.devexpress.com/WPF/402989/mvvm-framework/viewmodels/compile-time-generated-viewmodels
[GenerateViewModel]
public partial class EditFormViewModelDX
{
    [GenerateProperty]
    IEnumerable<string> countries;
    public EditFormViewModelDX() { }
    public EditFormViewModelDX(ICommonDataService dataService)
    {
        //Countries = dataService.GetCountries();
    }

    [GenerateCommand]
    async Task Save()
    {
        await Task.Delay(700);
        ThemedMessageBox.Show("Asynchronous save action");
    }
}
