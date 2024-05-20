using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Console.Model
{
    public class PublisherModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public PublisherModel(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            CompanyName = data[1];
        }

        public static List<PublisherModel> loadPusblihshers(string fileName)
        {
            List<PublisherModel> publishers = new List<PublisherModel>();
            try
            {
                StreamReader sr = new StreamReader(fileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    publishers.Add(new PublisherModel(sr.ReadLine()));
                }
                sr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fájl beolvasás sikertelen!\n" + ex.Message);
            }
            return publishers;
        }

    }
}
