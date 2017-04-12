namespace _01.SinoTheWalker
{
    using System;
    using System.Globalization;

    public class SinoTheWalker
    {
        public static void Main()
        {
            var timeFormat = @"hh\:mm\:ss";
            var departTime = TimeSpan.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);

            var steps = decimal.Parse(Console.ReadLine());
            var secondsPerStep = decimal.Parse(Console.ReadLine());

            var secondsInADay = 60 * 60 * 24;
            var totalSeconds = (int)(steps * secondsPerStep % secondsInADay);

            var arrivalTime = departTime.Add(new TimeSpan(0, 0, totalSeconds));

            Console.WriteLine("Time Arrival: " + arrivalTime.ToString(timeFormat));
        }
    }
}
