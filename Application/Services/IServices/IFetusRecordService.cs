﻿using Application.ViewModels.FetusRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IServices
{
    public interface IFetusRecordService
    {
        Task AddFetusRecordAsync(List<FetusRecordAddVM> fetusRecordAddVMs);
        Task UpdateAsync(FetusRecordVM fetusRecordVM);
        Task<IList<FetusRecordVM>> GetAllAsync();
        Task<FetusRecordVM> GetAsync(int id);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<IList<FetusRecordVM>> GetAllByFetusIdAsync(int id);
    }
}
