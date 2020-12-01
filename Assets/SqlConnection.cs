using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class SqlConnection : MonoBehaviour
{
    [SerializeField] string _dbName;
    [SerializeField] string _tableName;
    [SerializeField] [Range(2,6)] int _optionsPerExercise;

    ExercisesHandler _exercisesHandler;

    void Awake() 
    {
        _exercisesHandler = FindObjectOfType<ExercisesHandler>();    
    }

    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/" + _dbName;
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); 
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * " + "FROM " + _tableName; 
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            Exercise exercise = new Exercise();

            exercise.Id = reader.GetInt32(0);
            exercise.Question = reader.GetString(1);
            exercise.CorrectAnswer = reader.GetInt32(2) - 1;

            exercise.Options = new int[_optionsPerExercise];
            for (int i = 0; i < exercise.Options.Length; i++)
            {
                exercise.Options[i] = reader.GetInt32(3 + i);
            }

            _exercisesHandler.Exercises.Add(exercise);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
