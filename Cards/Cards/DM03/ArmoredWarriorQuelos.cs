using Engine;
using Engine.Abilities;
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
        public override void Apply(IGame game)
        {
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, Applier.ChooseCard(Applier.ManaZone.Cards.Where(x => !x.HasCivilization(Civilization.Fire)), ToString()));
            game.Move(Ability, ZoneType.ManaZone, ZoneType.Graveyard, Applier.Opponent.ChooseCard(Applier.Opponent.ManaZone.Cards.Where(x => !x.HasCivilization(Civilization.Fire)), ToString()));
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
}
