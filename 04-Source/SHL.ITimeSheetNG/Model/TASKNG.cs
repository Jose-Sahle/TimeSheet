﻿using System;
using System.Collections.Generic;
using System.Text;
using SHL.IRetorno.Model;
using SHL.Task.Model;

namespace SHL.ITimeSheetNG.Model
{
    public class TASKNG
    {
        public List<TASK> records { get; set; }
        public List<RETORNO> errors { get; set; }
    }
}