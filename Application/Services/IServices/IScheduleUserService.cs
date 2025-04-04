﻿using Application.ViewModels.ScheduleUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IServices
{
    public interface IScheduleUserService
    {
        Task AddAsync(ScheduleUserAddVM scheduleUserAddVM);
        Task UpdateAsync(ScheduleUserVM scheduleUserVM);
        Task<IList<ScheduleUserVM>> GetAllAsync();
        Task<ScheduleUserVM> GetAsync(int id);
        Task SoftDelete(int id);
        Task DeleteAsync(int id);
        Task<IList<ScheduleUserVM>> GetAllByPregnancyIdAsync(int id);
        Task<List<TrueScheduleVM>> GetAllByPregnancyIdAsyncV2(int id);
    }
}
