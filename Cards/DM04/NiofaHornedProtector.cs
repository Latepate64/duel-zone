using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM04;

public sealed class NiofaHornedProtector : EvolutionCreature
{
    public NiofaHornedProtector() : base("Niofa, Horned Protector", 6, 9000, Race.HornedBeast, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NiofaHornedProtectorEffect()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
