using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using AutoskillTestRun.Models;
using AutoskillTestRun.Pages;
using AutoskillTestRun.Services;
using PropertyChanged;
using ReactiveUI;
using Xamarin.Forms;

namespace AutoskillTestRun.PageModels
{

    class NewsFeedListPageModel : BasePageModel
    {
        private IDatabaseService _databaseService;
        private NewsFeed _newsFeed;
        public ObservableCollection<NewsFeed> NewsFeeds { get; set; }
        public ReactiveCommand AddNewsFeedCommand { get; private set; }
        
        public ReactiveCommand SelectedItemCommand { get; private set; }
        public ReactiveCommand LikesCommand { get; private set; }
        public ReactiveCommand DeleteCommand { get; private set; }
        public NewsFeed NewsFeed
        {
            get => _newsFeed;
            set => this.RaiseAndSetIfChanged(ref _newsFeed, value);
        }

        public NewsFeedListPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
           
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            NewsFeeds = new  ObservableCollection<NewsFeed>(_databaseService.GetNewsFeeds());
            AddNewsFeedCommand = ReactiveCommand.CreateFromTask(async () => await CoreMethods.PushPageModel<NewsFeedPageModel>());
            SelectedItemCommand = ReactiveCommand.Create<SelectedItemChangedEventArgs>(SelectedItemAction);
            LikesCommand = ReactiveCommand.Create<NewsFeed>(LikeChanges);
            DeleteCommand = ReactiveCommand.Create<NewsFeed>(DeleteItem);




        }

        public override void ReverseInit(object returnedData)
        {
       
            var news = returnedData as NewsFeed;
            if(!NewsFeeds.Contains(news)) 
              NewsFeeds.Add(news);
        }

        private async void SelectedItemAction(SelectedItemChangedEventArgs args)
        {
            var news = args.SelectedItem as NewsFeed;
            if (news == null)
                return;

            var page = CurrentPage as NewsFeedListPage;
            page.DeselectItem();
            await CoreMethods.PushPageModel<NewsFeedPageModel>(news);
        }

           private void LikeChanges(NewsFeed newsFeed)
        {
            newsFeed.LikesNum++;
            newsFeed.BackgroundColor = Color.White;
            newsFeed.TextColor = Color.DodgerBlue;
            RaisePropertyChanged();
        }



        }
        public async void DeleteItem( NewsFeed news)
        {  
           
           var res =  await CoreMethods.DisplayAlert("OH !", "Are you sure?", "Yes", "No");
            if (res)
            {
                NewsFeeds.Remove(news);
                RaisePropertyChanged();
            }
   
        }
    }
}
