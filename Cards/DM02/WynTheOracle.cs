using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class WynTheOracle : Creature
{
    public WynTheOracle() : base("Wyn, the Oracle", 2, 1500, Race.LightBringer,
        Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new LookEffect(0, 1)));
    }
}
