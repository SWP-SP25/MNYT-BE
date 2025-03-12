﻿using Application.Services.IServices;
using Application.ViewModels.PregnancyStandard;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class PregnancyStandardService : IPregnancyStandardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PregnancyStandardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddSync(PregnacyStandardAddVM pregnancyStandardAddVM)
        {
            var pregnancyStandard = _mapper.Map<PregnancyStandard>(pregnancyStandardAddVM);
            await _unitOfWork.PregnancyStandardRepo.AddAsync(pregnancyStandard);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var itemToDelete =await _unitOfWork.PregnancyStandardRepo.GetAsync(id);
            _unitOfWork.PregnancyStandardRepo.Delete(itemToDelete);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<PregnancyStandardVM>> GetAllAsync()
        {
            var items = await _unitOfWork.PregnancyStandardRepo.GetAllAsync();
            var result = _mapper.Map<IList<PregnancyStandardVM>>(items);
            return result;
        }

        public async Task<PregnancyStandardVM> GetAsync(int id)
        {
            var item = await _unitOfWork.PregnancyStandardRepo.GetAsync(id);
            var result = _mapper.Map<PregnancyStandardVM>(item);
            return result;
        }

        public async Task SoftDeleteAsync(int id)
        {
            var itemToDelete = await _unitOfWork.PregnancyStandardRepo.GetAsync(id);
            _unitOfWork.PregnancyStandardRepo.SoftDelete(itemToDelete);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task UpdateAsync(PregnacyStandardAddVM pregnancyVM)
        {
            var itemToUpdate = _mapper.Map<PregnancyStandard>(pregnancyVM);
            _unitOfWork.PregnancyStandardRepo.Update(itemToUpdate);
            return _unitOfWork.SaveChangesAsync();
        }
    }
}
