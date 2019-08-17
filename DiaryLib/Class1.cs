using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiaryLib
{
    public class Diary
    {
        private const string FIRST_NOTE_DATE_FILE_NAME = "firstdate.txt";
        public static string DateToFileName(DateTime date)
        {
            return $"{date.Year.ToString()}_" +
                $"{date.Month.ToString()}_" +
                $"{date.Day.ToString()}.txt";
        }
        public static DateTime FileNameToDate(string name)
        {
            int year = 0, mounth = 0, day = 0;
            int i = 0;
            while (name[i] != '_')
            {
                year *= 10;
                year += name[i] - '0';
                i++;
            }
            i++;
            while (name[i] != '_')
            {
                mounth *= 10;
                mounth += name[i] - '0';
                i++;
            }
            i++;
            while (name[i] != '.')
            {
                day *= 10;
                day += name[i] - '0';
                i++;
            }
            return new DateTime(year, mounth, day);
        }

        public static void ShawNotesListConsole()
        {
            List<string> notesFiles = GetNotesList();
            if (notesFiles.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = 0; i < notesFiles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {notesFiles[i]}");
                }
            }

        }

        public static List<string> GetNotesList()
        {
            List<string> list = new List<string>();
            if (File.Exists(FIRST_NOTE_DATE_FILE_NAME))
            {
                string firstFileName = File.ReadAllText(FIRST_NOTE_DATE_FILE_NAME);
                DateTime date = FileNameToDate(firstFileName);
                while (DateTime.Compare(date, DateTime.Now) < 0)
                {
                    if (File.Exists(DateToFileName(date)))
                    {
                        list.Add(DateToFileName(date));
                    }
                    date = date.AddDays(1);
                }
            }
            return list;
        }

        public static void AddNote(string note)
        {
            if (!File.Exists(FIRST_NOTE_DATE_FILE_NAME))
            {
                File.WriteAllText(FIRST_NOTE_DATE_FILE_NAME,
                    DateToFileName(DateTime.Now));
            }
            File.AppendAllText(DateToFileName(DateTime.Now),
                note);
        }
        public static void ShawNote(DateTime date)
        {
            if (File.Exists(DateToFileName(date)))
            {
                Console.WriteLine(File.ReadAllText(DateToFileName(date)));
            }
            else
            {
                Console.WriteLine("Запись не найдена");
            }
        }

    }
}
