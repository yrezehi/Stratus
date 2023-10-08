using Static.Models.Abstracts.Interfaces;
using Static.Models.ViewModels.Interfaces;

namespace Static.Models.ViewModels
{
    public class TableViewModel<T> : ITableViewModel<T> where T : IEntity
    {
        public IEntity Entity { get; set; } = (T)Activator.CreateInstance(typeof(T))!;
    }
}
