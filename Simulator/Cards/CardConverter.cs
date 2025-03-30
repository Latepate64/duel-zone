using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Engine;

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
            PrintedAbilities = card.abilities != null
                ? [.. card.abilities.Select(x => AbilityConverter.ToAbility(x, cardType))]
                : [],
            Civilizations = [.. card.civilizations.Select(ToCivilization)],
            ManaCost = int.Parse(card.cost),
            Name = card.name,
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
            race.Armorloid => Race.Armorloid,
            race.LiquidPeople => Race.LiquidPeople,
            race.BeastFolk => Race.BeastFolk,
            race.Berserker => Race.Berserker,
            race.GiantInsect => Race.GiantInsect,
            race.Human => Race.Human,
            race.Initiate => Race.Initiate,
            race.LightBringer => Race.LightBringer,
            race.LivingDead => Race.LivingDead,
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