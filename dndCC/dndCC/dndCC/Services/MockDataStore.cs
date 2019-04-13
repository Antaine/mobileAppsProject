using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dndCC.Models;

namespace dndCC.Services
{
    public class MockDataStore : IDataStore<Character>
    {
        List<Character> characters;

        public MockDataStore()
        {
            characters = new List<Character>();
            var mockCharacters = new List<Character>
            {
                new Character { Id = Guid.NewGuid().ToString(), Text = "First Character", Description="This is an Character description." },
                new Character { Id = Guid.NewGuid().ToString(), Text = "Second Character", Description="This is an Character description." },
                new Character { Id = Guid.NewGuid().ToString(), Text = "Third Character", Description="This is an Character description." },
                new Character { Id = Guid.NewGuid().ToString(), Text = "Fourth Character", Description="This is an Character description." },
                new Character { Id = Guid.NewGuid().ToString(), Text = "Fifth Character", Description="This is an Character description." },
                new Character { Id = Guid.NewGuid().ToString(), Text = "Sixth Character", Description="This is an Character description." },
            };

            foreach (var character in mockCharacters)
            {
                characters.Add(character);
            }
        }

        public async Task<bool> AddCharacterAsync(Character character)
        {
            characters.Add(character);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCharacterAsync(Character character)
        {
            var oldCharacter = characters.Where((Character arg) => arg.Id == character.Id).FirstOrDefault();
            characters.Remove(oldCharacter);
            characters.Add(character);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCharacterAsync(string id)
        {
            var oldCharacter = characters.Where((Character arg) => arg.Id == id).FirstOrDefault();
            characters.Remove(oldCharacter);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            return await Task.FromResult(characters.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(characters);
        }
    }
}