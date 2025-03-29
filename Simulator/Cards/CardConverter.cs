using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Simulator.Cards;

internal static class CardConverter
{
    public static IEnumerable<Card> Convert(cards cards)
    {
        var converted = new List<Card>();
        converted.AddRange(cards.creature.Select(ToCreature));
        converted.AddRange(cards.spell.Select(ToSpell));
        return converted;
    }

    static Card ToCard(card card, CardType cardType)
    {
        return new Card
        {
            PrintedAbilities = [.. card.abilities.Select(x => ToAbility(x, cardType))],
            Civilizations = [.. card.civilizations.Select(ToCivilization)],
            ManaCost = int.Parse(card.cost),
            Name = card.name,
        };
    }

    static IAbility ToAbility(ability ability, CardType cardType)
    {
        var effect = ToEffect(ability.effect, ability.param1);
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
            trigger.Whenyouputthiscreatureintothebattlezone => new WhenYouPutThisCreatureIntoTheBattleZoneAbility(effect),
            _ => throw new InvalidEnumArgumentException(),
        };
    }

    static IEffect ToEffect(effect effect, string param)
    {
        return effect switch
        {
            effect.Eachofyourcreaturesinthebattlezonegetspowerattacker1untiltheendoftheturn => new AuraBlastEffect(int.Parse(param)),
            effect.Eachofyourothercreaturesinbattlezonegets1powerandhasblockeranddoublebreaker => new KilstineNebulaElementalEffect(int.Parse(param)),
            effect.Youmaydrawacard => new YouMayDrawCardsEffect(1),
            _ => throw new InvalidEnumArgumentException(),
        };
    }

    static Card ToSpell(spell spell)
    {
        var card = ToCard(spell, CardType.Spell);
        card.CardType = CardType.Spell;
        return card;
    }

    static Card ToCreature(creature creature)
    {
        var card = ToCard(creature, CardType.Creature);
        card.CardType = CardType.Creature;
        card.PrintedPower = int.Parse(creature.power);
        card.Races = [.. creature.races.Select(ToRace)];
        return card;
    }

    static Race ToRace(race race)
    {
        return race switch
        {
            race.AngelCommand => Race.AngelCommand,
            race.LiquidPeople => Race.LiquidPeople,
            _ => throw new InvalidEnumArgumentException(),
        };
    }

    static Civilization ToCivilization(civilization civilization)
    {
        return civilization switch
        {
            civilization.Light => Civilization.Light,
            civilization.Water => Civilization.Water,
            civilization.Darkness => Civilization.Darkness,
            civilization.Fire => Civilization.Fire,
            civilization.Nature => Civilization.Nature,
            _ => throw new InvalidEnumArgumentException(),
        };
    }
}