using System;

namespace QuPOS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var matrix = new List<string>() { "xxDFOXx", "Brownxx", "xxGFOXx", "FOXOVER", "xVLAZYx", "xEJUMPx", "xRSwift" };

            var entries = wordListEntry.Text.Split(',').ToList();
            entries = entries.Select(x => x.Trim()).ToList();

            WordFinder finder = new WordFinder(matrix);
            var results = finder.Find(entries);

            if (results.Count() == 0) {
                CounterBtn.Text = "No results.";
            }
            else
            {
                CounterBtn.Text = results.Count() + " items found: " + string.Join(", ", results);
            }
        }
    }
}
