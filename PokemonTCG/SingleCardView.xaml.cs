using PokemonTCG.ModelClass;
using Xamarin.Forms;

namespace PokemonTCG
{
    public partial class SingleCardView : ContentPage
    {
        DatabaseManager dbManager = new DatabaseManager();
        Cards current;
        DBModel _current;

        public SingleCardView(Cards card)
        {
            InitializeComponent();
            Title = card.name;
            Card.Source = card.images.large;
            cRarity.Text += card.rarity;

            cArtist.Text += card.artist;
            cSet.Text += card.set.name;
            cSetNum.Text += card.number;
            current = card;

            RemoveButton.IsVisible = false;
        }

        public SingleCardView(DBModel card)
        {
            InitializeComponent();
            Title = card.name;
            Card.Source = card.imgLarge;
            cRarity.Text += card.rarity;

            cArtist.Text += card.artist;
            cSet.Text += card.setName;
            cSetNum.Text += card.setNumber;
            _current = card;
            AddButton.IsVisible = false;
        }

        async private void Save_Card(object sender, System.EventArgs e)
        {
            DBModel temp;
            if (current != null)
            {
                temp = new DBModel
                {
                    name = current.name,
                    imgSmall = current.images.small,
                    imgLarge = current.images.large,
                    rarity = current.rarity,
                    artist = current.artist,
                    setName = current.set.name,
                    setNumber = current.number,
                };
            } 
            else
            {
                temp = _current;
            }
           
            dbManager.AddNewCard(temp);
            AddButton.IsEnabled = false;
            await DisplayAlert("Success", "Successfully added " +  current.name + " to favorites!", "OK");
        }

        async private void Delete_Card(object sender, System.EventArgs e)
        {
            dbManager.RemoveCard(_current);
            await Navigation.PopAsync();
            await DisplayAlert("Success", "Removed card from favorites!", "OK");
        }
    }
}