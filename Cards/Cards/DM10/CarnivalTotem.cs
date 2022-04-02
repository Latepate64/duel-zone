using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class CarnivalTotem : Creature
    {
        public CarnivalTotem() : base("Carnival Totem", 6, 7000, Subtype.MysteryTotem, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new CarnivalTotemEffect());
        }
    }

    class CarnivalTotemEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var mana = source.GetController(game).ManaZone.Cards;
            var hand = source.GetController(game).Hand.Cards;
            game.Move(ZoneType.ManaZone, ZoneType.Hand, mana.ToArray());
            game.MoveTapped(ZoneType.Hand, ZoneType.ManaZone, hand.ToArray());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new CarnivalTotemEffect();
        }

        public override string ToString()
        {
            return "Put all the cards from your mana zone into your hand and, at the same time, put all the cards from your hand into your mana zone tapped.";
        }
    }
}
