using System;
namespace MiscConsoleMAC
{
	public interface IAgent
	{
		int Retrieve(int[] labels);

		bool Feedback(int reward, int[] nextState);
	}
}
