using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class KaratePotato : Engine.Creature
    {
        public KaratePotato() : base("Karate Potato", 4, 1000, Engine.Race.WildVeggies, Engine.Civilization.Nature)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KaratePotatoEffect()));
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
