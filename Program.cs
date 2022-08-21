using System;
using System.IO;
using System.Text;
using System.Threading;

public class Program
{
    public static void Main()
    {
        string set_date = (DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd"));
        int set_time_limit = 180;

        // Console.WriteLine(set_date);

        // To check if log file exists
        // If it does exists we check the date in it
        // If it does not exist then we create it with current date
        if(File.Exists("Timer.txt")){
            // Console.WriteLine("The file exists.");
            string[] lines = File.ReadAllLines("Timer.txt");

            if(lines[0] != set_date){
                using (StreamWriter fileStr = new StreamWriter("Timer.txt"))
                {
                    fileStr.WriteLine(set_date);
                    fileStr.WriteLine(set_time_limit);
                }
            }else{
                using (StreamReader sr = new StreamReader("Timer.txt"))
                {
                    sr.ReadLine();
                    set_time_limit = int.Parse(sr.ReadLine());
                }
            }
        } else {
            using (StreamWriter fileStr = File.CreateText("Timer.txt"))
            {
                fileStr.WriteLine(set_date);
                fileStr.WriteLine(set_time_limit);
            }
        }

        // We update our log file with minutes counteer
        while(true){
            // Console.WriteLine(set_time_limit);

                using (StreamWriter fileStr = new StreamWriter("Timer.txt"))
                {
                    fileStr.WriteLine(set_date);
                    fileStr.WriteLine(set_time_limit);
                }

            // If time runs out computer shuts down
            if(set_time_limit <= 0){
                // Console.WriteLine("Time's up!");
                System.Diagnostics.Process.Start("shutdown","/s /t 0");
            }
            
            set_time_limit -= 1;
            Thread.Sleep(60000);
        }
    }
}