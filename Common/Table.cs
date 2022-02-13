using System;

namespace Common
{
    public class Table
    {
        public Guid Id { get; set; }

        public Player Host { get; set; }

        public Player Guest { get; set; }

        public Table()
        {
            Id = Guid.NewGuid();
        }
    }
}
