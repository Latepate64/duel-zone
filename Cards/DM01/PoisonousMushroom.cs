using TriggeredAbilities;
using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM01
{
    class PoisonousMushroom : Engine.Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000, Interfaces.Race.BalloonMushroom, Interfaces.Civilization.Nature)
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
