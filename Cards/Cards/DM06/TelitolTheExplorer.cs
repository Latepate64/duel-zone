using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class TelitolTheExplorer : Creature
    {
        public TelitolTheExplorer() : base("Telitol, the Explorer", 4, 3000, Race.Gladiator, Civilization.Light)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TelitolTheExplorerEffect());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }

    class TelitolTheExplorerEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ShieldZone.HasCards && source.GetController(game).ChooseToTakeAction(ToString()))
            {
                source.GetController(game).Look(source.GetController(game), game, source.GetController(game).ShieldZone.Cards.ToArray());
                source.GetController(game).Unreveal(source.GetController(game).ShieldZone.Cards);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new TelitolTheExplorerEffect();
        }

        public override string ToString()
        {
            return "You may look at your shields. Then put them back where they were.";
        }
    }
}
