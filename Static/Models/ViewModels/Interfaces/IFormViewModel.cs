using Static.Models.Abstracts.Interfaces;
using System.Reflection;

namespace Static.Models.ViewModels.Interfaces
{
    public interface IFormViewModel<out T> where T : IEntity
    {
        public IEntity Entity { get; set; }
        public string Source { get; set; }
    }
}
