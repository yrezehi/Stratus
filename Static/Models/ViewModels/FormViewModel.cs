using Static.Models.Abstracts.Interfaces;
using Static.Models.ViewModels.Interfaces;
using Static.Utilities;
using System.Linq.Expressions;
using System.Reflection;

namespace Static.Models.ViewModels
{
    public class FormViewModel<T> : IFormViewModel<T> where T : IEntity
    {
        public string Source { get; set; }
        public IEntity Entity { get; set; } = (T)Activator.CreateInstance(typeof(T))!;
        
        public FormViewModel(string source) =>
            Source = source;
    }
}
