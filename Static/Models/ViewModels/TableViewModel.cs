using Static.Models.Abstracts.Interfaces;
using Static.Models.ViewModels.Interfaces;

namespace Static.Models.ViewModels
{
    public class TableViewModel<T> : ITableViewModel<T> where T : IEntity
    {
        public IEntity EntitySignture { get; set; } = (T)Activator.CreateInstance(typeof(T))!;
        public IList<T> Entities { get; set; }

        public TableViewModel(IList<T> entities) =>
            Entities = entities;

        public IEnumerable<T> GetEntities() =>
            Entities;
 
    }
}
