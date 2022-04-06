using UnityEngine;

public class HighlightUI : MonoBehaviour
{
    [SerializeField] GameObject _highlight;
    [SerializeField] HighlightUI[] _unHighlightObjects;

    public void Highlight()
    {
        _highlight.SetActive(true);
        UnHightlightOthers();
    }

    public void UnHighlight()
    {
        _highlight.SetActive(false);
    }

    void UnHightlightOthers()
    {
        foreach(var x in _unHighlightObjects)
        {
            x.GetComponent<HighlightUI>().UnHighlight();
        }
    }
}
