using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public class EmperorMaroll : EvolutionCreature
{
    public EmperorMaroll() : base("Emperor Maroll", 3, 5000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(
            new ReturnThisCreatureToYourHandEffect()));
        AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new EmperorMarollEffect()));
    }
}
