using System;

public abstract class Worker
{
    private string id;

    protected Worker(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        protected set
        {
            id = value;
        }
    }
}

