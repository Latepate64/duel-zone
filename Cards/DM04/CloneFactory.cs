using OneShotEffects;

namespace Cards.DM04
{
    sealed class CloneFactory : Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new ReturnUpToTwoCardsFromYourManaZoneToYourHandEffect());
        }
    }
}
