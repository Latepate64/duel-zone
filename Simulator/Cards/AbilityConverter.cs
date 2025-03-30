using System.ComponentModel;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Simulator.Cards;

internal static class AbilityConverter
{
    public static IAbility ToAbility(ability ability, CardType cardType)
    {
        var effect = EffectConverter.ToEffect(ability.effect, ability.param1, ability.param2);
        if (cardType == CardType.Spell)
        {
            return new SpellAbility(effect as IOneShotEffect);
        }
        if (ability.type == abilityType.wavestriker)
        {
            return new WaveStrikerAbility(new StaticAbility(effect as IContinuousEffect)); //TODO: wavestrikerabilities could also be triggered or activated
        }
        if (ability.trigger != trigger.none)
        {
            return ToTriggeredAbility(ability.trigger, effect as IOneShotEffect);
        }
        return new StaticAbility(effect as IContinuousEffect);
    }

    static TriggeredAbility ToTriggeredAbility(trigger trigger, IOneShotEffect effect)
    {
        return trigger switch
        {
            trigger.none => throw new InvalidEnumArgumentException(),
            // trigger.Whenyouputthiscreatureintothebattlezone => new WhenYouPutThisCreatureIntoTheBattleZoneAbility(effect),
            _ => throw new InvalidEnumArgumentException(),
        };
    }
}
