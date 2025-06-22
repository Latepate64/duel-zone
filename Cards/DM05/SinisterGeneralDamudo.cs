using TriggeredAbilities;

namespace Cards.DM05
{
    sealed class SinisterGeneralDamudo : Engine.Creature
    {
        public SinisterGeneralDamudo() : base("Sinister General Damudo", 6, 5000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000)));
        }
    }
}
