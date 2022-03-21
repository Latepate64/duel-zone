﻿using Common;

namespace Cards.Cards.DM04
{
    class DoboulgyserGiantRockBeast : EvolutionCreature
    {
        public DoboulgyserGiantRockBeast() : base("Doboulgyser, Giant Rock Beast", 6, 8000, Subtype.RockBeast, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}