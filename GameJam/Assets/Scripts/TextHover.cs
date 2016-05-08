using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, 
IPointerClickHandler {

	public Text theText;

	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = Color.yellow;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = Color.white;
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (eventData.selectedObject.name == "PlayButton")
			SceneManager.LoadScene ("Main");
		else {
			if (eventData.selectedObject.name == "ExitButton")
				Application.Quit ();
		}
	}
}
