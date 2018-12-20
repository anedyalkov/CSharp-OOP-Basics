namespace _08.MilitaryElite.Core
{
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Enums;
    using _08.MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;
        public Engine()
        {
            soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                var inputArgs = input.Split().ToArray();
                var type = inputArgs[0];
                var id = int.Parse(inputArgs[1]);
                var firstName = inputArgs[2];
                var lastName = inputArgs[3];
               

                if (type == "Private")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetPrivate(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Engineer")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier= GetEngineer(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Commando")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetCommando(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Spy")
                {
                    var codeNumber = int.Parse(inputArgs[4]);
                    soldier = GetSpy(id, firstName, lastName,codeNumber);
                }

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }
                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy privateSoldier = new Spy(id, firstName, lastName, codeNumber);
            return privateSoldier;
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            if (!Enum.TryParse(inputArgs[5], out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            for (int i = 6; i < inputArgs.Length; i += 2)
            {
                var codeName = inputArgs[i];
                var isValidState = Enum.TryParse(inputArgs[i + 1], out State st);
                if (isValidState)
                {
                    IMission mission = new Mission(codeName, st);
                    commando.Missions.Add(mission);
                }
                else
                {
                    continue;
                }
            }
            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            if (!Enum.TryParse(inputArgs[5], out Corps corps))
            {
                return null;
            }
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            for (int i = 6; i < inputArgs.Length; i += 2)
            {
                var partName = inputArgs[i];
                var hoursWorked = int.Parse(inputArgs[i + 1]);
                IRepair repair = new Repair(partName, hoursWorked);
                engineer.Repairs.Add(repair);
            }

            return engineer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < inputArgs.Length; i++)
            {
                var privateSoldierId = int.Parse(inputArgs[i]);
                IPrivate privateSodier = (IPrivate)soldiers.FirstOrDefault(p => p.Id == privateSoldierId);
                if (privateSodier != null)
                {
                    lieutenantGeneral.Privates.Add(privateSodier);
                }
            }

            return lieutenantGeneral;
        }

        private ISoldier GetPrivate(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            return privateSoldier;
        }
    }
}
