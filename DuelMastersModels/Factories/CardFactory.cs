using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.Factories
{
    internal static class CardFactory
    {
        internal static IDeckCard GenerateDeckCard(ICard card)
        {
            if (card is ICreature creature)
            {
                return new DeckCreature(creature);
            }
            else if (card is ISpell spell)
            {
                return new DeckSpell(spell);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }

        internal static IGraveyardCard GenerateGraveyardCard(ICard card)
        {
            if (card is ICreature creature)
            {
                return new GraveyardCreature(creature);
            }
            else if (card is ISpell spell)
            {
                return new GraveyardSpell(spell);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }

        internal static IHandCard GenerateHandCard(ICard card)
        {
            if (card is ICreature creature)
            {
                return new HandCreature(creature);
            }
            else if (card is ISpell spell)
            {
                return new HandSpell(spell);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }

        internal static IManaZoneCard GenerateManaZoneCard(ICard card)
        {
            if (card is ICreature creature)
            {
                return new ManaZoneCreature(creature);
            }
            else if (card is ISpell spell)
            {
                return new ManaZoneSpell(spell);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }

        internal static IShieldZoneCard GenerateShieldZoneCard(ICard card, bool knownToOwner)
        {
            if (card is ICreature creature)
            {
                return new ShieldZoneCreature(creature) { KnownToOwner = knownToOwner };
            }
            else if (card is ISpell spell)
            {
                return new ShieldZoneSpell(spell) { KnownToOwner = knownToOwner };
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(card));
            }
        }
    }
}
