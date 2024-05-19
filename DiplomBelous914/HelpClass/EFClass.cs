using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomBelous914.DB;

namespace DiplomBelous914.HelpClass
{
    public class EFClass
    {
        public static Entities Context { get; } = new Entities();
    }
}
