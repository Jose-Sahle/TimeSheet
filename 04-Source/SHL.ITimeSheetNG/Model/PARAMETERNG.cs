﻿using System;
using System.Collections.Generic;
using System.Text;
using SHL.IRetorno.Model;
using SHL.Syncronism.Model;

namespace SHL.ITimeSheetNG.Model
{
    public class PARAMETERNG
    {
        public List<PARAMETER> records { get; set; }
        public List<RETORNO> errors { get; set; }
    }
}