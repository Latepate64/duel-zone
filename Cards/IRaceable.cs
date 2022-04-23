using Engine;

namespace Cards
{
    interface IRaceable
    {
        Race Race { get; }
    }

    interface IMultiRaceable
    {
        Race[] Races { get; }
    }

    interface IPowerable
    {
        int Power { get; }
    }

    interface ICivilizationable
    {
        Civilization Civilization { get; }
    }

    interface IMultiCivilizationable
    {
        Civilization[] Civilizations { get; }
    }

    interface ICardAffectable
    {
        ICard Card { get; }
    }
}
