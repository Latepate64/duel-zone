﻿using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base(3, Civilization.Water, 2000, Race.LiquidPeople)
        {
            TriggerAbilities.Add(new AquaHulcusAbility(this));
        }
    }

    public class AquaHulcusAbility : TriggeredAbility
    {
        public AquaHulcusAbility(Card source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source) { }

        public override Choice Resolve(Duel duel, Choice choice)
        {
            if (choice == null) { return new YesNoChoice(Controller); }
            if ((choice as YesNoChoice).Decision) { Controller.DrawCards(1); }
            return null;
        }

        public override NonStaticAbility Copy()
        {
            return new AquaHulcusAbility(Source);
        }
    }
}
