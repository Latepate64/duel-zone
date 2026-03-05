using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class FranticChieftain : Creature
{
    public FranticChieftain() : base("Frantic Chieftain", 2, 2000, Race.Merfolk, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new FranticChieftainEffect()));
    }
}
