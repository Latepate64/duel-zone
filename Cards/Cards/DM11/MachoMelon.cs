using Common;

namespace Cards.Cards.DM11
{
    class MachoMelon : WaveStrikerCreature
    {
        public MachoMelon() : base("Macho Melon", 2, 1000, Subtype.WildVeggies, Civilization.Nature)
        {
            AddWaveStrikerAbility(new ContinuousEffects.PowerAttackerEffect(3000));
        }
    }
}
