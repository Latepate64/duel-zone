using OneShotEffects;

namespace Cards.DM01
{
    sealed class SpiralGate : Spell
    {
        public SpiralGate() : base("Spiral Gate", 2, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
