using Cards.StaticAbilities;

namespace Cards.Cards.DM11
{
    public class EngbeltTheSpydroid : Creature
    {
        public EngbeltTheSpydroid() : base("Engbelt, the Spydroid", 4, Common.Civilization.Light, 5500, Common.Subtype.Soltrooper)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
