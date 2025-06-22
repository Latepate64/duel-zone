using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class DeathCruzerTheAnnihilator : Creature
{
    public DeathCruzerTheAnnihilator() : base(
        "Death Cruzer, the Annihilator", 7, 13000, Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DeathCruzerTheAnnihilatorEffect()));
        AddStaticAbilities(new TripleBreakerEffect());
    }
}
