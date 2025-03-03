﻿using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pregnancy
{
    public class PregnancyVM : BaseEntity
    {
        public int? AccountId { get; set; }

        public string? Type { get; set; }

        public string? Status { get; set; }

        

        public DateOnly? EndDate { get; set; }

    }
}
