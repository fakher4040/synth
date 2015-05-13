using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;

namespace Synthesizer
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			//INTIALISATION
			//intialise the sample rate and create the required objects.

            // this will loop through the arguments that you've supplied to the application.
            //
            // example:
            //  Synthesizer.exe arg1 arg2 arg3
            //
            // will output:
            //  Argument 0 = Synthesizer.exe
            //  Argument 1 = arg1
            //  Argument 2 = arg2
            //  Argument 3 = arg3
            //
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Argument {0} = {1}", i, args[i]);
            }

			//change path
			string path = "C:\\Users\\Joshua\\Desktop\\notes.txt";
			int sampleRate = 4410;
			List<double> data = new List<double> ();
			SineOccilator o = new SineOccilator (sampleRate);
			ReadNotes Song = new ReadNotes (path);
		

			//MAIN PLAYING LOOP
			// Loop through every Note in Mary Had a Little Lamb and set
			// the ocillator to that frequncy
			// the loop that sin wave.
			foreach (double note in Song.Notes) {
				o.SetFrequency (note);
				for (int i = 0; i < sampleRate; i++) {
					data.Add (o.GetNext (i));
					Console.WriteLine (note.ToString ());
				}
			}

			//SAVE
			//Save the Tone to a wav file.
			SaveStream SaveWaveFile = new SaveStream (data.ToArray (), data.Count, sampleRate);
			SaveWaveFile.Save ("test.wav");
		}
	}
}

	


