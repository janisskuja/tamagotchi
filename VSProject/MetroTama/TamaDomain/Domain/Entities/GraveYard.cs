using System;
using SQLite;

namespace TamaDomain.Domain.Entities
{
    public class GraveYard
    {
        [PrimaryKey, AutoIncrement]
        public int GraveYardId { get; set; }
        public int PetId { get; set; }
        public DateTime TimeDied { get; set; }
        public string LastThought { get; set; }
    }
}
