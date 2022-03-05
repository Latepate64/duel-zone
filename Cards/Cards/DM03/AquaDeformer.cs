﻿using Common;

namespace Cards.Cards.DM03
{
    public class AquaDeformer : Creature
    {
        public AquaDeformer() : base("Aqua Deformer", 8, Civilization.Water, 3000, Subtype.LiquidPeople)
        {
            // When you put this creature into the battle zone, return 2 cards from your mana zone to your hand. Then your opponent chooses 2 cards in his mana zone and returns them to his hand.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShtraEffect(2)));
        }
    }
}
