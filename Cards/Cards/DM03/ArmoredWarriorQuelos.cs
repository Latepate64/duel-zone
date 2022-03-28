using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class ArmoredWarriorQuelos : Creature
    {
        public ArmoredWarriorQuelos() : base("Armored Warrior Quelos", 5, 2000, Subtype.Armorloid, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new ArmoredWarriorQuelosEffect());
        }
    }

    class ArmoredWarriorQuelosEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new ArmoredWarriorQuelosMana1Effect(), new ArmoredWarriorQuelosMana2Effect()})
            {
                effect.Apply(game, source);
            }
            return null;
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
        public ArmoredWarriorQuelosMana1Effect() : base(new OwnersManaZoneCivilizationCardFilter(Civilization.Light, Civilization.Water, Civilization.Darkness, Civilization.Nature), 1, 1, true)
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
    }

    class ArmoredWarriorQuelosMana2Effect : ManaBurnEffect
    {
        public ArmoredWarriorQuelosMana2Effect() : base(new OpponentsManaZoneCivilizationCardFilter(Civilization.Light, Civilization.Water, Civilization.Darkness, Civilization.Nature), 1, 1, false)
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
    }
}
