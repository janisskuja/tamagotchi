using SQLite;

namespace MetroTama.Domain.Entities
{
    class GameObject
    {
        [PrimaryKey]
        public int GameObjectId { get; set; }
        public string ObjectName { get; set; }
        public string Description { get; set; }
        public int HealthEffect { get; set; }
        public int HungerEffect { get; set; }
        public int HygeneEffect { get; set; }
        public int DisciplineEffect { get; set; }
        public int MoodEffect { get; set; }
        public int EnergyEffect { get; set; }
    }
}
