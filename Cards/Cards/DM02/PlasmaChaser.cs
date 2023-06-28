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
            var amount = game.BattleZone.GetCreatures(Applier.Opponent.Id).Count();

            if (amount > 0 && Applier.ChooseToTakeAction($"You may draw {amount} cards."))
            {
                Applier.DrawCards(amount, game, Ability);
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
