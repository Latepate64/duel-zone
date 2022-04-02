﻿using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class SirenConcerto : Spell
    {
        public SirenConcerto() : base("Siren Concerto", 1, Civilization.Water)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new SirenConcertoEffect());
        }
    }

    class SirenConcertoEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new IOneShotEffect[] { new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect(), new PutCardFromYourHandIntoYourManaZone() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SirenConcertoEffect();
        }

        public override string ToString()
        {
            return "Put a card from your mana zone into your hand. Then put a card from your hand into your mana zone.";
        }
    }

    class PutCardFromYourHandIntoYourManaZone : OneShotEffects.CardMovingChoiceEffect
    {
        public PutCardFromYourHandIntoYourManaZone() : base(new CardFilters.OwnersHandCardFilter(), 1, 1, true, ZoneType.Hand, ZoneType.ManaZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PutCardFromYourHandIntoYourManaZone();
        }

        public override string ToString()
        {
            return "Put a card from your hand into your mana zone.";
        }
    }
}