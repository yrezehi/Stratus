using Static.Models.Abstracts.Interfaces;
using System.Reflection;

namespace Static.Models.ViewModels.Interfaces
{
    public interface ITableViewModel<out T> where T : IEntity
    {
        public IEntity Entity { get; set; }
    }
}
