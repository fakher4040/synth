using System;
using System.IO;
using System.Collections.Generic;

namespace Synthesizer
{
	public class ReadNotes
	{
		private string _path;
		private string _text;
		private string[] _notes;
		List<double> _song = new List<double> ();
		public ReadNotes (string path)
		{
			_path = path;
			_text = File.ReadAllText (_path);

			_notes = _text.Split( new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
		}


		public List<double> Notes{get{return AddNotes();}}

		private List<double> AddNotes(){
		
			foreach(string c in _notes)
			{
				switch (c) 
				{
				case "C":
					_song.Add (NoteFrequnecy.C);
					break;
				case "CSHARP":
					_song.Add (NoteFrequnecy.Csharp);
					break;
				case "D":
					_song.Add (NoteFrequnecy.D);
					break;
				case "DSHARP":
					_song.Add (NoteFrequnecy.Dsharp);
					break;
				case "E":
					_song.Add (NoteFrequnecy.E);
					break;
				case "F":
					_song.Add (NoteFrequnecy.F);
					break;
				case "FSHARP":
					_song.Add (NoteFrequnecy.Fsharp);
					break;
				case "G":
					_song.Add (NoteFrequnecy.G);
					break;
				case "GSHARP":
					_song.Add (NoteFrequnecy.Gsharp);
					break;
				case "A":
					_song.Add (NoteFrequnecy.Asharp);
					break;
				case "ASHARP":
					_song.Add (NoteFrequnecy.Asharp);
					break;
				case "B":
					_song.Add (NoteFrequnecy.B);
					break;
				case "HC":
					_song.Add (NoteFrequnecy.hC);
					break;
				}
			}
			return _song;

		}
	
	}
}

