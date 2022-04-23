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
        public TelitolTheExplorerEffect()
        {
        }

        public TelitolTheExplorerEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            if (Controller.ShieldZone.HasCards && Controller.ChooseToTakeAction(ToString()))
            {
                Controller.Look(Controller, game, Controller.ShieldZone.Cards.ToArray());
                Controller.Unreveal(Controller.ShieldZone.Cards.ToArray());
            }
        }

        public override IOneShotEffect Copy()
        {
            return new TelitolTheExplorerEffect(this);
        }

        public override string ToString()
        {
            return "You may look at your shields. Then put them back where they were.";
        }
    }
}
