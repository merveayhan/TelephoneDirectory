﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Model.DAL.ORM.Enum;

namespace TelephoneDirectory.Model.DAL.ORM.Interface
{
    public class IBaseEntity
    {
        int ID { get; set; }
        DateTime AddDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime DeleteDate { get; set; }

        Status Status { get; set; }
    }
}
