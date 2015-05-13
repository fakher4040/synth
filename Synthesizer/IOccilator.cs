using System;

namespace Synthesizer
{
	interface IOccilator
	{
		double GetNext(int sampleNumberInSecond);
		void SetFrequency(double value);

	}
}

