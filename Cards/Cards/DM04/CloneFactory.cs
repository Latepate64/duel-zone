using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM04
{
    class CloneFactory : Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Civilization.Water)
        {
            AddSpellAbilities(new ReturnUpToCardsFromYourManaZoneToYourHandEffect(2));
        }
    }
}
