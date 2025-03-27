using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace TodoWPFApp
{
    public class TaskViewModel : ObservableObject
    {
        private ObservableCollection<TaskItem> _tasks;
        public ObservableCollection<TaskItem> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public RelayCommand AddTaskCommand { get; }

        //public TaskViewModel()
        //{
        //    Tasks = new ObservableCollection<TaskItem>(_context.Tasks.ToList());
        //    AddTaskCommand = new RelayCommand(AddTask);
        //}

        private void AddTask()
        {
            // Логика добавления задачи через ViewModel
        }
    }
}
