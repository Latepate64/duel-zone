using Cards.OneShotEffects;

namespace Cards.Cards.DM04
{
    class CloneFactory : Spell
    {
        public CloneFactory() : base("Clone Factory", 3, Engine.Civilization.Water)
        {
            AddSpellAbilities(new ReturnUpToCardsFromYourManaZoneToYourHandEffect(2));
        }
    }
}
