
using System;
namespace LibService
{
	public interface IRepository<T, TId>
	{
		int? Add(T item);

		int Update(T item);

		int Delete(T item);

		IList<T> GetAll();

		T GetById<TId>(TId id);
	}
}

