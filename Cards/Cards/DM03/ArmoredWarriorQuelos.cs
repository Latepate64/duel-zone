﻿using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class ArmoredWarriorQuelos : Creature
    {
        public ArmoredWarriorQuelos() : base("Armored Warrior Quelos", 5, 2000, Race.Armorloid, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new ArmoredWarriorQuelosEffect());
        }
    }

    class ArmoredWarriorQuelosEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new ArmoredWarriorQuelosMana1Effect(), new ArmoredWarriorQuelosMana2Effect()})
            {
                effect.Apply(game, source);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new ArmoredWarriorQuelosEffect();
        }

        public override string ToString()
        {
            return "Put a non-fire card from your mana zone into your graveyard. Then your opponent chooses a non-fire card in his mana zone and puts it into his graveyard.";
        }
    }

    class ArmoredWarriorQuelosMana1Effect : ManaBurnEffect
    {
        public ArmoredWarriorQuelosMana1Effect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ArmoredWarriorQuelosMana1Effect();
        }

        public override string ToString()
        {
            return "Put a non-fire card from your mana zone into your graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).ManaZone.Cards.Where(x => !x.HasCivilization(Civilization.Fire));
        }
    }

    class ArmoredWarriorQuelosMana2Effect : ManaBurnEffect
    {
        public ArmoredWarriorQuelosMana2Effect() : base(1, 1, false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ArmoredWarriorQuelosMana2Effect();
        }

        public override string ToString()
        {
            return "Your opponent chooses a non-fire card in his mana zone and puts it into his graveyard.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.GetOpponent(game).Id).ManaZone.Cards.Where(x => !x.HasCivilization(Civilization.Fire));
        }
    }
}
