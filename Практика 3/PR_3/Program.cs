using Microsoft.EntityFrameworkCore;
using PR_3.Models;
using System;

//namespace PR_3.Models
//{
//    public class ProgramEnrolleeExample
//    {
//        public static void Main(string[] args)
//        {
//            // Создаем экземпляр класса ProgramEnrolleeExample
//            var example = new ProgramEnrolleeExample();

//            // Запрашиваем у пользователя название программы
//            Console.WriteLine("Введите название программы обучения:");
//            string programName = Console.ReadLine();

//            // Вызываем метод GetEnrolleesForProgram, передавая введенное пользователем название программы
//            example.GetEnrolleesForProgram(programName);
//        }

//        public void GetEnrolleesForProgram(string programName)
//        {
//            using (var context = new Pr3Context())
//            {
//                var enrolleesForProgram = (
//                    from enrollee in context.Enrollees
//                    join programEnrollee in context.ProgramEnrollees on enrollee.EnrolleeId equals programEnrollee.EnrolleeId
//                    join program in context.Programs on programEnrollee.ProgramId equals program.ProgramId
//                    where program.NameProgram == programName
//                    select enrollee
//                ).ToList();

//                foreach (var enrollee in enrolleesForProgram)
//                {
//                    Console.WriteLine($"Enrollee ID: {enrollee.EnrolleeId}, Name: {enrollee.NameEnrollee}");
//                }
//            }
//        }
//    }
//}

//namespace PR_3.Models
//{
//    public class ProgramsWithRequiredSubject
//    {
//        public static void Main(string[] args)
//        {
//            // Создаем экземпляр класса ProgramsWithRequiredSubject
//            var example = new ProgramsWithRequiredSubject();

//            // Запрашиваем у пользователя название предмета ЕГЭ
//            Console.WriteLine("Введите название предмета ЕГЭ:");
//            string subjectName = Console.ReadLine();

//            // Вызываем метод GetProgramsForSubject, передавая введенное пользователем название предмета
//            example.GetProgramsForSubject(subjectName);
//        }

//        public void GetProgramsForSubject(string subjectName)
//        {
//            using (var context = new Pr3Context())
//            {
//                var programsWithRequiredSubject = (
//                    from program in context.Programs
//                    join programSubject in context.ProgramSubjects on program.ProgramId equals programSubject.ProgramId
//                    join subject in context.Subjects on programSubject.SubjectId equals subject.SubjectId
//                    where subject.NameSubject == subjectName
//                    select program
//                ).Distinct().ToList();

//                if (programsWithRequiredSubject.Any())
//                {
//                    Console.WriteLine($"Образовательные программы, на которые для поступления необходим предмет ЕГЭ '{subjectName}':");
//                    foreach (var program in programsWithRequiredSubject)
//                    {
//                        Console.WriteLine($"- {program.NameProgram}");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine($"Нет образовательных программ, на которые для поступления необходим предмет ЕГЭ '{subjectName}'.");
//                }
//            }
//        }
//    }
//}

//namespace PR_3.Models
//{
//    public class EgeSubjectStatistics
//    {
//        public static void Main(string[] args)
//        {
//            // Запрашиваем у пользователя предмет ЕГЭ
//            Console.WriteLine("Введите название предмета ЕГЭ:");
//            string subjectName = Console.ReadLine();

//            // Создаем экземпляр контекста базы данных
//            using (var context = new Pr3Context())
//            {
//                // Получаем статистику по выбранному предмету ЕГЭ
//                var subjectStatistics = (
//                    from enrolleeSubject in context.EnrolleeSubjects
//                    where enrolleeSubject.Subject.NameSubject.ToLower() == subjectName.ToLower()
//                    group enrolleeSubject by enrolleeSubject.Subject.NameSubject into subjectGroup
//                    select new
//                    {
//                        SubjectName = subjectGroup.Key,
//                        MinScore = subjectGroup.Min(es => es.Result),
//                        MaxScore = subjectGroup.Max(es => es.Result),
//                        EnrolleeCount = subjectGroup.Select(es => es.EnrolleeId).Distinct().Count()
//                    }
//                ).FirstOrDefault();

