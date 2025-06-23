using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class FunkyWizard : Creature
{
    public FunkyWizard() : base("Funky Wizard", 4, 2000, Race.Merfolk, Civilization.Water)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new FunkyWizardEffect()));
    }
}
