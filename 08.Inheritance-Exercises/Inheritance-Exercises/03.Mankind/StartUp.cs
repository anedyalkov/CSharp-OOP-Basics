namespace _03.Mankind
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var studentInfo = Console.ReadLine().Split().ToArray();
                var studentFirstName = studentInfo[0];
                var studentLastName = studentInfo[1];
                var facultyNumber = studentInfo[2];
                var student = new Student(studentFirstName, studentLastName, facultyNumber);
                

                var workerInfo = Console.ReadLine().Split().ToArray();
                var workerFirstName = workerInfo[0];
                var workerLastName = workerInfo[1];
                var workerWeekSalary = decimal.Parse(workerInfo[2]);
                var workingHoursPerDay = decimal.Parse(workerInfo[3]);
                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workingHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
