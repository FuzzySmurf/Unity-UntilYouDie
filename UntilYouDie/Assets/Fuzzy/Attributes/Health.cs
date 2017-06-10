using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fuzzy.Attribute.Model;

namespace Fuzzy.Attribute
{
    public class Health : AdjustableAttribute
    {
        public Health(int value) : base(value) {}
    }
}
