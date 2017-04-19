﻿using System;
using ForumDEG.Models;
using System.Collections.ObjectModel;
using ForumDEG.Interfaces;
using ForumDEG.Views;
using System.Threading.Tasks;

namespace ForumDEG.ViewModels {
    class ForunsViewModel : BaseViewModel {
        public ObservableCollection<ForumDetailViewModel> Forums { get; private set; } = new ObservableCollection<ForumDetailViewModel>();

        private ForumDetailViewModel _selectedForum;
        public ForumDetailViewModel SelectedForum {
            get { return _selectedForum; }
            set { SetValue(ref _selectedForum, value); }
        }

        private readonly IPageService _pageService;

        private static ForunsViewModel _instance = null;
        private ForunsViewModel(IPageService pageService) {
            _pageService = pageService;
        }

        public static ForunsViewModel GetInstance() {
            if (_instance == null) _instance = new ForunsViewModel(new PageService());
            return _instance;
        }

        public async Task SelectForum(ForumDetailViewModel forum) {
            if (forum == null)
                return;
            SelectedForum = forum;
            await _pageService.PushAsync(new ForumDetailPage());
        }

        // method for simulating local database
        public void UpdateForumsList() {
            var theme = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                "Curabitur ultrices fringilla quam, at dignissim enim eleifend ut." +
                "Nunc vitae purus luctus, gravida sem quis, blandit nisi." +
                "Quisque vestibulum mollis massa, eget scelerisque orci placerat ut." +
                "Aliquam erat volutpat. Donec quis tortor pulvinar,";
            Forums = new ObservableCollection<ForumDetailViewModel> {
                new ForumDetailViewModel { Title = "Forum X", Place = "Somewhere Over The Rainbow", Schedules = theme, Date = DateTime.Now },
                new ForumDetailViewModel { Title = "Forum Y", Place = "Somewhere Over The Rainbow", Schedules = theme, Date = new DateTime(2025, 4, 19, 00, 00, 00) },
                new ForumDetailViewModel { Title = "Forum W", Place = "Somewhere Over The Rainbow", Schedules = theme, Date = new DateTime(1996, 4, 19, 19, 00, 00) }
            };
        }
    }
}
