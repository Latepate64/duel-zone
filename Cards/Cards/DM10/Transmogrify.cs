﻿using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class Transmogrify : Spell
    {
        public Transmogrify() : base("Transmogrify", 3, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new TransmogrifyEffect());
        }
    }

    public class TransmogrifyEffect : OneShotEffect
    {
        public TransmogrifyEffect()
        {
        }

        public TransmogrifyEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var destroyedCreature = Controller.DestroyCreatureOptionally(game, Ability);
            if (destroyedCreature != null)
            {
                destroyedCreature.Owner.RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(game, Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new TransmogrifyEffect(this);
        }

        public override string ToString()
        {
            return "You may destroy a creature. If you do, its owner reveals cards from the top of his deck until he reveals a non-evolution creature. He puts that creature into the battle zone and puts the rest of those cards into his graveyard.";
        }
    }
}
