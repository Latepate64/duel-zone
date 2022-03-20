using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM02
{
    class PlasmaChaser : Creature
    {
        public PlasmaChaser() : base("Plasma Chaser", 6, 4000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new PlasmaChaserEffect()));
        }
    }

    class PlasmaChaserEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player != null)
            {
                var amount = game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Count();
                if (amount > 0 && player.Choose(new YesNoChoice(source.Owner, $"You may draw {amount} cards."), game).Decision)
                {
                    player.DrawCards(amount, game);
                }
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new PlasmaChaserEffect();
        }

        public override string ToString()
        {
            return "You may draw a number of cards equal to the number of creatures your opponent has in the battle zone.";
        }
    }
}
