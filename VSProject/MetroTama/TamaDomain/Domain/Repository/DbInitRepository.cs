using MetroTama.Domain.Entities;
using SQLite;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Enumerator;

namespace TamaDomain.Domain.Repository
{
    public sealed class DbInitRepository
    {
        public static void InitData()
        {
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                InsertFood(db);
                InsertObjects(db);
                InsertStages(db);
                InsertText(db);
            }

        }
        public static void InitTables()
        {
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                db.CreateTable<Pet>();
                db.CreateTable<Stage>();
                db.CreateTable<SayText>();
                db.CreateTable<GraveYard>();
                db.CreateTable<GameObject>();
            }

        }

        private static void InsertText(SQLiteConnection db)
        {
            db.DeleteAll<SayText>();
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 1,
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Health,
                Text = "I'm feeling\n very \nvery sick! :("
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 2,
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Health,
                Text = "Please take\n me to doctor!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 3,
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Health,
                Text = "An apple\n or watter\n would be nice!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 4,
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Health,
                Text = "I've feel\n very healthy!\n :) Thank you!"
            });

            db.InsertOrReplace(new SayText()
            {
                SayTextId = 5,
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "I could\n eat a horse!\n PLEASE FEED ME!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 6,
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "I want\n a burger!!\n NOW!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 7,
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "I would\n like\n something\n to eat, Please! ;)"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 8,
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Hunger,
                Text = "Thank you\n for feeding me,\n I Love YOU! :)"
            });

            db.InsertOrReplace(new SayText()
            {
                SayTextId = 9,
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "A. B..\n bebe\n boom \nbaam!!!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 10,
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "Read me a\n story, PLEASE!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 11,
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "I'm smart! :)"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 12,
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Discipline,
                Text = "In future\n I will be\n a rocket scientist!"
            });

            db.InsertOrReplace(new SayText()
            {
                SayTextId = 13,
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Energy,
                Text = "No..\n more..\n energy..\n"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 14,
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Energy,
                Text = "Sleep,\n I feel\n so sleepy!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 15,
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Energy,
                Text = "Let's play,\n let's do\n something!!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 16,
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Energy,
                Text = "WOOHOO!!!\n PARTY!!\n - I'm\n full of energy!"
            });

            db.InsertOrReplace(new SayText()
            {
                SayTextId = 17,
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "Ogh,\n whats that smell?\n Oh, it's me.\n CLEAN ME!!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 18,
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "I need a bath..."
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 19,
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "Hygene\n is very important,\n and I know it!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 20,
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Hygene,
                Text = "I feel\n clean like a unicorn!\n ^^"
            });

            db.InsertOrReplace(new SayText()
            {
                SayTextId = 21,
                From = 0,
                To = 25,
                Parametter = (int)ParameterEnum.Mood,
                Text = "I feel so lonely...\n I have nobody.. ;("
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 22,
                From = 25,
                To = 50,
                Parametter = (int)ParameterEnum.Mood,
                Text = "Wanna be fiends?\n Let's play!"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 23,
                From = 50,
                To = 75,
                Parametter = (int)ParameterEnum.Mood,
                Text = "This is fun!!\n I feel good! :D"
            });
            db.InsertOrReplace(new SayText()
            {
                SayTextId = 24,
                From = 75,
                To = 100,
                Parametter = (int)ParameterEnum.Mood,
                Text = "Today is a\n great day! Sun is shining\n ..and me to!"
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
                DisciplineEffect = -10,
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
                HealthEffect = 0,
                HungerEffect = -15,
                HygeneEffect = -2,
                DisciplineEffect = 25,
                MoodEffect = -25,
                EnergyEffect = -10,
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
                EnergyEffect = 5,
            });
            db.InsertOrReplace(new GameObject()
            {
                GameObjectId = (int)GameObjectEnum.Ball,
                ObjectName = "Play Ball!!",
                Description = "Play a little rugby!",
                HealthEffect = 2,
                HungerEffect = -15,
                HygeneEffect = 0,
                DisciplineEffect = -15,
                MoodEffect = 15,
                EnergyEffect = -25,
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
                HealthInterval = 14,
                HealthCoeff = 3,
                HungerInterval = 3,
                HungerCoeff = 2,
                HygeneInterval = 2,
                HygeneCoeff = 1,
                DisciplineInterval = 3,
                DisciplineCoeff = 2,
                MoodInterval = 1,
                MoodCoeff = 2,
                EnergyInterval = 2,
                EnergyCoeff = 1
            });

            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Baby,
                AgeFrom = 1,
                AgeTo = 6,
                HealthInterval = 14,
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
                HungerInterval = 14,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 10,
                DisciplineCoeff = 4,
                MoodInterval = 10,
                MoodCoeff = 4,
                EnergyInterval = 10,
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
                HygeneInterval = 14,
                HygeneCoeff = 3,
                DisciplineInterval = 14,
                DisciplineCoeff = 3,
                MoodInterval = 14,
                MoodCoeff = 3,
                EnergyInterval = 14,
                EnergyCoeff = 2
            });
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Adult,
                AgeFrom = 21,
                AgeTo = 50,
                HealthInterval = 14,
                HealthCoeff = 4,
                HungerInterval = 14,
                HungerCoeff = 4,
                HygeneInterval = 14,
                HygeneCoeff = 2,
                DisciplineInterval = 14,
                DisciplineCoeff = 1,
                MoodInterval = 14,
                MoodCoeff = 3,
                EnergyInterval = 14,
                EnergyCoeff = 3
            });
            db.InsertOrReplace(new Stage()
            {
                StageId = (int)StageEnum.Senior,
                AgeFrom = 50,
                AgeTo = 999,
                HealthInterval = 10,
                HealthCoeff = 2,
                HungerInterval = 14,
                HungerCoeff = 2,
                HygeneInterval = 10,
                HygeneCoeff = 3,
                DisciplineInterval = 14,
                DisciplineCoeff = 2,
                MoodInterval = 14,
                MoodCoeff = 3,
                EnergyInterval = 10,
                EnergyCoeff = 3
            });
        }
    }

}
