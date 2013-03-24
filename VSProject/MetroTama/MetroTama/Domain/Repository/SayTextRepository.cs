using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class SayTextRepository
    {
        public string GetSayText(int id)
        {
            Dictionary<int, SayText> texts = new Dictionary<int, SayText>();
            texts.Add(1, getText(1, "isSick"));
            texts.Add(2, getText(2, "low_Hungry"));
            texts.Add(3, getText(3, "medium_Hungry"));
            texts.Add(4, getText(4, "high_Hungry"));
            texts.Add(5, getText(5, "low_Healt"));
            texts.Add(6, getText(6, "medium_Healt"));
            texts.Add(7, getText(7, "high_Healt"));
            texts.Add(8, getText(8, "low_Hygene"));
            texts.Add(9, getText(9, "medium_Hygene"));
            texts.Add(10, getText(10, "high_Hygene"));
            texts.Add(11, getText(11, "low_Fun"));
            texts.Add(12, getText(12, "medium_Fun"));
            texts.Add(13, getText(13, "high_Fun"));
            texts.Add(14, getText(14, "low_Energy"));
            texts.Add(15, getText(15, "medium_Energy"));
            texts.Add(16, getText(16, "high_Energy"));
            texts.Add(17, getText(17, "low_Study"));
            texts.Add(18, getText(18, "medium_Study"));
            texts.Add(19, getText(19, "high_Study"));
            texts.Add(20, getText(20, "notSick"));

            return texts[id].Text;
        }

        private SayText getText(int id, string ParamName)
        {
            SayText saytext = new SayText();
            saytext.SayTextId = id;
            saytext.ParamName = ParamName;

            switch (id)
            {
                case 1:
                    {
                        saytext.Text = "Please, heal me!";
                    }
                    break;
                case 2:
                    {
                        saytext.Text = "Feed me fast!";
                    }
                    break;
                case 3:
                    {
                        saytext.Text = "Please feed me!";
                    }
                    break;
                case 4:
                    {
                        saytext.Text = "I don't want to eat!";
                    }
                    break;
                case 5:
                    {
                        saytext.Text = "Heal me ASAP!";
                    }
                    break;
                case 6:
                    {
                        saytext.Text = "Please heal me!";
                    }
                    break;
                case 7:
                    {
                        saytext.Text = "You can heal somebody else!";
                    }
                    break;
                case 8:
                    {
                        saytext.Text = "I'm dirty, wash me!";
                    }
                    break;
                case 9:
                    {
                        saytext.Text = "Can we go to shower?";
                    }
                    break;
                case 10:
                    {
                        saytext.Text = "Go to shower alone!";
                    }
                    break;
                case 11:
                    {
                        saytext.Text = "Play with me!";
                    }
                    break;
                case 12:
                    {
                        saytext.Text = "OK, we can play!";
                    }
                    break;
                case 13:
                    {
                        saytext.Text = "I'm happy!";
                    }
                    break;
                case 14:
                    {
                        saytext.Text = "I'm exhausted!";
                    }
                    break;
                case 15:
                    {
                        saytext.Text = "I want to rest!";
                    }
                    break;
                case 16:
                    {
                        saytext.Text = "Let's go to the party!";
                    }
                    break;
                case 17:
                    {
                        saytext.Text = "I'm stupid, help me!";
                    }
                    break;
                case 18:
                    {
                        saytext.Text = "I want to learn something new!";
                    }
                    break;
                case 19:
                    {
                        saytext.Text = "I think I'm smarter than you!";
                    }
                    break;
                case 20:
                    {
                        saytext.Text = "I'm feeling grate!";
                    }
                    break;
                default:
                    {
                        saytext.Text = "Leave me alone!";
                    }
                    break;
            }

            return saytext;
        }
    }
}
