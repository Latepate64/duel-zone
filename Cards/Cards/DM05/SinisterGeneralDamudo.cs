using Cards.TriggeredAbilities;

namespace Cards.Cards.DM05
{
    class SinisterGeneralDamudo : Engine.Creature
    {
        public SinisterGeneralDamudo() : base("Sinister General Damudo", 6, 5000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000)));
        }
    }
}
