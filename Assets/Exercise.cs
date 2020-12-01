using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    int _id; public int Id { get => _id; set => _id = value; }
    string _question; public string Question { get => _question; set => _question = value; }
    int _correctAnswer; public int CorrectAnswer { get => _correctAnswer; set => _correctAnswer = value; }
    int [] _options; public int[] Options { get => _options; set => _options = value; }
}
