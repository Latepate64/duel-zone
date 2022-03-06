using Cards.StaticAbilities;

namespace Cards.Cards.DM10
{
    class PoltalesterTheSpydroid : Creature
    {
        public PoltalesterTheSpydroid() : base("Poltalester, the Spydroid", 5, Common.Civilization.Light, 2000, Common.Subtype.Soltrooper)
        {
            ShieldTrigger = true;
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
