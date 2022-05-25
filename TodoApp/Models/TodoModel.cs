using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace TodoApp.Models
{
    internal class TodoModel : INotifyPropertyChanged
    {
        private string text;
        private bool isDone;
        
        [JsonProperty(propertyName: "text")]
        public string Text 
        {
            get 
            {
                return text;
            }
            set
            {
                if (text == value)
                    return;
                text = value.Trim();

                PropertyChange(nameof(Text));
            }
        }

        [JsonProperty(propertyName: "isDone")]
        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                if (isDone == value)
                    return;
                isDone = value;

                PropertyChange(nameof(IsDone));
            }
        }

        [JsonProperty(propertyName: "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected void PropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
