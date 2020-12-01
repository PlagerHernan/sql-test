using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExercisesHandler : MonoBehaviour
{
    List<Exercise> _exercises; public List<Exercise> Exercises { get => _exercises; set => _exercises = value; }

    Text _text;
    Button[] _buttons;
    int count;

    void Awake() 
    {
        _exercises = new List<Exercise>();    

        _text = GetComponentInChildren<Text>();
        _buttons = GetComponentsInChildren<Button>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            ShowData();
        }    
    }

    public void ShowData()
    {
        foreach (Exercise exercise in _exercises)
        {
            if (exercise.Id == count)
            {
                //Agrega pregunta al texto
                _text.text = exercise.Question;

                //Agrega opciones al texto de los botones
                for (int i = 0; i < exercise.Options.Length; i++)
                {
                    _buttons[i].GetComponentInChildren<Text>().text = exercise.Options[i].ToString();
                }

                //Respuesta correcta en verde
                //_buttons[exercise.CorrectAnswer].GetComponent<Image>().color = Color.green;
            }
        }
    }
}
