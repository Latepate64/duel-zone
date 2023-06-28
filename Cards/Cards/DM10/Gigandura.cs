using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class Gigandura : Creature
    {
        public Gigandura() : base("Gigandura", 5, 3000, Race.Chimera, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GiganduraEffect());
        }
    }

    class GiganduraEffect : OneShotEffect
    {
        public GiganduraEffect()
        {
        }

        public GiganduraEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var opponent = Applier.Opponent;
            Applier.Look(opponent, opponent.Hand.Cards.ToArray());
            var card = Applier.ChooseCardOptionally(opponent.Hand.Cards, ToString());
            if (card != null)
            {
                game.Move(Ability, ZoneType.Hand, ZoneType.ManaZone, card);
                var mana = Applier.ChooseCard(opponent.ManaZone.Cards, ToString());
                game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, mana);
            }
            opponent.Unreveal(card);
        }

        public override IOneShotEffect Copy()
        {
            return new GiganduraEffect(this);
        }

        public override string ToString()
        {
            return "Look at your opponent's hand. You may choose a card in it and put it into his mana zone. If you do, choose a card in his mana zone and put it into his hand.";
        }
    }
}
