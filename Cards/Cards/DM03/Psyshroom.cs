﻿using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM03
{
    class Psyshroom : Creature
    {
        public Psyshroom() : base("Psyshroom", 4, Common.Civilization.Nature, 2000, Common.Subtype.BalloonMushroom)
        {
            // Whenever this creature attacks, you may put a nature card from your graveyard into your mana zone.
            var filter = new CardFilters.OwnersGraveyardCardFilter();
            filter.Civilizations.Add(Common.Civilization.Nature);
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new CardMovingChoiceEffect(filter, 0, 1, true, ZoneType.Graveyard, ZoneType.ManaZone)));
        }
    }
}
