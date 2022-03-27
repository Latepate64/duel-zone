using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class FerrosaturnSpectralKnight : Creature
    {
        public FerrosaturnSpectralKnight() : base("Ferrosaturn, Spectral Knight", 1, 2000, Common.Subtype.RainbowPhantom, Common.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
