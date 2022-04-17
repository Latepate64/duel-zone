using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SpiralGate : Spell
    {
        public SpiralGate() : base("Spiral Gate", 2, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
