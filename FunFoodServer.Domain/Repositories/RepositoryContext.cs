using System;
using System.Collections.Generic;
using System.Threading;
using FunFoodServer.Infrastructure;

namespace FunFoodServer.Domain.Repositories
{
  public abstract class RepositoryContext : DisposeBaseObject, IRepositoryContext
  {
    private readonly Guid _id = new Guid();

    private readonly ThreadLocal<Dictionary<Guid, object>> _newEntities= new ThreadLocal<Dictionary<Guid, object>>(() => new Dictionary<Guid, object>());

    private readonly ThreadLocal<Dictionary<Guid, object>> _modifiedEntities = new ThreadLocal<Dictionary<Guid, object>>(() => new Dictionary<Guid, object>());

    private readonly ThreadLocal<Dictionary<Guid, object>> _deletedEntities = new ThreadLocal<Dictionary<Guid, object>>(() => new Dictionary<Guid, object>());

    private readonly ThreadLocal<bool> _committed = new ThreadLocal<bool>(() => true);

    protected IEnumerable<KeyValuePair<Guid, object>> NewEntities
    {
      get { return _newEntities.Value; }
    }

    protected IEnumerable<KeyValuePair<Guid, object>> ModifiedEntities
    {
      get { return _modifiedEntities.Value; }
    }

    protected IEnumerable<KeyValuePair<Guid, object>> DeletedEntities
    {
      get { return _deletedEntities.Value; }
    }

    protected void ClearRegistrations()
    {
      this._newEntities.Value.Clear();
      this._modifiedEntities.Value.Clear();
      this._deletedEntities.Value.Clear();
    }

    public Guid Id
    {
      get { return _id; }
    }

    public bool Committed
    {
      get { return _committed.Value; }
      protected set { _committed.Value = value; }
    }

    public virtual void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot
    {
      //register new entities
      if (entity.Id.Equals(Guid.Empty))
        throw new ArgumentException("The Id of the object is empty.", nameof(entity));
      if (_modifiedEntities.Value.ContainsKey(entity.Id))
        throw new InvalidOperationException("This object cannot be registered as a new object since it was marded as modified.");
      if (_newEntities.Value.ContainsKey(entity.Id))
        throw new InvalidOperationException("This object has already been registered as a new object.");
      _newEntities.Value.Add(entity.Id, entity);
      _committed.Value = false;
    }

    public virtual void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot
    {
      //register modified entities
      if (entity.Id.Equals(Guid.Empty))
        throw new ArgumentException("The Id of the object is empty.", nameof(entity));
      if (_deletedEntities.Value.ContainsKey(entity.Id))
        throw new InvalidOperationException("This object cannot be registered as a modified object since it was marked as deleted.");
      if (_modifiedEntities.Value.ContainsKey(entity.Id))
        throw new InvalidOperationException("This object has already been registered as a modified object");
      if (!_newEntities.Value.ContainsKey(entity.Id))
      {
        _modifiedEntities.Value.Add(entity.Id, entity);
        _committed.Value = false;
      }
    }

    public virtual void RegisterDelete<TAggregateRoot>(TAggregateRoot entity)
      where TAggregateRoot : class, IAggregateRoot
    {
      //register deleted entities
      if (entity.Id.Equals(Guid.Empty))
        throw new ArgumentException("The Id of the object is empty.", nameof(entity));
      if (_newEntities.Value.ContainsKey(entity.Id))
        if (_newEntities.Value.Remove(entity.Id))
          return;
      bool removeFromModified = _modifiedEntities.Value.Remove(entity.Id);
      bool addedToDeleted = false;
      if (!_deletedEntities.Value.ContainsKey(entity.Id))
      {
        _deletedEntities.Value.Add(entity.Id, entity);
        addedToDeleted = true;
      }

      _committed.Value = !(removeFromModified || addedToDeleted);
    }

    public abstract void Commit();

    public abstract void Rollback();
  }
}
