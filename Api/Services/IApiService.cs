using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IApiService
    {
        Task<AuthorModel> GetAuthorAsync(string Id);

        Task<bool> CreateAuthorAsync(AuthorModel author);

        Task<bool> DeleteAuthorAsync(string id);

        Task<bool> UpdateAuthorAsync(AuthorModel author);

        Task<List<AuthorModel>> GetAuthorListAsync(AuthorsListModel rules);

        bool CheckPropertyExist(string propertyName);
    }
}
