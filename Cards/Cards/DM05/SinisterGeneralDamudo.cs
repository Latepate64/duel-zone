using Common;

namespace Cards.Cards.DM05
{
    class SinisterGeneralDamudo : Creature
    {
        public SinisterGeneralDamudo() : base("Sinister General Damudo", 6, 5000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000)));
        }
    }
}
