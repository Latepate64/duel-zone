using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Creature is a card type.
    /// </summary>
    public class Creature : Card
    {
        #region Properties
        /// <summary>
        /// The base power of creature. Use Duel's method GetPower(creature) in order to get the actual power of a creature.
        /// </summary>
        public int Power { get; private set; }

        /// <summary>
        /// Race is a characteristic of a creature.
        /// </summary>
        public ReadOnlyCollection<string> Races => new ReadOnlyCollection<string>(_races);

        /// <summary>
        /// Summoning sickness limits when a creature is able to attack.
        /// </summary>
        public bool SummoningSickness { get; internal set; } = true;
        #endregion Properties

        private readonly ReadOnlyCollection<string> _races;

        /// <summary>
        /// Creates a creature.
        /// </summary>
        public Creature(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, string power, Collection<string> races) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator)
        {
            if (power == null)
            {
                throw new System.ArgumentNullException("power");
            }
            Power = int.Parse(power.Replace("+", "").Replace("-", ""), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            _races = new ReadOnlyCollection<string>(races);
        }
    }
}
