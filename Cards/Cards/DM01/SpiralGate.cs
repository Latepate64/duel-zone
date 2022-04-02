using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class SpiralGate : Spell
    {
        public SpiralGate() : base("Spiral Gate", 2, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect());
        }
    }
}
