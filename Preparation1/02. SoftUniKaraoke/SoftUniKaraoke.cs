namespace _02.SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(',').Select(a => a.Trim()).ToArray();
            var songs = Console.ReadLine().Split(',').Select(a => a.Trim()).ToArray();
            var dict = new Dictionary<string, SortedSet<string>>();

            var line = Console.ReadLine();

            while (line != "dawn")
            {
                var tokens = line.Split(',').Select(a => a.Trim()).ToArray();
                var currentParticipant = tokens[0];
                var currentSong = tokens[1];
                var currentAward = tokens[2];

                if (participants.Contains(currentParticipant) && songs.Contains(currentSong))
                {
                    if (!dict.ContainsKey(currentParticipant))
                    {
                        dict.Add(currentParticipant, new SortedSet<string>());
                    }

                    dict[currentParticipant].Add(currentAward);
                }

                line = Console.ReadLine();
            }

            if (dict.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            var sortedParticipantAwards = dict
                .OrderByDescending(a => a.Value.Count)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var participantAward in sortedParticipantAwards)
            {
                var participant = participantAward.Key;
                var awards = participantAward.Value;

                Console.WriteLine($"{participant}: {awards.Count} awards");

                foreach (var award in awards)
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }
    }
}
