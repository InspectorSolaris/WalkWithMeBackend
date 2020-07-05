using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.DTO
{
    public class HelloWorldDTO
    {
        public HelloWorldDTO(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }
    }
}
