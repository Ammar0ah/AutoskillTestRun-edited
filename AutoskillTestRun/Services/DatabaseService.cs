using AutoskillTestRun.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xamarin.Forms;


namespace AutoskillTestRun.Services
{
    /// <summary>
    /// Mock Database Service
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        private List<Contact> contacts;
        private List<Quote> quotes;
        private List<NewsFeed> _newsFeeds;

        public DatabaseService()
        {
            contacts = InitContacts();
            quotes = InitQuotes();
            _newsFeeds = InitNewsFeeds();
        }

        private List<NewsFeed> InitNewsFeeds()
        {
            return new List<NewsFeed>()
            {
                new NewsFeed()
                {
                    Id = 1,
                    Title = "When is Game of Thrones Season 8 returning?",
                    Body =
                        "Game of Thrones Season 8 was originally slated to return in late 2018 or early 2019. Sophie Turner, who plays Sansa, previously suggested that the show would return in 2019 during an interview with Variety, and HBO officially confirmed the news on April 21."
                        ,
                    CoverImage = ImageSource.FromResource("AutoskillTestRun.Assets.GOT2019.jpg")
                },
                new NewsFeed()
                {
                    Id = 2,
                    Title = "How many episodes will there be in Game of Thrones Season 8?",
                    Body = "As confirmed by show runners David Benioff and D. B. Weiss, Game of Thrones Season 8 will feature just six episodes. Though it is likely that each episode will be a feature-length, so anything from 60 mins to 120 minutes.",
                    CoverImage = ImageSource.FromResource("AutoskillTestRun.Assets.JonSnow_Arya.jpg")
                    
                }

            };
        }


        public void UpdateContact(Contact contact)
        {
            if (contact.Id == 0)
            {
                contact.Id = contacts.Count + 1;
                contacts.Add(contact);
            }
            else
            {
                var oldContact = contacts.Find(c => c.Id == contact.Id);
                oldContact.Name = contact.Name;
                oldContact.Phone = contact.Phone;
            }
        }


        public void UpdateQuote(Quote quote)
        {
            if (quote.Id == 0)
            {
                quote.Id = quotes.Count + 1;
                quotes.Add(quote);
            }
            else
            {
                var oldQuote = quotes.Find(q => q.Id == quote.Id);
                oldQuote.CustomerName = quote.CustomerName;
                oldQuote.Total = quote.Total;
            }
        }

        public void UpdateNewsFeed(NewsFeed newsFeed)
        {
            if (newsFeed.Id == 0)
            {
                newsFeed.Id = _newsFeeds.Count + 1;
                _newsFeeds.Add(newsFeed);
            }
            else
            {
                var oldnews = _newsFeeds.Find(q => q.Id == newsFeed.Id);
                oldnews.Title = newsFeed.Title;
                oldnews.Body = newsFeed.Body;
                oldnews.CoverImage = newsFeed.CoverImage;
                oldnews.LikesNum = newsFeed.LikesNum;
            }

        }
        public List<NewsFeed> GetNewsFeeds()
        {
            return _newsFeeds;
        }


        public List<Contact> GetContacts()
        {
            return contacts;
        }


        public List<Quote> GetQuotes()
        {
            return quotes;
        }


        private List<Contact> InitContacts()
        {
            return new List<Contact> {
                new Contact { Id = 1, Name = "Xam Consulting", Phone = "0404 865 350" },
                new Contact { Id = 2, Name = "Michael Ridland", Phone = "0404 865 350" },
                new Contact { Id = 3, Name = "Thunder Apps", Phone = "0404 865 350" },
            };
        }


        private List<Quote> InitQuotes()
        {
            return new List<Quote> {
                new Quote { Id = 1, CustomerName = "Xam Consulting", Total = "$350.00" },
                new Quote { Id = 2, CustomerName = "Michael Ridland", Total = "$3503.00" },
                new Quote { Id = 3, CustomerName = "Thunder Apps", Total = "$3504.00" },
            };
        }
    }
}
