using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    enum ACTION_TYPE
    {
        CREATE_DOCUMENT = 0, MODIFY_DOCUMENT = 1, DELETE_DOCUMENT = 2, CREATE_FLOW = 3, DELETE_FLOW = 4, ADD_REVISION = 5, VIEW_DOCUMENT = 6, VIEW_STATISTICS = 7
    };
}
