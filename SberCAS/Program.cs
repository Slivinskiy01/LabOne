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
            var svc = new PersonServices<PersonModel>("PersonModel");
            do
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!    Главное Меню     !!!!!!!!!!!!!!!!!!!!!!\n");
                Console.WriteLine("1. Показать всех клиентов");
                Console.WriteLine("2. Показать одного клиента");
                Console.WriteLine("3. Добавить Клиента");
                Console.WriteLine("4. Изминить Клиента");
                Console.WriteLine("5. Удалить Клиента");

                _input = Console.ReadLine();
                if (int.TryParse(_input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine();
                            foreach (var _ in svc.GetRows())
                            {
                                Console.WriteLine($"{_.IDNP} {_.Name} {_.LastName} {_.Age}");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                                Console.WriteLine($"\nВведите IDNP / Имя или Фамилию");
                                _input = Console.ReadLine();
                                GetSearch(svc, _input);
                            break;
                        case 3:
                                Console.WriteLine($"\nВведите IDNP Name LastName Age");
                                _input = Console.ReadLine();
                                var str = _input.Split(' ');
                            try
                            {
                                svc.GetNew(new PersonModel()
                                {
                                    IDNP = str[0],
                                    Name = str[1],
                                    LastName = str[2],
                                    Age = int.Parse(str[3]),
                                });
                            }
                            catch { }
                            break;

                        case 4:

                            Console.WriteLine($"\n Введите IDNP / Имя или Фамилию, Клиетна которого вы хотите изминить");
                            _input = Console.ReadLine();
                            var update = GetSearch(svc, _input);

                            Console.WriteLine($"\nВведите изминенный IDNP Name LastName Age");
                            _input = Console.ReadLine();
                            str = _input.Split(' ', ',');
                            update.IDNP = str[0];
                            update.Name = str[1];
                            update.LastName = str[2];
                            update.Age = int.Parse(str[3]);
                            Console.WriteLine($"\nУспешно обновлен");
                            svc.Update(update, null);
                        break;

                        case 5:
                            Console.WriteLine($"\nВведите IDNP, Клиетна которого вы хотите удалить");
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
        private static PersonModel GetSearch(PersonServices<PersonModel> svc, string _input)
        {
            var _per = svc.GetRows().FirstOrDefault(x => x.IDNP.ToString().Contains(_input))
                                     ?? svc.GetRows().FirstOrDefault(z => z.Name.Contains(_input))
                                     ?? svc.GetRows().FirstOrDefault(s => s.LastName.Contains(_input));

            if (_per != null)
                Console.WriteLine($"{_per.IDNP} {_per.Name} {_per.LastName} {_per.Age}");

            return _per;
        }
        
    }
}
