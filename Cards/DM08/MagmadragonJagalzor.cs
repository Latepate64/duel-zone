using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

sealed class MagmadragonJagalzor : TurboRushCreature
{
    public MagmadragonJagalzor() : base("Magmadragon Jagalzor", 6, 6000, Race.VolcanoDragon, Civilization.Fire)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTurboRushAbility(new MagmadragonJagalzorEffect());
    }
}
