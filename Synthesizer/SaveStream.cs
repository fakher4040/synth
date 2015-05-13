using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;

namespace Synthesizer
{
	public class SaveStream
	{
		private double[] sampleData;
		private long sampleCount;
		private int samplesPerSecond;
		public SaveStream ( double[] _sampleData, long _sampleCount, int _samplesPerSecond)
		{
			sampleData = _sampleData;
			sampleCount = _sampleCount;
			samplesPerSecond = _samplesPerSecond;
		}

		public void write (FileStream stream)
		{
			System.IO.BinaryWriter writer = new System.IO.BinaryWriter (stream);
			int RIFF = 0x46464952;
			int WAVE = 0x45564157;
			int formatChunkSize = 16;
			int headerSize = 8;
			int format = 0x20746D66;
			short formatType = 1;
			short tracks = 2;
			short bitsPerSample = 16;
			short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
			int bytesPerSecond = samplesPerSecond * frameSize;
			int waveSize = 4;
			int data = 0x61746164;
			int samples = (int)sampleCount;
			int dataChunkSize = samples * frameSize;
			int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
			writer.Write (RIFF);
			writer.Write (fileSize);
			writer.Write (WAVE);
			writer.Write (format);
			writer.Write (formatChunkSize);
			writer.Write (formatType);
			writer.Write (tracks);
			writer.Write (samplesPerSecond);
			writer.Write (bytesPerSecond);
			writer.Write (frameSize);
			writer.Write (bitsPerSample);
			writer.Write (data);
			writer.Write (dataChunkSize);

			double sample_l;
			short sl;
			for (int i = 0; i < sampleCount; i++) {
				sample_l = sampleData [i] * 30000.0;
				if (sample_l < -32767.0f) {
					sample_l = -32767.0f;
				}
				if (sample_l > 32767.0f) {
					sample_l = 32767.0f;
				}
				sl = (short)sample_l;
				stream.WriteByte ((byte)(sl & 0xff));
				stream.WriteByte ((byte)(sl >> 8));
				stream.WriteByte ((byte)(sl & 0xff));
				stream.WriteByte ((byte)(sl >> 8));
			}
			stream.Close ();
		}


		/// <summary>
		/// Saves the sine wave into a wav file.
		/// </summary>
		/// <param name="sampleData">Sample data.</param>
		/// <param name="sampleCount">Sample count.</param>
		/// <param name="samplesPerSecond">Samples per second.</param>
		public void Save(string filename)
		{
			FileStream stream = File.Create (filename);
			if (File.Exists (filename)) {
				write (stream);
			} else
			{
				try
				{
					write(stream);
				}
				catch(IOException)
				{
					Console.WriteLine("File in use!");
				}
				finally {
					stream.Close ();
				}
			}
				

		}
	}
}

