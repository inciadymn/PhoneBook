﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Abstract
{
    public interface IBaseService<TEntity>
        where TEntity : BaseEntity
    {
    }
}