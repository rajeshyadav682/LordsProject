using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Desktop.Model.Enum
{
    internal enum Forms
    {
        CreateClient = 101,
        SearchClient = 102,
        Payment = 103
    }

    public enum FormActions
    {
        None = 0,
        Add = 1,
        Update = 2,
        Delete = 3
    }

    public enum FormViews
    {
        List = 0,
        Record = 1
    }

    public enum FormType
    {
        CRUD = 0,
        Simple = 1
    }

}
