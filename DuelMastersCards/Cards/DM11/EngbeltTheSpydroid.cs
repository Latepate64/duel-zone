using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM11
{
    public class EngbeltTheSpydroid : Creature
    {
        public EngbeltTheSpydroid() : base("Engbelt, the Spydroid", 4, Civilization.Light, 5500, Subtype.Soltrooper)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
