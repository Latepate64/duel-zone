﻿using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class JackViperShadowOfDoom : EvolutionCreature
    {
        public JackViperShadowOfDoom() : base("Jack Viper, Shadow of Doom", 3, 4000, Engine.Subtype.Ghost, Civilization.Darkness)
        {
            AddStaticAbilities(new JackViperShadowOfDoomEffect());
        }
    }

    class JackViperShadowOfDoomEffect : DestructionReplacementOptionallyToHandEffect
    {
        public JackViperShadowOfDoomEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new JackViperShadowOfDoomEffect();
        }

        public override string ToString()
        {
            return "Whenever another of your darkness creatures would be put into your graveyard from the battle zone, you may return it to your hand instead.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return !IsSourceOfAbility(card, game) && card.Owner == GetController(game).Id && card.HasCivilization(Civilization.Darkness);
        }
    }
}
