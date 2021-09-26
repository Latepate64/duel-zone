using System;
using System.Collections.Generic;

namespace DuelMastersModels.Cards.Creatures
{
    public class GontaTheWarriorSavage : Creature
    {
        public GontaTheWarriorSavage(Guid owner) : base(owner, 2, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 4000, new List<Race> { Race.Human, Race.BeastFolk })
        {
        }

        public GontaTheWarriorSavage(GontaTheWarriorSavage x) : base(x) { }

        public override Card Copy()
        {
            return new GontaTheWarriorSavage(this);
        }
    }
}
