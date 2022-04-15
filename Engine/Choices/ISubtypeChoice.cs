using Common;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface ISubtypeChoice : IChoice
    {
        Subtype? Choice { get; set; }
        IEnumerable<Subtype> Excluded { get; set; }
    }

    public class SubtypeChoice : Choice, ISubtypeChoice
    {
        public SubtypeChoice(ISubtypeChoice choice) : base(choice)
        {
            Choice = choice.Choice;
            Excluded = choice.Excluded;
        }

        public SubtypeChoice(IPlayer maker, string description, params Subtype[] excluded) : base(maker, description)
        {
            Excluded = excluded;
        }

        public Subtype? Choice { get; set; }
        public IEnumerable<Subtype> Excluded { get; set; }

        public override bool IsValid()
        {
            return Choice.HasValue && !Excluded.Contains(Choice.Value);
        }
    }
}
