using System.Linq;

namespace Engine.Choices
{
    public interface ICivilizationChoice : IChoice
    {
        Civilization? Choice { get; set; }
        Civilization[] Excluded { get; }
    }

    public class CivilizationChoice : Choice, ICivilizationChoice
    {
        public CivilizationChoice(CivilizationChoice choice) : base(choice)
        {
            Choice = choice.Choice;
            Excluded = choice.Excluded;
        }

        public CivilizationChoice(IPlayer maker, string description, params Civilization[] excluded) : base(maker, description)
        {
            Excluded = excluded;
        }

        public Civilization? Choice { get; set; }
        public Civilization[] Excluded { get; }

        public override bool IsValid()
        {
            return Choice.HasValue && !Excluded.Contains(Choice.Value);
        }
    }
}
