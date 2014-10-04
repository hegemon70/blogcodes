using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace SimpleNowin
{
    public class Home : NancyModule
    {
        public Home()
        {
            Get["/"] = _ => View["home"];
        }
    }
}
