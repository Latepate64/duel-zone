using Abilities.Static;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class GeneralDarkFiend : Creature
{
    public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000, Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ShieldBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    ownShields: true
        )));
        AddAbilities(new DoubleBreakerAbility());
    }
}