using UnityEngine;
using UnityEngine.UI;

public class ActionTemplateScript : MonoBehaviour
{
    private ActionTemplate _template;
    public ActionTemplate Template
    {
        get { return _template; }

        set
        {
            UnregisterEvents();
            _template = value;
            RegisterEvents();
            Reset();
        }
    }

    private Image _image;
    private CanvasGroup _canvasGroup;

    private ActionMod _startCDEvent;
    private ActionMod _actionUsedEvent;

    private bool _onCooldown = false;

    void Start()
    {
        _image = GetComponent<Image>();
        _canvasGroup = GetComponent<CanvasGroup>();

        RegisterEvents();
    }

    void Update()
    {
        if (_onCooldown)
        {
            UpdateCooldownVisual();
        }
    }

    void RegisterEvents()
    {
        if (_startCDEvent == null)
        {
            _startCDEvent = new ActionMod(0, StartCooldownVisual);
        }
        if (_actionUsedEvent == null)
        {
            _actionUsedEvent = new ActionMod(0, ActionUsed);
        }

        _template.OnComplete.RegisterAction(_startCDEvent);
        _template.OnStart.RegisterAction(_actionUsedEvent);
    }

    void UnregisterEvents()
    {
        if (_template != null)
        {
            _template.OnComplete.UnregisterAction(_startCDEvent);
            _template.OnStart.UnregisterAction(_actionUsedEvent);
        }
    }
    
    void ActionUsed(ActionInstance action)
    {
        _canvasGroup.alpha = 0.5f;
    }
    
    void StartCooldownVisual(ActionInstance action)
    {
        _canvasGroup.alpha = 1f;
        _onCooldown = true;
        _image.fillAmount = 0f;
    }

    void UpdateCooldownVisual()
    {
        if (_template.CurrentCooldown >= 1f)
        {
            _image.fillAmount = 1f;
            _onCooldown = false;
        }
        else
        {
            _image.fillAmount = _template.CurrentCooldown;
        }
    }

    void Reset()
    {
        // Reset alpha and visual
        if (_canvasGroup != null && _image != null)
        {
            _canvasGroup.alpha = 1f;
            UpdateCooldownVisual();
        }

        // Update on cooldown flag
        _onCooldown = _template.CooldownFinish > Time.time;
    }

}
