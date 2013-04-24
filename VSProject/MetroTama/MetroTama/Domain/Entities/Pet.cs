using System;
using SQLite;

namespace MetroTama.Domain.Entities
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int PetId { get; set; }
        public int PetStageId { get; set; }
        public int FavoriteGameObjectId { get; set; }
        public int DislikeGameObjectId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Hygene { get; set; }
        public int Hunger { get; set; }
        public int Energy { get; set; }
        public int Discipline { get; set; }
        public int Mood { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public bool Sleeping { get; set; }
        public bool Current { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
