using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoskillTestRun.Models;
using AutoskillTestRun.Services;
using Plugin.Media;
using ReactiveUI;
using Xamarin.Forms;

namespace AutoskillTestRun.PageModels
{
    public class NewsFeedPageModel : BasePageModel
    {
        private IDatabaseService _databaseService;
        public NewsFeed NewsFeed { get; set; }
        public ReactiveCommand AddImageCommand { get; set; }
        public ReactiveCommand SaveCommand { get; set; }

        public NewsFeedPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            AddImageCommand = ReactiveCommand.CreateFromTask(AddImage);
            SaveCommand = ReactiveCommand.CreateFromTask(SavePost);
        }

        private async Task SavePost()
        {
            _databaseService.UpdateNewsFeed(NewsFeed);
           
            await CoreMethods.PopPageModel(NewsFeed);
        }


        public override void Init(object initData)
        {
          
            NewsFeed = initData as NewsFeed;
            if (NewsFeed == null)
                NewsFeed = new NewsFeed() { CoverImage = ImageSource.FromResource("AutoskillTestRun.Assets.Load.jpg") };
        }

        async Task AddImage()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable)
            {
                await CoreMethods.DisplayAlert("Shame !", "No Camera Availabel", "Back");

            }

            var media = await CrossMedia.Current.PickPhotoAsync();
            if (media == null)
                return;

            var result = await CoreMethods.DisplayAlert("Are you sure to add this photo?", media.Path, "Yes", "No");
            if (result)
                NewsFeed.CoverImage = ImageSource.FromStream(() => media.GetStream());
        }

    }
}
