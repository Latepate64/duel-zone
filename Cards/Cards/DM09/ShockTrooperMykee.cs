﻿namespace Cards.Cards.DM09
{
    class ShockTrooperMykee : Creature
    {
        public ShockTrooperMykee() : base("Shock Trooper Mykee", 6, 1000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
        }
    }
}
