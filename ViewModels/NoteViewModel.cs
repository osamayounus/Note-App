using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Note_App.Data;
using Note_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_App.ViewModels
{
    public partial class NoteViewModel : ObservableObject
    {
        DBContext dbContext;

        // Fields
        [ObservableProperty]
        string noteTitle;

        [ObservableProperty]
        string noteDescription;

        [ObservableProperty]
        Note selectedNote;

        [ObservableProperty]
        ObservableCollection<Note> noteCollection;
        private NoteEntity dataHelper;

        public NoteViewModel()
        {
            noteCollection = new ObservableCollection<Note>();
            dataHelper = new NoteEntity();
            LoadData();
        }

        // Commands
        [RelayCommand]
        async void EditNote()
        { 
           if (selectedNote != null)
           {
                
                var newNote = new Note
                {
                    Id = selectedNote.Id,
                    Title = NoteTitle,
                    Description = NoteDescription
                };
                await dataHelper.UpdateDataAsync(newNote);
                LoadData();
                
           }
        }

        [RelayCommand]
        async Task DeletenoteAsync()
        {
            //remove the Note
            if (selectedNote != null)
            {
                await dataHelper.RemoveDataAsync(selectedNote);
                LoadData();
            }
            // reset values
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
        }

        [RelayCommand]
        async Task AddnoteAsync()
        {
            if (NoteTitle != string.Empty)
            {
                //Generate New ID
                //int NewId = NoteCollection.Count > 0 ? NoteCollection.Max(p => p.Id) + 1 : 1;
                //Set New Note
                var note = new Note
                {
                    Title = NoteTitle,
                    Description = NoteDescription,
                };
                await dataHelper.AddDataAsync(note);
                LoadData();
                // reset values
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }

        public void SetData()
        {
            NoteTitle = SelectedNote.Title;
            NoteDescription = SelectedNote.Description;
        }
        public async void LoadData()
        {
            NoteCollection.Clear();
            foreach(var note in await dataHelper.GetAllAsync())
            {
                 NoteCollection.Add(note);
            }
        }
    }
}
