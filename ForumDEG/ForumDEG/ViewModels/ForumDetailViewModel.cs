﻿using System;
using ForumDEG.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace ForumDEG.ViewModels {
    public class ForumDetailViewModel : PageService {
        public string Title { get; set; }
        public string Place { get; set; }
        public string Schedules { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public bool IsPast { get; private set; }
        public int Registration { get; set; }

        public ICommand ConfirmCommand { get; private set; }
        public ICommand DisconfirmCommand { get; private set; }

        public ForumDetailViewModel() {
            ConfirmCommand = new Command(ConfirmPresence);
            DisconfirmCommand = new Command(DisconfirmPresence);
            IsPast = HasPassed();
        }

        public bool HasPassed() {
            return DateTime.Now > Date;
        }

        private async void ConfirmPresence() {
            await PushAsync(new ForumEditPage(Registration)); 
        }

        private void DisconfirmPresence() { }
    }
}
