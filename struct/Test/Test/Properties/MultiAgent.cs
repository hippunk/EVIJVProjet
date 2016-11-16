using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Test
{
	public class MultiAgent
	{
		/*
		private static volatile bool _shouldStop;
		private List<IAgent> agents;
		private List<Thread> listeThread;

		public MultiAgent()
		{
			this.agents = new List<IAgent>();
			this.listeThread = new List<Thread>();
			_shouldStop = false;
		}

		public void AddAgent(IAgent agent)
		{
			this.agents.Add(agent);
		}

		public void Start()
		{
			for (int i = 0; i < this.agents.Count; i++)
			{
				Thread aux = new Thread(this.agents.ElementAt(i).setup);
				this.listeThread.Add(aux);
			}

			for (int j = 0; j < this.listeThread.Count; j++)
			{
				this.listeThread.ElementAt(j).Start();
			}
		}

		public void Stop()
		{
			_shouldStop = true;
		}
	}

*/
	}
}
