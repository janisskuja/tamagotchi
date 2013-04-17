using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroTama.Domain.Entities;

namespace MetroTama.Domain.Repository
{
    class SayTextRepository
    {
        public string GetSayText(int id)
        {
            var texts = new Dictionary<int, SayText>
                {
                    {1, GetText(1, "isSick")},
                    {2, GetText(2, "low_Hungry")},
                    {3, GetText(3, "medium_Hungry")},
                    {4, GetText(4, "high_Hungry")},
                    {5, GetText(5, "low_Healt")},
                    {6, GetText(6, "medium_Healt")},
                    {7, GetText(7, "high_Healt")},
                    {8, GetText(8, "low_Hygene")},
                    {9, GetText(9, "medium_Hygene")},
                    {10, GetText(10, "high_Hygene")},
                    {11, GetText(11, "low_Fun")},
                    {12, GetText(12, "medium_Fun")},
                    {13, GetText(13, "high_Fun")},
                    {14, GetText(14, "low_Energy")},
                    {15, GetText(15, "medium_Energy")},
                    {16, GetText(16, "high_Energy")},
                    {17, GetText(17, "low_Study")},
                    {18, GetText(18, "medium_Study")},
                    {19, GetText(19, "high_Study")},
                    {20, GetText(20, "notSick")}
                };

            return texts[id].Text;
        }

        private static SayText GetText(int id, string paramName)
        {
            var saytext = new SayText {SayTextId = id, ParamName = paramName};

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
                        saytext.Text = "I don't want \nto eat!";
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
                        saytext.Text = "You can heal \nsomebody else!";
                    }
                    break;
                case 8:
                    {
                        saytext.Text = "I'm dirty, wash me!";
                    }
                    break;
                case 9:
                    {
                        saytext.Text = "Can we go to \nshower?";
                    }
                    break;
                case 10:
                    {
                        saytext.Text = "Go to shower \nalone!";
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
                        saytext.Text = "Let's go to \nthe party!";
                    }
                    break;
                case 17:
                    {
                        saytext.Text = "I'm stupid,\nhelp me!";
                    }
                    break;
                case 18:
                    {
                        saytext.Text = "I want to learn \nsomething new!";
                    }
                    break;
                case 19:
                    {
                        saytext.Text = "I think I'm \nsmarter than you!";
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
