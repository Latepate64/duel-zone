using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;

namespace Cards.DM06;

public sealed class TelitolTheExplorer : Creature
{
    public TelitolTheExplorer() : base("Telitol, the Explorer", 4, 3000, Race.Gladiator, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TelitolTheExplorerEffect()));
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
