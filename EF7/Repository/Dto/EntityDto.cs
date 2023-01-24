﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.Repository.Dto
{
    public class EntityDto
    {
        private int? _id;

        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = ((value == 0) ? null : value);
            }
        }
    }
}
