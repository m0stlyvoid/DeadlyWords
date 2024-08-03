using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 

public class InputAsVariable : MonoBehaviour
{
    [SerializeField] private string word;
    [SerializeField] private string letter;
    [SerializeField] AudioClip[] keyboardSounds;
    public TMP_InputField inputField;
    public TextMeshProUGUI oldWordDisplay;
    public AudioSource SoundWrong;
    public AudioSource SoundRight;
    public AudioSource SoundKeyboard;
    private int lastIndex;
    private bool wordRight;
    
    
    //called onChange
    public void SetWord()
    {
        word = inputField.text;
        //Debug.Log(word.Length);
        AudioClip keyboard = keyboardSounds[Random.Range(1, keyboardSounds.Length)];
        SoundKeyboard.PlayOneShot(keyboard);
    }

    // called onChangeEnd
    public void SetLetter()
    {
        if(wordRight)
        {
            letter = word.Substring(word.Length - 1);
            Debug.Log(letter);
            oldWordDisplay.text = word;
            SoundRight.Play();
           
        }
       else
        {
            SoundWrong.Play();
        }

        inputField.text = "";
    }

    // Called OnChange
    public void CompareFirstLetter()
    {
        if (letter == word.Substring(0, 1))
        {
            wordRight = true; 
            Debug.Log("right");
        }
        else
        {
            wordRight = false; 
            Debug.Log("wrong");
        }
    }
}

