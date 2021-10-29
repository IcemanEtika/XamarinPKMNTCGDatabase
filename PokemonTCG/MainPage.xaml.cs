using PokemonTCG.ModelClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PokemonTCG
{
    public partial class MainPage : ContentPage
    {
        NetworkingManager manager = new NetworkingManager();
        ObservableCollection<TCGSets> sets;
        ObservableCollection<TCGSets> searchResults;
        List<TCGSets> setList;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            setList = await manager.getSets();
            sets = new ObservableCollection<TCGSets>();
            foreach (TCGSets i in setList)
            {
                sets.Add(new TCGSets(i.id, i.name, i.series, i.printedTotal, i.total, i.legalities, i.ptcgoCode, i.releaseDate, i.updatedAt, i.images));
            }
            SetList.ItemsSource = sets;
        }

        void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            searchResults = new ObservableCollection<TCGSets>();
            SetList.ItemsSource = null;

            if (searchBar.Text != "" && setList != null)
            {
                foreach (TCGSets i in setList)
                {
                    if (i.name.ToLower().StartsWith(searchBar.Text.ToLower()))
                    {
                        searchResults.Add(new TCGSets(i.id, i.name, i.series, i.printedTotal, i.total, i.legalities, i.ptcgoCode, i.releaseDate, i.updatedAt, i.images));
                    }
                }
                SetList.ItemsSource = searchResults;
            }
            else
            {
                SetList.ItemsSource = sets;
            }
        }

        async void viewSetCards(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new MultiCardView((e.SelectedItem as TCGSets)));
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoriteList());
        }
    }
}
