using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class CarnivalTotem : Creature
    {
        public CarnivalTotem() : base("Carnival Totem", 6, 7000, Race.MysteryTotem, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new CarnivalTotemEffect());
        }
    }

    class CarnivalTotemEffect : OneShotEffect
    {
        public CarnivalTotemEffect()
        {
        }

        public CarnivalTotemEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var mana = Controller.ManaZone.Cards;
            var hand = Controller.Hand.Cards;
            game.Move(Source, ZoneType.ManaZone, ZoneType.Hand, mana.ToArray());
            game.MoveTapped(Source, ZoneType.Hand, ZoneType.ManaZone, hand.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new CarnivalTotemEffect(this);
        }

        public override string ToString()
        {
            return "Put all the cards from your mana zone into your hand and, at the same time, put all the cards from your hand into your mana zone tapped.";
        }
    }
}
