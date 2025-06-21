using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;

/// <summary>
/// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
/// </summary>
public class ManaZone : Zone, IManaZone
{
    public ManaZone(params ICard[] cards) : base(ZoneType.ManaZone, cards) { }

    public ManaZone(ManaZone zone) : base(zone)
    {
    }

    public IEnumerable<ICard> TappedCards => Cards.Where(card => card.Tapped);
    public IEnumerable<ICard> UntappedCards => Cards.Where(card => !card.Tapped);

    public bool AreAllCivilizationCards(Civilization civ) => Cards.All(x => x.HasCivilization(civ));

    public override IZone Copy()
    {
        return new ManaZone(this);
    }

    public IEnumerable<ICard> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum)
    {
        return Creatures.Where(c => !c.IsEvolutionCreature && c.ManaCost <= maximum);
    }
}
