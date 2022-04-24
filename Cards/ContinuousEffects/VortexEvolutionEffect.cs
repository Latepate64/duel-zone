using Combinatorics.Collections;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
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
            var validPairs = combinations.Where(x => CanEvolveFrom(evolutionCreature, x[0], x[x.Count - 1]));
            return validPairs.Any();
        }

        private bool CanEvolveFrom(ICard evolutionCreature, ICard bait1, ICard bait2)
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

        public override IContinuousEffect Copy()
        {
            return new VortexEvolutionEffect(this);
        }

        public override string ToString()
        {
            return $"Vortex evolution — Put on one of your {Race1}s and one of your {Race2}s.";
        }

        public void Evolve(ICard evolutionCreature, IGame game)
        {
            var creatures = game.BattleZone.GetCreatures(evolutionCreature.Owner.Id);
            System.Collections.Generic.IEnumerable<ICard> baits;
            do
            {
                baits = evolutionCreature.Owner.ChooseCards(creatures, 2, 2, "Choose creatures to evolve from.");
            }
            while (CanEvolveFrom(evolutionCreature, baits.First(), baits.Last()));
            game.ProcessEvents(new EvolutionEvent(evolutionCreature.Owner, evolutionCreature, baits.ToArray()));
        }
    }
}
