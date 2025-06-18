using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SpiralGate : Engine.Spell
    {
        public SpiralGate() : base("Spiral Gate", 2, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
