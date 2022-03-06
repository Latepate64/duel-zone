﻿using Common;

namespace Cards.Cards.DM05
{
    class AmbushScorpion : Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000));

            // When this creature is destroyed, you may choose an Ambush Scorpion in your mana zone and put it into the battle zone.
            AddAbilities(new TriggeredAbilities.DestroyedAbility(new OneShotEffects.AmbushScorpionEffect()));
        }
    }
}
