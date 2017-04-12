namespace _03.EnduranceRally
{
    using System;
    using System.Linq;

    public class EnduranceRally
    {
        public static void Main()
        {
            var drivers = Console.ReadLine().Split(' ');
            var trackLayout = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var index = 0;

            for (int a = 0; a < drivers.Length; a++)
            {
                var currentDriver = drivers[a];
                var fuel = (double)currentDriver[0];

                for (int b = 0; b < trackLayout.Length; b++)
                {
                    if (!checkpoints.Contains(b))
                    {
                        fuel = fuel - trackLayout[b];
                    }
                    else
                    {
                        fuel = fuel + trackLayout[b];
                    }

                    if (fuel <= 0)
                    {
                        index = b;
                        break;
                    }
                }

                if (fuel <= 0)
                {
                    Console.WriteLine($"{currentDriver} - reached {index}");
                }
                else
                {
                    Console.WriteLine($"{currentDriver} - fuel left {fuel:f2}");
                }
            }
        }
    }
}
