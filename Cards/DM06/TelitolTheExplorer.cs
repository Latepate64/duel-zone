using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Engine.Abilities;

namespace Cards.DM06
{
    class TelitolTheExplorer : Creature
    {
        public TelitolTheExplorer() : base("Telitol, the Explorer", 4, 3000, Race.Gladiator, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TelitolTheExplorerEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
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
                Controller.Look(Controller, game, [.. Controller.ShieldZone.Cards]);
                Controller.Unreveal([.. Controller.ShieldZone.Cards]);
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
