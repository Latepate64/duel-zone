using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM12
{
    public class ValkyerStarstormElemental : Creature
    {
        public ValkyerStarstormElemental() : base("Valkyer, Starstorm Elemental", 5, Civilization.Light, 7000, Subtype.AngelCommand)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
