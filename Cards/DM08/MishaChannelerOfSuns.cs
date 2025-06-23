using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM08;

sealed class MishaChannelerOfSuns : Creature
{
    public MishaChannelerOfSuns() : base("Misha, Channeler of Suns", 5, 5000, Race.MechaDelSol, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureCannotBeAttackedByDragonsEffect());
    }
}
