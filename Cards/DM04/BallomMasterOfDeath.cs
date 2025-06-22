using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM04;

public class BallomMasterOfDeath : EvolutionCreature
{
    public BallomMasterOfDeath() : base("Ballom, Master of Death", 8, 12000, Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BallomMasterOfDeathEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
