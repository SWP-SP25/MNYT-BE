﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Subject
{
    public class SubjectAddVM
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TuitionFee { get; set; }
    }
}
