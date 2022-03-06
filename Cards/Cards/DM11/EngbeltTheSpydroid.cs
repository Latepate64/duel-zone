using Cards.StaticAbilities;

namespace Cards.Cards.DM11
{
    class EngbeltTheSpydroid : Creature
    {
        public EngbeltTheSpydroid() : base("Engbelt, the Spydroid", 4, 5500, Common.Subtype.Soltrooper, Common.Civilization.Light)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
