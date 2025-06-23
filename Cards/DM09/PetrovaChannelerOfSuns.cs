using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class PetrovaChannelerOfSuns : Creature
{
    public PetrovaChannelerOfSuns() : base("Petrova, Channeler of Suns", 5, 3500, Race.AngelCommand, Civilization.Light)
    {
        AddStaticAbilities(new PetrovaEffect(), new OpponentCannotChooseThisCreatureEffect());
    }
}
