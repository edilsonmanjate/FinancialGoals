﻿namespace FinancialGoals.Core.Entities;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }

    public BaseEntity(Guid id)
    {
        Id = id;
        IsDeleted = false;
    }

    public Guid Id { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Delete()
    {
        IsDeleted = true;
    }
    public void Update()
    {
        CreatedAt = DateTime.Now;
    }


}