//                // Выводим статистику выбранного предмета ЕГЭ
//                if (subjectStatistics != null)
//                {
//                    Console.WriteLine($"Предмет: {subjectStatistics.SubjectName}");
//                    Console.WriteLine($"Минимальный балл: {subjectStatistics.MinScore}");
//                    Console.WriteLine($"Максимальный балл: {subjectStatistics.MaxScore}");
//                    Console.WriteLine($"Количество абитуриентов: {subjectStatistics.EnrolleeCount}");
//                }
//                else
//                {
//                    Console.WriteLine("Предмет не найден.");
//                }
//            }
//        }
//    }
//}




//namespace PR_3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Запрос у пользователя минимального балла
//            Console.WriteLine("Введите минимальный балл:");
//            int minScore = Convert.ToInt32(Console.ReadLine());

//            using (var context = new Pr3Context())
//            {
//                var programSubjects = context.ProgramSubjects
//                    .Include(ps => ps.Program)
//                    .Include(ps => ps.Subject)
//                    .Where(ps => ps.MinResult > minScore)
//                    .Select(ps => new
//                    {
//                        ProgramName = ps.Program.NameProgram,
//                        SubjectName = ps.Subject.NameSubject,
//                        MinResult = ps.MinResult
//                    })
//                    .ToList();

//                foreach (var ps in programSubjects)
//                {
//                    Console.WriteLine($"Программа: {ps.ProgramName}, Предмет: {ps.SubjectName}, Минимальный балл: {ps.MinResult}");
//                }
//            }
//        }
//    }
//}

//namespace PR_3
//{
//    class Program
//{
//    static void Main(string[] args)
//    {
//        using (var context = new Pr3Context())
//        {
//            // Находим максимальное значение плана набора
//            var maxPlan = context.Programs.Max(p => p.Plan);

//            // Выбираем все программы с планом набора, равным максимальному значению
//            var programsWithMaxPlan = context.Programs
//                .Where(p => p.Plan == maxPlan)
//                .ToList();

//            // Проверяем, найдены ли программы
//            if (programsWithMaxPlan.Any())
//            {
//                // Выводим результаты для каждой найденной программы
//                foreach (var program in programsWithMaxPlan)
//                {
//                    Console.WriteLine($"Образовательная программа: {program.NameProgram}, План набора: {program.Plan}");
//                }
//            }
//        }
//    }
//}
//}

//namespace PR_3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new Pr3Context())
//            {
//                var additionalScores = context.Enrollees
//                    .Include(e => e.EnrolleeAchievements)
//                    .Select(e => new
//                    {
//                        EnrolleeName = e.NameEnrollee,
//                        TotalAdditionalScore = e.EnrolleeAchievements.Sum(ea => ea.Achievement.Bonus)
//                    })
//                    .ToList();

//                foreach (var score in additionalScores)
//                {
//                    // Проверка, если общий балл больше 10, округляем до 10
//                    var roundedScore = Math.Min(score.TotalAdditionalScore, 10);

//                    Console.WriteLine($"Абитуриент: {score.EnrolleeName}, Дополнительные баллы: {roundedScore}");
//                }
//            }
//        }
//    }
//}

//namespace PR_3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new Pr3Context())
//            {
//                var programApplications = context.ProgramEnrollees
//                    .GroupBy(pe => pe.ProgramId)
//                    .Select(g => new
//                    {
//                        ProgramId = g.Key,
//                        ProgramName = g.FirstOrDefault().Program.NameProgram,
//                        ApplicantsCount = g.Count()
//                    })
//                    .ToList();

//                foreach (var application in programApplications)
//                {
//                    Console.WriteLine($"Программа: {application.ProgramName}, Количество абитуриентов: {application.ApplicantsCount}");
//                }
//            }   
//        }
//    }
//}

