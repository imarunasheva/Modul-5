using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Modul_5
{
    class Programm
    {
        static (string Name, string Lastname, int Age, string PetOwner, int CountPet, string[]? PetName, int CountColor, string[] favColors) Anketa()
        {
            (string Name, string Lastname, int Age, string PetOwner, int CountPet, string[]? PetName, int CountColor, string[] favColors) User;

            do
            {
                Console.WriteLine("Введите имя: ");
                User.Name = Console.ReadLine();
            }
            while (!CheckUserData(User.Name));

            do
            {
                Console.WriteLine("Введите фамилию: ");
                User.Lastname = Console.ReadLine();
            }
            while (!CheckUserData(User.Lastname));

            do
            {
                Console.WriteLine("Введите возраст цифрами: ");
                bool age = byte.TryParse(Console.ReadLine(), out var corrAge);
                User.Age = age == true ? corrAge : 0;
            }
            while (!CheckUserData(User.Age));

            do
            {
                Console.WriteLine("У вас есть питомец? да/нет: ");
                User.PetOwner = Console.ReadLine();
            }
            while (User.PetOwner != "Да" && User.PetOwner != "да" && User.PetOwner != "Нет" && User.PetOwner != "нет");
                                   
            if (User.PetOwner == "Да" || User.PetOwner == "да")
            {
                do
                {
                    Console.WriteLine("Введите количество питомцев: ");
                    bool numPet = byte.TryParse(Console.ReadLine(), out var corrNumPet);
                    User.CountPet = numPet == true ? corrNumPet : 0;
                }
                while (!CheckUserData(User.CountPet));
                 
                User.PetName = Pets(User.CountPet);
            }
            else
            {
                User.CountPet = 0;
                User.PetName = null;
            }
         
            do
            {
                Console.WriteLine("Введите количество любимых цветов: ");
                bool count = byte.TryParse(Console.ReadLine(), out var corrCount);
                User.CountColor = count == true ? corrCount : 0;
            }
            while (!CheckUserData(User.CountColor));

            User.favColors = FavColors(User.CountColor);


            static string[] Pets(int item)
            {
                var PetName = new string[item];
                for (int i = 0; i < PetName.Length; i++)
                {
                    do
                    {
                        Console.WriteLine("Введите имя {0} питомца: ", i + 1);
                        PetName[i] = Console.ReadLine();
                    }
                    while (!CheckUserData(PetName[i]));
                }

                return PetName;
             }

            static string[] FavColors(int item)
            {
                var favColors = new string[item];
                for (int i = 0; i < favColors.Length; i++)
                {
                    do
                    {
                        Console.WriteLine("Введите {0} любимый цвет: ", i + 1);
                        favColors[i] = Console.ReadLine();
                    }
                    while (!CheckUserData(favColors[i]));
                }

                return favColors;
            }

            static bool CheckUserData<T>(T Arg)
            {
                if (Arg is string)
                {
                    int CharCount = (Arg as string).Length;
                    string specialCharAbc = @"\|!#$%&/()=?»«@£§€{}.-; !@#'<>_,0123456789";


                    if (CharCount == 0)
                    {
                        Console.WriteLine("Введите корректное значение (в диапазоне от 2 до 50 символов)");
                        return false;
                    }

                    else if (CharCount < 2 || CharCount > 50)
                    {
                        Console.WriteLine("Введите корректное значение (в диапазоне от 2 до 50 символов)");
                        return false;
                    }
                     
                    else if (CharCount > 2 || CharCount < 50)                 
                    {
                        foreach (var item in specialCharAbc)
                        {
                            if ((Arg as string).Contains(item))
                            {
                                Console.WriteLine("Введите корректное значение без спец.символов и чисел");
                                return false;
                            }
                        }
                                                
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }

                else if (Arg is int)
                {
                    int ArgInt = Convert.ToInt32(Arg);
                    string ArgString = Convert.ToString(Arg);
                    string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;!@#'<>_,";

                    if (ArgInt == 0)
                    {
                        Console.WriteLine("Введите корректное значение (в диапазоне от 1 до 100)");
                        return false;
                    }

                    else if (ArgInt < 1 || ArgInt > 100)
                    {
                        Console.WriteLine("Введите корректное значение (в диапазоне от 1 до 100)");
                        return false;
                    }

                    else if (ArgInt > 1 || ArgInt < 100)
                    {
                        foreach (var item in specialChar)
                        {
                            if (ArgString.Contains(item))
                            {
                                Console.WriteLine("Введите корректное значение без спец.символов");
                                return false;
                            }
                        }

                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else 
                {
                    return false;
                }
            }
                                  
            return User;

        }

        static void ResultPrint((string Name, string Lastname, int Age, string PetOwner, int CountPet, string[]? PetName, int CountColor, string[] favColors) User)
        {
            if (User.CountPet > 0)
            {
                Console.WriteLine("Анкета пользователя: \nИмя: {0} \nФамилия: {1} \nВозраст: {2} \nНаличие питомцев: {3} \nКоличество питомцев: {4} \nИмена питомцев: {5} \nКол-во любимый цветов: {6} \nЛюбимые цвета: {7}",
                    User.Name, User.Lastname, User.Age, User.PetOwner, User.CountPet, string.Join(", ", User.PetName), User.CountColor, string.Join(", ", User.favColors));
            }
            else
            {
                Console.WriteLine("Анкета пользователя: \nИмя: {0} \nФамилия: {1} \nВозраст: {2} \nНаличие питомцев: {3} \nКол-во любимый цветов: {4} \nЛюбимые цвета: {5}",
                    User.Name, User.Lastname, User.Age, User.PetOwner, User.CountColor, string.Join(", ", User.favColors));

            }
        }

        static void Main(string[] args)
        {
            ResultPrint(Anketa());

            Console.ReadLine();
        }
        
    }
  
}

