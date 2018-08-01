using UnityEngine;

public abstract class ActionTemplate : ScriptableObject
{
    [SerializeField]
    private string _animationName;
    public string AnimationName { get { return _animationName; } set { _animationName = value; } }

    protected abstract bool Initialize(Character user, Character target);

    public abstract void StartAction(Character user, Character target);

    public abstract void CompleteAction();
}

public abstract class ActionTemplate<T> : ActionTemplate where T : Ability, new()
{
    public abstract T ActionInstance { get; set; }

    public abstract CooldownHandler Cooldowner { get; set; }

    public abstract ActionProcessor<T> Processor { get; set; } 

    public abstract ActionEffector<T> Effector { get; set; }

    protected override bool Initialize(Character user, Character target)
    {
        Debug.Log(((BasicCooldownHandler)Cooldowner).TimeRemaining);
        if (Cooldowner.OffCooldown() && ActionInstance == null)
        {
            ActionInstance = new T();
            ActionInstance.User = user;
            ActionInstance.Target = target;
            ActionInstance.Template = this;
            return true;
        }
        return false;
    }

    public override void StartAction(Character user, Character target)
    {
        if (Initialize(user, target))
        {
            Processor.ProcessStartEvents(ActionInstance);
        }
    }

    public override void CompleteAction()
    {
        if (ActionInstance != null)
        {
            Processor.ProcessCompleteEvents(ActionInstance);
            Effector.Effect(ActionInstance);
            Cooldowner.StartCooldown();
            ActionInstance = null;
        }
    }
}