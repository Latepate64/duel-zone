using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class WilyCarpenter : Creature
    {
        public WilyCarpenter() : base("Wily Carpenter", 3, 1000, Engine.Race.Merfolk, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new WilyCarpenterEffect());
        }
    }

    class WilyCarpenterEffect : OneShotEffect
    {

        public WilyCarpenterEffect(WilyCarpenterEffect effect) : base(effect)
        {
        }

        public WilyCarpenterEffect()
        {
        }

        public override void Apply()
        {
            Applier.DrawCardsOptionally(Ability, 2);
            Applier.DiscardOwnCards(Ability, 2);
        }

        public override IOneShotEffect Copy()
        {
            return new WilyCarpenterEffect(this);
        }

        public override string ToString()
        {
            return "Draw up to 2 cards. Then discard 2 cards from your hand.";
        }
    }
}
