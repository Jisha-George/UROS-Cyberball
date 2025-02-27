﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*
You simply need to call `data = new JSONData(path)`
Then query the specific elements using `data.GameMode`
*/

//https://www.youtube.com/watch?v=6uMFEM-napE

public class JSONData {

		public string GameMode = "Inclusive";
		public string Age = "Child";
		public string Gender = "Only Boys";
		public int Rounds = 20;

		public JSONData (string path)
		{
			//Converts relative path to global path
			string filePath = Path.Combine(Application.streamingAssetsPath, path);

			//Read in file if exists, and parse to JSONData object
			if(File.Exists(filePath))
			{
					string dataAsJson = File.ReadAllText(filePath);
					loadSelf(JsonUtility.FromJson<GameData>(dataAsJson));
			}
			else {
				Debug.LogError("Cannot load game data!");
			}

		}


		//Loads data from JSON object into parent
		private void loadSelf(GameData gd) {
			this.GameMode = gd.GameMode;
			this.Age = gd.Age;
			this.Gender = gd.Gender;
			this.Rounds = gd.Rounds;
		}

}


class GameData {
	public string GameMode = "Inclusive";
	public string Age = "Child";
	public string Gender = "Only Boys";
	public int Rounds = 20;
}
