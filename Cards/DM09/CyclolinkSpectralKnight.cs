using TriggeredAbilities;

namespace Cards.DM09
{
    class CyclolinkSpectralKnight : Engine.Creature
    {
        public CyclolinkSpectralKnight() : base("Cyclolink, Spectral Knight", 4, 3000, Interfaces.Race.RainbowPhantom, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
