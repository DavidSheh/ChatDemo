using UnityEngine;

/// <summary>
/// Very simple example of how to use a TextList with a UIInput for chat.
/// </summary>

[RequireComponent(typeof(UIInput))]
[AddComponentMenu("NGUI/Examples/Chat Input")]
public class ChatInput : MonoBehaviour
{
    public UITextList textList;
    public bool fillWithDummyData = false;

    UIInput mInput;
    void Start()
    {
        mInput = GetComponent<UIInput>();
        mInput.label.maxLineCount = 1;

        if (fillWithDummyData && textList != null)
        {

        }
    }

    public void OnSubmit()
    {
        if (textList != null)
        {
            string text = NGUIText.StripSymbols(mInput.value);

            if (!string.IsNullOrEmpty(text))
            {
                textList.Add(text);
                mInput.value = "";
                mInput.isSelected = false;
            }
        }
    }
}
