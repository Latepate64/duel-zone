using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class FunkyWizard : Creature
    {
        public FunkyWizard() : base("Funky Wizard", 4, 2000, Race.Merfolk, Civilization.Water)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new FunkyWizardEffect());
        }
    }

    class FunkyWizardEffect : OneShotEffect
    {
        public FunkyWizardEffect()
        {
        }

        public FunkyWizardEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            foreach (var player in game.Players)
            {
                if (player.ChooseToTakeAction("You may draw a card."))
                {
                    player.DrawCards(1, game, GetSourceAbility(game));
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new FunkyWizardEffect(this);
        }

        public override string ToString()
        {
            return "Each player may draw a card.";
        }
    }
}
