using MetroTama.Domain;
using MetroTama.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Services
{
    class SayTextService
    {
        private static Random r = new Random();
        private static int LOW_VALUE = 50;
        private static int MEDIUM_VALUE = 80;
        public string GetText(Pet temp_pet)
        {
            int sw = r.Next(1, 7);
            SayTextRepository temp_saytext_rep = new SayTextRepository();
            string temp_say_text;
            switch (sw)
            {
                case 1:
                    {
                        if (temp_pet.isSick)
                            temp_say_text = temp_saytext_rep.GetSayText(1);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(20);
                    }
                    break;
                case 2:
                    {
                        if (temp_pet.Hungry <= LOW_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(2);
                        else if (temp_pet.Hungry <= MEDIUM_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(3);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(4);
                    }
                    break;
                case 3:
                    {
                        if (temp_pet.Healt <= LOW_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(5);
                        else if (temp_pet.Healt <= MEDIUM_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(6);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(7);
                    }
                    break;
                case 4:
                    {
                        if (temp_pet.Hygene <= LOW_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(8);
                        else if (temp_pet.Hygene <= MEDIUM_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(9);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(10);
                    }
                    break;
                case 5:
                    {
                        if (temp_pet.Fun <= LOW_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(11);
                        else if (temp_pet.Fun <= MEDIUM_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(12);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(13);
                    }
                    break;
                case 6:
                    {
                        if (temp_pet.Energy <= LOW_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(14);
                        else if (temp_pet.Energy <= MEDIUM_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(15);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(16);
                    }
                    break;
                case 7:
                    {
                        if (temp_pet.Study <= LOW_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(17);
                        else if (temp_pet.Study <= MEDIUM_VALUE)
                            temp_say_text = temp_saytext_rep.GetSayText(18);
                        else
                            temp_say_text = temp_saytext_rep.GetSayText(19);
                    }
                    break;
                default:
                    temp_say_text = "Nothing to say!";
                    break;
            }
           
            return temp_say_text;
        }
    }
}
