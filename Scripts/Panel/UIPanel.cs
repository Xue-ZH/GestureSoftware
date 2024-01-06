using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    public virtual string PanelName => gameObject.name;

    public virtual void Open(params object[] args)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        OnInit();
    }

    public virtual void Close(bool destory)
    {
        gameObject.SetActive(false);
        if (destory) Destroy(gameObject);
    }

    protected virtual void OnInit() { }
}
