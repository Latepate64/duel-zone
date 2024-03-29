﻿using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class WaveLance : Spell
    {
        public WaveLance() : base("Wave Lance", 3, Civilization.Water)
        {
            AddSpellAbilities(new WaveLanceEffect());
        }
    }

    class WaveLanceEffect : OneShotEffect
    {
        public WaveLanceEffect()
        {
        }

        public WaveLanceEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creature = Controller.ChooseCard(game.BattleZone.Creatures, ToString());
            if (creature != null)
            {
                game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, creature);
                if (creature.IsDragon)
                {
                    Controller.DrawCardsOptionally(game, Ability, 1);
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new WaveLanceEffect(this);
        }

        public override string ToString()
        {
            return "Choose a creature in the battle zone and return it to its owner's hand. If it has Dragon in its race, you may draw a card.";
        }
    }
}
