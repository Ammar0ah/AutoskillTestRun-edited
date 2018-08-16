using System;
using System.Collections.Generic;
using System.Text;
using Android.Media;
using Xamarin.Forms;

namespace AutoskillTestRun.Models
{  
    [AddINotifyPropertyChangedInterface]
    public class NewsFeed
    {  
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int LikesNum { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public ImageSource CoverImage { get; set; }
    }
}
