using System;
using System.ComponentModel;
using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;

namespace Simulator.Cards;

internal static class EffectConverter
{
    public static IEffect ToEffect(effect effect, string param1, string param2)
    {
        return effect switch
        {
            effect.Eachofyourcreaturesinthebattlezonegetspowerattacker1untiltheendoftheturn => new AuraBlastEffect(int.Parse(param1)),
            effect.Eachofyourothercreaturesinbattlezonegets1powerandhasblockeranddoublebreaker => new KilstineNebulaElementalEffect(int.Parse(param1)),
            // effect.Youmaydrawacard => new Cards.OneShotEffects.YouMayDrawCardsEffect(1),
            effect.Whenthiscreaturewouldbedestroyedreturnittoyourhandinstead => new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect(),
            effect.Chooseupto2creaturesinthebattlezoneandreturnthemtotheirownershands => new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect(),
            effect.Whileyouhaveatleastone1inthebattlezonethiscreaturegets2powerduringitsattacks => new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(int.Parse(param2), Enum.Parse<Race>(param1)),
            _ => throw new InvalidEnumArgumentException(),
        };
    }
}
