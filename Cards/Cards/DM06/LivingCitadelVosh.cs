using Common;

namespace Cards.Cards.DM06
{
    class LivingCitadelVosh : EvolutionCreature
    {
        public LivingCitadelVosh() : base("Living Citadel Vosh", 5, 5000, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.TapAbilityAddingAbility(Civilization.Nature, new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
