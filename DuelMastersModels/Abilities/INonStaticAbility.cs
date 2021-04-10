using DuelMastersModels.Effects.OneShotEffects;

namespace DuelMastersModels.Abilities
{
    public interface INonStaticAbility
    {
        IPlayer Controller { get; set; }
        ReadOnlyOneShotEffectCollection Effects { get; }

        PlayerActionWithEndInformation ContinueResolution(IDuel duel);
    }
}