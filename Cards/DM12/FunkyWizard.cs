using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM12;

public sealed class FunkyWizard : Creature
{
    public FunkyWizard() : base("Funky Wizard", 4, 2000, Race.Merfolk, Civilization.Water)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new FunkyWizardEffect()));
    }
}
