﻿namespace Common
{
    public class LeaveTable
    {
        public Table Table { get; set; }

        public Player Player { get; set; }

        public override string ToString()
        {
            return $"{Player} left {Table}.";
        }
    }
}
