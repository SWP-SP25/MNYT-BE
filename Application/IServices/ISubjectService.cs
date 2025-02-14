﻿using Application.ViewModels.Subject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISubjectService
    {
        Task AddAsync(SubjectAddVM subjectVM);
        Task<IList<SubjectVM>> GetAllAsync();
        Task<SubjectVM> GetByIdAsync(int id);
    }
}
