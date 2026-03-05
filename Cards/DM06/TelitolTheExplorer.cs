using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class TelitolTheExplorer : Creature
{
    public TelitolTheExplorer() : base("Telitol, the Explorer", 4, 3000, Race.Gladiator, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TelitolTheExplorerEffect()));
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
