using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM04;

public sealed class GalklifeDragon : Creature
{
    public GalklifeDragon() : base("Galklife Dragon", 7, 6000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalklifeDragonEffect()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
