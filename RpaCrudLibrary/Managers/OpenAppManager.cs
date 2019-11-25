using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RpaCrudLibrary.Interfaces.IManagers;
using RpaCrudLibrary.Interfaces.IRepositories;
using RpaCrudLibrary.Models;

namespace RpaCrudLibrary.Managers
{
    public class OpenAppManager: IOpenAppManager
    {
        //repository hides bussines logic and it's used to do CRUD operations
        private readonly IOpenAppRepository _openAppRepository;

        //openAppRepository is assigned via API's DI
        public OpenAppManager(IOpenAppRepository openAppRepository)
        {
            _openAppRepository = openAppRepository;
        }
        public async Task<OpenApp> CreateAsync(OpenApp openApp)
        {
            return await _openAppRepository.CreateAsync(openApp);
        }

        public async Task<OpenApp> AlterAsync(OpenApp openApp)
        {
            return await _openAppRepository.UpdateAsync(openApp);
        }

        public async Task<OpenApp> GetAsync(Expression<Func<OpenApp, bool>> expression)
        {
            return await _openAppRepository.GetOneByConditionAsync(expression);
        }

        public async Task<List<OpenApp>> GetAllAsync()
        {
            return await _openAppRepository.GetAllAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _openAppRepository.DeleteAsync(id);
        }
    }
}