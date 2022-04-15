using Common;

namespace Cards.Cards.DM09
{
    class CyclolinkSpectralKnight : Creature
    {
        public CyclolinkSpectralKnight() : base("Cyclolink, Spectral Knight", 4, 3000, Engine.Subtype.RainbowPhantom, Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
