using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class PlasmaChaser : Creature
{
    public PlasmaChaser() : base("Plasma Chaser", 6, 4000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new PlasmaChaserEffect()));
    }
}
