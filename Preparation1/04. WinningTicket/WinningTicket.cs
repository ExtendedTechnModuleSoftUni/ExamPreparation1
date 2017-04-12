namespace _04.WinningTicket
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WinningTicket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

            var regex = new Regex(@"@{6,}|#{6,}|\${6,}|\^{6,}");

            foreach (var ticket in tickets)
            {
                var ticketLength = ticket.Length;

                if (ticketLength != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    var leftPartTicket = ticket.Substring(0, ticket.Length / 2);
                    var rightPartTicket = ticket.Substring(ticket.Length / 2);

                    var leftMatch = regex.Match(leftPartTicket);
                    var rightMatch = regex.Match(rightPartTicket);

                    if (leftMatch.Success && rightMatch.Success)
                    {
                        var leftSymbol = leftMatch.Groups[0].ToString().First();
                        var rightSymbol = rightMatch.Groups[0].ToString().First();

                        if (leftSymbol == rightSymbol)
                        {
                            if (leftMatch.Length == 10 && rightMatch.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftMatch.Length}{leftSymbol} Jackpot!");
                            }
                            else
                            {
                                var minLength = Math.Min(leftMatch.Groups[0].Length, rightMatch.Groups[0].Length);
                                Console.WriteLine($"ticket \"{ticket}\" - {minLength}{leftSymbol}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}