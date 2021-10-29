using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PokemonTCG
{
    public partial class FavoriteList : ContentPage
    {
        DatabaseManager dbManager = new DatabaseManager();
        ObservableCollection<DBModel> favorites = new ObservableCollection<DBModel>();
        ObservableCollection<DBModel> searchResults;

        public FavoriteList()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            favorites = await dbManager.CreateTable();
            CardList.ItemsSource = favorites;
        }

        void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            searchResults = new ObservableCollection<DBModel>();
            CardList.ItemsSource = null;

            if (searchBar.Text != "" && favorites != null)
            {
                foreach (DBModel i in favorites)
                {
                    if (i.name.ToLower().StartsWith(searchBar.Text.ToLower()))
                    {
                        var temp = new DBModel
                        {
                            ID = i.ID,
                            name = i.name,
                            imgSmall = i.imgSmall,
                            imgLarge = i.imgLarge,
                            rarity = i.rarity,
                            artist = i.artist,
                            setName = i.setName,
                            setNumber = i.setNumber,
                            setTotal = i.setTotal
                        };
                        searchResults.Add(temp);
                    }
                }
                CardList.ItemsSource = searchResults;
            }
            else
            {
                CardList.ItemsSource = favorites;
            }
        }

        async void viewCard(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SingleCardView(e.SelectedItem as DBModel));
        }

        async void DeleteAll(object sender, EventArgs e)
        {
            await dbManager.RemoveAllCards();
            CardList.ItemsSource = null;
            await DisplayAlert("Success", "All favorites cleared!", "OK");
        }
    }
}