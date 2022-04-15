using Common;

namespace Cards.Cards.DM05
{
    class SinisterGeneralDamudo : Creature
    {
        public SinisterGeneralDamudo() : base("Sinister General Damudo", 6, 5000, Engine.Subtype.DarkLord, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000));
        }
    }
}
