using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<TodoModel> todos;
        private TodoService todoService;        
       
        public MainWindow()
        {
            InitializeComponent();
            
            string path = ConfigurationManager.AppSettings["defaultPath"] ?? String.Empty;
            todoService = new(path);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            todos = todoService.LoadData();
            todosGrid.ItemsSource = todos;

            todos.ListChanged += todoListItemChangedHandler;
        }

        private void todoListItemChangedHandler(object? sender, ListChangedEventArgs e)
        {
            todoService.SaveData(todos);
        }
    }
}
