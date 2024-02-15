
using System.Globalization;
using System.IO;




// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();


if (resp == "1")
{
        // create data file


    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
        // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new Random();


        // create file
    StreamWriter sw = new StreamWriter("data.txt");


    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
        sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
  DateTime today = DateTime.Now;
  StreamReader sr = new StreamReader("data.txt");
      string sleepData = sr.ReadLine();
       while (sleepData != null){
  string[] vaules = sleepData.Split(',');
  string[] dateHours = vaules[1].Split('|');
  string[] date = vaules[0].Split("/");
  int x = int.Parse(date[0]);

    //   string mounth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x);

    string month = " "; 
    int monthInt = int.Parse(date[0]);

    if (monthInt == 1){
        month = "Jan";
    }else if(monthInt == 2){
        month = "Feb";
    } else if (monthInt == 3){
        month = "Mar";
    } else if (monthInt == 4){
        month = "Apr";
    } else if (monthInt == 5){
        month = "May";
    } else if (monthInt == 6){
        month = "June";
    } else if(monthInt == 7){
        month = "July";
    } else if (monthInt == 8){
        month = "Aug";
    } else if (monthInt == 9){
        month = "Sept";
    } else if (monthInt == 10){
        month = "Oct";
    } else if(monthInt == 11){
        month = "Nov";
    } else if  (monthInt == 12){
        month = "Dec";
    }
   
    double totalHours = 0;
    for(int h = 0; h < dateHours.Length; h++){
       int y = int.Parse(dateHours[h]);
        totalHours += y;
    }
     double avgHours = totalHours / 7;
    //  double.ToString("{0:0.00}", avgHours);
    avgHours =  Math.Round(avgHours, 2);
     Console.WriteLine($"Week of {month:MMM}, {date[1]:dd}, {date[2]:yyyy}");  
     Console.WriteLine("Su Mo Tu we Th Fr Sa Tot Avg");
     Console.WriteLine("-- -- -- -- -- -- -- --- ---");
          for(int q = 0; q < dateHours.Length; q++){
              Console.Write($" {dateHours [q]}");
         
          }
               Console.Write($"    {totalHours}");
              Console.Write($"    {avgHours}");
           Console.WriteLine(" ");
           
          sleepData = sr.ReadLine();

        
        
       }
sr.Close();
}