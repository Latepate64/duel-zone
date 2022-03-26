using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class DolmarksTheShadowWarrior : Creature
    {
        public DolmarksTheShadowWarrior() : base("Dolmarks, the Shadow Warrior", 4, 4000, Civilization.Darkness, Civilization.Fire)
        {
            AddSubtypes(Subtype.Ghost, Subtype.Human);
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new DolmarksTheShadowWarriorEffect()));
        }
    }

    class DolmarksTheShadowWarriorEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            foreach (var effect in new OneShotEffect[] { new SacrificeEffect(), new PutCardsFromYourManaZoneIntoYourGraveyard(1), new OpponentSacrificeEffect(), new YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(1) })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new DolmarksTheShadowWarriorEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures and put a card from your mana zone into your graveyard. Then your opponent chooses and destroys one of his creatures and chooses a card in his mana zone and puts it into his graveyard.";
        }
    }
}
