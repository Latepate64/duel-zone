using OneShotEffects;
using TriggeredAbilities;
using Engine.Abilities;

namespace Cards.DM09
{
    sealed class WhisperingTotem : Engine.Creature
    {
        public WhisperingTotem() : base("Whispering Totem", 4, 2000, Interfaces.Race.MysteryTotem, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WhisperingTotemEffect()));
        }
    }

    sealed class WhisperingTotemEffect : SearchCardWithNameEffect
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
