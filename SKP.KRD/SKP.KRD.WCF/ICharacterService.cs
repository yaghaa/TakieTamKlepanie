using System.Collections.Generic;
using SKP.KRD.Gamification;

namespace KRD.SKP.Service.Library
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();

        void AddCharacter(Character character);
    }
}