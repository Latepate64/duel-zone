using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class RoarOfTheEarth : Spell
    {
        public RoarOfTheEarth() : base("Roar of the Earth", 2, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new RoarOfTheEarthEffect());
        }
    }

    class RoarOfTheEarthEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public RoarOfTheEarthEffect() : base(1, 1, true, new CardFilters.OwnersManaZoneMinCostCreatureFilter(6)) { }

        public override IOneShotEffect Copy()
        {
            return new RoarOfTheEarthEffect();
        }

        public override string ToString()
        {
            return "Return a creature that costs 6 or more from your mana zone to your hand.";
        }
    }
}
