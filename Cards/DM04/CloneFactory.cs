using OneShotEffects;

namespace Cards.DM04
{
    class CloneFactory : Engine.Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new ReturnUpToTwoCardsFromYourManaZoneToYourHandEffect());
        }
    }
}
