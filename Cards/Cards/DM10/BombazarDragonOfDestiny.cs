using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM10
{
    public class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, 6000)
        {
            AddCivilizations(Civilization.Fire, Civilization.Nature);
            AddSubtypes(Subtype.ArmoredDragon, Subtype.EarthDragon);

            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new DoubleBreakerAbility());
            // When you put this creature into the battle zone, destroy all other creatures that have 6000 power. Take an extra turn after this one. You lose the game at the end of that turn.
            Abilities.Add(new PutIntoPlayAbility(new BombazarDragonOfDestinyEffect()));
        }
    }
}
