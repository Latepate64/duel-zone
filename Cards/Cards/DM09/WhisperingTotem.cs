using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class WhisperingTotem : Creature
    {
        public WhisperingTotem() : base("Whispering Totem", 4, 2000, Engine.Race.MysteryTotem, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new WhisperingTotemEffect());
        }
    }

    class WhisperingTotemEffect : SearchCardWithNameEffect
    {
        public WhisperingTotemEffect(SearchCardWithNameEffect effect) : base(effect)
        {
        }

        public WhisperingTotemEffect() : base("Whispering Totem")
        {
        }

        public override IOneShotEffect Copy()
        {
            return new WhisperingTotemEffect(this);
        }
    }
}
