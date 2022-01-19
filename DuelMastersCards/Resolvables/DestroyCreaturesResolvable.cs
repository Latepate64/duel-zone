﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class DestroyCreaturesResolvable : Resolvable
    {
        public CardFilter Filter { get; }

        public DestroyCreaturesResolvable(CardFilter filter)
        {
            Filter = filter;
        }

        public DestroyCreaturesResolvable(DestroyCreaturesResolvable resolvable) : base(resolvable)
        {
            Filter = resolvable.Filter;
        }

        public override Resolvable Copy()
        {
            return new DestroyCreaturesResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            duel.Destroy(duel.CreaturePermanents.Where(x => Filter.Applies(x, duel)).ToList());
        }
    }
}
