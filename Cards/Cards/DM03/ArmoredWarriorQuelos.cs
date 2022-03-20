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
            AddAbilities(new TriggeredAbilities.AttackAbility(new ArmoredWarriorQuelosEffect()));
        }
    }

    class ArmoredWarriorQuelosEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var filter1 = new OwnersManaZoneCivilizationCardFilter(Civilization.Light, Civilization.Water, Civilization.Darkness, Civilization.Nature);
            var filter2 = new OpponentsManaZoneCivilizationCardFilter(Civilization.Light, Civilization.Water, Civilization.Darkness, Civilization.Nature);
            foreach (var effect in new OneShotEffect[] { new ManaBurnEffect(filter1, 1, 1, true), new ManaBurnEffect(filter2, 1, 1, false)})
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new ArmoredWarriorQuelosEffect();
        }

        public override string ToString()
        {
            return "Put a non-fire card from your mana zone into your graveyard. Then your opponent chooses a non-fire card in his mana zone and puts it into his graveyard.";
        }
    }
}
