using TriggeredAbilities;

namespace Cards.DM09
{
    class CyclolinkSpectralKnight : Engine.Creature
    {
        public CyclolinkSpectralKnight() : base("Cyclolink, Spectral Knight", 4, 3000, Engine.Race.RainbowPhantom, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
