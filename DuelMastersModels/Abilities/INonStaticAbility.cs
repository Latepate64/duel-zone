using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Abilities
{
    public interface INonStaticAbility : IAbility
    {
        IPlayer Controller { get; set; }
        ReadOnlyOneShotEffectCollection Effects { get; }

        PlayerActionWithEndInformation ContinueResolution(IDuel duel);
    }
}