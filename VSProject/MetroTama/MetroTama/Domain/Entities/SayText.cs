﻿using SQLite;

namespace MetroTama.Domain.Entities
{
    class SayText
    {
        [PrimaryKey, AutoIncrement]
        public int SayTextId { get; set; }
        public int Parametter { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Text { get; set; }
    }
}
