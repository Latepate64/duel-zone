using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM02
{
    class PlasmaChaser : Creature
    {
        public PlasmaChaser() : base("Plasma Chaser", 6, 4000, Race.GelFish, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new PlasmaChaserEffect());
        }
    }

    class PlasmaChaserEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var amount = game.BattleZone.GetCreatures(GetOpponent(game).Id).Count();

            if (amount > 0 && Controller.ChooseToTakeAction($"You may draw {amount} cards."))
            {
                Controller.DrawCards(amount, game, Source);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new PlasmaChaserEffect();
        }

        public override string ToString()
        {
            return "You may draw a number of cards equal to the number of creatures your opponent has in the battle zone.";
        }
    }
}
