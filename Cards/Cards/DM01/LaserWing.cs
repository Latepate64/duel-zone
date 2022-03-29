using Cards.CardFilters;
using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class LaserWing : Spell
    {
        public LaserWing() : base("Laser Wing", 5, Common.Civilization.Light)
        {
            AddSpellAbilities(new LaserWingEffect());
        }
    }

    class LaserWingEffect : CreateContinuousEffectChoiceEffect
    {
        public LaserWingEffect() : base(new OwnersBattleZoneCreatureFilter(), 0, 2, true, new ThisCreatureCannotBeBlockedThisTurnEffect())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LaserWingEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 of your creatures in the battle zone. They can't be blocked this turn.";
        }
    }
}
