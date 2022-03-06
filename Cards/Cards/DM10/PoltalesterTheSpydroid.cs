using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class PoltalesterTheSpydroid : Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, 2000, Common.Subtype.Soltrooper, Common.Civilization.Light)
        {
            ShieldTrigger = true;
            AddAbilities(new BlockerAbility(), new CannotAttackPlayersAbility());
        }
    }
}
