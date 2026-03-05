using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class LarbaGeerTheImmaculate : EvolutionCreature
{
    public LarbaGeerTheImmaculate() : base("Larba Geer, the Immaculate", 3, 5000, Race.Guardian, Civilization.Light)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new LarbaGeerTheImmaculateEffect()));
    }
}
