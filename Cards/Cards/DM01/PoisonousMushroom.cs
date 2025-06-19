using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000, Engine.Race.BalloonMushroom, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PoisonousMushroomEffect()));
        }
    }

    class PoisonousMushroomEffect : YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect
    {
        public PoisonousMushroomEffect() : base(1)
        {
        }

        public PoisonousMushroomEffect(PoisonousMushroomEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PoisonousMushroomEffect(this);
        }
    }
}
