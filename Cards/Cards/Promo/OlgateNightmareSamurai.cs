﻿using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.Promo
{
    class OlgateNightmareSamurai : Creature
    {
        public OlgateNightmareSamurai() : base("Olgate, Nightmare Samurai", 7, 6000, Engine.Subtype.DemonCommand, Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
            AddTriggeredAbility(new OlgateAbility());
        }
    }

    class OlgateAbility : DestroyedAbility
    {
        public OlgateAbility() : base(new OneShotEffects.YouMayUntapThisCreatureEffect())
        {
        }

        public OlgateAbility(OlgateAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new OlgateAbility();
        }

        public override string ToString()
        {
            return "Whenever one of your creatures is destroyed, you may untap this creature.";
        }

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return card.Owner == Controller && card.Id != Source;
        }
    }
}
