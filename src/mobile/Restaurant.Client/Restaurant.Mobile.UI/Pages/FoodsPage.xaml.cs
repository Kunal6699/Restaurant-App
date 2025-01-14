﻿using System;
using System.Reactive.Linq;
using Autofac;
using Restaurant.Core.ViewModels;
using Restaurant.Core.ViewModels.Food;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class FoodsPage : FoodsXamlPage
    {
        public FoodsPage()
        {
            InitializeComponent();
            ViewModel = App.Container.Resolve<FoodsViewModel>();
            FoodsList.SelectionChanged += (s, e) => { FoodsList.SelectedItem = null; };
            BindingContext = ViewModel;
        }

        protected override async void OnLoaded()
        {
            base.OnLoaded();
            await ViewModel.LoadFoods();
        }
    }

    public abstract class FoodsXamlPage : BaseContentPage<FoodsViewModel>
    {
    }
}
