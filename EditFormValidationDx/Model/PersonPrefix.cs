using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditFormValidationDx.Model
{
    public enum PersonPrefix
    {
        [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Doctor.svg")]
        Dr,
        [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Customers.svg")]
        Mr,
        [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Mr.svg")]
        Ms,
        [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Miss.svg")]
        Miss,
        [Image(EmployeeImageHelper.ImagesPath + "Outlook Inspired/Mrs.svg")]
        Mrs
    }
    public static class EmployeeImageHelper
    {
        public const string ImagesPath = "pack://application:,,,/DevExpress.Images.v25.1;component/SvgImages/";
    }
}
