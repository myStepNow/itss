﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Exceptions.Base;

namespace Domain.Models.Exceptions
{
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException()
            : base($"Invalid client request. The tokenDto has some invalid values.")
        {

        }
    }
}
