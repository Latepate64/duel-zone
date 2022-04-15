﻿namespace Cards.Cards.DM01
{
    class Draglide : Creature
    {
        public Draglide() : base("Draglide", 5, 5000, Engine.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureAttacksEachTurnIfAbleEffect());
        }
    }
}
