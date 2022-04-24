using Combinatorics.Collections;
using Engine;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class VortexEvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        public VortexEvolutionEffect(Race race1, Race race2)
        {
            Race1 = race1;
            Race2 = race2;
        }

        public VortexEvolutionEffect(VortexEvolutionEffect effect) : base(effect)
        {
            Race1 = effect.Race1;
            Race2 = effect.Race2;
        }

        public Race Race1 { get; }
        public Race Race2 { get; }

        public bool CanEvolve(IGame game, ICard evolutionCreature)
        {
            var baits = game.BattleZone.GetCreatures(evolutionCreature.Owner.Id);
            var combinations = new Combinations<ICard>(baits, 2, GenerateOption.WithoutRepetition);
            var foo = combinations.Where(x => CanEvolveFrom(game, evolutionCreature, x[0], x[x.Count - 1]));
            return baits.Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }

        private bool CanEvolveFrom(IGame game, ICard evolutionCreature, ICard bait1, ICard bait2)
        {
            if (IsSourceOfAbility(evolutionCreature))
            {
                if (bait1.HasRace(Race1))
                {
                    return bait2.HasRace(Race2);
                }
                else if (bait1.HasRace(Race2))
                {
                    return bait2.HasRace(Race1);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CanEvolveFrom(ICard bait, ICard evolutionCreature, IGame game)
        {
            throw new NotImplementedException();
        }

        public override IContinuousEffect Copy()
        {
            return new VortexEvolutionEffect(this);
        }

        public override string ToString()
        {
            return $"Vortex evolution — Put on one of your {Race1}s and one of your {Race2}s.";
        }
    }
}
