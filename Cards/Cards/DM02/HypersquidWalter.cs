﻿namespace Cards.Cards.DM02
{
    class HypersquidWalter : Creature
    {
        public HypersquidWalter() : base("Hypersquid Walter", 3, 1000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            // Whenever this creature attacks, you may draw a card.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.ControllerMayDrawCardsEffect(1)));
        }
    }
}
