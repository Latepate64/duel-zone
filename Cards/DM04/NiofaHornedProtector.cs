using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM04;

public class NiofaHornedProtector : EvolutionCreature
{
    public NiofaHornedProtector() : base("Niofa, Horned Protector", 6, 9000, Race.HornedBeast, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NiofaHornedProtectorEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
