using Interfaces;

namespace Cards.DM03;

public class Gigamantis : EvolutionCreature
{
    public Gigamantis() : base("Gigamantis", 4, 5000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new GigamantisEffect());
    }
}
