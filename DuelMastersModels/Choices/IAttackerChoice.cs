﻿using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public interface IAttackerChoice
    {
        IEnumerable<Creature> AttackCreatures { get; }
    }
}