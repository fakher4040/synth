using System;
namespace SignWaveTest {
	interface IOccilator {
		double GetNext(int sampleNumberInSecond);
		void SetFrequency(double value);
	}

	interface IDetuneable {
		void SetDetune(double maxDetune);
	}
}
