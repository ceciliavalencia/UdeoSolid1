using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdeOSolid1
{
    class Program
    {
        //Diario --> entries, almacenar, fechas, descripción.
        static void Main(string[] args)
        {
            Console.WriteLine("Mi diario");

            Diario diario = new Diario();
            //string path = @"c:\SolidUdeoUno\DiarioSolid.txt";
            string path = @"c:\temp\DiarioSolid.txt";
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(diario.AddEntry("SOLID Save Files Entry " + i + "\n"));
            }

            diario.Save(path, true);

            Console.WriteLine("Diario guardado en " + path);
            Console.ReadLine();
        }
    }

    public class Diario
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public Diario()
        {

        }
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public string FindEntry(string text)
        {
            var match = entries.Contains(text);
            if (match)
            {
                return match.ToString();
            }
            return "";
        }
        public void Load(string text)
        {
        }
        // polimorfismo
        public void Load(Uri uri) {}
        public void Save(string fileName, bool overwrite = false)
        {
            Persistencia persistencia = new Persistencia();
            persistencia.SaveToFile(ToString(), fileName, overwrite);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistencia
    {
        public Persistencia()
        {

        }
        public void SaveToFile(Diario diario, string fileName, bool overwrite = false)
        {
            //Diario, filename
            if (overwrite)
            {
                File.WriteAllText(fileName, "contenido de prueba");
            }
        }
        public void SaveToFile(string diario, string fileName, bool overwrite = false)
        {
            //Diario, filename
            if (overwrite || File.Exists(fileName))
            {
                File.WriteAllText(fileName, diario);
            }
        }
    }
}
