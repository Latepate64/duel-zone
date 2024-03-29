﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM03
{
    class Psyshroom : Creature
    {
        public Psyshroom() : base("Psyshroom", 4, 2000, Race.BalloonMushroom, Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new PsyshroomEffect());
        }
    }

    class PsyshroomEffect : FromGraveyardIntoManaZoneEffect
    {
        public PsyshroomEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PsyshroomEffect();
        }

        public override string ToString()
        {
            return "You may put a nature card from your graveyard into your mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.GetCards(Civilization.Nature);
        }
    }
}
