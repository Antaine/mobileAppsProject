using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dndCC.Services
{
    public interface IDataStore<C>
    {
        Task<bool> AddCharacterAsync(C character);
        Task<bool> UpdateCharacterAsync(C character);
        Task<bool> DeleteCharacterAsync(string id);
        Task<C> GetCharacterAsync(string id);
        Task<IEnumerable<C>> GetCharactersAsync(bool forceRefresh = false);
    }
}
