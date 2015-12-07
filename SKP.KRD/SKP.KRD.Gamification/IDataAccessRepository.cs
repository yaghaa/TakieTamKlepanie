using System.Collections.Generic;

namespace SKP.KRD.Gamification
{
    public interface IDataAccessRepository
    {
        List<Character> GetCharacters();

        bool AddCharacter(Character character);

    }
}