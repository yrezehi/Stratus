using ExecuteRoslyn.Declarations.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteRoslyn.Declarations.Web.Services
{
    public static class IBaseService
    {
        public static void Build()
        {
            Method findMethod = new Method { Modifier = "public", Name = "Find" };
            Method getAllMethod = new Method { Modifier = "public", Name = "GetAll" };
            Method paginateMethod = new Method { Modifier = "public", Name = "Paginate" };
            Method findByIdmethod = new Method { Modifier = "public", Name = "FindById" };
            Method deleteMethod = new Method { Modifier = "public", Name = "Delete" };
            Method updateMethod = new Method { Modifier = "", Name = "Update" };
            Method insertMethod = new Method { Modifier = "", Name = "Insert" };
        }
    }
}
