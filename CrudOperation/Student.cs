using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation
{
    public class Student : BaseEntity
    {
        internal object id;

        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNo { get; set; }
        public string ClassName { get; set; }
        public int StudentAge { get; set; }

    }
}
