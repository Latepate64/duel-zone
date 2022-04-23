using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class LivingCitadelVosh : EvolutionCreature
    {
        public LivingCitadelVosh() : base("Living Citadel Vosh", 5, 5000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Engine.Civilization.Nature, new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
