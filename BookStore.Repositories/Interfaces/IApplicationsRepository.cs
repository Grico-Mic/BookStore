using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Interfaces
{
    public interface IApplicationsRepository
    {
        Task<Application> GetByApiKeyAsync(string apiKey);
    }
}
