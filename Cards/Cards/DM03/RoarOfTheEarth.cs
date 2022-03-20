using Common;

namespace Cards.Cards.DM03
{
    class RoarOfTheEarth : Spell
    {
        public RoarOfTheEarth() : base("Roar of the Earth", 2, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new RoarOfTheEarthEffect());
        }
    }

    class RoarOfTheEarthEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public RoarOfTheEarthEffect() : base(new OneShotEffects.SelfManaRecoveryEffect(1, 1, true, new CardFilters.OwnersManaZoneMinCostCreatureFilter(6))) { }

        public override string ToString()
        {
            return "Return a creature that costs 6 or more from your mana zone to your hand.";
        }
    }
}
