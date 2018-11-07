using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LetterTray : MonoBehaviour {
  public static LetterTray instance = null;

  public string currString;
  private Trie dictionary;
  private Trie.Trieiter iter;

  public bool AddLetter(char c) {
    c = Char.ToLower(c);
    currString += c;
    return iter.AddLetter(c);
  }

  public List<char> GetValid()
  {
    return iter.GetValid();
  }

  //Clears the word and returns whether the word exists
  public bool ClearWord() {
    Debug.Log(currString);
    bool toReturn = iter.Contains();

        if (toReturn)
        {
            GameController.instance.wordCount += 1;
            if (currString.Length > GameController.instance.longestWord.Length)
            {
                GameController.instance.longestWord = currString;
            }
        }

    currString = "";
    iter = dictionary.GetIter();
    return toReturn;
  }

  // Use this for initialization
  void Awake () {
    if(instance == null || instance.Equals(null))
    {
      instance = this;
      var MytextAsset = Resources.Load("scrabble_lower", typeof(TextAsset)) as TextAsset;
      char[] charSeparators = new char[] { '\n' };
      string[] words = MytextAsset.text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

      dictionary = new Trie();
      foreach (string s in words) {
        dictionary.AddWord(s);
      }

      currString = "";
      iter = dictionary.GetIter();
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void Start(){}
  
  void Update () {}
}
