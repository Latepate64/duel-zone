﻿using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class BazagazealDragon : Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, Civilization.Fire, 8000, Subtype.ArmoredDragon)
        {
            AddAbilities(new SpeedAttackerAbility(), new CanAttackUntappedCreaturesAbility(), new DoubleBreakerAbility(), new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
