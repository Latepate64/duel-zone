using ContinuousEffects;

namespace Cards.DM06
{
    class LivingCitadelVosh : EvolutionCreature
    {
        public LivingCitadelVosh() : base("Living Citadel Vosh", 5, 5000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Interfaces.Civilization.Nature, new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
