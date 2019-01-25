using LiteDB;
using SberCAS.DataContext;
using SberCAS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCAS
{
    class Program
    {
        static void Main(string[] args)
        {
            string _input;
            var svc = new Services<PlayerModel>("PlayerModel");


            do
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!    Главное Меню     !!!!!!!!!!!!!!!!!!!!!!\n");
                Console.WriteLine("1. Показать всех Игроков");
                Console.WriteLine("2. Показать одного Игрока");
                Console.WriteLine("3. Добавить Игрока");
                Console.WriteLine("4. Изминить Игрока");
                Console.WriteLine("5. Удалить Игрока");

                _input = Console.ReadLine();
                if (int.TryParse(_input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine();
                            foreach (var _per in svc.GetRows())
                            {
                                Console.WriteLine($"{_per.Name}" +
                                                  $"{_per.LastName} " +
                                                  $"{_per.Address} " +
                                                  $"{_per.BrithDay} " +
                                                  $"{_per.NrInTeam} " +
                                                  $"{_per.Salary} " +
                                                  $"{_per.CountGame} " +
                                                  $"{_per.CountGoal} " +
                                                  $"{_per.Growth} " +
                                                  $"{_per.Weight} " +
                                                  $"{_per.TransferCost} ");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                                Console.WriteLine($"\nВведите Номер в Команде / Имя или Фамилию");
                                _input = Console.ReadLine();
                                GetSearch(svc, _input);
                            break;
                        case 3:
                                Console.WriteLine($"\nВведите Номер в Команде Имя Фамилию ДатуРождения");
                                _input = Console.ReadLine();
                                var str = _input.Split(' ');
                            try
                            {
                                svc.GetNew(new PlayerModel()
                                {
                                    Name = str[0],
                                    LastName = str[1],
                                    Address = str[2],
                                    BrithDay = str[3],
                                    NrInTeam = str[4],
                                    Salary = decimal.Parse(str[5]),
                                    CountGame = int.Parse(str[6]),
                                    CountGoal = int.Parse(str[7]),
                                    Growth = int.Parse(str[8]),
                                    Weight = int.Parse(str[9]),
                                    TransferCost = decimal.Parse(str[10])
                                });
                            }
                            catch { }
                            break;

                        case 4:

                            Console.WriteLine($"\n Введите Номер в Команде / Имя или Фамилию, Игрока которого вы хотите изминить");
                            _input = Console.ReadLine();
                            var update = GetSearch(svc, _input);

                            Console.WriteLine($"\nВведите изминенный Номер в Команде, Имя, Фамилию, Дата Рождения");
                            _input = Console.ReadLine();
                            str = _input.Split(' ', ',');

                            try
                            {
                                update.Name = str[0];
                                update.LastName = str[1];
                                update.Address = str[2];
                                update.BrithDay = str[3];
                                update.NrInTeam = str[4];
                                update.Salary = decimal.Parse(str[5]);
                                update.CountGame = int.Parse(str[6]);
                                update.CountGoal = int.Parse(str[7]);
                                update.Growth = int.Parse(str[8]);
                                update.Weight = int.Parse(str[9]);
                                update.TransferCost = decimal.Parse(str[10]);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message) }
                            Console.WriteLine($"\nУспешно обновлен");
                            svc.Update(update, null);
                            
                        break;

                        case 5:
                            Console.WriteLine($"\nВведите Номер в Команде, Игрока которого вы хотите удалить");
                            _input = Console.ReadLine();
                            var delete = GetSearch(svc, _input);
                            svc.Delete(delete.Guid);
                            Console.WriteLine($"\nУспешно удален");

                            break;

                        default:
                            Console.WriteLine("\nНеправельный ввод!");
                            break;
                    }
                }




            } while (_input.ToUpper() != "E");

        }

        /// <summary>
        /// Search Person
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="_input"></param>
        /// <returns></returns>
        private static PlayerModel GetSearch(Services<PlayerModel> svc, string _input)
        {
            var _per = svc.GetRows().FirstOrDefault(x => x.NrInTeam.ToString().Contains(_input))
                                     ?? svc.GetRows().FirstOrDefault(z => z.Name.Contains(_input))
                                     ?? svc.GetRows().FirstOrDefault(s => s.LastName.Contains(_input));

            if (_per != null)
                Console.WriteLine($"{_per.Name}" +
                    $"{_per.LastName} " +
                    $"{_per.Address} " +
                    $"{_per.BrithDay} " +
                    $"{_per.NrInTeam} " +
                    $"{_per.Salary} " +
                    $"{_per.CountGame} " +
                    $"{_per.CountGoal} " +
                    $"{_per.Growth} " +
                    $"{_per.Weight} " +
                    $"{_per.TransferCost} ");
            return _per;
        }
        
    }
}
