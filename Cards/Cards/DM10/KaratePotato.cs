using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class KaratePotato : Creature
    {
        public KaratePotato() : base("Karate Potato", 4, 1000, Engine.Race.WildVeggies, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new KaratePotatoEffect());
        }
    }

    class KaratePotatoEffect : YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect
    {
        public KaratePotatoEffect() : base(2)
        {
        }

        public KaratePotatoEffect(YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new KaratePotatoEffect(this);
        }
    }
}
