using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class LivingCitadelVosh : EvolutionCreature
    {
        public LivingCitadelVosh() : base("Living Citadel Vosh", 5, 5000, Engine.Subtype.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Engine.Civilization.Nature, new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
