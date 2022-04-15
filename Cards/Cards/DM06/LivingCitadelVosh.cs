using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class LivingCitadelVosh : EvolutionCreature
    {
        public LivingCitadelVosh() : base("Living Citadel Vosh", 5, 5000, Engine.Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Civilization.Nature, new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
