using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace PokemonBlazor.Services
{
    public class Leaderboard
    {
        public EventHandler LeaderboardChanged;
        private ObservableCollection<LeaderboardEntry> Entries { get; set; } = new ObservableCollection<LeaderboardEntry>();

        public Leaderboard()
        {
            Entries.CollectionChanged += (sender, e) => LeaderboardChanged?.Invoke(this, e);
        }

        public async Task AddEntry(string name, int score)
        {
            if (Entries.Any(e => e.Name == name))
            {
                var entry = Entries.First(e => e.Name == name);
                if (entry.Score < score)
                {
                    entry.Score = score;
                    LeaderboardChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
                return;
            }
            else
            {
                Entries.Add(new LeaderboardEntry { Name = name, Score = score });
            }
        }

        public async Task Clear()
        {
            Entries.Clear();
        }

        public async Task<List<LeaderboardEntry>> GetEntries()
        {
            return Entries.OrderByDescending(e => e.Score).ToList();
        }
    }

    public class LeaderboardEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
