using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using TodoApp.Models;

namespace TodoApp.Services
{
    internal class TodoService
    {
        private readonly string path;
        public TodoService(string filePath)
        {
            if (!String.IsNullOrWhiteSpace(filePath))
            {
                path = filePath;
            }   
            else 
                path = Environment.CurrentDirectory + @"\data.json";
        }

        public BindingList<TodoModel> LoadData()
        {          
            var resultList = new BindingList<TodoModel>();

            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path); 
                    return resultList;
                }

                string json = File.ReadAllText(path, Encoding.UTF8);

                if (!String.IsNullOrWhiteSpace(json))
                    resultList = JsonConvert.DeserializeObject<BindingList<TodoModel>>(json);            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            return resultList!;
        }

        public void SaveData(BindingList<TodoModel> data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data);

                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                File.WriteAllText(path,json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

	public void ClearList()
        {
            File.WriteAllText(path, String.Empty);
        }
	
    }
}
