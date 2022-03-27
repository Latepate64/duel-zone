using Common;

namespace Cards.Cards.DM06
{
    class ProclamationOfDeath : Spell
    {
        public ProclamationOfDeath() : base("Proclamation of Death", 4, Civilization.Darkness)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
