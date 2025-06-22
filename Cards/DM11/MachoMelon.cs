using ContinuousEffects;

namespace Cards.DM11
{
    sealed class MachoMelon : WaveStrikerCreature
    {
        public MachoMelon() : base("Macho Melon", 2, 1000, Interfaces.Race.WildVeggies, Interfaces.Civilization.Nature)
        {
            AddWaveStrikerAbility(new PowerAttackerEffect(3000));
        }
    }
}
