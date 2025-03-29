using System.ComponentModel;
using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;

namespace Simulator.Cards;

internal static class EffectConverter
{
    public static IEffect ToEffect(effect effect, string param)
    {
        return effect switch
        {
            effect.Eachofyourcreaturesinthebattlezonegetspowerattacker1untiltheendoftheturn => new AuraBlastEffect(int.Parse(param)),
            effect.Eachofyourothercreaturesinbattlezonegets1powerandhasblockeranddoublebreaker => new KilstineNebulaElementalEffect(int.Parse(param)),
            effect.Youmaydrawacard => new YouMayDrawCardsEffect(1),
            _ => throw new InvalidEnumArgumentException(),
        };
    }
}
