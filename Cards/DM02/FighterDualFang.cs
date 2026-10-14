using Abilities.Static;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class FighterDualFang : EvolutionCreature
{
    public FighterDualFang() : base("Fighter Dual Fang", 6, 8000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new PutTopCardsOfDeckIntoManaZoneEffect(2)));
        AddAbilities(new DoubleBreakerAbility());
    }
}