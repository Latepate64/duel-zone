﻿using Common;

namespace Cards.Cards.DM06
{
    class GraveWormQ : Creature
    {
        public GraveWormQ() : base("Grave Worm Q", 5, 3000, Civilization.Darkness)
        {
            AddSubtypes(Subtype.Survivor, Subtype.ParasiteWorm);
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(Subtype.Survivor)));
        }
    }
}
