using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Utilities
{
    class DEMO_dataValidation
    {
        public static void tryMe()
        {
            var tm = new TestMe() { MyString = "sssss" };

            ValidationContext context = new ValidationContext(tm);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(tm, context, results, true);

            foreach (var item in results)
            {
                Console.WriteLine(item.ErrorMessage);
            }
        }
    }
    public class TestMe
    {
        [Required(ErrorMessage = "{0} is required.")]
        public int MyInt { get; set; }

        [StringLength(2, ErrorMessage = "{0} cannot be more than 2.")]
        public string MyString { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string AnotherString { get; set; }
    }
}
