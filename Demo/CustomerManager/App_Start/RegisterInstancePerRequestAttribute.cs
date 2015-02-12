using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManager.App_Start
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterInstancePerRequestAttribute : Attribute { }

}