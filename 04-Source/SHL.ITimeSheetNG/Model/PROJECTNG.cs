﻿using System;
using System.Collections.Generic;
using System.Text;
using SHL.IRetorno.Model;
using SHL.Project.Model;

namespace SHL.ITimeSheetNG.Model
{
    public class PROJECTNG
    {
        public List<PROJECT> records { get; set; }
        public List<RETORNO> errors { get; set; }
    }
}
