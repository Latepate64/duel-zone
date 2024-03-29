﻿namespace Cards.Cards.DM11
{
    class YulianaChannelerOfSuns : Creature
    {
        public YulianaChannelerOfSuns() : base("Yuliana, Channeler of Suns", 3, 3000, Engine.Race.MechaDelSol, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddStaticAbilities(new ContinuousEffects.OpponentCannotChooseThisCreatureEffect());
        }
    }
}
