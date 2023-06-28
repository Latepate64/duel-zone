﻿using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.Cards.DM09
{
    class IceVaporShadowOfAnguish : Creature
    {
        public IceVaporShadowOfAnguish() : base("Ice Vapor, Shadow of Anguish", 5, 1000, Race.Ghost, Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverYourOpponentCastsSpellAbility(new IceVaporShadowOfAnguishEffect()));
        }
    }

    class WheneverYourOpponentCastsSpellAbility : TriggeredAbility
    {
        public WheneverYourOpponentCastsSpellAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WheneverYourOpponentCastsSpellAbility(WheneverYourOpponentCastsSpellAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is SpellCastEvent e && e.Player.Id == Controller.Opponent.Id;
        }

        public override IAbility Copy()
        {
            return new WheneverYourOpponentCastsSpellAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever your opponent casts a spell, {GetEffectText()}";
        }
    }

    class IceVaporShadowOfAnguishEffect : OneShotEffect
    {
        public override void Apply()
        {
            Applier.Opponent.DiscardOwnCard(Ability);
            Applier.Opponent.BurnOwnMana(Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new IceVaporShadowOfAnguishEffect();
        }

        public override string ToString()
        {
            return "He chooses and discards a card from his hand, then chooses a card in his mana zone and puts it into his graveyard.";
        }
    }
}
