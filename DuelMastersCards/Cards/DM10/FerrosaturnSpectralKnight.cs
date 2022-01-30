using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM10
{
    public class FerrosaturnSpectralKnight : Creature
    {
        public FerrosaturnSpectralKnight() : base("Ferrosaturn, Spectral Knight", 1, Civilization.Light, 2000, Subtype.RainbowPhantom)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
