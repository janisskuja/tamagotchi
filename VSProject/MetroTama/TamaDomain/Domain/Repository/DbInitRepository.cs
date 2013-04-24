using MetroTama.Domain.Entities;
using SQLite;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Enumerator;

namespace TamaDomain.Domain.Repository
{
    public sealed class DbInitRepository
    {
        public void InitTablesAndData()
        {
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                db.CreateTable<Pet>();
                db.CreateTable<Stage>();
                db.CreateTable<SayText>();
                db.CreateTable<GraveYard>();
                db.CreateTable<GameObject>();
                db.DeleteAll<GameObject>();
                InsertFood(db);
                InsertObjects(db);
                InsertStages(db);
                InsertText(db);
            }
          
        }

        private void InsertText(SQLiteConnection db)
        {

            db.InsertOrReplace(new SayText()
            {
                From = 0,
                To = 25,
                Parametter = (int) ParameterEnum.Health,
                Text = "I'm feeling very very sick! :("
            });
            db.InsertOrReplace(new SayText()
            {
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Health,
                Text = "Please take me to doctor!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Health,
                Text = "An apple or watter would be nice!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Health,
                Text = "I've feel very healthy! :) Thank you!"
            });

            db.InsertOrReplace(new SayText()
            {
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "I could eat a horse! PLEASE FEED ME!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "I want a burger!! NOW!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "I would like something to eat, Please! ;)"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "Thank you for feeding me, I Love YOU! :)"
            });

            db.InsertOrReplace(new SayText()
            {
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "A. B.. bebe boom baam!!!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "Read me a story, PLEASE!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "I'm smart! :)"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "In future I will be a rocket scientist!"
            });

            db.InsertOrReplace(new SayText()
            {
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Energy,
                Text = "No.. more.. energy.."
            });
            db.InsertOrReplace(new SayText()
            {
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Energy,
                Text = "Sleep, I feel so sleepy!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Energy,
                Text = "Let's play, let's do something!!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Energy,
                Text = "WOOHOO!!! PARTY!! - I'm full of energy!"
            });

            db.InsertOrReplace(new SayText()
            {
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "Ogh, whats that smell? Oh, it's me. CLEAN ME!!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "I need a bath..."
            });
            db.InsertOrReplace(new SayText()
            {
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "Hygene is very important, and I know it!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "I feel clean like a unicorn! ^^"
            });

            db.InsertOrReplace(new SayText()
            {
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Mood,
                Text = "I feel so lonely... I have nobody.. ;("
            });
            db.InsertOrReplace(new SayText()
            {
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Mood,
                Text = "Wanna be fiends? Let's play!"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Mood,
                Text = "This is fun!! I feel good! :D"
            });
            db.InsertOrReplace(new SayText()
            {
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Mood,
                Text = "Today is a great day! Sun is shining ..and me to!"
            });
        }

        private static void InsertFood(SQLiteConnection db)
        {
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Apple,
                ObjectName = "Apple",
                Description = "Healthy apple",
                HealthEffect = 5,
                HungerEffect = 5,
                HygeneEffect = 0,
                DisciplineEffect = 0,
                MoodEffect = 5,
                EnergyEffect = 3,
            });
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Burger,
                ObjectName = "Burger",
                Description = "Lotsofcaloriesburger, with cheese and stuff!",
                HealthEffect = -5,
                HungerEffect = 10,
                HygeneEffect = -2,
                DisciplineEffect = 0,
                MoodEffect = 5,
                EnergyEffect = 6,
            });
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Watter,
                ObjectName = "Watter",
                Description = "A refreshing glass of watter",
                HealthEffect = 1,
                HungerEffect = 2,
                HygeneEffect = 0,
                DisciplineEffect = 0,
                MoodEffect = 3,
                EnergyEffect = 10,
            });
        }
        private static void InsertObjects(SQLiteConnection db)
        {
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Soap,
                ObjectName = "Soap",
                Description = "Take the soap and clean your pet",
                HealthEffect = 0,
                HungerEffect = 0,
                HygeneEffect = 15,
                DisciplineEffect = 0,
                MoodEffect = 0,
                EnergyEffect = 0,
            });
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Book,
                ObjectName = "Book",
                Description = "Contains good education",
                HealthEffect = -1,
                HungerEffect = -1,
                HygeneEffect = -2,
                DisciplineEffect = 20,
                MoodEffect = -20,
                EnergyEffect = -6,
            });
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Light,
                ObjectName = "Day and night",
                Description = "Put your pet to sleep or wake him up",
                HealthEffect = 5,
                HungerEffect = -5,
                HygeneEffect = 0,
                DisciplineEffect = 0,
                MoodEffect = -10,
                EnergyEffect = 10,
            });
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Medkit,
                ObjectName = "Healing object",
                Description = "heal your pet",
                HealthEffect = 25,
                HungerEffect = -10,
                HygeneEffect = -10,
                DisciplineEffect = 0,
                MoodEffect = 10,
                EnergyEffect = 0,
            });
        }

        private static void InsertStages(SQLiteConnection db)
        {
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Egg,
                AgeFrom = 0,
                AgeTo = 1,
                HealthInterval = 0,
                HealthCoeff = 0,
                HungerInterval = 0,
                HungerCoeff = 0,
                HygeneInterval = 0,
                HygeneCoeff = 0,
                DisciplineInterval = 0,
                DisciplineCoeff = 0,
                MoodInterval = 0,
                MoodCoeff = 0,
                EnergyInterval = 0,
                EnergyCoeff = 0
            });

            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Baby,
                AgeFrom = 1,
                AgeTo = 6,
                HealthInterval = 30,
                HealthCoeff = 1,
                HungerInterval = 10,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 0,
                DisciplineCoeff = 0,
                MoodInterval = 10,
                MoodCoeff = 2,
                EnergyInterval = 10,
                EnergyCoeff = 3
            });
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Child,
                AgeFrom = 6,
                AgeTo = 11,
                HealthInterval = 10,
                HealthCoeff = 3,
                HungerInterval = 15,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 10,
                DisciplineCoeff = 4,
                MoodInterval = 10,
                MoodCoeff = 4,
                EnergyInterval = 20,
                EnergyCoeff = 3
            });
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Teen,
                AgeFrom = 11,
                AgeTo = 21,
                HealthInterval = 10,
                HealthCoeff = 4,
                HungerInterval = 10,
                HungerCoeff = 3,
                HygeneInterval = 30,
                HygeneCoeff = 3,
                DisciplineInterval = 30,
                DisciplineCoeff = 3,
                MoodInterval = 30,
                MoodCoeff = 3,
                EnergyInterval = 30,
                EnergyCoeff = 2
            });
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Adult,
                AgeFrom = 21,
                AgeTo = 50,
                HealthInterval = 30,
                HealthCoeff = 4,
                HungerInterval = 30,
                HungerCoeff = 4,
                HygeneInterval = 40,
                HygeneCoeff = 2,
                DisciplineInterval = 40,
                DisciplineCoeff = 1,
                MoodInterval = 40,
                MoodCoeff = 3,
                EnergyInterval = 30,
                EnergyCoeff = 3
            });
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Senior,
                AgeFrom = 50,
                AgeTo = 999,
                HealthInterval = 10,
                HealthCoeff = 2,
                HungerInterval = 30,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 60,
                DisciplineCoeff = 2,
                MoodInterval = 60,
                MoodCoeff = 3,
                EnergyInterval = 10,
                EnergyCoeff = 3
            });
        }
    }

}
