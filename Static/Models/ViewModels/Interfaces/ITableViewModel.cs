using Static.Models.Abstracts.Interfaces;
using System.Reflection;

namespace Static.Models.ViewModels.Interfaces
{
    public interface ITableViewModel<out T> where T : IEntity
    {
        public IEntity EntitySignture { get; set; }
        public IEnumerable<T> GetEntities();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
