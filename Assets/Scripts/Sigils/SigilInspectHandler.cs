
public class SigilInspectHandler : InspectHandler {

    void OnMouseEnter()
    {
        ShowInfoDisplay(gameObject);
    }

    void OnMouseExit()
    {
        HideInfoDisplay();
    }


}