//namespace PR_3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new Pr3Context())
//            {
//                // Запрашиваем у пользователя названия двух предметов ЕГЭ
//                Console.WriteLine("Введите название первого предмета ЕГЭ:");
//                string subject1 = Console.ReadLine();

//                Console.WriteLine("Введите название второго предмета ЕГЭ:");
//                string subject2 = Console.ReadLine();

//                // Запрос к базе данных с использованием введенных предметов
//                var programs = context.Programs
//                    .Include(p => p.ProgramSubjects)
//                    .Where(p => p.ProgramSubjects.Count(ps => ps.Subject.NameSubject == subject1 || ps.Subject.NameSubject == subject2) == 2)
//                    .Select(p => new
//                    {
//                        ProgramName = p.NameProgram
//                    })
//                    .ToList();

//                // Вывод результата
//                foreach (var program in programs)
//                {
//                    Console.WriteLine($"Образовательная программа: {program.ProgramName}");
//                }
//            }
//        }
//    }
//}

//namespace PR_3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new Pr3Context())
//            {
//                // Получаем все программы и их соответствующие предметы
//                var programs = context.Programs
//                    .Include(p => p.ProgramSubjects)
//                    .ToList();

//                // Получаем всех абитуриентов и их результаты ЕГЭ по предметам
//                var enrollees = context.Enrollees
//                    .Include(e => e.EnrolleeSubjects)
//                    .ToList();

//                // Для каждой программы и каждого абитуриента считаем общее количество баллов
//                foreach (var program in programs)
//                {
//                    Console.WriteLine($"Образовательная программа: {program.NameProgram}");

//                    foreach (var enrollee in enrollees)
//                    {
//                        // Считаем сумму баллов абитуриента по предметам, необходимым для данной программы
//                        var totalScore = program.ProgramSubjects.Sum(ps =>
//                        {
//                            var enrolleeSubject = enrollee.EnrolleeSubjects.FirstOrDefault(es => es.SubjectId == ps.SubjectId);
//                            return enrolleeSubject != null ? enrolleeSubject.Result : 0;
//                        });

//                        Console.WriteLine($"Абитуриент: {enrollee.NameEnrollee}, Количество баллов: {totalScore}");
//                    }

//                    Console.WriteLine();
//                }
//            }
//        }
//    }
//}

//namespace PR_3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new Pr3Context())
//            {
//                Получаем все программы и их соответствующие предметы
//               var programs = context.Programs
//                   .Include(p => p.ProgramSubjects)
//                   .ToList();

//                Получаем всех абитуриентов и их результаты ЕГЭ по предметам
//               var enrollees = context.Enrollees
//                   .Include(e => e.EnrolleeSubjects)
//                   .ToList();

//                Для каждого абитуриента проверяем, подходит ли его результаты для каждой программы
//                foreach (var enrollee in enrollees)
//                {
//                    Console.WriteLine($"Абитуриент зачислен: {enrollee.NameEnrollee}");

//                    Проверяем каждую программу
//                    foreach (var program in programs)
//                    {
//                        Проверяем, удовлетворяют ли результаты абитуриента минимальным требованиям программы
//                        bool canBeEnrolled = program.ProgramSubjects.All(ps =>
//                        {
//                            var enrolleeSubject = enrollee.EnrolleeSubjects.FirstOrDefault(es => es.SubjectId == ps.SubjectId);
//                            return enrolleeSubject != null && enrolleeSubject.Result >= ps.MinResult;
//                        });

//                        Если абитуриент не удовлетворяет требованиям программы, выводим информацию
//                        if (!canBeEnrolled)
//                        {
//                            Console.WriteLine($"Не может быть зачислен на программу: {program.NameProgram}");
//                        }
//                    }

//                    Console.WriteLine();
//                }
//            }
//        }
//    }
//}