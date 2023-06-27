using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class ShockHurricane : Spell
    {
        public ShockHurricane() : base("Shock Hurricane", 5, Civilization.Water)
        {
            AddSpellAbilities(new ShockHurricaneEffect());
        }
    }

    class ShockHurricaneEffect : OneShotEffect
    {
        public ShockHurricaneEffect()
        {
        }

        public ShockHurricaneEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var player = Applier;
            var amount = player.ChooseAnyNumberOfCards(game.BattleZone.GetCreatures(player.Id), ToString()).Count();
            var choosableAmount = game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Count();
            if (amount > 0 && amount <= choosableAmount)
            {
                if (Applier.ChooseToTakeAction($"You may choose {amount} of your opponent's creatures in the battle zone and return them to your opponent's hand."))
                {
                    var creatures = player.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id), amount, amount, ToString());
                    game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, creatures.ToArray());
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new ShockHurricaneEffect(this);
        }

        public override string ToString()
        {
            return "Return any number of your creatures from the battle zone to your hand. Then you may choose that many of your opponent's creatures in the battle zone and return them to your opponent's hand.";
        }
    }
}
