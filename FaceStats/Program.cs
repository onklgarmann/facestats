using System;
using System.IO;
using System.Text.RegularExpressions;


namespace FaceStats
{
    class Program
    {
        static void Main(string[] args)
        {
            long timestamp;
            int messages=0;
            bool sender;
            String path = @"C:\Users\Garmann\Dropbox\FaceStats\";
            using (StreamWriter sw = File.AppendText(path + "output.json"))
            {
                sw.WriteLine("\"messages\": [");
                for (int i = 1; i < 2; i++)
                {
                    using (StreamReader sr = File.OpenText(path + "message_" + i + ".json"))
                    {
                        String s = "";

                        while ((s = sr.ReadLine()) != null)
                        { 
                            
                            if (s.Contains("timestamp_ms"))
                            {
                                Int64.TryParse(Regex.Match(s, @"\d+").Value, out timestamp);
                                messages++;
                                //Console.WriteLine(timestamp);
                                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
                                Console.WriteLine(dateTimeOffset.Date);
                                
                            }
                        }
                    }
                }
                Console.WriteLine(messages);
            }
            
        }

    }
}
