using PokemonTCG.ModelClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace PokemonTCG
{
    public partial class MultiCardView : ContentPage
    {
        NetworkingManager manager = new NetworkingManager();
        ObservableCollection<Cards> cards;
        ObservableCollection<Cards> searchResults;
        List<Cards> cardList;
        TCGSets currentSet;
        string queryID;

        public MultiCardView(TCGSets set)
        {
            InitializeComponent();
            queryID = set.id;
            Title = set.name;
            currentSet = set;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            cardList = await manager.getCards(queryID);
            
            cards = new ObservableCollection<Cards>();
            foreach (Cards i in cardList)
            {
                cards.Add(new Cards(i.id, i.name, i.supertype, i.subtypes, i.level, i.hp, i.types, i.evolvesFrom, i.abilities, i.attacks, i.weaknesses,
                    i.retreatCost, i.convertedRetreatCost, i.set, i.number, i.artist, i.rarity, i.flavorText, i.nationalPokedexNumbers, i.legalities,
                    i.images, i.tcgplayer, i.cardmarket, i.evolvesTo, i.resistances, i.rules));
            }
            CardList.ItemsSource = cards;

        }
        void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            searchResults = new ObservableCollection<Cards>();
            CardList.ItemsSource = null;

            if (searchBar.Text != "" && cardList != null)
            {
                foreach (Cards i in cardList)
                {
                    if (i.name.ToLower().StartsWith(searchBar.Text.ToLower()))
                    {
                        searchResults.Add(new Cards(i.id, i.name, i.supertype, i.subtypes, i.level, i.hp, i.types, i.evolvesFrom, i.abilities, i.attacks, i.weaknesses,
                        i.retreatCost, i.convertedRetreatCost, i.set, i.number, i.artist, i.rarity, i.flavorText, i.nationalPokedexNumbers, i.legalities,
                        i.images, i.tcgplayer, i.cardmarket, i.evolvesTo, i.resistances, i.rules));
                    }
                }
                CardList.ItemsSource = searchResults;
            }
            else
            {
                CardList.ItemsSource = cards;
            }
        }

        async void viewCard(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SingleCardView(e.SelectedItem as Cards));
        }

        async void ShowInfo(object sender, EventArgs e)
        {
            await DisplayAlert("Set Info", "Set Name: " + currentSet.name + "\nSeries: " + currentSet.series + 
                "\nRelease Date: " + currentSet.releaseDate + "\nPrinted Total Cards: "
                + currentSet.printedTotal + "\nTotal Cards: " + currentSet.total, "OK");
        }
    }
}